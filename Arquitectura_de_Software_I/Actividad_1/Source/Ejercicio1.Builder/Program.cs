using Ejercicio_1.Builders;
using Ejercicio_1.Models;

namespace Ejercicio_1;

/// <summary>
/// Programa principal que demuestra el uso del patrón Builder
/// </summary>
class Program
{
    static void Main()
    {
        Console.WriteLine("=== DEMOSTRACIÓN DEL PATRÓN BUILDER ===\n");

        // Se crea la instancia del Builder
        IAutomovilBuilder builder = new AutomovilBuilder();
        Director director = new Director(builder);

        // Ejemplo #1: Construcción manual sin Director
        Console.WriteLine("EJEMPLO #1: Construcción manual de un Renault Logan");
        Console.WriteLine("=====================================================");

        Automovil autoRenault = builder
            .Reset()
            .SetMarca("Renault")
            .SetModelo("Logan")
            .SetTipo(TipoAutomovil.Familiar)
            .SetAnio(2025)
            .SetMotor(TipoMotor.Basico)
            .SetColor("Negro")
            .SetLlantas("17\" Aleación")
            .SetTransmision(TipoTransmision.Automatica)
            .SetFaros(TipoFaros.Halogeno)
            .SetTapiceria(TipoTapiceria.Vinilo)
            .SetVolante("Cuero")
            .SetSonido("Estándar")
            .SetInteriores("Plástico")
            .SetAireAcondicionado(true)
            .SetGPS(true)
            .SetFrenosABS(true)
            .Build();

        Console.WriteLine(autoRenault);
        Console.WriteLine(new string('=', 80) + "\n");

        // Ejemplo #2: Construcción usando Director - Automóvil Deportivo
        Console.WriteLine("EJEMPLO #2: Construcción usando Director - Ferrari Deportivo");
        Console.WriteLine("=============================================================");

        Automovil autoDeportivo = director.AutomovilDeportivo().Build();
        Console.WriteLine(autoDeportivo);
        Console.WriteLine(new string('=', 80) + "\n");

        // Ejemplo #3: Construcción usando Director con personalizaciones adicionales
        Console.WriteLine("EJEMPLO #3: Mercedes de Lujo con personalizaciones adicionales");
        Console.WriteLine("=============================================================");

        Automovil autoDeLujo = director.AutomovilDeLujo()
            .SetDVDParaAtras(true)
            .SetGanchoRemolque(true)
            .SetParrillaTecho(true)
            .SetPortavasos(true)
            .SetSoporteCelular(true)
            .SetRinesPersonalizados("20\" Cromado")
            .SetLucesInterioresLED(true)
            .SetSonidoTumbaCarro(true)
            .Build();

        Console.WriteLine(autoDeLujo);
        Console.WriteLine(new string('=', 80) + "\n");

        // Ejemplo #4: SUV Familiar
        Console.WriteLine("EJEMPLO #4: SUV Familiar - Toyota RAV4");
        Console.WriteLine("======================================");

        Automovil autoSUV = director.AutomovilSUV().Build();
        Console.WriteLine(autoSUV);
        Console.WriteLine(new string('=', 80) + "\n");

        // Ejemplo #5: Pickup Utilitaria
        Console.WriteLine("EJEMPLO #5: Pickup Utilitaria - Ford F-150");
        Console.WriteLine("===========================================");

        Automovil autoPickup = director.AutomovilPickup().Build();
        Console.WriteLine(autoPickup);
        Console.WriteLine(new string('=', 80) + "\n");

        // Ejemplo #6: Construcción personalizada desde cero
        Console.WriteLine("EJEMPLO #6: Construcción completamente personalizada");
        Console.WriteLine("====================================================");

        Automovil autoPersonalizado = director.BuilderPersonalizado()
            .SetMarca("Tesla")
            .SetModelo("Model S")
            .SetTipo(TipoAutomovil.DeLujo)
            .SetAnio(2025)
            .SetMotor(TipoMotor.Electrico)
            .SetColor("Azul Metálico")
            .SetLlantas("19\" Aleación Deportiva")
            .SetTransmision(TipoTransmision.Automatica)
            .SetFaros(TipoFaros.Laser)
            .SetTapiceria(TipoTapiceria.Cuero)
            .SetSonido("Premium Audio")
            .SetInteriores("Vegano Premium")
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
            .SetParlantesExtra(true)
            .SetLucesInterioresLED(true)
            .Build();

        Console.WriteLine(autoPersonalizado);

        Console.WriteLine("\n=== FIN DE LA DEMOSTRACIÓN ===");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
