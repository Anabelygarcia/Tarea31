namespace Tarea31;

/// <summary>
/// Pila (LIFO) implementada con un arreglo estático de tamaño fijo.
/// Puntero de índice: _top (posición del último elemento; -1 = pila vacía).
/// No usa Stack&lt;T&gt;, List&lt;T&gt; ni ninguna otra colección nativa.
/// </summary>
public class Pila : IEstructura
{
    private readonly int[] _datos;   // memoria fija, se reserva una sola vez
    private int _top;                // índice del tope

    public string Nombre => "Pila";
    public int Capacidad => _datos.Length;

    public Pila(int capacidad = 5)
    {
        if (capacidad <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacidad), "La capacidad debe ser mayor que 0.");
        _datos = new int[capacidad];
        _top = -1;
    }

    public bool IsEmpty() => _top == -1;
    public bool IsFull() => _top == _datos.Length - 1;

    /// <summary>Inserta en el tope. Devuelve false si hay desbordamiento (overflow).</summary>
    public bool Push(int valor)
    {
        if (IsFull()) return false;
        _top++;
        _datos[_top] = valor;
        return true;
    }

    /// <summary>Retira el tope. Devuelve false si la pila está vacía (underflow).</summary>
    public bool Pop(out int valor)
    {
        if (IsEmpty()) { valor = 0; return false; }
        valor = _datos[_top];
        _top--;
        return true;
    }

    /// <summary>Consulta el tope sin retirarlo.</summary>
    public bool Peek(out int valor)
    {
        if (IsEmpty()) { valor = 0; return false; }
        valor = _datos[_top];
        return true;
    }

    public string Mostrar()
    {
        string s = "  Pila [base -> tope]: ";
        if (IsEmpty()) s += "(vacía)";
        for (int i = 0; i <= _top; i++) s += _datos[i] + " ";
        return s + $"| top={_top}";
    }

    bool IEstructura.Insertar(int valor) => Push(valor);
    bool IEstructura.Retirar(out int valor) => Pop(out valor);
    bool IEstructura.Consultar(out int valor) => Peek(out valor);
}
