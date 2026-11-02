namespace Tarea31;

/// <summary>
/// Contrato común para poder manejar Pila, Cola simple y Cola circular
/// desde un mismo menú. Cada clase conserva además sus nombres propios
/// (Push/Pop o Enqueue/Dequeue).
/// </summary>
public interface IEstructura
{
    string Nombre { get; }
    bool Insertar(int valor);
    bool Retirar(out int valor);
    bool Consultar(out int valor);
    bool IsEmpty();
    bool IsFull();
    string Mostrar();
}
