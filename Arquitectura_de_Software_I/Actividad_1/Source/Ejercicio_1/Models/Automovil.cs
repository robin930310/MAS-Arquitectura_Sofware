namespace Ejercicio_1.Models;

public class Automovil
{
    public string Marca { get; }
    public string Modelo { get; }
    public string Tipo { get; }
    public int Año { get; }
    public string Motor { get; }
    public string Color { get; }
    public string Llantas { get; }
    public string Sonido { get; }
    public string Interiores { get; }
    public bool TechoSolar { get; }
    public bool GPS { get; }
    public string Volante { get; }
    public string Transmision { get; }
    public string Faros { get; }
    public string Tapiceria { get; }
    public bool AireAcondicionado { get; }
    public bool CamaraReversa { get; }
    public bool SensoresDelanteros { get; }
    public bool SensoresTraseros { get; }
    public bool VidriosElectricos { get; }
    public bool EspejosElectricos { get; }
    public bool BaulAutomatico { get; }
    public bool Polarizado { get; }
    public bool FrenosABS { get; }
    public bool ControlEstabilidad { get; }
    public bool AirbagsLaterales { get; }
    public bool Alarma { get; }
    public bool BloqueoCentral { get; }
    public bool PantallaAndroidAuto { get; }
    public bool ParlantesExtra { get; }
    public bool DVDParaAtras { get; }
    public bool GanchoRemolque { get; }
    public bool ParrillaTecho { get; }
    public bool Portavasos { get; }
    public bool SoporteCelular { get; }
    public string RinesPersonalizados { get; }
    public bool LucesInterioresLED { get; }
    public bool SonidoTumbaCarro { get; }

    public Automovil(
        string marca, string modelo, string tipo, int año, string motor, string color, string llantas, string sonido,
        string interiores, bool techoSolar, bool gps, string volante, string transmision,
        string faros, string tapiceria, bool aireAcondicionado, bool camaraReversa,
        bool sensoresDelanteros, bool sensoresTraseros,
        bool vidriosElectricos, bool espejosElectricos, bool baulAutomatico,
        bool polarizado, bool frenosABS, bool controlEstabilidad,
        bool airbagsLaterales, bool alarma, bool bloqueoCentral,
        bool pantallaAndroidAuto, bool parlantesExtra, bool dvdParaAtras,
        bool ganchoRemolque, bool parrillaTecho, bool portavasos, bool soporteCelular,
        string rinesPersonalizados, bool lucesInterioresLED, bool sonidoTumbaCarro
    )
    {
        Marca = marca;
        Modelo = modelo;
        Tipo = tipo;
        Año = año;
        Motor = motor;
        Color = color;
        Llantas = llantas;
        Sonido = sonido;
        Interiores = interiores;
        TechoSolar = techoSolar;
        GPS = gps;
        Volante = volante;
        Transmision = transmision;
        Faros = faros;
        Tapiceria = tapiceria;
        AireAcondicionado = aireAcondicionado;
        CamaraReversa = camaraReversa;
        SensoresDelanteros = sensoresDelanteros;
        SensoresTraseros = sensoresTraseros;
        VidriosElectricos = vidriosElectricos;
        EspejosElectricos = espejosElectricos;
        BaulAutomatico = baulAutomatico;
        Polarizado = polarizado;
        FrenosABS = frenosABS;
        ControlEstabilidad = controlEstabilidad;
        AirbagsLaterales = airbagsLaterales;
        Alarma = alarma;
        BloqueoCentral = bloqueoCentral;
        PantallaAndroidAuto = pantallaAndroidAuto;
        ParlantesExtra = parlantesExtra;
        DVDParaAtras = dvdParaAtras;
        GanchoRemolque = ganchoRemolque;
        ParrillaTecho = parrillaTecho;
        Portavasos = portavasos;
        SoporteCelular = soporteCelular;
        RinesPersonalizados = rinesPersonalizados;
        LucesInterioresLED = lucesInterioresLED;
        SonidoTumbaCarro = sonidoTumbaCarro;
    }

    public Automovil Clone()
    {
        return (Automovil)this.MemberwiseClone();
    }

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
        AddIfGreaterThanZero("Año", Año);
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
