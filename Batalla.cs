using Personajes;
using GestionPersonajes;
using Historial;
using System.Threading;

namespace Batalla{
    public class Torneo{
        public void battleRoyale(List<Personaje> personajes){
            PersonajesJson gestion = new PersonajesJson();  
            HistorialJson historial = new HistorialJson(); 
            //Mostrar personajes
            Console.WriteLine("Participantes del torneo:");
            gestion.imprimirListaDePersonajes(personajes);

            int ronda = 1;
            string nombreApuesta = realizarApuesta(personajes);

            while(personajes.Count()>1){         //Mientras haya mas de un personaje en pie...
                Random random = new Random();
                int pos1;
                int pos2;
                do{
                    pos1 = random.Next(personajes.Count());
                    pos2 = random.Next(personajes.Count());
                } while (pos1 == pos2);
                Personaje personaje1 = personajes[pos1];     //Personajes aleatorios
                Personaje personaje2 = personajes[pos2];
                Console.WriteLine("\n━━━━━ Ronda "+ ronda +": "+ personaje1.datos.Nombre+" VS "+personaje2.datos.Nombre + " ━━━━━");
                //Thread.Sleep(3000); //Agregar delay entre rondas
                int turno = 0;
                do{
                    if(turno%2 == 0){
                        atacar(personaje1,personaje2);
                    }else{
                        atacar(personaje2,personaje1);
                    }
                    turno++;
                }while(personaje1.caracteristicas.salud>0 && personaje2.caracteristicas.salud>0);
                
                //Comprobar ganador
                if(personaje1.caracteristicas.salud>personaje2.caracteristicas.salud){
                    publicarGanador(personaje1, personaje2, personajes);
                }else{
                    publicarGanador(personaje2, personaje1, personajes);
                }
                //Thread.Sleep(3000); //Agregar delay entre rondas
                ronda++;
            }
            gestion.mostarGanador(personajes[0], nombreApuesta);

            //Guardar datos de ganador en el historial        
            historial.GuardarGanador(personajes[0],"Historial");
        }

        public void peleaEquipos(List<Personaje> personajes){
            PersonajesJson gestion = new PersonajesJson();  
            HistorialJson historial = new HistorialJson(); 
            var equipo1 = new List<Personaje>();
            var equipo2 = new List<Personaje>();
            Random random = new Random();

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
            Console.WriteLine("Equipo 1:");
            gestion.imprimirListaDePersonajes(equipo1);
            Console.WriteLine("Equipo 2:");
            gestion.imprimirListaDePersonajes(equipo2);

            int ronda = 1;
            while(equipo1.Count()>1 && equipo2.Count()>1){  
                int pos1;
                int pos2;
                do{
                    pos1 = random.Next(equipo1.Count());
                    pos2 = random.Next(equipo2.Count());
                } while (pos1 == pos2);
                Personaje personaje1 = equipo1[pos1];     //Personajes aleatorios
                Personaje personaje2 = equipo2[pos2];
                Console.WriteLine("\n━━━━━ Ronda "+ ronda +": "+ personaje1.datos.Nombre+" VS "+personaje2.datos.Nombre + " ━━━━━");
                //Thread.Sleep(3000); //Agregar delay entre rondas
                int turno = 0;
                do{
                    if(turno%2 == 0){
                        atacar(personaje1,personaje2);
                    }else{
                        atacar(personaje2,personaje1);
                    }
                    turno++;
                }while(personaje1.caracteristicas.salud>0 && personaje2.caracteristicas.salud>0);
                
                //Comprobar ganador
                if(personaje1.caracteristicas.salud>personaje2.caracteristicas.salud){
                    Console.WriteLine(personaje1.datos.Nombre+" es el vencedor!");
                    Console.WriteLine(personaje2.datos.Nombre+" queda fuera");
                    equipo2.Remove(personaje2);
                }else{
                    Console.WriteLine(personaje2.datos.Nombre+" es el vencedor!");
                    Console.WriteLine(personaje1.datos.Nombre+" queda fuera");
                    equipo1.Remove(personaje1);
                }
                //Thread.Sleep(3000); //Agregar delay entre rondas
                ronda++;
            }
  
            if(equipo1.Count()>equipo2.Count()){
                Console.WriteLine("Equipo 1 ganador\nLos integrantes del equipo son:");
                foreach(Personaje personaje in equipo1){
                    gestion.imprimirPersonaje(personaje);
                    historial.GuardarGanador(personaje,"Historial");
                }
            }else{
                Console.WriteLine("Equipo 2 ganador\nLos integrantes del equipo son:");
                foreach(Personaje personaje in equipo2){
                    gestion.imprimirPersonaje(personaje);
                    historial.GuardarGanador(personaje,"Historial");
                }
            }
        }


        //Funciones para peleas
        public void atacar(Personaje personaje1, Personaje personaje2){
            Console.WriteLine(personaje1.datos.Nombre + " ataca a " + personaje2.datos.Nombre);
            Random random = new Random();
            int ataque;
            int efectividad;
            int defensa;
            int dmg;
            ataque = personaje1.caracteristicas.Destreza*personaje1.caracteristicas.Fuerza*personaje1.caracteristicas.Nivel;
            efectividad = random.Next(1,100);
            defensa = personaje2.caracteristicas.Armadura*personaje2.caracteristicas.Velocidad;
            dmg = ((ataque*efectividad)-defensa)/500;
            string textoDmg = personaje2.datos.Nombre+" sufre "+dmg+" de dano ("+personaje2.caracteristicas.salud+" -> ";
            personaje1.caracteristicas.dmgInfligido += dmg;
            personaje2.caracteristicas.dmgRecibido += dmg;
            personaje2.caracteristicas.salud -= dmg;
            Console.WriteLine(textoDmg+personaje2.caracteristicas.salud+")");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            personaje1.caracteristicas.turnosJugados++;
            personaje2.caracteristicas.turnosJugados++;
            //Thread.Sleep(1000); //Agregar delay entre turnos
        }
        public void publicarGanador(Personaje personaje1, Personaje personaje2, List<Personaje> personajes){
            Random random = new Random();
            Console.WriteLine(personaje1.datos.Nombre+" es el vencedor!");
            Console.WriteLine(personaje2.datos.Nombre+" queda fuera");
            personajes.Remove(personaje2);
            if(random.Next()%2==0){
                personaje1.caracteristicas.salud = 110;
                Console.WriteLine("+10 de salud para "+personaje1.datos.Nombre);
            }else{
                personaje1.caracteristicas.Armadura =+ 10;
                personaje1.caracteristicas.salud = 100;
                Console.WriteLine("+10 de armadura para "+personaje1.datos.Nombre); 
            }
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

    }
}