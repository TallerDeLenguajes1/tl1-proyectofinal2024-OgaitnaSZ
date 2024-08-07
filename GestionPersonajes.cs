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
        string[] datos = {
            $"DATOS:",
            $"    Tipo: {personaje.datos.Tipo}",
            $"    Edad: {personaje.datos.Edad}",
            $"    Fecha de nacimiento: {personaje.datos.fechaNacimiento.ToShortDateString()}"
        };

        string[] caracteristicas = {
            $"CARACTERISTICAS:",
            $"    Velocidad: {personaje.caracteristicas.Velocidad}",
            $"    Destreza: {personaje.caracteristicas.Destreza}",
            $"    Fuerza: {personaje.caracteristicas.Fuerza}",
            $"    Nivel: {personaje.caracteristicas.Nivel}",
            $"    Armadura: {personaje.caracteristicas.Armadura}"
        };

        int maxLineas = Math.Max(datos.Length, caracteristicas.Length);

        Console.WriteLine(personaje.datos.Nombre+", "+personaje.datos.Apodo);
        for (int i = 0; i < maxLineas; i++){
            string datosLinea = i < datos.Length ? datos[i] : "";
            string caracteristicasLinea = i < caracteristicas.Length ? caracteristicas[i] : "";

            Console.WriteLine($"{datosLinea,-40} {caracteristicasLinea}");
        }

        Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    }

    public string realizarApuesta(List<Personaje> personajes){
        Console.WriteLine("Escribe el nombre del personaje por el que apuestas:");
        bool encontrado;
        string nombreApuesta;
        do{
            nombreApuesta = Console.ReadLine();
            encontrado = false;
            foreach(Personaje personaje in personajes){
                if (personaje.datos.Nombre.ToLower() == nombreApuesta.ToLower()){
                    encontrado = true;
                    break;
                }
            }
            if (encontrado){
                Console.WriteLine($"El personaje con el nombre '{nombreApuesta}' se ha encontrado.");
            }else{
                Console.WriteLine("No se encontro el personaje, escribe otro por favor: ");
            }
        }while(!encontrado);
        
        return nombreApuesta;
    } 
    public void mostarGanador(Personaje ganador, string nombreApuesta){
        Console.WriteLine($"\nFelicidades! El ganador del torneo es:");
        imprimirPersonaje(ganador);

        if (ganador.datos.Nombre.ToLower() == nombreApuesta.ToLower()){
            Console.WriteLine("Ganaste la apuesta!");
        }else{
            Console.WriteLine("No ganaste la apuesta, suerte a la proxima!");
        }
    }

    }

}