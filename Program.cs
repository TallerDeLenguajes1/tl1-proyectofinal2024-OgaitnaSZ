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
while(personajes.Count()>1){
    Random random = new Random();
    Console.WriteLine("Seleccione dos personajes para pelear");
    Personaje personaje1 = personajes[random.Next(personajes.Count())];
    Personaje personaje2 = personajes[random.Next(personajes.Count())];
    personaje1.caracteristicas.salud = 100;
    personaje2.caracteristicas.salud = 100;

    int turno = 0;
    int ataque;
    int efectividad;
    int defensa;
    int dmg;
    do{
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
    while(personaje1.caracteristicas.salud>0 && personaje2.caracteristicas.salud>0);
    if(personaje1.caracteristicas.salud>personaje2.caracteristicas.salud){
        Console.WriteLine("El personaje 1 es el vencedor!");
        Console.WriteLine("El personaje 2 queda fuera");
        personajes.Remove(personaje2);
        if(random.Next()%2==0){
            personaje1.caracteristicas.salud = 110;
            Console.WriteLine("+10 de salud para el personaje 1");
        }else{
            personaje1.caracteristicas.Armadura =+ 10;
            Console.WriteLine("+10 de armadura para el personaje 1"); 
        }
    }else{
            Console.WriteLine("El personaje 2 es el vencedor!");
            Console.WriteLine("El personaje 1 queda fuera");
            personajes.Remove(personaje1);
        if(random.Next()%2==0){
            personaje1.caracteristicas.salud = 110;
            Console.WriteLine("+10 de salud para el personaje 2");
        }else{
            personaje1.caracteristicas.Armadura =+ 10;
            Console.WriteLine("+10 de armadura para el personaje 2"); 
        }
    }
}
Console.WriteLine(personajes[0]);
string datosGanador = $@"
Felicidades! El ganador del torneo es{personajes[0].datos.Nombre}, {personajes[0].datos.Apodo},
DATOS:
Tipo: {personajes[0].datos.Tipo}
Edad: {personajes[0].datos.Edad}
Fecha de nacimiento: {personajes[0].datos.fechaNacimiento.ToShortDateString()}
CARACTERISTICAS:
Velocidad: {personajes[0].caracteristicas.Velocidad}
Destreza: {personajes[0].caracteristicas.Destreza}
Fuerza: {personajes[0].caracteristicas.Fuerza}
Nivel: {personajes[0].caracteristicas.Nivel}
Armadura: {personajes[0].caracteristicas.Armadura}
------------------------------------------------------------";
Console.WriteLine(datosGanador);

HistorialJson historial = new HistorialJson();
WinRate winRate = new WinRate();
winRate.victorias = 2;
winRate.derrotas = 1;
historial.GuardarGanador(personajes[0],winRate,"Historial");