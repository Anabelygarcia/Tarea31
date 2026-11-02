# Tarea 3.1 - Implementación estática de Pilas y Colas (C# / .NET 10)

Pila, Cola simple y Cola circular con arreglos estáticos (`int[]`) y punteros de índice
(`_top`, `_front`, `_rear`). No se usan `Stack<T>`, `Queue<T>`, `List<T>` ni otras colecciones nativas.

## Abrir en Visual Studio
1. Instala Visual Studio 2022 (17.14 o superior) o Visual Studio 2026 con el SDK de .NET 10.
2. Abre `Tarea31.sln`.
3. Presiona F5 (o Ctrl+F5) para ejecutar.

## Desde la terminal
    dotnet run --project Tarea31

## Archivos
- `Pila.cs`, `ColaSimple.cs`, `ColaCircular.cs`: las tres estructuras
- `IEstructura.cs`: contrato común para el menú
- `Program.cs`: menú interactivo y pruebas automáticas (opción 4)
