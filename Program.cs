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
        do{
            personaje = fabrica.cargarPersonaje();
            personaje.caracteristicas.salud = 100;
        }while(personajes.Contains(personaje));
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
Console.WriteLine("----- Comienza el torneo -----");
int saludTemp = 100;
int ronda = 1;
while(personajes.Count()>1){
    Random random = new Random();
    int p1;
    int p2;
    do{
        p1 = random.Next(personajes.Count());
        p2 = random.Next(personajes.Count());
    } while (p1 == p2);
    Personaje personaje1 = personajes[p1];
    Personaje personaje2 = personajes[p2];
    Console.WriteLine("\nRonda "+ ronda +": "+ personaje1.datos.Nombre+" VS "+personaje2.datos.Nombre);

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
        saludTemp = personaje1.caracteristicas.salud;
        Console.WriteLine(personaje1.datos.Nombre+" es el vencedor!");
        Console.WriteLine(personaje2.datos.Nombre+" queda fuera");
        personajes.Remove(personaje2);
        if(random.Next()%2==0){
            personaje1.caracteristicas.salud = 110;
            Console.WriteLine("+10 de salud para "+personaje1.datos.Nombre);
        }else{
            personaje1.caracteristicas.Armadura =+ 10;
            personaje1.caracteristicas.salud = 100;
            Console.WriteLine("+10 de armadura para "+personaje1.datos.Nombre); 
        }
    }else{
            saludTemp = personaje2.caracteristicas.salud;
            Console.WriteLine(personaje2.datos.Nombre+" es el vencedor!");
            Console.WriteLine(personaje1.datos.Nombre+" queda fuera");
            personajes.Remove(personaje1);
        if(random.Next()%2==0){
            personaje2.caracteristicas.salud = 110;
            Console.WriteLine("+10 de salud para "+personaje2.datos.Nombre);
        }else{
            personaje2.caracteristicas.Armadura =+ 10;
            personaje2.caracteristicas.salud = 100;
            Console.WriteLine("+10 de armadura para "+personaje2.datos.Nombre); 
        }
    }
    ronda++;
}
string datosGanador = $@"
Felicidades! El ganador del torneo es {personajes[0].datos.Nombre}, {personajes[0].datos.Apodo}!
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
Finalizo con {saludTemp} de salud
------------------------------------------------------------";
Console.WriteLine(datosGanador);

HistorialJson historial = new HistorialJson();

historial.GuardarGanador(personajes[0],"Historial");