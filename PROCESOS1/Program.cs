using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Mostrar procesos en ejecución");
            Console.WriteLine("2. Iniciar un nuevo proceso");
            Console.WriteLine("3. Finalizar un proceso");
            Console.WriteLine("4. Salir");
            Console.Write("Elija una opción: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowRunningProcesses();
                    break;
                case "2":
                    StartNewProcess();
                    break;
                case "3":
                    KillProcess();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }
        }
    }

    static void ShowRunningProcesses()
    {
        var runningProcesses = Process.GetProcesses();

        foreach (var process in runningProcesses)
        {
            Console.WriteLine($"ID: {process.Id}, Nombre: {process.ProcessName}");
        }
    }

    static void StartNewProcess()
    {
        Console.Write("Ingrese el nombre del proceso para iniciar (ej. notepad): ");
        string processName = Console.ReadLine();

        try
        {
            Process.Start(processName);
            Console.WriteLine($"Proceso {processName} iniciado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al iniciar el proceso: {ex.Message}");
        }
    }

    static void KillProcess()
    {
        Console.Write("Ingrese el ID del proceso para finalizar: ");
        string processId = Console.ReadLine();

        try
        {
            var process = Process.GetProcesses().FirstOrDefault(p => p.Id == int.Parse(processId));
            process?.Kill();
            Console.WriteLine($"Proceso con ID {processId} finalizado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al finalizar el proceso: {ex.Message}");
        }
    }
}