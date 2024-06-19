using Personajes;

namespace Creador{
    public class FabricaDePersonajes{
        Random random = new Random();
        public Personaje cargarPersonaje(){
            Personaje personaje = new Personaje();
            Datos datos = new Datos();
            Caracteristicas caract = new Caracteristicas();

            caract.Velocidad = random.Next(1,10);
            caract.Destreza = random.Next(1,5);
            caract.Fuerza = random.Next(1,10);
            caract.Nivel = random.Next(1,10);
            caract.Armadura = random.Next(1,10);
            caract.salud = 100;

            datos.Tipo = "Humano";
            datos.Nombre = "Kakashi";
            datos.Apodo = "El ninja que copia";
            datos.fechaNacimiento = new DateTime();
            datos.Edad = random.Next(0,300);

            personaje.datos = datos;
            personaje.caracteristicas = caract;
            return personaje;
        }
    }
}