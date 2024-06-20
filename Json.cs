using System;
using System.Text.Json;
using Personajes;

public class Root{
    public Personaje personaje{get;set;}
}

namespace Json{
    public class PersonajesJson{
        string json = "personajes.json";

        //Root datosJson = JsonSerializer.Deserialize<Root>(json);
    }

}