using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;
using Batalla;

var personajes = new List<Personaje>();  //Lista de personajes
HistorialJson historial = new HistorialJson();
PersonajesJson gestion = new PersonajesJson();
FabricaDePersonajes fabrica = new FabricaDePersonajes();


//Inicio del juego
Console.WriteLine("Bienvenidos a League of Legends Battle Royale");
Console.WriteLine("Seleccione una opcion:\n0: Iniciar el juego\n1: Ver Historial de ganadores\n2: Salir\n");
bool control = true;
int opcion;
while(control){
    opcion = int.Parse(Console.ReadLine());
    switch(opcion){
        case 0:
            //Carga de personajes
            if(gestion.existe("json/PersonajesGuardados.json")){  //Verificar si existen personajes
                personajes = gestion.leerPersonajes("PersonajesGuardados");  
            }else{   //Sino, genera personajes nuevos
                personajes = await fabrica.cargarPersonajes();
                gestion.guardarPersonajes(personajes,"PersonajesGuardados");
            }

            //Mostrar personajes
            Console.WriteLine("Participantes del torneo:");
            foreach(Personaje personaje in personajes){
                Random random = new Random();
                //Asignar caracteristicas aleatorias
                personaje.caracteristicas = fabrica.asignarCaracteristicas(random.Next(1, 10), random.Next(1, 5), random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));
                gestion.imprimirPersonaje(personaje);
            }

            //Apuesta por el ganador
            string nombreApuesta;
            nombreApuesta = gestion.realizarApuesta(personajes);

            //Comenzar partida
            Console.WriteLine("━━━━━━ Comienza el torneo ━━━━━━");
            Torneo batalla = new Torneo();
            Personaje ganador = batalla.vencedorTorneo(personajes);

            //Mensaje ganador
            gestion.mostarGanador(ganador, nombreApuesta);

            //Guardar datos de ganador en el historial        
            historial.GuardarGanador(ganador,"Historial");
            control = false;
        break;
        case 1:
            historial.mostrarHistorial();
            control = false;
        break;
        case 2:
            Console.WriteLine("Saliendo del juego...");
            control = false;
        break;
        default:
            Console.WriteLine("Seleccione una opcion valida:");
        break;
    }
}

