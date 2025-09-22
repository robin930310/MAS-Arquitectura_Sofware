using Ejercicio_1.Builders;
using Ejercicio_1.Models;

class Program
{
    static void Main()
    {

        // Se Crea la instancia del Builder
        IAutomovilBuilder builder = new AutomovilBuilder();
        Director director = new Director(builder);


        // Ejemplo #1
        // Se Crea un Vehiculo con el "Builder" sin usar el "Director"
        Automovil autoRenault = builder
                    .Reset()
                    .SetMarca("Renault")
                    .SetModelo("Logan")
                    .SetTipo("Familiar")
                    .SetAnio(2025)
                    .SetMotor("V4 1.6L")
                    .SetColor("Negro")
                    .SetLlantas("17")
                    .SetVolante("Cuero")
                    .SetTransmision("Automática")
                    .SetFaros("Alogenos")
                    .SetTapiceria("Poliester")
                    .Build();

        Console.WriteLine("Ejemplo #1");
        Console.WriteLine(autoRenault);


        // Ejemplo #2
        // Se crea un vehiculo con el "Builder + Director"
        Automovil autoDeportivo = director.AutomovilDeportivo().Build();

        Console.WriteLine("Ejemplo #2");
        Console.WriteLine(autoDeportivo);


        // Ejemplo #3
        // Se crea un vehiculo con el "Builder + Director", modificando una propiedad
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


        Console.WriteLine("Ejemplo #3");
        Console.WriteLine(autoDeLujo);
    }
}
