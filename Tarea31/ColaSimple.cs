namespace Tarea31;

/// <summary>
/// Cola lineal (FIFO) con arreglo estático.
/// Punteros de índice: _front (primer elemento) y _rear (último elemento).
/// Cola vacía: _front &gt; _rear.
/// Limitación: los espacios liberados al frente NO se reutilizan, por lo que
/// la cola puede marcarse "llena" aunque existan huecos libres.
/// </summary>
public class ColaSimple : IEstructura
{
    private readonly int[] _datos;
    private int _front;
    private int _rear;

    public string Nombre => "Cola simple";
    public int Capacidad => _datos.Length;

    public ColaSimple(int capacidad = 5)
    {
        if (capacidad <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacidad), "La capacidad debe ser mayor que 0.");
        _datos = new int[capacidad];
        _front = 0;
        _rear = -1;
    }

    public bool IsEmpty() => _front > _rear;
    public bool IsFull() => _rear == _datos.Length - 1;

    public bool Enqueue(int valor)
    {
        if (IsFull()) return false;
        _rear++;
        _datos[_rear] = valor;
        return true;
    }

    public bool Dequeue(out int valor)
    {
        if (IsEmpty()) { valor = 0; return false; }
        valor = _datos[_front];
        _front++;
        return true;
    }

    public bool Peek(out int valor)
    {
        if (IsEmpty()) { valor = 0; return false; }
        valor = _datos[_front];
        return true;
    }

    public string Mostrar()
    {
        string s = "  Cola [front -> rear]: ";
        if (IsEmpty()) s += "(vacía)";
        for (int i = _front; i <= _rear; i++) s += _datos[i] + " ";
        return s + $"| front={_front} rear={_rear}";
    }

    bool IEstructura.Insertar(int valor) => Enqueue(valor);
    bool IEstructura.Retirar(out int valor) => Dequeue(out valor);
    bool IEstructura.Consultar(out int valor) => Peek(out valor);
}
