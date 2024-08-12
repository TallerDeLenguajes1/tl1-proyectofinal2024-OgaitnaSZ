#League of Legends Battle Royale
El proyecto desarrollado es un juego de rol basado en el popular moba League of Legends creado por Riot Games.
Este proyecto incluye un sistema de combate por turnos y dos modos de juego principales Battle Royale y Por equipos.

##Descripción del proyecto
El juego inicia con un menú que ofrece tres opciones
-Jugar Permite al jugador iniciar una partida en uno de los modos de juego disponibles.
-Historial de ganadores Muestra un registro de las partidas anteriores, incluyendo los campeones que participaron y sus resultados.
-Salir del juego Cierra el juego.

##Modos de Juego
League of Legends Battle Royale ofrece dos modos de juego principales.

###Battle Royale (Todos contra todos):
El juego selecciona aleatoriamente a 10 campeones de League of Legends. Los campeones se enfrentan en combates uno contra uno, siguiendo un sistema de turnos en el que cada personaje realiza un ataque por turno. 
La batalla continúa hasta que uno de los campeones reduce la vida del otro a 0, eliminándolo del juego.  El proceso se repite hasta que solo queda un campeón en pie, quien es declarado Ganador.

Además, en el modo Battle Royale, los jugadores tienen la opción de apostar por uno de los campeones antes de que inicien los combates. 
Esta característica añade un elemento adicional de estrategia y emoción, ya que los jugadores deben intentar predecir cuál será el último campeón en pie.

###Modo Por Equipos (5 vs 5):
En el modo por equipos, los 10 campeones seleccionados se dividen aleatoriamente en dos equipos de 5. 
Los personajes que ocupan la misma posición en cada equipo se enfrentan entre sí. Hasta que un equipo elimine a todos los miembros del equipo contrario.

##Funcionamiento del Juego
###Selección de Campeones
El juego utiliza un algoritmo para seleccionar aleatoriamente a 10 campeones de una API de personajes de League of Legends. 
La selección es completamente aleatoria, lo que garantiza que cada partida sea única y ofrezca una experiencia de juego diferente.

###Sistema de Combate
El sistema de combate es por turnos, donde cada campeón tiene la oportunidad de realizar un ataque durante su turno. 
Los campeones atacan hasta que uno de los dos reduce la vida del otro a 0. El combate continúa hasta que se determina un ganador, que es el último campeón o equipo en pie.

###Apuestas en el Modo Battle Royale
Antes de iniciar los combates en el modo Battle Royale, los jugadores pueden apostar por un campeón. 
Esta apuesta es una decisión estratégica que puede incrementar la emoción del juego, ya que los jugadores se involucran aún más en el desarrollo de las batallas.

###Historial de Partidas
Una vez finalizada una partida, el o los campeones ganadores y los resultados se guardan en un historial. Este historial es accesible desde el menú principal y permite a los jugadores revisar el desempeño de los campeones ganadores en partidas anteriores.

##Probar el juego
>Aclaración Para probar el juego debes tener usar el sistema operativo Windows.
Si deseas probar el juego, aquí tienes una pequeña guía para probarlo:
###1. Instalar dependencias
-.NET 8.0 https://dotnet.microsoft.com/es-es/download
-Visual Studio Code https://code.visualstudio.com/download

###2. Descargar juego
Una vez descargadas las dependencias, descarga el juego comprimido en ZIP, a través de este enlace:
https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-OgaitnaSZ/archive/refs/heads/main.zip.
Luego descomprime la carpeta.

###3. Ejecución
Ejecuta Visual Studio Code, toca en **Archivo** y selecciona **Abrir Carpeta**. Luego selecciona la carpeta del proyecto.
Una vez seleccionada, toca en **Terminal** y selecciona **Nueva Terminal**.
En la terminal escribe `dotnet run` y espera a que cargue el juego para empezar a interactuar con el.

##Información técnica y recursos utilizados
###API de campeones de League of Legends
Los campeones aleatorios seleccionados en el proyecto, son cargados desde una API oficial de Riot Games.
En el proyecto se utiliza para obtener nombres y sus tipos.
API Utilizada https://ddragon.leagueoflegends.com/cdn/12.6.1/data/es_MX/champion.json
Portal para desarrolladores de RIOT https://developer.riotgames.com/docs/lol

###Documentacion Utilizada
-Catedra de Taller de Lenguajes (FACET - UNT) https://github.com/TallerDeLenguajes1
-Documentación oficial de C# https://learn.microsoft.com/es-es/dotnet/csharp

###Proximas actualizaciones
El proyecto esta aun en desarrollo, pero hay cambios planeados para la próxima versión
-**Resumen corto de campeones:** Próximamente se agregara un resumen corto de cada campeón al momento de presentarlos.
-**Nombres en equipos:** Se agregaran nombres aleatorios a los equipos, para una experiencia mas divertida.
-**Selección con teclado:** Las opciones podrán ser elegidas utilizando las flechas del teclado, para mejorar la experiencia de usuario.
-**Mejoras visuales:** Se implementaran mejoras en colores y diseño.
