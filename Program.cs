using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;
using Batalla;
using GestionarProyecto;

var personajes = new List<Personaje>();  //Lista de personajes
HistorialJson historial = new();
PersonajesJson gestion = new();
FabricaDePersonajes fabrica = new();
Gestionar gestionar = new();

//Inicio del juego
Console.WriteLine("Bienvenidos a League of Legends Battle Royale");
gestionar.menuOpciones();
bool control = true;
int opcion;
while(control){
    if(int.TryParse(Console.ReadLine(), out opcion)){
        switch(opcion){
        case 0:
            //Carga de personajes
            personajes = await gestion.cargarPersonajes();

            //Comenzar partida
            Console.WriteLine("━━━━━━ Comienza el torneo ━━━━━━");
            Torneo batalla = new();
            bool controlModoDeJuego = true;
            while(control){
                gestionar.modoDeJuego();
                while(controlModoDeJuego){
                    if(int.TryParse(Console.ReadLine(), out opcion)){
                        if(opcion == 0){
                            batalla.battleRoyale(personajes);
                            controlModoDeJuego = false;
                            control = false;
                        }else if(opcion == 1){
                            batalla.peleaEquipos(personajes);
                            controlModoDeJuego = false;
                            control = false;
                        }else{
                            Console.Write("Seleccione una opcion valida: ");
                        }
                    }else{
                        Console.Write("Seleccione una opcion valida:");
                    }
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
            Console.Write("Seleccione una opcion valida:");
        break;
    }
    }else{
        Console.Write("Seleccione una opcion valida: ");
    }
}

