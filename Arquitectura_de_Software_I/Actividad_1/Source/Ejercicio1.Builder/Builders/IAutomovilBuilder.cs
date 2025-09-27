using Ejercicio_1.Models;

namespace Ejercicio_1.Builders;

/// <summary>
/// Interfaz que define el contrato para construir un automóvil paso a paso
/// </summary>
public interface IAutomovilBuilder
{
    /// <summary>
    /// Reinicia el builder para comenzar una nueva construcción
    /// </summary>
    IAutomovilBuilder Reset();

    // Métodos para propiedades básicas (obligatorias)
    IAutomovilBuilder SetMarca(string marca);
    IAutomovilBuilder SetModelo(string modelo);
    IAutomovilBuilder SetTipo(TipoAutomovil tipo);
    IAutomovilBuilder SetAnio(int año);
    IAutomovilBuilder SetMotor(TipoMotor motor);
    IAutomovilBuilder SetColor(string color);
    IAutomovilBuilder SetLlantas(string llantas);
    IAutomovilBuilder SetTransmision(TipoTransmision transmision);
    IAutomovilBuilder SetFaros(TipoFaros faros);
    IAutomovilBuilder SetTapiceria(TipoTapiceria tapiceria);

    // Métodos para propiedades opcionales
    IAutomovilBuilder SetSonido(string sonido);
    IAutomovilBuilder SetInteriores(string interiores);
    IAutomovilBuilder SetVolante(string volante);
    IAutomovilBuilder SetRinesPersonalizados(string rines);

    // Métodos para características opcionales (booleanas)
    IAutomovilBuilder SetTechoSolar(bool techoSolar);
    IAutomovilBuilder SetGPS(bool gps);
    IAutomovilBuilder SetAireAcondicionado(bool aireAcondicionado);
    IAutomovilBuilder SetCamaraReversa(bool camaraReversa);
    IAutomovilBuilder SetSensoresDelanteros(bool sensoresDelanteros);
    IAutomovilBuilder SetSensoresTraseros(bool sensoresTraseros);
    IAutomovilBuilder SetVidriosElectricos(bool vidriosElectricos);
    IAutomovilBuilder SetEspejosElectricos(bool espejosElectricos);
    IAutomovilBuilder SetBaulAutomatico(bool baulAutomatico);
    IAutomovilBuilder SetPolarizado(bool polarizado);
    IAutomovilBuilder SetFrenosABS(bool frenosABS);
    IAutomovilBuilder SetControlEstabilidad(bool controlEstabilidad);
    IAutomovilBuilder SetAirbagsLaterales(bool airbagsLaterales);
    IAutomovilBuilder SetAlarma(bool alarma);
    IAutomovilBuilder SetBloqueoCentral(bool bloqueoCentral);
    IAutomovilBuilder SetPantallaAndroidAuto(bool pantallaAndroidAuto);
    IAutomovilBuilder SetParlantesExtra(bool parlantesExtra);
    IAutomovilBuilder SetDVDParaAtras(bool dvdParaAtras);
    IAutomovilBuilder SetGanchoRemolque(bool ganchoRemolque);
    IAutomovilBuilder SetParrillaTecho(bool parrillaTecho);
    IAutomovilBuilder SetPortavasos(bool portavasos);
    IAutomovilBuilder SetSoporteCelular(bool soporteCelular);
    IAutomovilBuilder SetLucesInterioresLED(bool lucesInterioresLED);
    IAutomovilBuilder SetSonidoTumbaCarro(bool sonidoTumbaCarro);

    /// <summary>
    /// Construye y retorna el automóvil con todas las configuraciones establecidas
    /// </summary>
    /// <returns>Automóvil construido</returns>
    /// <exception cref="InvalidOperationException">Si faltan propiedades obligatorias</exception>
    Automovil Build();
}
