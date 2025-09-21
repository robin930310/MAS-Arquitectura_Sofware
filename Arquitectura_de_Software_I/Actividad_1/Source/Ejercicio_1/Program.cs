using Ejercicio_1.Builders;
using Ejercicio_1.Factories;
using Ejercicio_1.Models;

class Program
{
    static void Main()
    {
        AutomovilFactory factory;

        try
        {
            factory = new AutoDeLujoFactory();
            Automovil autoDeLujo = factory.CrearAutomovil();
            Console.WriteLine($"\n## Automóvil de Lujo:\n{autoDeLujo}");

            factory = new AutoBasicoFactory();
            Automovil autoBasico = factory.CrearAutomovil();
            Console.WriteLine($"\n## Automóvil Básico:\n{autoBasico}");

            factory = new AutoDeportivoFactory();
            Automovil autoDeportivo = factory.CrearAutomovil();
            Console.WriteLine($"\n## Automóvil Deportivo:\n{autoDeportivo}");

            var autoEspecial = new AutomovilBuilder(new AutoDeLujoFactory().CrearAutomovil())
                        .SetColor("Rojo Metalizado")
                        .SetModelo("Edición Especial")
                        .SetAño(2026)
                        .Build();

            Console.WriteLine($"\n## Automóvil Especial:\n{autoEspecial}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error al crear el auto especial: {ex.Message}");
        }
    }
}
