using Ejercicio_1.Models;

namespace Ejercicio_1.Builders;

public class AutomovilBuilder
{
    private readonly Automovil? _baseAutomovil;

    private string? _marca;
    private string? _modelo;
    private string? _tipo;
    private int? _año;
    private string? _motor;
    private string? _color;
    private string? _llantas;
    private string? _sonido;
    private string? _interiores;
    private bool _techoSolar;
    private bool _gps;
    private string? _volante;
    private string? _transmision;
    private string? _faros;
    private string? _tapiceria;
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
    private string? _rinesPersonalizados;
    private bool _lucesInterioresLED;
    private bool _sonidoTumbaCarro;

    public AutomovilBuilder(Automovil? baseAutomovil = null)
    {
        if (baseAutomovil != null)
        {
            _baseAutomovil = baseAutomovil.Clone();

            _marca = _baseAutomovil.Marca;
            _modelo = _baseAutomovil.Modelo;
            _tipo = _baseAutomovil.Tipo;
            _año = _baseAutomovil.Año;
            _motor = _baseAutomovil.Motor;
            _color = _baseAutomovil.Color;
            _llantas = _baseAutomovil.Llantas;
            _sonido = _baseAutomovil.Sonido;
            _interiores = _baseAutomovil.Interiores;
            _techoSolar = _baseAutomovil.TechoSolar;
            _gps = _baseAutomovil.GPS;
            _volante = _baseAutomovil.Volante;
            _transmision = _baseAutomovil.Transmision;
            _faros = _baseAutomovil.Faros;
            _tapiceria = _baseAutomovil.Tapiceria;
            _aireAcondicionado = _baseAutomovil.AireAcondicionado;
            _camaraReversa = _baseAutomovil.CamaraReversa;
            _sensoresDelanteros = _baseAutomovil.SensoresDelanteros;
            _sensoresTraseros = _baseAutomovil.SensoresTraseros;
            _vidriosElectricos = _baseAutomovil.VidriosElectricos;
            _espejosElectricos = _baseAutomovil.EspejosElectricos;
            _baulAutomatico = _baseAutomovil.BaulAutomatico;
            _polarizado = _baseAutomovil.Polarizado;
            _frenosABS = _baseAutomovil.FrenosABS;
            _controlEstabilidad = _baseAutomovil.ControlEstabilidad;
            _airbagsLaterales = _baseAutomovil.AirbagsLaterales;
            _alarma = _baseAutomovil.Alarma;
            _bloqueoCentral = _baseAutomovil.BloqueoCentral;
            _pantallaAndroidAuto = _baseAutomovil.PantallaAndroidAuto;
            _parlantesExtra = _baseAutomovil.ParlantesExtra;
            _dvdParaAtras = _baseAutomovil.DVDParaAtras;
            _ganchoRemolque = _baseAutomovil.GanchoRemolque;
            _parrillaTecho = _baseAutomovil.ParrillaTecho;
            _portavasos = _baseAutomovil.Portavasos;
            _soporteCelular = _baseAutomovil.SoporteCelular;
            _rinesPersonalizados = _baseAutomovil.RinesPersonalizados;
            _lucesInterioresLED = _baseAutomovil.LucesInterioresLED;
            _sonidoTumbaCarro = _baseAutomovil.SonidoTumbaCarro;
        }
    }

