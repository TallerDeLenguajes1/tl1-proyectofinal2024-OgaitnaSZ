using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;
using Batalla;

var personajes = new List<Personaje>();  //Lista de personajes

PersonajesJson gestion = new PersonajesJson();
if(gestion.existe("json/PersonajesGuardados.json")){  //Verificar si existen personajes
    personajes = gestion.leerPersonajes("PersonajesGuardados");  
}else{   //Sino, genera personajes nuevos
    for(int i=0 ; i<10 ; i++){
        Personaje personaje = new Personaje();
        FabricaDePersonajes fabrica = new FabricaDePersonajes();
        do{
            personaje = await fabrica.cargarPersonaje();
        }while(personajes.Contains(personaje));  //Control para que no hayan personajes repetidos
        personajes.Add(personaje);
    }
    gestion.guardarPersonajes(personajes,"PersonajesGuardados");
}

//Mostrar personajes
Console.WriteLine("Participantes del torneo:");
foreach(Personaje personaje in personajes){
    gestion.imprimirPersonaje(personaje);
}

//Apuesta por el ganador
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
        Console.WriteLine($"No se encontro el personaje, escribe otro por favor: ");
    }
}while(!encontrado);

//Comenzar partida
Console.WriteLine("----- Comienza el torneo -----");
Torneo batalla = new Torneo();
Personaje ganador = batalla.vencedorTorneo(personajes);

//Mensaje ganador
Console.WriteLine($"\nFelicidades! El ganador del torneo es:");
gestion.imprimirPersonaje(ganador);

if (ganador.datos.Nombre == nombreApuesta){
    Console.WriteLine("Ganaste la apuesta!");
}else{
    Console.WriteLine("No ganaste la apuesta, suerte a la proxima!");
}

//Guardar datos de ganador en el historial
HistorialJson historial = new HistorialJson();
historial.GuardarGanador(ganador,"Historial");