using Ejercicio_1.Models;
using Ejercicio_1.Builders;

namespace Ejercicio_1.Factories
{
    public abstract class AutomovilFactory
    {
        public abstract Automovil CrearAutomovil();
        protected AutomovilBuilder BaseAutomovilBuilder()
        {
            return new AutomovilBuilder()
                .SetMarca("Genérica")
                .SetModelo("Modelo Base")
                .SetTipo("Estándar")
                .SetAño(2025)
                .SetMotor("Motor Básico")
                .SetColor("Blanco")
                .SetLlantas("16\" Aleación")
                .SetVolante("Estándar")
                .SetTransmision("Manual")
                .SetFaros("Halógeno")
                .SetTapiceria("Tela")
                .SetSonido("Estándar")
                .SetInteriores("Plástico");
        }
    }

    public class AutoDeLujoFactory : AutomovilFactory
    {  
        public override Automovil CrearAutomovil()
        {
            var builder = BaseAutomovilBuilder()
                .SetMarca("Mercedes")
                .SetModelo("Clase S")
                .SetTipo("De Lujo")
                .SetAño(2025)
                .SetMotor("V8 4.0L")
                .SetColor("Negro")
                .SetLlantas("18\" Aleación")
                .SetVolante("Cuero")
                .SetTransmision("Automática")
                .SetFaros("LED")
                .SetTapiceria("Cuero")
                .SetSonido("Bose")
                .SetInteriores("Piel premium");

            return builder.Build();
        }
    }

    public class AutoBasicoFactory : AutomovilFactory
    {
        public override Automovil CrearAutomovil()
        {
            var builder = BaseAutomovilBuilder()
                .SetMarca("Toyota")
                .SetModelo("Corolla")
                .SetTipo("Básico")
                .SetAño(2025)
                .SetMotor("1.6L")
                .SetColor("Blanco")
                .SetLlantas("16\" Aleación")
                .SetVolante("Plástico")
                .SetTransmision("Manual")
                .SetFaros("Halógeno")
                .SetTapiceria("Tela")
                .SetSonido("Estándar")
                .SetInteriores("Plástico");

            return builder.Build();
        }
    }

    public class AutoDeportivoFactory : AutomovilFactory
    {
        public override Automovil CrearAutomovil()
        {
            var builder = new AutomovilBuilder()
                .SetMarca("Ferrari")
                .SetModelo("488 Spider")
                .SetTipo("Deportivo")
                .SetAño(2025)
                .SetMotor("V8 3.9L Turbo")
                .SetColor("Rojo")
                .SetLlantas("20\" Deportivas")
                .SetVolante("Deportivo")
                .SetTransmision("Automática")
                .SetFaros("LED")
                .SetTapiceria("Cuero")
                .SetSonido("Bose")
                .SetInteriores("Piel premium");

            return builder.Build();
        }
    }
}
