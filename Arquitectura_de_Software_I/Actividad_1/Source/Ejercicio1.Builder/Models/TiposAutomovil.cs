namespace Ejercicio_1.Models;

/// <summary>
/// Enumeraciones para las opciones predefinidas del automóvil
/// </summary>
public enum TipoAutomovil
{
    [DescripcionEnum("Automóvil Básico")] Basico,
    [DescripcionEnum("Automóvil Familiar")] Familiar,
    [DescripcionEnum("Automóvil Deportivo")] Deportivo,
    [DescripcionEnum("Automóvil de Lujo")] DeLujo,
    [DescripcionEnum("SUV")] SUV,
    [DescripcionEnum("Pickup")] Pickup
}

public enum TipoMotor
{
    [DescripcionEnum("Motor Básico")] Basico,
    [DescripcionEnum("Motor Intermedio")] Intermedio,
    [DescripcionEnum("Motor Potente")] Potente,
    [DescripcionEnum("Motor Deportivo")] Deportivo,
    [DescripcionEnum("Motor Eléctrico")] Electrico
}

public enum TipoTransmision
{
    [DescripcionEnum("Transmisión Manual")] Manual,
    [DescripcionEnum("Transmisión Automática")] Automatica,
    [DescripcionEnum("Transmisión CVT")] CVT,
    [DescripcionEnum("Transmisión Semi-Automática")] SemiAutomatica
}

public enum TipoFaros
{
    [DescripcionEnum("Faros Halógenos")] Halogeno,
    [DescripcionEnum("Faros Xenón")] Xenon,
    [DescripcionEnum("Faros LED")] LED,
    [DescripcionEnum("Faros Láser")] Laser
}

public enum TipoTapiceria
{
    [DescripcionEnum("Tapicería de Tela")] Tela,
    [DescripcionEnum("Tapicería de Vinilo")] Vinilo,
    [DescripcionEnum("Tapicería de Cuero")] Cuero,
    [DescripcionEnum("Tapicería de Alcántara")] Alcantara
}

