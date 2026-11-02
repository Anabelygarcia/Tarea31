namespace Tarea31;

/// <summary>
/// Cola circular (FIFO) con arreglo estático.
/// _front y _rear avanzan con aritmética modular (índice + 1) % capacidad.
/// _cantidad distingue una cola llena de una vacía.
/// Los espacios liberados SÍ se reutilizan.
/// </summary>
public class ColaCircular : IEstructura
{
    private readonly int[] _datos;
    private int _front;      // índice del primer elemento
    private int _rear;       // índice de la siguiente posición libre
    private int _cantidad;   // elementos almacenados

    public string Nombre => "Cola circular";
    public int Capacidad => _datos.Length;

    public ColaCircular(int capacidad = 5)
    {
        if (capacidad <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacidad), "La capacidad debe ser mayor que 0.");
        _datos = new int[capacidad];
        _front = 0;
        _rear = 0;
        _cantidad = 0;
    }

    public bool IsEmpty() => _cantidad == 0;
    public bool IsFull() => _cantidad == _datos.Length;

    public bool Enqueue(int valor)
    {
        if (IsFull()) return false;
        _datos[_rear] = valor;
        _rear = (_rear + 1) % _datos.Length;
        _cantidad++;
        return true;
    }

    public bool Dequeue(out int valor)
    {
        if (IsEmpty()) { valor = 0; return false; }
        valor = _datos[_front];
        _front = (_front + 1) % _datos.Length;
        _cantidad--;
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
        string s = "  Cola circular [front -> rear]: ";
        if (IsEmpty()) s += "(vacía)";
        int idx = _front;
        for (int i = 0; i < _cantidad; i++)
        {
            s += _datos[idx] + " ";
            idx = (idx + 1) % _datos.Length;
        }
        return s + $"| front={_front} rear={_rear} cantidad={_cantidad}";
    }

    bool IEstructura.Insertar(int valor) => Enqueue(valor);
    bool IEstructura.Retirar(out int valor) => Dequeue(out valor);
    bool IEstructura.Consultar(out int valor) => Peek(out valor);
}
