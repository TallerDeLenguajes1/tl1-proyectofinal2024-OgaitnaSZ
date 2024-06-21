using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;
using Rendimiento;

var personajes = new List<Personaje>();

//Verificar si existen personajes
PersonajesJson gestion = new PersonajesJson();
if(gestion.existe("../../../json/PersonajesGuardados.json")){
    Console.WriteLine("Si");
    personajes = gestion.leerPersonajes("PersonajesGuardados");
}else{
    for(int i=0 ; i<10 ; i++){
        Personaje personaje = new Personaje();
        FabricaDePersonajes fabrica = new FabricaDePersonajes();
        personaje = fabrica.cargarPersonaje();
        personajes.Add(personaje);
    }
    gestion.guardarPersonajes(personajes,"PersonajesGuardados");
    personajes = gestion.leerPersonajes("PersonajesGuardados");
}
Console.WriteLine("Personajes Cargados:");
foreach(Personaje personaje in personajes){
    string datosPersonajes = $@" PERSONAJE {personajes}
DATOS:
    {personaje.datos.Nombre}, {personaje.datos.Apodo},
    Tipo: {personaje.datos.Tipo}
    Edad: {personaje.datos.Edad}
    Fecha de nacimiento: {personaje.datos.fechaNacimiento.ToShortDateString()}
CARACTERISTICAS:
    Velocidad: {personaje.caracteristicas.Velocidad}
    Destreza: {personaje.caracteristicas.Destreza}
    Fuerza: {personaje.caracteristicas.Fuerza}
    Nivel: {personaje.caracteristicas.Nivel}
    Armadura: {personaje.caracteristicas.Armadura}
------------------------------------------------------------";
    Console.WriteLine(datosPersonajes);
}
Console.WriteLine("Personajes cargados: "+personajes.Count);


// HistorialJson historial = new HistorialJson();
// WinRate winRate = new WinRate();
// winRate.victorias = 2;
// winRate.derrotas = 1;

// var partidaCargada = new List<Partida>();
// partidaCargada =  historial.leerGanadores("Historial");
// Console.WriteLine(partidaCargada);