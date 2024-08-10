namespace GestionarProyecto {
    public class Gestionar{
        public void menuOpciones(){
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃    Seleccione una opcion     ┃");
            Console.Write("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0. ");
            Console.ResetColor();
            Console.Write("Iniciar el juego           ┃\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("1. ");
            Console.ResetColor();
            Console.Write("Ver Historial de ganadores ┃\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("2. ");
            Console.ResetColor();
            Console.Write("Salir                      ┃\n");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
        public void modoDeJuego(){
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃ Seleccione un modo de juego  ┃");
            Console.Write("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0. ");
            Console.ResetColor();
            Console.Write("Battle Royale              ┃\n┃");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("1. ");
            Console.ResetColor();
            Console.Write("Por equipos (5 vs 5)       ┃\n");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
    }
}