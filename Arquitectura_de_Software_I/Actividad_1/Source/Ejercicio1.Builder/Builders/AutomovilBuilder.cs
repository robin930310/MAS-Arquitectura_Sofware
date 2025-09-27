using Ejercicio_1.Models;

namespace Ejercicio_1.Builders;

/// <summary>
/// Implementación concreta del Builder para construir automóviles
/// </summary>
public class AutomovilBuilder : IAutomovilBuilder
{
    // Propiedades básicas (obligatorias)
    private string _marca = string.Empty;
    private string _modelo = string.Empty;
    private TipoAutomovil _tipo;
    private int? _anio;
    private TipoMotor _motor;
    private string _color = string.Empty;
    private string _llantas = string.Empty;
    private TipoTransmision _transmision;
    private TipoFaros _faros;
    private TipoTapiceria _tapiceria;

    // Propiedades opcionales
    private string _sonido = string.Empty;
    private string _interiores = string.Empty;
    private string _volante = string.Empty;
    private string _rinesPersonalizados = string.Empty;

    // Características opcionales (booleanas)
    private bool _techoSolar;
    private bool _gps;
    private bool _aireAcondicionado;
    private bool _camaraReversa;
    private bool _sensoresDelanteros;
    private bool _sensoresTraseros;
    private bool _vidriosElectricos;
    private bool _espejosElectricos;
    private bool _baulAutomatico;
    private bool _polarizado;
    private bool _frenosABS;
    private bool _controlEstabilidad;
    private bool _airbagsLaterales;
    private bool _alarma;
    private bool _bloqueoCentral;
    private bool _pantallaAndroidAuto;
    private bool _parlantesExtra;
    private bool _dvdParaAtras;
    private bool _ganchoRemolque;
    private bool _parrillaTecho;
    private bool _portavasos;
    private bool _soporteCelular;
    private bool _lucesInterioresLED;
    private bool _sonidoTumbaCarro;

    public IAutomovilBuilder Reset()
    {
        // Reinicia todas las propiedades a sus valores por defecto
        _marca = string.Empty;
        _modelo = string.Empty;
        _tipo = default;
        _anio = null;
        _motor = default;
        _color = string.Empty;
        _llantas = string.Empty;
        _transmision = default;
        _faros = default;
        _tapiceria = default;
        _sonido = string.Empty;
        _interiores = string.Empty;
        _volante = string.Empty;
        _rinesPersonalizados = string.Empty;

        // Reinicia todas las características opcionales
        _techoSolar = false;
        _gps = false;
        _aireAcondicionado = false;
        _camaraReversa = false;
        _sensoresDelanteros = false;
        _sensoresTraseros = false;
        _vidriosElectricos = false;
        _espejosElectricos = false;
        _baulAutomatico = false;
        _polarizado = false;
        _frenosABS = false;
        _controlEstabilidad = false;
        _airbagsLaterales = false;
        _alarma = false;
        _bloqueoCentral = false;
        _pantallaAndroidAuto = false;
        _parlantesExtra = false;
        _dvdParaAtras = false;
        _ganchoRemolque = false;
        _parrillaTecho = false;
        _portavasos = false;
        _soporteCelular = false;
        _lucesInterioresLED = false;
        _sonidoTumbaCarro = false;

        return this;
    }

    // Métodos para propiedades básicas (obligatorias)
    public IAutomovilBuilder SetMarca(string marca) { _marca = marca ?? string.Empty; return this; }
    public IAutomovilBuilder SetModelo(string modelo) { _modelo = modelo ?? string.Empty; return this; }
    public IAutomovilBuilder SetTipo(TipoAutomovil tipo) { _tipo = tipo; return this; }
    public IAutomovilBuilder SetAnio(int anio) { _anio = anio; return this; }
    public IAutomovilBuilder SetMotor(TipoMotor motor) { _motor = motor; return this; }
    public IAutomovilBuilder SetColor(string color) { _color = color ?? string.Empty; return this; }
    public IAutomovilBuilder SetLlantas(string llantas) { _llantas = llantas ?? string.Empty; return this; }
    public IAutomovilBuilder SetTransmision(TipoTransmision transmision) { _transmision = transmision; return this; }
    public IAutomovilBuilder SetFaros(TipoFaros faros) { _faros = faros; return this; }
    public IAutomovilBuilder SetTapiceria(TipoTapiceria tapiceria) { _tapiceria = tapiceria; return this; }

    // Métodos para propiedades opcionales
    public IAutomovilBuilder SetSonido(string sonido) { _sonido = sonido ?? string.Empty; return this; }
    public IAutomovilBuilder SetInteriores(string interiores) { _interiores = interiores ?? string.Empty; return this; }
    public IAutomovilBuilder SetVolante(string volante) { _volante = volante ?? string.Empty; return this; }
    public IAutomovilBuilder SetRinesPersonalizados(string rines) { _rinesPersonalizados = rines ?? string.Empty; return this; }

