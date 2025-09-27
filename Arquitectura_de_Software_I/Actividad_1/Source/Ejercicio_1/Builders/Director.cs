using System.Reflection;
using Ejercicio_1.Models;

namespace Ejercicio_1.Builders;

/// <summary>
/// Director mejorado que usa reflexión para automatizar configuraciones de vehículos
/// </summary>
public class Director
{
    private readonly IAutomovilBuilder _builder;

    public Director(IAutomovilBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    /// <summary>
    /// Aplica características automáticamente basado en el tipo de vehículo
    /// </summary>
    public IAutomovilBuilder AplicarCaracteristicasPorTipo(TipoAutomovil tipo)
    {
        // Configuraciones predefinidas por tipo de vehículo
        var configuraciones = GetConfiguracionesPorTipo(tipo);

        foreach (var caracteristica in configuraciones)
        {
            AplicarCaracteristica(caracteristica, true);
        }

        return _builder;
    }

    private void AplicarCaracteristica(string nombreCaracteristica, bool valor)
    {
        // Usar reflexión para encontrar y aplicar la característica
        var metodo = _builder.GetType().GetMethod($"Set{nombreCaracteristica}");
        if (metodo != null)
        {
            metodo.Invoke(_builder, new object[] { valor });
        }
    }

    private List<string> GetConfiguracionesPorTipo(TipoAutomovil tipo)
    {
        return tipo switch
        {
            TipoAutomovil.DeLujo => new List<string>
            {
                "TechoSolar", "GPS", "AireAcondicionado", "CamaraReversa",
                "SensoresDelanteros", "SensoresTraseros", "VidriosElectricos", "EspejosElectricos",
                "FrenosABS", "ControlEstabilidad", "AirbagsLaterales", "Alarma", "BloqueoCentral",
                "PantallaAndroidAuto"
            },
            TipoAutomovil.Deportivo => new List<string>
            {
                "TechoSolar", "GPS", "AireAcondicionado", "CamaraReversa",
                "SensoresDelanteros", "SensoresTraseros", "VidriosElectricos", "EspejosElectricos",
                "FrenosABS", "ControlEstabilidad", "AirbagsLaterales", "Alarma", "BloqueoCentral",
                "PantallaAndroidAuto", "ParlantesExtra"
            },
            TipoAutomovil.SUV => new List<string>
            {
                "GPS", "AireAcondicionado", "CamaraReversa", "SensoresDelanteros", "SensoresTraseros",
                "VidriosElectricos", "EspejosElectricos", "FrenosABS", "ControlEstabilidad",
                "AirbagsLaterales", "Alarma", "BloqueoCentral", "GanchoRemolque", "ParrillaTecho"
            },
            TipoAutomovil.Pickup => new List<string>
            {
                "GPS", "AireAcondicionado", "CamaraReversa", "FrenosABS", "ControlEstabilidad",
                "AirbagsLaterales", "Alarma", "BloqueoCentral", "GanchoRemolque", "ParrillaTecho"
            },
            _ => new List<string>() // Básico y Familiar sin características adicionales
        };
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
    /// Construye un automóvil de lujo con características premium
    /// </summary>
    public IAutomovilBuilder AutomovilDeLujo()
    {
        _builder
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
            .SetInteriores("Piel premium");

        return AplicarCaracteristicasPorTipo(TipoAutomovil.DeLujo);
    }

    /// <summary>
    /// Construye un automóvil deportivo con características de alto rendimiento
    /// </summary>
    public IAutomovilBuilder AutomovilDeportivo()
    {
        _builder
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
            .SetInteriores("Piel premium");

        return AplicarCaracteristicasPorTipo(TipoAutomovil.Deportivo);
    }

    /// <summary>
    /// Construye un SUV familiar con características prácticas
    /// </summary>
    public IAutomovilBuilder AutomovilSUV()
    {
        _builder
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
            .SetInteriores("Plástico resistente");

        return AplicarCaracteristicasPorTipo(TipoAutomovil.SUV);
    }

    /// <summary>
    /// Construye una pickup utilitaria
    /// </summary>
    public IAutomovilBuilder AutomovilPickup()
    {
        _builder
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
            .SetInteriores("Plástico resistente");

        return AplicarCaracteristicasPorTipo(TipoAutomovil.Pickup);
    }

    /// <summary>
    /// Retorna el builder para construcción personalizada
    /// </summary>
    public IAutomovilBuilder BuilderPersonalizado()
    {
        return _builder.Reset();
    }
}
