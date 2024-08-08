using System;
using System.Text.Json;
using Personajes;

namespace Historial{
    public class Partida{
        public Personaje personaje{get;set;}
        public int victorias{get;set;}
        public double dmgInfligido{get;set;}
        public double dmgRecibido{get;set;}
        public double ratioDeDmg{get;set;}
        public double dmgPromedioPorTurno{get;set;}
        public DateTime fecha{get;set;}
    }
    public class HistorialJson{
        public void GuardarGanador(Personaje personaje, string nombreArchivo){
            try{
                List<Partida> historalCompleto = new List<Partida>();
                Partida partida = new Partida();
                partida.personaje = personaje;
                partida.victorias = 1;
                partida.dmgInfligido= personaje.caracteristicas.dmgInfligido;
                partida.dmgRecibido = personaje.caracteristicas.dmgRecibido;
                partida.ratioDeDmg = Math.Round((partida.dmgInfligido/partida.dmgRecibido),2);
                partida.dmgPromedioPorTurno = Math.Round((partida.dmgInfligido/personaje.caracteristicas.turnosJugados),2);
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

        public void mostrarHistorial(){
            var ganadores = new List<Partida>();
            try{
                ganadores = leerGanadores("historial");   
            }catch{
                Console.WriteLine("Nno hay partidas recientes");
            }
            foreach(Partida ganador in ganadores){
                imprimirPartida(ganador);
            }
        }

        private void imprimirPartida(Partida partida){
            Console.WriteLine(partida.personaje.datos.Nombre+","+partida.personaje.datos.Tipo);
            Console.WriteLine("   Victorias: "+partida.victorias);
            Console.WriteLine("   Dano infligido: "+partida.dmgInfligido);
            Console.WriteLine("   Dano recibido: "+partida.dmgRecibido);
            Console.WriteLine("   Ratio de dano: "+partida.ratioDeDmg);
            Console.WriteLine("   Dano promedio por turno: "+partida.dmgPromedioPorTurno);
            Console.WriteLine("   Fecha: "+partida.fecha.ToShortDateString());
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}