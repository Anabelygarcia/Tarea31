using System.Text;

namespace Tarea31;

internal static class Program
{
    private const int Capacidad = 5;

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Una instancia de cada estructura, todas con memoria estática de 5 posiciones.
        IEstructura[] estructuras =
        {
            new Pila(Capacidad),
            new ColaSimple(Capacidad),
            new ColaCircular(Capacidad)
        };

        int opcion;
        do
        {
            Console.WriteLine();
            Console.WriteLine($"===== ESTRUCTURAS ESTÁTICAS (capacidad {Capacidad}) =====");
            Console.WriteLine("1) Pila");
            Console.WriteLine("2) Cola simple");
            Console.WriteLine("3) Cola circular");
            Console.WriteLine("4) Ejecutar pruebas automáticas (las 3 estructuras)");
            Console.WriteLine("0) Salir");
            opcion = LeerEntero("Elige: ");

            if (opcion >= 1 && opcion <= 3)
                SubMenu(estructuras[opcion - 1]);
            else if (opcion == 4)
                PruebasAutomaticas();
        } while (opcion != 0);

        Console.WriteLine("Fin del programa.");
    }

    // ---------------------------------------------------------------- menú interactivo
    private static void SubMenu(IEstructura e)
    {
        bool esPila = e is Pila;
        int op;
        do
        {
            Console.WriteLine();
            Console.WriteLine($"--- {e.Nombre.ToUpper()} ---");
            Console.WriteLine($"1) {(esPila ? "Push" : "Enqueue")}");
            Console.WriteLine($"2) {(esPila ? "Pop" : "Dequeue")}");
            Console.WriteLine("3) Peek");
            Console.WriteLine("4) isEmpty");
            Console.WriteLine("5) isFull");
            Console.WriteLine("6) Mostrar");
            Console.WriteLine("0) Volver");
            op = LeerEntero("Opción: ");

            switch (op)
            {
                case 1:
                    int v = LeerEntero("Valor: ");
                    Console.WriteLine(e.Insertar(v) ? "  OK" : "  ERROR: estructura llena (overflow)");
                    break;
                case 2:
                    if (e.Retirar(out int r)) Console.WriteLine($"  Elemento retirado: {r}");
                    else Console.WriteLine("  ERROR: estructura vacía (underflow)");
                    break;
                case 3:
                    if (e.Consultar(out int c)) Console.WriteLine($"  Elemento al frente/tope: {c}");
                    else Console.WriteLine("  La estructura está vacía");
                    break;
                case 4:
                    Console.WriteLine($"  isEmpty: {e.IsEmpty().ToString().ToLower()}");
                    break;
                case 5:
                    Console.WriteLine($"  isFull: {e.IsFull().ToString().ToLower()}");
                    break;
                case 6:
                    Console.WriteLine(e.Mostrar());
                    break;
            }
        } while (op != 0);
    }

    private static int LeerEntero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? texto = Console.ReadLine();
            if (texto == null) return 0;               // fin de entrada: salir
            if (int.TryParse(texto, out int valor)) return valor;
            Console.WriteLine("Entrada inválida, escribe un número entero.");
        }
    }

    // ---------------------------------------------------------------- pruebas automáticas
    private static void PruebasAutomaticas()
    {
        PruebaPila();
        PruebaColaSimple();
        PruebaColaCircular();
    }

    private static void PruebaPila()
    {
        var p = new Pila(Capacidad);
        Console.WriteLine($"\n=== PRUEBAS DE PILA (capacidad {Capacidad}) ===");
        Console.WriteLine($"1) isEmpty al inicio: {p.IsEmpty().ToString().ToLower()}");
        Console.WriteLine("2) Push de 10,20,30,40,50:");
        for (int i = 1; i <= 5; i++) { p.Push(i * 10); Console.WriteLine(p.Mostrar()); }
        Console.WriteLine($"3) isFull: {p.IsFull().ToString().ToLower()}");
        Console.WriteLine("4) Push(60) con pila llena: " + (p.Push(60) ? "ok" : "ERROR: desbordamiento (overflow)"));
        p.Peek(out int v);
        Console.WriteLine($"5) Peek: {v} (no se elimina)");
        Console.WriteLine(p.Mostrar());
        Console.WriteLine("6) Pop hasta vaciar:");
        while (p.Pop(out v)) { Console.WriteLine($"  Pop -> {v}"); Console.WriteLine(p.Mostrar()); }
        Console.WriteLine("7) Pop con pila vacía: " + (p.Pop(out v) ? "ok" : "ERROR: subdesbordamiento (underflow)"));
        Console.WriteLine($"8) isEmpty al final: {p.IsEmpty().ToString().ToLower()}");
    }

    private static void PruebaColaSimple()
    {
        var c = new ColaSimple(Capacidad);
        Console.WriteLine($"\n=== PRUEBAS DE COLA SIMPLE (capacidad {Capacidad}) ===");
        Console.WriteLine("1) Enqueue de 10,20,30,40,50:");
        for (int i = 1; i <= 5; i++) { c.Enqueue(i * 10); Console.WriteLine(c.Mostrar()); }
        Console.WriteLine("2) Enqueue(60) con cola llena: " + (c.Enqueue(60) ? "ok" : "ERROR: cola llena"));
        Console.WriteLine("3) Dequeue x3:");
        int v;
        for (int i = 0; i < 3; i++) { c.Dequeue(out v); Console.WriteLine($"  Dequeue -> {v}"); Console.WriteLine(c.Mostrar()); }
        Console.WriteLine("4) Hay 3 espacios libres al frente, pero Enqueue(70): " +
            (c.Enqueue(70) ? "ok" : "ERROR: cola 'llena' (rear=4). Limitación de la cola simple"));
        Console.WriteLine("5) Vaciar la cola:");
        while (c.Dequeue(out v)) Console.WriteLine($"  Dequeue -> {v}");
        Console.WriteLine(c.Mostrar());
        Console.WriteLine("6) Dequeue con cola vacía: " + (c.Dequeue(out v) ? "ok" : "ERROR: cola vacía"));
    }

    private static void PruebaColaCircular()
    {
        var c = new ColaCircular(Capacidad);
        Console.WriteLine($"\n=== PRUEBAS DE COLA CIRCULAR (capacidad {Capacidad}) ===");
        Console.WriteLine("1) Enqueue de 10,20,30,40,50:");
        for (int i = 1; i <= 5; i++) { c.Enqueue(i * 10); Console.WriteLine(c.Mostrar()); }
        Console.WriteLine($"2) isFull: {c.IsFull().ToString().ToLower()} | Enqueue(60): " + (c.Enqueue(60) ? "ok" : "ERROR: cola llena"));
        Console.WriteLine("3) Dequeue x3:");
        int v;
        for (int i = 0; i < 3; i++) { c.Dequeue(out v); Console.WriteLine($"  Dequeue -> {v}"); Console.WriteLine(c.Mostrar()); }
        Console.WriteLine("4) Reutilización de espacios: Enqueue(70) y Enqueue(80) (rear da la vuelta):");
        c.Enqueue(70); Console.WriteLine(c.Mostrar());
        c.Enqueue(80); Console.WriteLine(c.Mostrar());
        c.Peek(out v);
        Console.WriteLine($"5) Peek: {v}");
        Console.WriteLine("6) Vaciar la cola:");
        while (c.Dequeue(out v)) Console.WriteLine($"  Dequeue -> {v}");
        Console.WriteLine(c.Mostrar());
        Console.WriteLine("7) Dequeue con cola vacía: " + (c.Dequeue(out v) ? "ok" : "ERROR: cola vacía"));
    }
}
