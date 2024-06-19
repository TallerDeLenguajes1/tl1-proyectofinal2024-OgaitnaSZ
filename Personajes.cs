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
        public int salud;

    }

    public class Datos{
        public string Tipo;
        public string Nombre;
        public string Apodo;
        public DateTime fechaNacimiento;
        public int Edad;
    }
}