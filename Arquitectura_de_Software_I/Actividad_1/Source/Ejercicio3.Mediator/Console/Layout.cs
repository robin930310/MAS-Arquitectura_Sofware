using Spectre.Console;

namespace Ejercicio3.Layout;

/// <summary>
/// Clase responsable de gestionar y renderizar el layout del chat en consola.
/// Implementa un patrón Singleton para asegurar una única instancia.
/// </summary>
public class Layout
{
    private Panel _rootPanel;
    private readonly IDictionary<string, List<string>> _userPanels;

    private static Layout _instance;

    /// </summary>
    private Layout()
    {
        _userPanels = new Dictionary<string, List<string>>();
    }

    /// <summary>
    /// Instancia única de ChatLayout
    /// </summary>
    public static Layout Instance => _instance ??= new Layout();

    /// <summary>
    /// Solicita al usuario el número de participantes del chat.
    /// </summary>
    /// <returns>Número de participantes seleccionado.</returns>
    public int SelectCountUsers()
    {
        AnsiConsole.Clear();
        return AnsiConsole.Prompt(new TextPrompt<int>("[bold yellow]¿Numero de participantes del Chat (2-5)?[/]")
              .Validate((n) => n switch
              {
                  < 2 => ValidationResult.Error("Al menos 2 participantes"),
                  > 6 => ValidationResult.Error("Maximo 5 Participantes"),
                  _ => ValidationResult.Success()
              }));
    }

    /// <summary>
    /// Inicializa los paneles del chat para cada usuario.
    /// </summary>
    /// <param name="chatNames">Nombres de los participantes.</param>
    public void SetChatPanels(IEnumerable<string> chatNames)
    {
        chatNames.ToList().ForEach(x => _userPanels.Add(x, [$"[green] ✔ Online[/]"]));
        Render();
    }

    /// <summary>
    /// Agrega un mensaje al panel de un usuario.
    /// </summary>
    /// <param name="user">Usuario destinatario.</param>
    /// <param name="message">Mensaje a agregar.</param>
    public void AddUserMessage(string user, string message)
    {
        _userPanels[user].Add(message);
    }

    /// <summary>
    /// Renderiza el layout principal del chat en consola.
    /// </summary>
    public void Render()
    {
        _rootPanel = new Panel(new Columns(RenderUserPanels()))
        {
            Header = new PanelHeader("[yellow] Mediator Chat's [/]", Justify.Center),
            Expand = true
        };

        AnsiConsole.Clear();
        AnsiConsole.Write(_rootPanel);
    }

    /// <summary>
    /// Renderiza los paneles individuales de cada usuario.
    /// </summary>
    /// <returns>Enumeración de paneles de usuario.</returns>
    private IEnumerable<Panel> RenderUserPanels()
    {
        IList<Panel> panels = new List<Panel>();

        foreach (KeyValuePair<string, List<string>> userPanel in _userPanels)
        {
            Panel panel = new Panel(RenderPanelMessages(userPanel.Value))
            {
                Header = new PanelHeader($"[yellow] Chat de {userPanel.Key} [/]", Justify.Center),
                Expand = true
            };

            panels.Add(panel);
        }

        return panels;
    }

    /// <summary>
    /// Renderiza los mensajes de un panel de usuario.
    /// </summary>
    /// <param name="messages">Lista de mensajes.</param>
    /// <returns>Objeto Rows con los mensajes renderizados.</returns>
    private Rows RenderPanelMessages(IList<string> messages)
    {
        return new Rows(messages.ToList().Select(x => new Markup(x)));
    }

    /// <summary>
    /// Solicita al usuario los datos para enviar un mensaje (remitente, destinatario y contenido).
    /// </summary>
    /// <returns>Tupla con remitente, destinatario y mensaje.</returns>
    public Tuple<string, string, string> ChatForm()
    {
        string messageFrom = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("--------------------------------\n\n[bold yellow]¿Quien envia el Mensaje?[/]")
                    .AddChoices(_userPanels.Keys.Select(x => x)));

        string messageTo = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("--------------------------------\n\n[bold yellow]¿A quien se le envia el Mensaje?[/]?")
                .AddChoices(_userPanels.Keys.Select(x => x).Except([messageFrom])
                .Append("Todos")));

        string message = AnsiConsole.Prompt(new TextPrompt<string>($"[bold yellow]({messageFrom} -> {messageTo}) 📨 Mensaje:[/]"));


        return new Tuple<string, string, string>(messageFrom, messageTo, message);
    }
}

