using System;
using System.Text.Json;
using Personajes;

namespace GestionPersonajes{
    public class PersonajesJson{
        public void guardarPersonajes(List<Personaje> personaje, string nombreArchivo){
            try{
                string jsonString = JsonSerializer.Serialize(personaje, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("json/"+nombreArchivo+".json", jsonString);
                Console.WriteLine("Personajes guardados correctamente");
            }catch{
                Console.WriteLine("No se pudieron guardar los personajes");
            }
        }
        public List<Personaje> leerPersonajes(string nombreArchivo){
            string json = File.ReadAllText("json/"+nombreArchivo+".json");
            var opciones = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
            return JsonSerializer.Deserialize<List<Personaje>>(json, opciones);
        }
        public bool existe(string ruta){
            if (File.Exists(ruta)){
                return true;
            }else{return false;}
        }

        public void imprimirPersonaje(Personaje personaje){
string datosPersonajes = $@"
DATOS:
    {personaje.datos.Nombre}, {personaje.datos.Apodo},
    Tipo: {personaje.datos.Tipo}
    Edad: {personaje.datos.Edad}
    Fecha de nacimiento: {personaje.datos.fechaNacimiento.ToShortDateString()}
CARACTERISTICAS:
    Velocidad: {personaje.caracteristicas.Velocidad}
    Destreza: {personaje.caracteristicas.Destreza}
    Fuerza: {personaje.caracteristicas.Fuerza}
    Nivel: {personaje.caracteristicas.Nivel}
    Armadura: {personaje.caracteristicas.Armadura}
------------------------------------------------------------";
    Console.WriteLine(datosPersonajes);
        }
    }

}