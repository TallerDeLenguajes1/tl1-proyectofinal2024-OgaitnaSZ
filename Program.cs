using GestionPersonajes;
using Historial;
using Batalla;
using MensajesProyecto;

Mensajes.mensajeBienvenida(); //Mensaje de bienvenida

bool control = true;
while(control){
    Mensajes.menuOpciones();
    int opcion;
    bool control2 = true;
    if(int.TryParse(Console.ReadLine(), out opcion)){
        switch(opcion){
        case 1:
            var personajes = await PersonajesJson.cargarPersonajes();  //Cargar lista de personajes

            while(control && personajes.Count > 1){
                Mensajes.modoDeJuego();  //Seleccion de modo de juego

                while(control2){
                    if(int.TryParse(Console.ReadLine(), out opcion)){
                        if(opcion == 1){
                            Torneo.battleRoyale(personajes);
                            control2 = false;
                            control = false;
                        }else if(opcion == 2){
                            Torneo.peleaEquipos(personajes);
                            control2 = false;
                            control = false;
                        }else{
                            Mensajes.errorOpcion();
                        }
                    }else{
                        Mensajes.errorOpcion();
                    }
                }
            }
            break;
        case 2:
            HistorialJson.mostrarHistorial();
            Mensajes.historial();
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
            Mensajes.errorOpcion();
        break;
    }
    }else{
        Mensajes.errorOpcion();
    }
}

