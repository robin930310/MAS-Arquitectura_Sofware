using Ejercicio_1.Models;

namespace Ejercicio_1.Builders;

/// <summary>
/// Director que maneja la construcción de automóviles usando el patrón Builder
/// Define configuraciones predefinidas para diferentes tipos de vehículos
/// </summary>
public class Director
{
    private readonly IAutomovilBuilder _builder;

    public Director(IAutomovilBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    /// <summary>
    /// Construye un automóvil básico con configuraciones mínimas
    /// </summary>
    public IAutomovilBuilder AutomovilBasico()
    {
        return _builder
            .Reset()
            .SetMarca("Genérica")
            .SetModelo("Modelo Base")
            .SetTipo(TipoAutomovil.Basico)
            .SetAnio(2025)
            .SetMotor(TipoMotor.Basico)
            .SetColor("Blanco")
            .SetLlantas("16\" Aleación")
            .SetTransmision(TipoTransmision.Manual)
            .SetFaros(TipoFaros.Halogeno)
            .SetTapiceria(TipoTapiceria.Tela)
            .SetSonido("Estándar")
            .SetInteriores("Plástico");
    }

    /// <summary>
    /// Construye un automóvil de lujo con todas las características premium
    /// </summary>
    public IAutomovilBuilder AutomovilDeLujo()
    {
        return _builder
            .Reset()
            .SetMarca("Mercedes")
            .SetModelo("Clase S")
            .SetTipo(TipoAutomovil.DeLujo)
            .SetAnio(2025)
            .SetMotor(TipoMotor.Potente)
            .SetColor("Negro")
            .SetLlantas("18\" Aleación")
            .SetTransmision(TipoTransmision.Automatica)
            .SetFaros(TipoFaros.LED)
            .SetTapiceria(TipoTapiceria.Cuero)
            .SetSonido("Bose")
            .SetInteriores("Piel premium")
            .SetTechoSolar(true)
            .SetGPS(true)
            .SetAireAcondicionado(true)
            .SetCamaraReversa(true)
            .SetSensoresDelanteros(true)
            .SetSensoresTraseros(true)
            .SetVidriosElectricos(true)
            .SetEspejosElectricos(true)
            .SetFrenosABS(true)
            .SetControlEstabilidad(true)
            .SetAirbagsLaterales(true)
            .SetAlarma(true)
            .SetBloqueoCentral(true)
            .SetPantallaAndroidAuto(true);
    }

    /// <summary>
    /// Construye un automóvil deportivo con características de alto rendimiento
    /// </summary>
    public IAutomovilBuilder AutomovilDeportivo()
    {
        return _builder
            .Reset()
            .SetMarca("Ferrari")
            .SetModelo("488 Spider")
            .SetTipo(TipoAutomovil.Deportivo)
            .SetAnio(2025)
            .SetMotor(TipoMotor.Deportivo)
            .SetColor("Rojo")
            .SetLlantas("20\" Deportivas")
            .SetTransmision(TipoTransmision.Automatica)
            .SetFaros(TipoFaros.LED)
            .SetTapiceria(TipoTapiceria.Alcantara)
            .SetSonido("Bose")
            .SetInteriores("Piel premium")
            .SetTechoSolar(true)
            .SetGPS(true)
            .SetAireAcondicionado(true)
            .SetCamaraReversa(true)
            .SetSensoresDelanteros(true)
            .SetSensoresTraseros(true)
            .SetVidriosElectricos(true)
            .SetEspejosElectricos(true)
            .SetFrenosABS(true)
            .SetControlEstabilidad(true)
            .SetAirbagsLaterales(true)
            .SetAlarma(true)
            .SetBloqueoCentral(true)
            .SetPantallaAndroidAuto(true)
            .SetParlantesExtra(true);
    }

    /// <summary>
    /// Construye un SUV familiar con características prácticas
    /// </summary>
    public IAutomovilBuilder AutomovilSUV()
    {
        return _builder
            .Reset()
            .SetMarca("Toyota")
            .SetModelo("RAV4")
            .SetTipo(TipoAutomovil.SUV)
            .SetAnio(2025)
            .SetMotor(TipoMotor.Intermedio)
            .SetColor("Plata")
            .SetLlantas("17\" Aleación")
            .SetTransmision(TipoTransmision.Automatica)
            .SetFaros(TipoFaros.LED)
            .SetTapiceria(TipoTapiceria.Vinilo)
            .SetSonido("JBL")
            .SetInteriores("Plástico resistente")
            .SetGPS(true)
            .SetAireAcondicionado(true)
            .SetCamaraReversa(true)
            .SetSensoresDelanteros(true)
            .SetSensoresTraseros(true)
            .SetVidriosElectricos(true)
            .SetEspejosElectricos(true)
            .SetFrenosABS(true)
            .SetControlEstabilidad(true)
            .SetAirbagsLaterales(true)
            .SetAlarma(true)
            .SetBloqueoCentral(true)
            .SetGanchoRemolque(true)
            .SetParrillaTecho(true);
    }

    /// <summary>
    /// Construye una pickup utilitaria
    /// </summary>
    public IAutomovilBuilder AutomovilPickup()
    {
        return _builder
            .Reset()
            .SetMarca("Ford")
            .SetModelo("F-150")
            .SetTipo(TipoAutomovil.Pickup)
            .SetAnio(2025)
            .SetMotor(TipoMotor.Potente)
            .SetColor("Blanco")
            .SetLlantas("18\" Acero")
            .SetTransmision(TipoTransmision.Automatica)
            .SetFaros(TipoFaros.Xenon)
            .SetTapiceria(TipoTapiceria.Vinilo)
            .SetSonido("Estándar")
            .SetInteriores("Plástico resistente")
            .SetGPS(true)
            .SetAireAcondicionado(true)
            .SetCamaraReversa(true)
            .SetFrenosABS(true)
            .SetControlEstabilidad(true)
            .SetAirbagsLaterales(true)
            .SetAlarma(true)
            .SetBloqueoCentral(true)
            .SetGanchoRemolque(true)
            .SetParrillaTecho(true);
    }

    /// <summary>
    /// Retorna el builder para construcción personalizada
    /// </summary>
    public IAutomovilBuilder BuilderPersonalizado()
    {
        return _builder.Reset();
    }
}
