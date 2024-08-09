using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;
using Batalla;
using GestionarProyecto;

var personajes = new List<Personaje>();  //Lista de personajes
HistorialJson historial = new HistorialJson();
PersonajesJson gestion = new PersonajesJson();
FabricaDePersonajes fabrica = new FabricaDePersonajes();
Gestionar gestionar = new Gestionar();

//Inicio del juego
Console.WriteLine("Bienvenidos a League of Legends Battle Royale");
gestionar.menuOpciones();
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

            //Comenzar partida
            Console.WriteLine("━━━━━━ Comienza el torneo ━━━━━━");
            Torneo batalla = new Torneo();
            bool controlModoDeJuego = true;
            while(control){
                gestionar.modoDeJuego();
                opcion = int.Parse(Console.ReadLine());
                if(opcion == 0){
                    batalla.battleRoyale(personajes);
                    controlModoDeJuego = false;
                    control = false;
                }else{
                    batalla.peleaEquipos(personajes);
                    controlModoDeJuego = false;
                    control = false;
                }
            }
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

