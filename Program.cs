using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;
using Batalla;

var personajes = new List<Personaje>();  //Lista de personajes

//Verificar si existen personajes
PersonajesJson gestion = new PersonajesJson();
if(gestion.existe("json/PersonajesGuardados.json")){
    personajes = gestion.leerPersonajes("PersonajesGuardados");
}else{
    for(int i=0 ; i<10 ; i++){
        Personaje personaje = new Personaje();
        FabricaDePersonajes fabrica = new FabricaDePersonajes();
        do{
            personaje = fabrica.cargarPersonaje();
            personaje.caracteristicas.salud = 100;
        }while(personajes.Contains(personaje));  //Control para que no hayan personajes repetidos
        personajes.Add(personaje);
    }
    gestion.guardarPersonajes(personajes,"PersonajesGuardados");
}
Console.WriteLine("Personajes Cargados:");
foreach(Personaje personaje in personajes){
    gestion.imprimirPersonaje(personaje);
}
Console.WriteLine("Personajes cargados: "+personajes.Count);

//Comenzar partida
Console.WriteLine("----- Comienza el torneo -----");
Torneo batalla = new Torneo();
Personaje ganador = batalla.vencedorTorneo(personajes);
Console.WriteLine($"Felicidades! El ganador del torneo es {ganador.datos.Nombre}, {ganador.datos.Apodo}");
gestion.imprimirPersonaje(ganador);

//Guardar datos de ganador en el historial
HistorialJson historial = new HistorialJson();
historial.GuardarGanador(ganador,"Historial");