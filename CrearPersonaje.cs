using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Personajes;

namespace Creador {
    public class Identidad {
        public string nombre { get; set; }
        public string apodo { get; set; }
        public string tipo { get; set; }
    }

    public class FabricaDePersonajes {
        Random random = new Random();

        public async Task<List<Personaje>> cargarPersonajes() {
            List<Identidad> datosList = await ObtenerDatosDeAPI();
            var personajes = new List<Personaje>();
            
            for(int i=0 ; i<10 ; i++){
                bool encontrado = true;
                do{  //Control de personajes repetidos
                    Personaje personaje = new Personaje();
                    personaje.datos = asignarDatos(datosList);
                    personaje.caracteristicas = asignarCaracteristicas(random.Next(1, 10), random.Next(1, 5), random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));
                    foreach(Personaje personajeLista in personajes){
                        if (personajeLista.datos.Nombre.ToLower() == personaje.datos.Nombre.ToLower()){
                            encontrado = false;
                            break;
                        }
                    }
                    if(encontrado){
                        personajes.Add(personaje);
                        encontrado = false;
                    }
                }while(encontrado);
            }
            return personajes;
        }

        public async Task<List<Identidad>> ObtenerDatosDeAPI() {
            using var httpClient = new HttpClient();
            var url = "https://ddragon.leagueoflegends.com/cdn/12.1.1/data/es_MX/champion.json";
            var response = await httpClient.GetStringAsync(url);
            var json = JsonDocument.Parse(response);
            var campeones = json.RootElement.GetProperty("data");

            var listaDatos = new List<Identidad>();
            foreach (var campeon in campeones.EnumerateObject()) {
                var nombre = campeon.Value.GetProperty("name").GetString();
                var titulo = campeon.Value.GetProperty("title").GetString();
                var tipo = campeon.Value.GetProperty("tags")[0].GetString();

                listaDatos.Add(new Identidad {
                    nombre = nombre,
                    apodo = titulo,
                    tipo = tipo
                });
            }
            return listaDatos;
        }

        public Datos asignarDatos(List<Identidad> listaDatos) {
            Datos datos = new Datos();

            // Elijo un nombre, apodo y tipo en una posicion aleatoria de la lista
            int pos = random.Next(listaDatos.Count);
            datos.Nombre = listaDatos[pos].nombre;
            datos.Apodo = listaDatos[pos].apodo;
            datos.Tipo = listaDatos[pos].tipo;

            // Fecha de nacimiento y edad aleatorias
            datos.fechaNacimiento = new DateTime(random.Next(1724, 2024), random.Next(1, 13), random.Next(1, 29));
            datos.Edad = DateTime.Now.Year - datos.fechaNacimiento.Year;
            return datos;
        }

        public Caracteristicas asignarCaracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura) {
            Caracteristicas caracteristicas = new Caracteristicas();
            caracteristicas.Velocidad = velocidad;
            caracteristicas.Destreza = destreza;
            caracteristicas.Fuerza = fuerza;
            caracteristicas.Nivel = nivel;
            caracteristicas.Armadura = armadura;
            caracteristicas.salud = 100;
            return caracteristicas;
        }
    }
}

