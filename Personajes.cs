namespace Personajes{
    public class Personaje{
        public Datos datos{get;set;}
        public Caracteristicas caracteristicas{get;set;}
    }

    public class Caracteristicas{
        private int velocidad;
        public int Velocidad{
            get => velocidad;
            set => velocidad = value;
        }
        private int destreza;
        public int Destreza{
            get => destreza;
            set => destreza = value;
        }
        private int fuerza;
        public int Fuerza{
            get => fuerza;
            set => fuerza = value;
        }
        private int nivel;
        public int Nivel{
            get => nivel;
            set => nivel = value;
        }
        private int armadura;
        public int Armadura{
            get => armadura;
            set => armadura = value;
        }
        private int salud;
        public int Salud{
            get => salud;
            set => salud = value;
        }
        //Agregados
        public int dmgInfligido;
        public int dmgRecibido;
        public int turnosJugados;

    }

    public class Datos{
        public string Tipo{get;set;}
        public string Nombre{get;set;}
        public string Apodo{get;set;}
        public DateTime fechaNacimiento{get;set;}
        public int Edad{get;set;}
    }
}