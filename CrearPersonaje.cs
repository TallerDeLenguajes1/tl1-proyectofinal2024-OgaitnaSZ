using System;
using System.IO;
using System.Text.Json;
using Personajes;

namespace Creador{
    public class Identidad{
        public string nombre { get; set; }
        public string apodo { get; set; }
        public string tipo { get; set; }
    }

    public class FabricaDePersonajes{
        Random random = new Random();
        public Personaje cargarPersonaje(){
            string json = File.ReadAllText("json/nombresyapodos.json");
            var opciones = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
            List<Identidad> datosList = JsonSerializer.Deserialize<List<Identidad>>(json, opciones);
            Personaje personaje = new Personaje();
            
            //Asignacion de valores
            personaje.datos = asignarDatos(datosList);
            personaje.caracteristicas = asignarCaracteristicas(random.Next(1,10), random.Next(1,5), random.Next(1,10), random.Next(1,10), random.Next(1,10));
            return personaje;
        }
        public Datos asignarDatos(List<Identidad> listaDatos){
            Random random = new Random();
            Datos datos = new Datos();

            //Elijo un nombre, apodo y tipo en una posicion aleatoria de la lista
            int pos = random.Next(listaDatos.Count);
            datos.Nombre = listaDatos[pos].nombre;    
            datos.Apodo = listaDatos[pos].apodo;
            datos.Tipo = listaDatos[pos].tipo;

            // Fecha de naciemiento y edad aleatorias
            datos.fechaNacimiento = new DateTime(random.Next(1724, 2024), random.Next(1, 13), random.Next(1, 29));
            datos.Edad = DateTime.Now.Year - datos.fechaNacimiento.Year;
            return datos;
        }
        public Caracteristicas asignarCaracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura){
            Caracteristicas caracteristicas = new Caracteristicas();
            caracteristicas.Velocidad = velocidad;
            caracteristicas.Destreza = destreza;
            caracteristicas.Fuerza = fuerza;
            caracteristicas.Nivel = nivel;
            caracteristicas.Armadura = armadura;
            return caracteristicas;
        }
    }
}