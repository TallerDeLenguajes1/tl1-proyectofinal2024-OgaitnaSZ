using System;
using Personajes;
using Creador;
using GestionPersonajes;
using Historial;

var personajes = new List<Personaje>();  //Lista de personajes

//Verificar si existen personajes
PersonajesJson gestion = new PersonajesJson();
if(gestion.existe("../../../json/PersonajesGuardados.json")){
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
}
Console.WriteLine("Personajes Cargados:");
foreach(Personaje personaje in personajes){
    string datosPersonajes = $@"
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
int ronda = 1;
while(personajes.Count()>1){         //Mientras haya mas de un personaje en pie...
    Random random = new Random();
    int pos1;
    int pos2;
    do{
        pos1 = random.Next(personajes.Count());
        pos2 = random.Next(personajes.Count());
    } while (pos1 == pos2);
    Personaje personaje1 = personajes[pos1];     //Personajes aleatorios
    Personaje personaje2 = personajes[pos2];
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
------------------------------------------------------------";
Console.WriteLine(datosGanador);

//Guardar datos de ganador en el historial
HistorialJson historial = new HistorialJson();
historial.GuardarGanador(personajes[0],"Historial");