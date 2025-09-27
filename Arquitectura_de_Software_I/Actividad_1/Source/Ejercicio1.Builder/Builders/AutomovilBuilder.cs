using System.Reflection;
using Ejercicio_1.Models;

namespace Ejercicio_1.Builders;

/// <summary>
/// Implementación del Builder usando reflexión para reducir código repetitivo
/// </summary>
public class AutomovilBuilder : IAutomovilBuilder
{
    // Diccionario para almacenar los valores de las propiedades
    private readonly Dictionary<string, object> _propiedades = new();

    public IAutomovilBuilder Reset()
    {
        _propiedades.Clear();

        // Usar reflexión para resetear automáticamente todas las propiedades
        var tipoAutomovil = typeof(Automovil);
        var propiedades = tipoAutomovil.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in propiedades)
        {
            if (prop.PropertyType == typeof(bool))
            {
                _propiedades[prop.Name] = false;
            }
            else if (prop.PropertyType == typeof(string))
            {
                _propiedades[prop.Name] = string.Empty;
            }
            else if (prop.PropertyType == typeof(int))
            {
                _propiedades[prop.Name] = 0;
            }
            // Para enums, se mantiene el valor por defecto (primera opción)
        }

        return this;
    }

    // Métodos para propiedades básicas (obligatorias)
    public IAutomovilBuilder SetMarca(string marca) { _propiedades["Marca"] = marca ?? string.Empty; return this; }
    public IAutomovilBuilder SetModelo(string modelo) { _propiedades["Modelo"] = modelo ?? string.Empty; return this; }
    public IAutomovilBuilder SetTipo(TipoAutomovil tipo) { _propiedades["Tipo"] = tipo; return this; }
    public IAutomovilBuilder SetAnio(int año) { _propiedades["Anio"] = año; return this; }
    public IAutomovilBuilder SetMotor(TipoMotor motor) { _propiedades["Motor"] = motor; return this; }
    public IAutomovilBuilder SetColor(string color) { _propiedades["Color"] = color ?? string.Empty; return this; }
    public IAutomovilBuilder SetLlantas(string llantas) { _propiedades["Llantas"] = llantas ?? string.Empty; return this; }
    public IAutomovilBuilder SetTransmision(TipoTransmision transmision) { _propiedades["Transmision"] = transmision; return this; }
    public IAutomovilBuilder SetFaros(TipoFaros faros) { _propiedades["Faros"] = faros; return this; }
    public IAutomovilBuilder SetTapiceria(TipoTapiceria tapiceria) { _propiedades["Tapiceria"] = tapiceria; return this; }

    // Métodos para propiedades opcionales
    public IAutomovilBuilder SetSonido(string sonido) { _propiedades["Sonido"] = sonido ?? string.Empty; return this; }
    public IAutomovilBuilder SetInteriores(string interiores) { _propiedades["Interiores"] = interiores ?? string.Empty; return this; }
    public IAutomovilBuilder SetVolante(string volante) { _propiedades["Volante"] = volante ?? string.Empty; return this; }
    public IAutomovilBuilder SetRinesPersonalizados(string rines) { _propiedades["RinesPersonalizados"] = rines ?? string.Empty; return this; }

    // Métodos para características opcionales (booleanas) - Usando reflexión para simplificar
    public IAutomovilBuilder SetTechoSolar(bool techoSolar) { _propiedades["TechoSolar"] = techoSolar; return this; }
    public IAutomovilBuilder SetGPS(bool gps) { _propiedades["GPS"] = gps; return this; }
    public IAutomovilBuilder SetAireAcondicionado(bool aireAcondicionado) { _propiedades["AireAcondicionado"] = aireAcondicionado; return this; }
    public IAutomovilBuilder SetCamaraReversa(bool camaraReversa) { _propiedades["CamaraReversa"] = camaraReversa; return this; }
    public IAutomovilBuilder SetSensoresDelanteros(bool sensoresDelanteros) { _propiedades["SensoresDelanteros"] = sensoresDelanteros; return this; }
    public IAutomovilBuilder SetSensoresTraseros(bool sensoresTraseros) { _propiedades["SensoresTraseros"] = sensoresTraseros; return this; }
    public IAutomovilBuilder SetVidriosElectricos(bool vidriosElectricos) { _propiedades["VidriosElectricos"] = vidriosElectricos; return this; }
    public IAutomovilBuilder SetEspejosElectricos(bool espejosElectricos) { _propiedades["EspejosElectricos"] = espejosElectricos; return this; }
    public IAutomovilBuilder SetBaulAutomatico(bool baulAutomatico) { _propiedades["BaulAutomatico"] = baulAutomatico; return this; }
    public IAutomovilBuilder SetPolarizado(bool polarizado) { _propiedades["Polarizado"] = polarizado; return this; }
    public IAutomovilBuilder SetFrenosABS(bool frenosABS) { _propiedades["FrenosABS"] = frenosABS; return this; }
    public IAutomovilBuilder SetControlEstabilidad(bool controlEstabilidad) { _propiedades["ControlEstabilidad"] = controlEstabilidad; return this; }
    public IAutomovilBuilder SetAirbagsLaterales(bool airbagsLaterales) { _propiedades["AirbagsLaterales"] = airbagsLaterales; return this; }
    public IAutomovilBuilder SetAlarma(bool alarma) { _propiedades["Alarma"] = alarma; return this; }
    public IAutomovilBuilder SetBloqueoCentral(bool bloqueoCentral) { _propiedades["BloqueoCentral"] = bloqueoCentral; return this; }
    public IAutomovilBuilder SetPantallaAndroidAuto(bool pantallaAndroidAuto) { _propiedades["PantallaAndroidAuto"] = pantallaAndroidAuto; return this; }
    public IAutomovilBuilder SetParlantesExtra(bool parlantesExtra) { _propiedades["ParlantesExtra"] = parlantesExtra; return this; }
    public IAutomovilBuilder SetDVDParaAtras(bool dvdParaAtras) { _propiedades["DVDParaAtras"] = dvdParaAtras; return this; }
    public IAutomovilBuilder SetGanchoRemolque(bool ganchoRemolque) { _propiedades["GanchoRemolque"] = ganchoRemolque; return this; }
    public IAutomovilBuilder SetParrillaTecho(bool parrillaTecho) { _propiedades["ParrillaTecho"] = parrillaTecho; return this; }
    public IAutomovilBuilder SetPortavasos(bool portavasos) { _propiedades["Portavasos"] = portavasos; return this; }
    public IAutomovilBuilder SetSoporteCelular(bool soporteCelular) { _propiedades["SoporteCelular"] = soporteCelular; return this; }
    public IAutomovilBuilder SetLucesInterioresLED(bool lucesInterioresLED) { _propiedades["LucesInterioresLED"] = lucesInterioresLED; return this; }
    public IAutomovilBuilder SetSonidoTumbaCarro(bool sonidoTumbaCarro) { _propiedades["SonidoTumbaCarro"] = sonidoTumbaCarro; return this; }

    public Automovil Build()
    {
        // Validación de campos obligatorios
        var errores = new List<string>();

        if (!_propiedades.ContainsKey("Marca") || string.IsNullOrWhiteSpace((string)_propiedades["Marca"]))
            errores.Add("Marca es obligatoria");
        if (!_propiedades.ContainsKey("Modelo") || string.IsNullOrWhiteSpace((string)_propiedades["Modelo"]))
            errores.Add("Modelo es obligatorio");
        if (!_propiedades.ContainsKey("Anio") || (int)_propiedades["Anio"] <= 1900)
            errores.Add("Año debe ser válido (mayor a 1900)");
        if (!_propiedades.ContainsKey("Color") || string.IsNullOrWhiteSpace((string)_propiedades["Color"]))
            errores.Add("Color es obligatorio");
        if (!_propiedades.ContainsKey("Llantas") || string.IsNullOrWhiteSpace((string)_propiedades["Llantas"]))
            errores.Add("Llantas son obligatorias");

        if (errores.Any())
        {
            throw new InvalidOperationException($"Error en la construcción del automóvil: {string.Join(", ", errores)}");
        }

        // Usar reflexión para crear el automóvil automáticamente
        var automovil = new Automovil();
        var tipoAutomovil = typeof(Automovil);

        foreach (var kvp in _propiedades)
        {
            var propiedad = tipoAutomovil.GetProperty(kvp.Key);
            if (propiedad != null && propiedad.CanWrite)
            {
                // Para propiedades init-only, necesitamos usar reflection
                var campo = tipoAutomovil.GetField($"<{kvp.Key}>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
                if (campo != null)
                {
                    campo.SetValue(automovil, kvp.Value);
                }
            }
        }

        return automovil;
    }
}
