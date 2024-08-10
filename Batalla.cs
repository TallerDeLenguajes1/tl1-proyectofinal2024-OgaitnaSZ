using Personajes;
using GestionPersonajes;
using Historial;
using MnesajesProyecto;
using Creador;

namespace Batalla{
    public class Torneo{
        public void battleRoyale(List<Personaje> personajes){
            PersonajesJson gestion = new PersonajesJson();  
            HistorialJson historial = new HistorialJson();

            AsignarCaracteristicas(personajes); //Reasignar caracteristicas

            //Mostrar personajes
            Console.WriteLine("Participantes del torneo:");
            gestion.imprimirListaDePersonajes(personajes);

            int ronda = 1;
            int pos1;
            int pos2;
            string nombreApuesta = RealizarApuesta(personajes);

            while(personajes.Count() > 1){         //Mientras haya mas de un personaje en pie...
                Random random = new Random();
                do{
                    pos1 = random.Next(personajes.Count());
                    pos2 = random.Next(personajes.Count());
                } while (pos1 == pos2);
                Personaje personaje1 = personajes[pos1];     //Personajes aleatorios
                Personaje personaje2 = personajes[pos2];
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n━━━━━ Ronda "+ ronda +": "+ personaje1.datos.Nombre+" VS "+personaje2.datos.Nombre + " ━━━━━");
                Console.ResetColor();
                Thread.Sleep(3000); //Agregar delay entre enfrentamientos
                Combatir(personaje1, personaje2);
                
                //Comprobar ganador
                if(personaje1.caracteristicas.Salud>personaje2.caracteristicas.Salud){
                    PublicarGanador(personaje1, personaje2);
                    personajes.Remove(personaje2);
                }else{
                    PublicarGanador(personaje2, personaje1);
                    personajes.Remove(personaje1);
                }
                ronda++;
            }
            gestion.mostarGanador(personajes[0], nombreApuesta);

            //Guardar datos de ganador en el historial        
            historial.GuardarGanador(personajes[0],"Historial");
        }

        public void peleaEquipos(List<Personaje> personajes){
            PersonajesJson gestion = new PersonajesJson();  
            HistorialJson historial = new HistorialJson();
            
            AsignarCaracteristicas(personajes); //Reasignar caracteristicas

            var equipo1 = new List<Personaje>();
            var equipo2 = new List<Personaje>();
            Random random = new Random();

            //Distribuir personajes en 2 equipos
            for(int i=0 ; i<10 ; i++){
                int pos = random.Next(personajes.Count());
                if(i%2 ==  0){
                    equipo1.Add(personajes[pos]);
                    personajes.Remove(personajes[pos]);
                }else{
                    equipo2.Add(personajes[pos]);
                    personajes.Remove(personajes[pos]);
                }
            }

            //Mostrar equipos
            gestion.imprimirEquipos(equipo1,equipo2);

            int pos1 = 0;
            int pos2 = 0;
            while(equipo1.Count()>0 && equipo2.Count()>0){  
                Personaje personaje1 = equipo1[pos1];
                Personaje personaje2 = equipo2[pos2];
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\n━━━━━ "+ personaje1.datos.Nombre+"(Equipo 1) VS "+personaje2.datos.Nombre + "(Equipo 2) ━━━━━");
                Console.ResetColor();
                Thread.Sleep(3000); //Agregar delay entre enfrentamientos
                Combatir(personaje1, personaje2);
                
                //Comprobar ganador
                if(personaje1.caracteristicas.Salud>personaje2.caracteristicas.Salud){
                    PublicarGanador(personaje1,personaje2);
                    equipo2.Remove(personaje2);
                    pos1++;
               }else{
                    PublicarGanador(personaje2, personaje1);
                    equipo1.Remove(personaje1);
                    pos2++;
               }
               if(pos1>=equipo1.Count() || pos2>=equipo2.Count()){
                    pos1 = 0;
                    pos2 = 0;
                }
            }
  
            if(equipo1.Count() > equipo2.Count()){
                Console.WriteLine("Equipo 1 ganador\nLos integrantes en pie del equipo son:");
                foreach(Personaje personaje in equipo1){
                    gestion.imprimirPersonaje(personaje);
                    historial.GuardarGanador(personaje,"Historial");
                }
            }else{
                Console.WriteLine("Equipo 2 ganador\nLos integrantes en pie del equipo son:");
                foreach(Personaje personaje in equipo2){
                    gestion.imprimirPersonaje(personaje);
                    historial.GuardarGanador(personaje,"Historial");
                }
            }
        }

        //Funciones para peleas
        public static void Atacar(Personaje personaje1, Personaje personaje2){
            Console.Write(personaje1.datos.Nombre + " ⚔️  " + personaje2.datos.Nombre);
            Random random = new Random();
            int ataque;
            int efectividad;
            int defensa;
            int dmg;
            ataque = personaje1.caracteristicas.Destreza*personaje1.caracteristicas.Fuerza*personaje1.caracteristicas.Nivel;
            efectividad = random.Next(1,100);
            defensa = personaje2.caracteristicas.Armadura*personaje2.caracteristicas.Velocidad;
            dmg = ((ataque*efectividad)-defensa)/500;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" ("+personaje2.caracteristicas.Salud+" -> ");
            personaje1.caracteristicas.dmgInfligido += dmg;
            personaje2.caracteristicas.dmgRecibido += dmg;
            personaje2.caracteristicas.Salud -= dmg;
            Console.WriteLine(personaje2.caracteristicas.Salud+")");
            Console.ResetColor();
            Console.WriteLine("─────────────────────────────────────");
            personaje1.caracteristicas.turnosJugados++;
            personaje2.caracteristicas.turnosJugados++;
            //Thread.Sleep(1000); //Agregar delay entre turnos
        }
        public void Combatir(Personaje personaje1, Personaje personaje2){
            int turno = 0;
            do{
                if(turno%2 == 0){
                    Atacar(personaje1,personaje2);
                }else{
                    Atacar(personaje2,personaje1);
                }
                turno++;
            }while(personaje1.caracteristicas.Salud>0 && personaje2.caracteristicas.Salud>0);
        }
        public static void AsignarCaracteristicas(List<Personaje> personajes){
            FabricaDePersonajes fab = new();
            Random random = new ();
            foreach(Personaje personaje in personajes){
                personaje.caracteristicas = fab.asignarCaracteristicas(random.Next(1, 10), random.Next(1, 5), random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));
            }
        }
        public static void PublicarGanador(Personaje personaje1, Personaje personaje2){
            Random random = new Random();
            Mensajes mensaje = new();
            mensaje.mensajeGanador(personaje1,personaje2);

            if(random.Next()%2==0){
                personaje1.caracteristicas.Salud = 110;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+10 de Salud para "+personaje1.datos.Nombre);
                Console.ResetColor();
            }else{
                personaje1.caracteristicas.Armadura =+ 10;
                personaje1.caracteristicas.Salud = 100;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+10 de armadura para "+personaje1.datos.Nombre); 
                Console.ResetColor();
            }
        }
        public static string RealizarApuesta(List<Personaje> personajes){
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
    }
}