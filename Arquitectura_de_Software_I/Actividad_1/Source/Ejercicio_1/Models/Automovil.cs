namespace Ejercicio_1.Models;

public class Automovil
{
    public string Marca { get; init; }
    public string Modelo { get; init; }
    public string Tipo { get; init; }
    public int Anio { get; init; }
    public string Motor { get; init; }
    public string Color { get; init; }
    public string Llantas { get; init; }
    public string Sonido { get; init; }
    public string Interiores { get; init; }
    public bool TechoSolar { get; init; }
    public bool GPS { get; init; }
    public string Volante { get; init; }
    public string Transmision { get; init; }
    public string Faros { get; init; }
    public string Tapiceria { get; init; }
    public bool AireAcondicionado { get; init; }
    public bool CamaraReversa { get; init; }
    public bool SensoresDelanteros { get; init; }
    public bool SensoresTraseros { get; init; }
    public bool VidriosElectricos { get; init; }
    public bool EspejosElectricos { get; init; }
    public bool BaulAutomatico { get; init; }
    public bool Polarizado { get; init; }
    public bool FrenosABS { get; init; }
    public bool ControlEstabilidad { get; init; }
    public bool AirbagsLaterales { get; init; }
    public bool Alarma { get; init; }
    public bool BloqueoCentral { get; init; }
    public bool PantallaAndroidAuto { get; init; }
    public bool ParlantesExtra { get; init; }
    public bool DVDParaAtras { get; init; }
    public bool GanchoRemolque { get; init; }
    public bool ParrillaTecho { get; init; }
    public bool Portavasos { get; init; }
    public bool SoporteCelular { get; init; }
    public string RinesPersonalizados { get; init; }
    public bool LucesInterioresLED { get; init; }
    public bool SonidoTumbaCarro { get; init; }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();

        void AddIfNotEmpty(string label, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                sb.AppendLine($"{label}: {value}");
        }

        void AddIfTrue(string label, bool value)
        {
            if (value)
                sb.AppendLine($"{label}: Sí");
        }

        void AddIfGreaterThanZero(string label, int value)
        {
            if (value > 0)
                sb.AppendLine($"{label}: {value}");
        }

        AddIfNotEmpty("Marca", Marca);
        AddIfNotEmpty("Modelo", Modelo);
        AddIfNotEmpty("Tipo", Tipo);
        AddIfGreaterThanZero("Año", Anio);
        AddIfNotEmpty("Motor", Motor);
        AddIfNotEmpty("Color", Color);
        AddIfNotEmpty("Llantas", Llantas);
        AddIfNotEmpty("Sonido", Sonido);
        AddIfNotEmpty("Interiores", Interiores);
        AddIfTrue("Techo Solar", TechoSolar);
        AddIfTrue("GPS", GPS);
        AddIfNotEmpty("Volante", Volante);
        AddIfNotEmpty("Transmisión", Transmision);
        AddIfNotEmpty("Faros", Faros);
        AddIfNotEmpty("Tapicería", Tapiceria);
        AddIfTrue("Aire Acondicionado", AireAcondicionado);
        AddIfTrue("Cámara Reversa", CamaraReversa);
        AddIfTrue("Sensores Delanteros", SensoresDelanteros);
        AddIfTrue("Sensores Traseros", SensoresTraseros);
        AddIfTrue("Vidrios Eléctricos", VidriosElectricos);
        AddIfTrue("Espejos Eléctricos", EspejosElectricos);
        AddIfTrue("Baúl Automático", BaulAutomatico);
        AddIfTrue("Polarizado", Polarizado);
        AddIfTrue("Frenos ABS", FrenosABS);
        AddIfTrue("Control Estabilidad", ControlEstabilidad);
        AddIfTrue("Airbags Laterales", AirbagsLaterales);
        AddIfTrue("Alarma", Alarma);
        AddIfTrue("Bloqueo Central", BloqueoCentral);
        AddIfTrue("Pantalla Android Auto", PantallaAndroidAuto);
        AddIfTrue("Parlantes Extra", ParlantesExtra);
        AddIfTrue("DVD Para Atrás", DVDParaAtras);
        AddIfTrue("Gancho Remolque", GanchoRemolque);
        AddIfTrue("Parrilla Techo", ParrillaTecho);
        AddIfTrue("Portavasos", Portavasos);
        AddIfTrue("Soporte Celular", SoporteCelular);
        AddIfNotEmpty("Rines Personalizados", RinesPersonalizados);
        AddIfTrue("Luces Interiores LED", LucesInterioresLED);
        AddIfTrue("Sonido TumbaCarro", SonidoTumbaCarro);

        return sb.ToString();
    }
}
