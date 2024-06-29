using Personajes;

namespace Batalla{
    public class Torneo{
        public Personaje vencedorTorneo(List<Personaje> personajes){
            int ronda = 1;

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
                Console.WriteLine("\nRonda "+ ronda +": "+ personaje1.datos.Nombre+" VS "+personaje2.datos.Nombre);

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
                ronda++;
            }
            return personajes[0];
        }
        public void atacar(Personaje personaje1, Personaje personaje2){
            Random random = new Random();
            int ataque;
            int efectividad;
            int defensa;
            int dmg;
            ataque = personaje1.caracteristicas.Destreza*personaje1.caracteristicas.Fuerza*personaje1.caracteristicas.Nivel;
            efectividad = random.Next(1,100);
            defensa = personaje2.caracteristicas.Armadura*personaje2.caracteristicas.Velocidad;
            dmg = ((ataque*efectividad)-defensa)/500;
            personaje1.caracteristicas.dmgInfligido += dmg;
            personaje2.caracteristicas.dmgRecibido += dmg;
            personaje2.caracteristicas.salud -= dmg;
            personaje1.caracteristicas.turnosJugados++;
            personaje2.caracteristicas.turnosJugados++;
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
    }
}