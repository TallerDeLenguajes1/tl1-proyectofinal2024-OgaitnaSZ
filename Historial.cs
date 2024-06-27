using System;
using System.Text.Json;
using Personajes;

namespace Historial{
    public class Partida{
        public Personaje personaje{get;set;}
        public int victorias{get;set;}
        public DateTime fecha{get;set;}
    }
    public class HistorialJson{
        public void GuardarGanador(Personaje personaje, string nombreArchivo){
            try{
                List<Partida> historalCompleto = new List<Partida>();
                Partida partida = new Partida();
                partida.personaje = personaje;
                partida.victorias = 1;
                partida.fecha = DateTime.Now;

                if(existe("json/"+nombreArchivo+".json")){   //Revisamos si existen mas ganadores
                    historalCompleto = leerGanadores(nombreArchivo);   //Si existe, los cargamos en una lista
                    string json = File.ReadAllText("json/"+nombreArchivo+".json");
                    if(json.Contains(partida.personaje.datos.Nombre)){    //Revisamos si este personaje ya gano alguna vez
                        for(int i=0 ; i<historalCompleto.Count() ; i++){
                            if(historalCompleto[i].personaje.datos.Nombre == partida.personaje.datos.Nombre){
                                partida.victorias++;     //Sumamos sus victorias
                            }
                        }
                    }
                }

                historalCompleto.Add(partida);
                string jsonString = JsonSerializer.Serialize(historalCompleto, new JsonSerializerOptions { WriteIndented = true});
                File.WriteAllText("json/"+nombreArchivo+".json", jsonString);
                Console.WriteLine("Partida guardada correctamente");
            }catch{
                Console.WriteLine("No se pudo guardar la partida");
            }
        }

        public List<Partida> leerGanadores(string nombreArchivo){
            string json = File.ReadAllText("json/"+nombreArchivo+".json");
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