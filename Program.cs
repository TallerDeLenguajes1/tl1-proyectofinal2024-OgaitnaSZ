using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;
using Rendimiento;

var personajes = new List<Personaje>();

FabricaDePersonajes fab1 = new FabricaDePersonajes();
Personaje personaje = new Personaje();

for(int i=0 ; i<3 ; i++){
    personaje = fab1.cargarPersonaje();
    personajes.Add(personaje);
}

PersonajesJson guardar = new PersonajesJson();
guardar.guardarPersonajes(personajes,"PersonajesGuardados");

var personajesCargados = new List<Personaje>();
personajesCargados = guardar.leerPersonajes("PersonajesGuardados");
Console.WriteLine(personajesCargados.Count);

if(guardar.existe("../../../a.txt")){
    Console.WriteLine("existe");
}else{
    Console.WriteLine("NO");
}


HistorialJson historial = new HistorialJson();
WinRate winRate = new WinRate();
winRate.victorias = 2;
winRate.derrotas = 1;

historial.GuardarGanador(personaje, winRate,"Historial" );

var partidaCargada = new List<Partida>();
partidaCargada =  historial.leerGanadores("Historial");
Console.WriteLine(partidaCargada);