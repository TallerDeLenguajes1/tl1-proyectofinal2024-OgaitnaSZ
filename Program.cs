using System;
using Personajes;
using Creador;
using GestionPersonajes;

var personajes = new List<Personaje>();

FabricaDePersonajes fab1 = new FabricaDePersonajes();
Personaje personaje = new Personaje();

for(int i=0 ; i<3 ; i++){
    personaje = fab1.cargarPersonaje();
    personajes.Add(personaje);
}

PersonajesJson guardar = new PersonajesJson();
guardar.guardarPersonajes(personajes,"guardados");

var personajesCargados = new List<Personaje>();
personajesCargados = guardar.leerPersonajes("guardados");
Console.WriteLine(personajesCargados.Count);

if(guardar.existe("../../../a.txt")){
    Console.WriteLine("existe");
}else{
    Console.WriteLine("NO");
}

