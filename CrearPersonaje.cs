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
            string json = File.ReadAllText("../../../json/nombresyapodos.json");

            var opciones = new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            };

            List<Identidad> datosList = JsonSerializer.Deserialize<List<Identidad>>(json, opciones);

            Personaje personaje = new Personaje();
            Datos datos = new Datos();
            Caracteristicas caract = new Caracteristicas();

            caract.Velocidad = random.Next(1,10);
            caract.Destreza = random.Next(1,5);
            caract.Fuerza = random.Next(1,10);
            caract.Nivel = random.Next(1,10);
            caract.Armadura = random.Next(1,10);
            caract.salud = 100;

            datos.Nombre = datosList[random.Next(datosList.Count)].nombre;
            datos.Apodo = datosList[random.Next(datosList.Count)].apodo;
            datos.Tipo = datosList[random.Next(datosList.Count)].tipo;

            // Fecha de naciemiento y edad aleatorias
            datos.fechaNacimiento = new DateTime(random.Next(1724, 2024), random.Next(1, 13), random.Next(1, 29));
            datos.Edad = DateTime.Now.Year - datos.fechaNacimiento.Year;

            //Asignacion de valores
            personaje.datos = datos;
            personaje.caracteristicas = caract;
            return personaje;
        }
    }
}