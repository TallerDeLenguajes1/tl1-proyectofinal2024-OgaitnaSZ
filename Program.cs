using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;
using Batalla;
using MnesajesProyecto;

var personajes = new List<Personaje>();  //Lista de personajes
HistorialJson historial = new();
PersonajesJson gestion = new();
FabricaDePersonajes fabrica = new();
Mensajes mensaje = new();

//Inicio del juego
mensaje.mensajeBienvenida();
bool control = true;
while(control){
    mensaje.menuOpciones();
    int opcion;
    bool control2 = true;
    if(int.TryParse(Console.ReadLine(), out opcion)){
        switch(opcion){
        case 1:
            //Carga de personajes
            personajes = await gestion.cargarPersonajes();

            //Comenzar partida
            Console.WriteLine("━━━━━━ Comienza el torneo ━━━━━━");
            Torneo batalla = new();
            while(control){
                mensaje.modoDeJuego();
                while(control2){
                    if(int.TryParse(Console.ReadLine(), out opcion)){
                        if(opcion == 1){
                            batalla.battleRoyale(personajes);
                            control2 = false;
                            control = false;
                        }else if(opcion == 2){
                            batalla.peleaEquipos(personajes);
                            control2 = false;
                            control = false;
                        }else{
                            mensaje.errorOpcion();
                        }
                    }else{
                        mensaje.errorOpcion();
                    }
                }
            }
            break;
        case 2:
            historial.mostrarHistorial();
            mensaje.historial();
            while(control2){
                if(int.TryParse(Console.ReadLine(), out opcion)){
                    if(opcion == 1){
                        control2 = false;
                    }else if(opcion == 2){
                        Console.WriteLine("Saliendo del juego...");
                        control2 = false;
                        control = false;
                    }
                }
            }
            break;
        case 3:
            Console.WriteLine("Saliendo del juego...");
            control = false;
            break;
        default:
            mensaje.errorOpcion();
        break;
    }
    }else{
        mensaje.errorOpcion();
    }
}

