using Ejercicio_1.Models;

namespace Ejercicio_1.Builders;

public class AutomovilBuilder : IAutomovilBuilder
{
    private Automovil _baseAutomovil;

    private string _marca;
    private string _modelo;
    private string _tipo;
    private int? _anio;
    private string _motor;
    private string _color;
    private string _llantas;
    private string _sonido;
    private string _interiores;
    private bool _techoSolar;
    private bool _gps;
    private string _volante;
    private string _transmision;
    private string _faros;
    private string _tapiceria;
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
    private string _rinesPersonalizados;
    private bool _lucesInterioresLED;
    private bool _sonidoTumbaCarro;

    public AutomovilBuilder()
    {
        this._baseAutomovil = new Automovil();
    }

    public IAutomovilBuilder Reset()
    {
        this._baseAutomovil = new Automovil();
        return this;
    }

    public IAutomovilBuilder SetMarca(string marca) { _marca = marca; return this; }
    public IAutomovilBuilder SetModelo(string modelo) { _modelo = modelo; return this; }
    public IAutomovilBuilder SetTipo(string tipo) { _tipo = tipo; return this; }
    public IAutomovilBuilder SetAnio(int anio) { _anio = anio; return this; }
    public IAutomovilBuilder SetMotor(string motor) { _motor = motor; return this; }
    public IAutomovilBuilder SetColor(string color) { _color = color; return this; }
    public IAutomovilBuilder SetLlantas(string llantas) { _llantas = llantas; return this; }
    public IAutomovilBuilder SetSonido(string sonido) { _sonido = sonido; return this; }
    public IAutomovilBuilder SetInteriores(string interiores) { _interiores = interiores; return this; }
    public IAutomovilBuilder SetTechoSolar(bool techoSolar) { _techoSolar = techoSolar; return this; }
    public IAutomovilBuilder SetGPS(bool gps) { _gps = gps; return this; }
    public IAutomovilBuilder SetVolante(string volante) { _volante = volante; return this; }
    public IAutomovilBuilder SetTransmision(string transmision) { _transmision = transmision; return this; }
    public IAutomovilBuilder SetFaros(string faros) { _faros = faros; return this; }
    public IAutomovilBuilder SetTapiceria(string tapiceria) { _tapiceria = tapiceria; return this; }
    public IAutomovilBuilder SetAireAcondicionado(bool aireAcondicionado) { _aireAcondicionado = aireAcondicionado; return this; }
    public IAutomovilBuilder SetCamaraReversa(bool camaraReversa) { _camaraReversa = camaraReversa; return this; }
    public IAutomovilBuilder SetSensoresDelanteros(bool value) { _sensoresDelanteros = value; return this; }
    public IAutomovilBuilder SetSensoresTraseros(bool value) { _sensoresTraseros = value; return this; }
    public IAutomovilBuilder SetVidriosElectricos(bool value) { _vidriosElectricos = value; return this; }
    public IAutomovilBuilder SetEspejosElectricos(bool value) { _espejosElectricos = value; return this; }
    public IAutomovilBuilder SetBaulAutomatico(bool value) { _baulAutomatico = value; return this; }
    public IAutomovilBuilder SetPolarizado(bool value) { _polarizado = value; return this; }
    public IAutomovilBuilder SetFrenosABS(bool value) { _frenosABS = value; return this; }
    public IAutomovilBuilder SetControlEstabilidad(bool value) { _controlEstabilidad = value; return this; }
    public IAutomovilBuilder SetAirbagsLaterales(bool value) { _airbagsLaterales = value; return this; }
    public IAutomovilBuilder SetAlarma(bool value) { _alarma = value; return this; }
    public IAutomovilBuilder SetBloqueoCentral(bool value) { _bloqueoCentral = value; return this; }
    public IAutomovilBuilder SetPantallaAndroidAuto(bool value) { _pantallaAndroidAuto = value; return this; }
    public IAutomovilBuilder SetParlantesExtra(bool value) { _parlantesExtra = value; return this; }
    public IAutomovilBuilder SetDVDParaAtras(bool value) { _dvdParaAtras = value; return this; }
    public IAutomovilBuilder SetGanchoRemolque(bool value) { _ganchoRemolque = value; return this; }
    public IAutomovilBuilder SetParrillaTecho(bool value) { _parrillaTecho = value; return this; }
    public IAutomovilBuilder SetPortavasos(bool value) { _portavasos = value; return this; }
    public IAutomovilBuilder SetSoporteCelular(bool value) { _soporteCelular = value; return this; }
    public IAutomovilBuilder SetRinesPersonalizados(string rines) { _rinesPersonalizados = rines; return this; }
    public IAutomovilBuilder SetLucesInterioresLED(bool value) { _lucesInterioresLED = value; return this; }
    public IAutomovilBuilder SetSonidoTumbaCarro(bool value) { _sonidoTumbaCarro = value; return this; }

    public Automovil Build()
    {
        // Validación de campos obligatorios
        if (_marca == null) throw new InvalidOperationException("Marca no puede ser null");
        if (_modelo == null) throw new InvalidOperationException("Modelo no puede ser null");
        if (_tipo == null) throw new InvalidOperationException("Tipo no puede ser null");
        if (_anio == null) throw new InvalidOperationException("Año no puede ser null");
        if (_motor == null) throw new InvalidOperationException("Motor no puede ser null");
        if (_color == null) throw new InvalidOperationException("Color no puede ser null");
        if (_llantas == null) throw new InvalidOperationException("Llantas no pueden ser null");
        if (_volante == null) throw new InvalidOperationException("Volante no puede ser null");
        if (_transmision == null) throw new InvalidOperationException("Transmision no puede ser null");
        if (_faros == null) throw new InvalidOperationException("Faros no pueden ser null");
        if (_tapiceria == null) throw new InvalidOperationException("Tapiceria no pueden ser null");

        return new Automovil
        {
            Marca = _marca!,
            Modelo = _modelo!,
            Tipo = _tipo ?? "Básico",
            Anio = _anio!.Value,
            Motor = _motor!,
            Color = _color!,
            Llantas = _llantas!,
            Sonido = _sonido ?? "",
            Interiores = _interiores ?? "",
            TechoSolar = _techoSolar,
            GPS = _gps,
            Volante = _volante ?? "",
            Transmision = _transmision!,
            Faros = _faros ?? "",
            Tapiceria = _tapiceria ?? "",
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
            RinesPersonalizados = _rinesPersonalizados ?? "",
            LucesInterioresLED = _lucesInterioresLED,
            SonidoTumbaCarro = _sonidoTumbaCarro
        };
    }
}
