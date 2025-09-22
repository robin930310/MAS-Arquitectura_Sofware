using Ejercicio_1.Models;

namespace Ejercicio_1.Builders
{
    public interface IAutomovilBuilder
    {
        public IAutomovilBuilder Reset();

        public IAutomovilBuilder SetMarca(string marca);
        public IAutomovilBuilder SetModelo(string modelo);
        public IAutomovilBuilder SetTipo(string tipo);
        public IAutomovilBuilder SetAnio(int año);
        public IAutomovilBuilder SetMotor(string motor);
        public IAutomovilBuilder SetColor(string color);
        public IAutomovilBuilder SetLlantas(string llantas);
        public IAutomovilBuilder SetSonido(string sonido);
        public IAutomovilBuilder SetInteriores(string interiores);
        public IAutomovilBuilder SetTechoSolar(bool techoSolar);
        public IAutomovilBuilder SetGPS(bool gps);
        public IAutomovilBuilder SetVolante(string volante);
        public IAutomovilBuilder SetTransmision(string transmision);
        public IAutomovilBuilder SetFaros(string faros);
        public IAutomovilBuilder SetTapiceria(string tapiceria);
        public IAutomovilBuilder SetAireAcondicionado(bool aireAcondicionado);
        public IAutomovilBuilder SetCamaraReversa(bool camaraReversa);
        public IAutomovilBuilder SetSensoresDelanteros(bool value);
        public IAutomovilBuilder SetSensoresTraseros(bool value);
        public IAutomovilBuilder SetVidriosElectricos(bool value);
        public IAutomovilBuilder SetEspejosElectricos(bool value);
        public IAutomovilBuilder SetBaulAutomatico(bool value);
        public IAutomovilBuilder SetPolarizado(bool value);
        public IAutomovilBuilder SetFrenosABS(bool value);
        public IAutomovilBuilder SetControlEstabilidad(bool value);
        public IAutomovilBuilder SetAirbagsLaterales(bool value);
        public IAutomovilBuilder SetAlarma(bool value);
        public IAutomovilBuilder SetBloqueoCentral(bool value);
        public IAutomovilBuilder SetPantallaAndroidAuto(bool value);
        public IAutomovilBuilder SetParlantesExtra(bool value);
        public IAutomovilBuilder SetDVDParaAtras(bool value);
        public IAutomovilBuilder SetGanchoRemolque(bool value);
        public IAutomovilBuilder SetParrillaTecho(bool value);
        public IAutomovilBuilder SetPortavasos(bool value);
        public IAutomovilBuilder SetSoporteCelular(bool value);
        public IAutomovilBuilder SetRinesPersonalizados(string rines);
        public IAutomovilBuilder SetLucesInterioresLED(bool value);
        public IAutomovilBuilder SetSonidoTumbaCarro(bool value);

        public Automovil Build();
    }
}