    // Métodos para características opcionales (booleanas)
    public IAutomovilBuilder SetTechoSolar(bool techoSolar) { _techoSolar = techoSolar; return this; }
    public IAutomovilBuilder SetGPS(bool gps) { _gps = gps; return this; }
    public IAutomovilBuilder SetAireAcondicionado(bool aireAcondicionado) { _aireAcondicionado = aireAcondicionado; return this; }
    public IAutomovilBuilder SetCamaraReversa(bool camaraReversa) { _camaraReversa = camaraReversa; return this; }
    public IAutomovilBuilder SetSensoresDelanteros(bool sensoresDelanteros) { _sensoresDelanteros = sensoresDelanteros; return this; }
    public IAutomovilBuilder SetSensoresTraseros(bool sensoresTraseros) { _sensoresTraseros = sensoresTraseros; return this; }
    public IAutomovilBuilder SetVidriosElectricos(bool vidriosElectricos) { _vidriosElectricos = vidriosElectricos; return this; }
    public IAutomovilBuilder SetEspejosElectricos(bool espejosElectricos) { _espejosElectricos = espejosElectricos; return this; }
    public IAutomovilBuilder SetBaulAutomatico(bool baulAutomatico) { _baulAutomatico = baulAutomatico; return this; }
    public IAutomovilBuilder SetPolarizado(bool polarizado) { _polarizado = polarizado; return this; }
    public IAutomovilBuilder SetFrenosABS(bool frenosABS) { _frenosABS = frenosABS; return this; }
    public IAutomovilBuilder SetControlEstabilidad(bool controlEstabilidad) { _controlEstabilidad = controlEstabilidad; return this; }
    public IAutomovilBuilder SetAirbagsLaterales(bool airbagsLaterales) { _airbagsLaterales = airbagsLaterales; return this; }
    public IAutomovilBuilder SetAlarma(bool alarma) { _alarma = alarma; return this; }
    public IAutomovilBuilder SetBloqueoCentral(bool bloqueoCentral) { _bloqueoCentral = bloqueoCentral; return this; }
    public IAutomovilBuilder SetPantallaAndroidAuto(bool pantallaAndroidAuto) { _pantallaAndroidAuto = pantallaAndroidAuto; return this; }
    public IAutomovilBuilder SetParlantesExtra(bool parlantesExtra) { _parlantesExtra = parlantesExtra; return this; }
    public IAutomovilBuilder SetDVDParaAtras(bool dvdParaAtras) { _dvdParaAtras = dvdParaAtras; return this; }
    public IAutomovilBuilder SetGanchoRemolque(bool ganchoRemolque) { _ganchoRemolque = ganchoRemolque; return this; }
    public IAutomovilBuilder SetParrillaTecho(bool parrillaTecho) { _parrillaTecho = parrillaTecho; return this; }
    public IAutomovilBuilder SetPortavasos(bool portavasos) { _portavasos = portavasos; return this; }
    public IAutomovilBuilder SetSoporteCelular(bool soporteCelular) { _soporteCelular = soporteCelular; return this; }
    public IAutomovilBuilder SetLucesInterioresLED(bool lucesInterioresLED) { _lucesInterioresLED = lucesInterioresLED; return this; }
    public IAutomovilBuilder SetSonidoTumbaCarro(bool sonidoTumbaCarro) { _sonidoTumbaCarro = sonidoTumbaCarro; return this; }

    public Automovil Build()
    {
        // Validación de campos obligatorios
        var errores = new List<string>();

        if (string.IsNullOrWhiteSpace(_marca))
            errores.Add("Marca es obligatoria");
        if (string.IsNullOrWhiteSpace(_modelo))
            errores.Add("Modelo es obligatorio");
        if (_anio == null || _anio <= 1900)
            errores.Add("Año debe ser válido (mayor a 1900)");
        if (string.IsNullOrWhiteSpace(_color))
            errores.Add("Color es obligatorio");
        if (string.IsNullOrWhiteSpace(_llantas))
            errores.Add("Llantas son obligatorias");

        if (errores.Any())
        {
            throw new InvalidOperationException($"Error en la construcción del automóvil: {string.Join(", ", errores)}");
        }

        return new Automovil
        {
            // Propiedades básicas (obligatorias)
            Marca = _marca,
            Modelo = _modelo,
            Tipo = _tipo,
            Anio = _anio!.Value,
            Motor = _motor,
            Color = _color,
            Llantas = _llantas,
            Transmision = _transmision,
            Faros = _faros,
            Tapiceria = _tapiceria,

            // Propiedades opcionales
            Sonido = _sonido,
            Interiores = _interiores,
            Volante = _volante,
            RinesPersonalizados = _rinesPersonalizados,

            // Características opcionales (booleanas)
            TechoSolar = _techoSolar,
            GPS = _gps,
            AireAcondicionado = _aireAcondicionado,
            CamaraReversa = _camaraReversa,
            SensoresDelanteros = _sensoresDelanteros,
            SensoresTraseros = _sensoresTraseros,
            VidriosElectricos = _vidriosElectricos,
            EspejosElectricos = _espejosElectricos,
            BaulAutomatico = _baulAutomatico,
            Polarizado = _polarizado,
            FrenosABS = _frenosABS,
            ControlEstabilidad = _controlEstabilidad,
            AirbagsLaterales = _airbagsLaterales,
            Alarma = _alarma,
            BloqueoCentral = _bloqueoCentral,
            PantallaAndroidAuto = _pantallaAndroidAuto,
            ParlantesExtra = _parlantesExtra,
            DVDParaAtras = _dvdParaAtras,
            GanchoRemolque = _ganchoRemolque,
            ParrillaTecho = _parrillaTecho,
            Portavasos = _portavasos,
            SoporteCelular = _soporteCelular,
            LucesInterioresLED = _lucesInterioresLED,
            SonidoTumbaCarro = _sonidoTumbaCarro
        };
    }
}
