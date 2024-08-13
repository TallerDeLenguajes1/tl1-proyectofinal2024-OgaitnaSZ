using Personajes;

namespace MensajesProyecto {
    public class Mensajes(){
        public static void mensajeBienvenida(){
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@" 
 __                               ___    __                      _     
|  |   ___ ___ ___ _ _ ___    ___|  _|  |  |   ___ ___ ___ ___ _| |___ 
|  |__| -_| .'| . | | | -_|  | . |  _|  |  |__| -_| . | -_|   | . |_ -|
|_____|___|__,|_  |___|___|  |___|_|    |_____|___|_  |___|_|_|___|___|
              |___|                               |___|                                                                     
                                                        BATTLE ROYALE");
            Console.ResetColor();
        }
        public static void menuOpciones(){
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃    Seleccione una opcion     ┃");
            Console.Write("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("1. ");
            Console.ResetColor();
            Console.Write("Jugar                      ┃\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("2. ");
            Console.ResetColor();
            Console.Write("Historial de Ganadores     ┃\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("3. ");
            Console.ResetColor();
            Console.Write("Salir del juego            ┃\n");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
        public static void modoDeJuego(){
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃ Seleccione un modo de juego  ┃");
            Console.Write("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("1. ");
            Console.ResetColor();
            Console.Write("Battle Royale              ┃\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("2. ");
            Console.ResetColor();
            Console.Write("Por equipos (5 vs 5)       ┃\n");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
        public static void historial(){
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("1. ");
            Console.ResetColor();
            Console.Write("Volver                     ┃\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("2. ");
            Console.ResetColor();
            Console.Write("Salir del juego            ┃\n");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
        public static void errorOpcion(){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Seleccione una opcion valida: ");
            Console.ResetColor();
        }
        public static void mensajeGanador(Personaje ganador, Personaje perdedor){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ganador.datos.Nombre+" es el vencedor! 👑");
            Console.ResetColor();
            Console.WriteLine(perdedor.datos.Nombre+" queda fuera");
        }
        public static void equipoGanador(string nombreEquipo){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"━━━━━━ Equipo {nombreEquipo} Ganador ━━━━━━");
            Console.ResetColor();
            Console.WriteLine("Los integrantes en pie del equipo son:");
        }
    }
}