    public AutomovilBuilder SetMarca(string marca) { _marca = marca; return this; }
    public AutomovilBuilder SetModelo(string modelo) { _modelo = modelo; return this; }
    public AutomovilBuilder SetTipo(string tipo) { _tipo = tipo; return this; }
    public AutomovilBuilder SetAño(int año) { _año = año; return this; }
    public AutomovilBuilder SetMotor(string motor) { _motor = motor; return this; }
    public AutomovilBuilder SetColor(string color) { _color = color; return this; }
    public AutomovilBuilder SetLlantas(string llantas) { _llantas = llantas; return this; }
    public AutomovilBuilder SetSonido(string sonido) { _sonido = sonido; return this; }
    public AutomovilBuilder SetInteriores(string interiores) { _interiores = interiores; return this; }
    public AutomovilBuilder SetTechoSolar(bool techoSolar) { _techoSolar = techoSolar; return this; }
    public AutomovilBuilder SetGPS(bool gps) { _gps = gps; return this; }
    public AutomovilBuilder SetVolante(string volante) { _volante = volante; return this; }
    public AutomovilBuilder SetTransmision(string transmision) { _transmision = transmision; return this; }
    public AutomovilBuilder SetFaros(string faros) { _faros = faros; return this; }
    public AutomovilBuilder SetTapiceria(string tapiceria) { _tapiceria = tapiceria; return this; }
    public AutomovilBuilder SetAireAcondicionado(bool aireAcondicionado) { _aireAcondicionado = aireAcondicionado; return this; }
    public AutomovilBuilder SetCamaraReversa(bool camaraReversa) { _camaraReversa = camaraReversa; return this; }
    public AutomovilBuilder SetSensoresDelanteros(bool value) { _sensoresDelanteros = value; return this; }
    public AutomovilBuilder SetSensoresTraseros(bool value) { _sensoresTraseros = value; return this; }
    public AutomovilBuilder SetVidriosElectricos(bool value) { _vidriosElectricos = value; return this; }
    public AutomovilBuilder SetEspejosElectricos(bool value) { _espejosElectricos = value; return this; }
    public AutomovilBuilder SetBaulAutomatico(bool value) { _baulAutomatico = value; return this; }
    public AutomovilBuilder SetPolarizado(bool value) { _polarizado = value; return this; }
    public AutomovilBuilder SetFrenosABS(bool value) { _frenosABS = value; return this; }
    public AutomovilBuilder SetControlEstabilidad(bool value) { _controlEstabilidad = value; return this; }
    public AutomovilBuilder SetAirbagsLaterales(bool value) { _airbagsLaterales = value; return this; }
    public AutomovilBuilder SetAlarma(bool value) { _alarma = value; return this; }
    public AutomovilBuilder SetBloqueoCentral(bool value) { _bloqueoCentral = value; return this; }
    public AutomovilBuilder SetPantallaAndroidAuto(bool value) { _pantallaAndroidAuto = value; return this; }
    public AutomovilBuilder SetParlantesExtra(bool value) { _parlantesExtra = value; return this; }
    public AutomovilBuilder SetDVDParaAtras(bool value) { _dvdParaAtras = value; return this; }
    public AutomovilBuilder SetGanchoRemolque(bool value) { _ganchoRemolque = value; return this; }
    public AutomovilBuilder SetParrillaTecho(bool value) { _parrillaTecho = value; return this; }
    public AutomovilBuilder SetPortavasos(bool value) { _portavasos = value; return this; }
    public AutomovilBuilder SetSoporteCelular(bool value) { _soporteCelular = value; return this; }
    public AutomovilBuilder SetRinesPersonalizados(string rines) { _rinesPersonalizados = rines; return this; }
    public AutomovilBuilder SetLucesInterioresLED(bool value) { _lucesInterioresLED = value; return this; }
    public AutomovilBuilder SetSonidoTumbaCarro(bool value) { _sonidoTumbaCarro = value; return this; }

    public Automovil Build()
    {
        // Validación de campos obligatorios
        if (_marca == null) throw new InvalidOperationException("Marca no puede ser null");
        if (_modelo == null) throw new InvalidOperationException("Modelo no puede ser null");
        if (_tipo == null) throw new InvalidOperationException("Tipo no puede ser null");
        if (_año == null) throw new InvalidOperationException("Año no puede ser null");
        if (_motor == null) throw new InvalidOperationException("Motor no puede ser null");
        if (_color == null) throw new InvalidOperationException("Color no puede ser null");
        if (_llantas == null) throw new InvalidOperationException("Llantas no pueden ser null");
        if (_volante == null) throw new InvalidOperationException("Volante no puede ser null");
        if (_transmision == null) throw new InvalidOperationException("Transmision no puede ser null");
        if (_faros == null) throw new InvalidOperationException("Faros no pueden ser null");
        if (_tapiceria == null) throw new InvalidOperationException("Tapiceria no pueden ser null");

        return new Automovil(
            _marca!,
            _modelo!,
            tipo: _tipo ?? "Básico",
            _año!.Value,
            _motor!,
            _color!,
            _llantas!,
            _sonido ?? "",
            _interiores ?? "",
            _techoSolar,
            _gps,
            _volante ?? "",
            _transmision!,
            _faros ?? "",
            _tapiceria ?? "",
            _aireAcondicionado,
            _camaraReversa,
            _sensoresDelanteros,
            _sensoresTraseros,
            _vidriosElectricos,
            _espejosElectricos,
            _baulAutomatico,
            _polarizado,
            _frenosABS,
            _controlEstabilidad,
            _airbagsLaterales,
            _alarma,
            _bloqueoCentral,
            _pantallaAndroidAuto,
            _parlantesExtra,
            _dvdParaAtras,
            _ganchoRemolque,
            _parrillaTecho,
            _portavasos,
            _soporteCelular,
            _rinesPersonalizados ?? "",
            _lucesInterioresLED,
            _sonidoTumbaCarro
        );
    }
}
