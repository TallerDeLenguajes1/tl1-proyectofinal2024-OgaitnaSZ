using System;
using System.Text.Json;
using Personajes;
using Creador;

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

        public void imprimirListaDePersonajes(List<Personaje> personajes){
            foreach(Personaje personaje in personajes){
                imprimirPersonaje(personaje);
            }
        }
        public void imprimirEquipos(List<Personaje> equipo1, List<Personaje> equipo2){
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃                EQUIPO 1                ┃                  EQUIPO 2                 ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            for(int i=0 ; i<5 ; i++){
                string[] datos1 = {
                    $"{i+1}. {equipo1[i].datos.Nombre}, {equipo1[i].datos.Apodo}",
                    $"    Tipo: {equipo1[i].datos.Tipo}",
                    $"    Edad: {equipo1[i].datos.Edad}",
                    $"    Nacimiento: {equipo1[i].datos.fechaNacimiento.ToShortDateString()}"
                };

                string[] caracteristicas1 = {
                    $"CARACTERISTICAS:",
                    $"    Velocidad: {equipo1[i].caracteristicas.Velocidad}",
                    $"    Destreza: {equipo1[i].caracteristicas.Destreza}",
                    $"    Fuerza: {equipo1[i].caracteristicas.Fuerza}",
                    $"    Nivel: {equipo1[i].caracteristicas.Nivel}",
                    $"    Armadura: {equipo1[i].caracteristicas.Armadura}"
                };

                string[] datos2 = {
                    $"{i+1}. {equipo2[i].datos.Nombre}, {equipo2[i].datos.Apodo}",
                    $"    Tipo: {equipo2[i].datos.Tipo}",
                    $"    Edad: {equipo2[i].datos.Edad}",
                    $"    Nacimiento: {equipo2[i].datos.fechaNacimiento.ToShortDateString()}"
                };

                string[] caracteristicas2 = {
                    $"CARACTERISTICAS:",
                    $"    Velocidad: {equipo2[i].caracteristicas.Velocidad}",
                    $"    Destreza: {equipo2[i].caracteristicas.Destreza}",
                    $"    Fuerza: {equipo2[i].caracteristicas.Fuerza}",
                    $"    Nivel: {equipo2[i].caracteristicas.Nivel}",
                    $"    Armadura: {equipo2[i].caracteristicas.Armadura}"
                };


                int maxDatosLines = Math.Max(datos1.Length, datos2.Length);
                int maxCaracteristicasLines = Math.Max(caracteristicas1.Length, caracteristicas2.Length);

                // Imprimir las líneas de DATOS
                for (int j = 0; j < maxDatosLines; j++){
                    string datos1Line = j < datos1.Length ? datos1[j] : "";
                    string datos2Line = j < datos2.Length ? datos2[j] : "";
                    
                    Console.WriteLine($"{datos1Line,-40} ┃ {datos2Line}");
                }

                // Imprimir las líneas de CARACTERISTICAS
                for (int j = 0; j < maxCaracteristicasLines; j++){
                    string caracteristicas1Line = j < caracteristicas1.Length ? caracteristicas1[j] : "";
                    string caracteristicas2Line = j < caracteristicas2.Length ? caracteristicas2[j] : "";
                    
                    Console.WriteLine($"{caracteristicas1Line,-40} ┃ {caracteristicas2Line}");
                }
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            }
        }
        public void imprimirPersonaje(Personaje personaje){
            string[] datos = {
                $"DATOS:",
                $"    Tipo: {personaje.datos.Tipo}",
                $"    Edad: {personaje.datos.Edad}",
                $"    Nacimiento: {personaje.datos.fechaNacimiento.ToShortDateString()}"
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

        public void mostarGanador(Personaje ganador, string nombreApuesta){
            Console.WriteLine($"\nFelicidades! El ganador del torneo es:");
            imprimirPersonaje(ganador);

            if (ganador.datos.Nombre.ToLower() == nombreApuesta.ToLower()){
                Console.WriteLine("Ganaste la apuesta!");
            }else{
                Console.WriteLine("No ganaste la apuesta, suerte a la proxima!");
            }
        }

        public async Task<List<Personaje>> cargarPersonajes(){
            var personajes = new List<Personaje>();
            FabricaDePersonajes fabrica = new FabricaDePersonajes();
            if(existe("json/PersonajesGuardados.json")){  //Verificar si existen personajes
                personajes = leerPersonajes("PersonajesGuardados");  
            }else{   //Sino, genera personajes nuevos
                personajes = await fabrica.cargarPersonajes();
                guardarPersonajes(personajes,"PersonajesGuardados");
            }
            return personajes;
        }


    }

}