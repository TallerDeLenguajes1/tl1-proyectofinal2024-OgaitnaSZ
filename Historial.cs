using System;
using System.Text.Json;
using Personajes;
using Rendimiento;

namespace Historial{
    public class Partida{
        public Personaje personaje{get;set;}
        public WinRate winrate{get;set;}
    }
    public class HistorialJson{
        public void GuardarGanador(Personaje personaje, WinRate winrate, string nombreArchivo){
            try{
                List<Partida> historalCompleto = leerGanadores(nombreArchivo);
                Partida partida = new Partida();
                partida.personaje = personaje;
                partida.winrate = winrate;
                historalCompleto.Add(partida);
                string jsonString = JsonSerializer.Serialize(historalCompleto, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("../../../json/"+nombreArchivo+".json", jsonString);
                Console.WriteLine("Partida guardada correctamente");
            }catch{
                Console.WriteLine("No se pudo guardar la partida");
            }
        }

        public List<Partida> leerGanadores(string nombreArchivo){
            string json = File.ReadAllText("../../../json/"+nombreArchivo+".json");
            Console.WriteLine(json);
            var opciones = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
            return JsonSerializer.Deserialize<List<Partida>>(json, opciones);
        }

        public bool existe(string ruta){
            if (File.Exists(ruta)){
                return true;
            }else{return false;}
        }
    }
}