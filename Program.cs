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

//Comenzar partida
Console.WriteLine("Selecciones dos personajes para pelear");
Personaje personaje1 = personajes[5];
Personaje personaje2 = personajes[2];

Random random = new Random();
int turno = 0;
int ataque;
int efectividad;
int defensa;
int dmg;
while(personaje1.caracteristicas.salud>0 || personaje2.caracteristicas.salud>0){
    if(turno%2 == 0){
        ataque = personaje1.caracteristicas.Destreza*personaje1.caracteristicas.Fuerza*personaje1.caracteristicas.Nivel;
        efectividad = random.Next(1,100);
        defensa = personaje2.caracteristicas.Armadura*personaje2.caracteristicas.Velocidad;
        dmg = ((ataque*efectividad)-defensa)/500;
        personaje2.caracteristicas.salud -= dmg;
    }else{
        ataque = personaje2.caracteristicas.Destreza*personaje2.caracteristicas.Fuerza*personaje2.caracteristicas.Nivel;
        efectividad = random.Next(1,100);
        defensa = personaje1.caracteristicas.Armadura*personaje1.caracteristicas.Velocidad;
        dmg = ((ataque*efectividad)-defensa)/500;
        personaje1.caracteristicas.salud -= dmg;
    }
    turno++;
}
if(personaje1.caracteristicas.salud>0){
    Console.WriteLine("ganador 1");
}
if(personaje2.caracteristicas.salud>0){
    Console.WriteLine("ganador 2");
}



// HistorialJson historial = new HistorialJson();
// WinRate winRate = new WinRate();
// winRate.victorias = 2;
// winRate.derrotas = 1;

// var partidaCargada = new List<Partida>();
// partidaCargada =  historial.leerGanadores("Historial");
// Console.WriteLine(partidaCargada);