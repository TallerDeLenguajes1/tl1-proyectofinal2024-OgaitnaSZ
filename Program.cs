﻿using System;
using Personajes;
using Creador;

var personajes = new List<Personaje>();

FabricaDePersonajes fab1 = new FabricaDePersonajes();
Personaje personaje = new Personaje();

personaje = fab1.cargarPersonaje();
personajes.Add(personaje);

Console.WriteLine(personaje.caracteristicas.Armadura);