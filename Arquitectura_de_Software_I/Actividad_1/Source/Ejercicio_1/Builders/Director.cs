namespace Ejercicio_1.Builders
{
    public class Director
    {
        private readonly IAutomovilBuilder _builder;

        public Director(IAutomovilBuilder builder)
        {
            _builder = builder;
        }

        public IAutomovilBuilder AutomovilBasico()
        {

            return _builder
                .Reset()
                .SetMarca("Genérica")
                .SetModelo("Modelo Base")
                .SetTipo("Estándar")
                .SetAnio(2025)
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

        public IAutomovilBuilder AutomovilDeLujo()
        {
            return _builder
                 .Reset()
                 .SetMarca("Mercedes")
                 .SetModelo("Clase S")
                 .SetTipo("De Lujo")
                 .SetAnio(2025)
                 .SetMotor("V8 4.0L")
                 .SetColor("Negro")
                 .SetLlantas("18\" Aleación")
                 .SetVolante("Cuero")
                 .SetTransmision("Automática")
                 .SetFaros("LED")
                 .SetTapiceria("Cuero")
                 .SetSonido("Bose")
                 .SetInteriores("Piel premium");
        }

        public IAutomovilBuilder AutomovilDeportivo()
        {
            return _builder
                .Reset()
                .SetMarca("Ferrari")
                .SetModelo("488 Spider")
                .SetTipo("Deportivo")
                .SetAnio(2025)
                .SetMotor("V8 3.9L Turbo")
                .SetColor("Rojo")
                .SetLlantas("20\" Deportivas")
                .SetVolante("Deportivo")
                .SetTransmision("Automática")
                .SetFaros("LED")
                .SetTapiceria("Cuero")
                .SetSonido("Bose")
                .SetInteriores("Piel premium");
        }

        public IAutomovilBuilder AutomovilBase()
        {
            return _builder;
        }
    }
}
