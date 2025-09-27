using System.Reflection;

namespace Ejercicio_1.Models;

[AttributeUsage(AttributeTargets.Property)]
public class CaracteristicaOpcionalAttribute : Attribute
{
    public string Nombre { get; }
    public CaracteristicaOpcionalAttribute(string nombre) => Nombre = nombre;
}

[AttributeUsage(AttributeTargets.Property)]
public class PropiedadBuilderAttribute : Attribute
{
    public string NombreMetodoSet { get; }
    public object ValorPorDefecto { get; }

    public PropiedadBuilderAttribute(string nombreMetodoSet, object valorPorDefecto = null!)
    {
        NombreMetodoSet = nombreMetodoSet;
        ValorPorDefecto = valorPorDefecto ?? false; // Default para boolean
    }
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class DescripcionEnumAttribute : Attribute
{
    public string Descripcion { get; }
    public DescripcionEnumAttribute(string descripcion) => Descripcion = descripcion;
}

[AttributeUsage(AttributeTargets.Class)]
public class ConfiguracionVehiculoAttribute : Attribute
{
    public string[] CaracteristicasIncluidas { get; }
    public ConfiguracionVehiculoAttribute(params string[] caracteristicas)
    {
        CaracteristicasIncluidas = caracteristicas;
    }
}

/// <summary>
/// Clase que representa un automóvil con todas sus configuraciones opcionales
/// </summary>
public class Automovil
{
    // Propiedades básicas (obligatorias)
    public string Marca { get; init; } = string.Empty;
    public string Modelo { get; init; } = string.Empty;
    public TipoAutomovil Tipo { get; init; }
    public int Anio { get; init; }
    public TipoMotor Motor { get; init; }
    public string Color { get; init; } = string.Empty;
    public string Llantas { get; init; } = string.Empty;
    public TipoTransmision Transmision { get; init; }
    public TipoFaros Faros { get; init; }
    public TipoTapiceria Tapiceria { get; init; }

    // Propiedades opcionales
    public string Sonido { get; init; } = string.Empty;
    public string Interiores { get; init; } = string.Empty;
    public string Volante { get; init; } = string.Empty;
    public string RinesPersonalizados { get; init; } = string.Empty;

    // Características opcionales (booleanas)
    [CaracteristicaOpcional("Techo Solar")] public bool TechoSolar { get; init; }
    [CaracteristicaOpcional("GPS")] public bool GPS { get; init; }
    [CaracteristicaOpcional("Aire Acondicionado")] public bool AireAcondicionado { get; init; }
    [CaracteristicaOpcional("Cámara Reversa")] public bool CamaraReversa { get; init; }
    [CaracteristicaOpcional("Sensores Delanteros")] public bool SensoresDelanteros { get; init; }
    [CaracteristicaOpcional("Sensores Traseros")] public bool SensoresTraseros { get; init; }
    [CaracteristicaOpcional("Vidrios Eléctricos")] public bool VidriosElectricos { get; init; }
    [CaracteristicaOpcional("Espejos Eléctricos")] public bool EspejosElectricos { get; init; }
    [CaracteristicaOpcional("Baúl Automático")] public bool BaulAutomatico { get; init; }
    [CaracteristicaOpcional("Polarizado")] public bool Polarizado { get; init; }
    [CaracteristicaOpcional("Frenos ABS")] public bool FrenosABS { get; init; }
    [CaracteristicaOpcional("Control de Estabilidad")] public bool ControlEstabilidad { get; init; }
    [CaracteristicaOpcional("Airbags Laterales")] public bool AirbagsLaterales { get; init; }
    [CaracteristicaOpcional("Alarma")] public bool Alarma { get; init; }
    [CaracteristicaOpcional("Bloqueo Central")] public bool BloqueoCentral { get; init; }
    [CaracteristicaOpcional("Pantalla Android Auto")] public bool PantallaAndroidAuto { get; init; }
    [CaracteristicaOpcional("Parlantes Extra")] public bool ParlantesExtra { get; init; }
    [CaracteristicaOpcional("DVD Para Atrás")] public bool DVDParaAtras { get; init; }
    [CaracteristicaOpcional("Gancho de Remolque")] public bool GanchoRemolque { get; init; }
    [CaracteristicaOpcional("Parrilla de Techo")] public bool ParrillaTecho { get; init; }
    [CaracteristicaOpcional("Portavasos")] public bool Portavasos { get; init; }
    [CaracteristicaOpcional("Soporte para Celular")] public bool SoporteCelular { get; init; }
    [CaracteristicaOpcional("Luces Interiores LED")] public bool LucesInterioresLED { get; init; }
    [CaracteristicaOpcional("Sonido Tumba Carro")] public bool SonidoTumbaCarro { get; init; }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("=== CONFIGURACIÓN DEL AUTOMÓVIL ===");
        sb.AppendLine();

        // Información básica
        sb.AppendLine("INFORMACIÓN BÁSICA:");
        sb.AppendLine($"Marca: {Marca}");
        sb.AppendLine($"Modelo: {Modelo}");
        sb.AppendLine($"Tipo: {Tipo}");
        sb.AppendLine($"Año: {Anio}");
        sb.AppendLine($"Motor: {Motor}");
        sb.AppendLine($"Color: {Color}");
        sb.AppendLine($"Llantas: {Llantas}");
        sb.AppendLine($"Transmisión: {Transmision}");
        sb.AppendLine($"Faros: {Faros}");
        sb.AppendLine($"Tapicería: {Tapiceria}");
        sb.AppendLine();

        // Características opcionales
        var opciones = GetOpcionesActivas();
        if (opciones.Any())
        {
            sb.AppendLine("CARACTERÍSTICAS ADICIONALES:");
            foreach (var opcion in opciones)
            {
                sb.AppendLine($"• {opcion}");
            }
            sb.AppendLine();
        }

        // Detalles personalizados
        var detalles = GetDetallesPersonalizados();
        if (detalles.Any())
        {
            sb.AppendLine("DETALLES PERSONALIZADOS:");
            foreach (var detalle in detalles)
            {
                sb.AppendLine($"• {detalle}");
            }
        }

        return sb.ToString();
    }

    private List<string> GetOpcionesActivas()
    {
        var opciones = new List<string>();
        var props = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in props)
        {
            if (prop.PropertyType == typeof(bool) &&
                prop.GetCustomAttribute<CaracteristicaOpcionalAttribute>() is { } attr &&
                (bool)prop.GetValue(this)!)
            {
                opciones.Add(attr.Nombre);
            }
        }

        return opciones;
    }

    private List<string> GetDetallesPersonalizados()
    {
        var detalles = new List<string>();

        if (!string.IsNullOrWhiteSpace(Sonido)) detalles.Add($"Sistema de Sonido: {Sonido}");
        if (!string.IsNullOrWhiteSpace(Interiores)) detalles.Add($"Interiores: {Interiores}");
        if (!string.IsNullOrWhiteSpace(Volante)) detalles.Add($"Volante: {Volante}");
        if (!string.IsNullOrWhiteSpace(RinesPersonalizados)) detalles.Add($"Rines Personalizados: {RinesPersonalizados}");

        return detalles;
    }
}
