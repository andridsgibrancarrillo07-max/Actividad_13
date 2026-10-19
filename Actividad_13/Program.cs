using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("SISTEMA DE CONTROL DE MOTORES");
        Console.WriteLine();

        // 1. MOTOR CD
        Console.WriteLine("--- MOTOR DC ---");
        MotorCD motorCD1 = new MotorCD();
        Console.Write("Ingrese el identificador del motor: ");
        motorCD1.Identificador = Console.ReadLine() ?? "Sin identificador";
        Console.Write("Ingrese la temperatura del motor: ");
        motorCD1.Temperatura = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese la corriente del motor: ");
        motorCD1.Corriente = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese la velocidad del motor en rpm: ");
        motorCD1.Velocidad = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese el voltaje del motor: ");
        motorCD1.Voltaje = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("DATOS DEL MOTOR DC");
        Console.WriteLine($"Motor: {motorCD1.Identificador}");
        Console.WriteLine($"Temperatura: {motorCD1.Temperatura} °C");
        Console.WriteLine($"Corriente: {motorCD1.Corriente} A");
        Console.WriteLine($"Velocidad: {motorCD1.Velocidad} rpm");
        Console.WriteLine($"Voltaje: {motorCD1.Voltaje} V");
        Console.WriteLine($"Estado: {motorCD1.ObtenerEstado()}");
        Console.WriteLine($"Revisión de temperatura: {motorCD1.RevisarTemperatura()}");
        Console.WriteLine();

        // 2. MOTOR AC 
        Console.WriteLine("--- MOTOR AC ---");
        MotorAC motorAC1 = new MotorAC();
        Console.Write("Ingrese el identificador del motor: ");
        motorAC1.Identificador = Console.ReadLine() ?? "Sin identificador";
        Console.Write("Ingrese la temperatura del motor: ");
        motorAC1.Temperatura = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese la corriente del motor: ");
        motorAC1.Corriente = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese la velocidad del motor en rpm: ");
        motorAC1.Velocidad = Convert.ToDouble(Console.ReadLine());

        // MODIFICACIÓN DE FASE CON NÚMEROS
        Console.Write("Ingrese el tipo de fase del motor (1 = Monofásico, 2 = Trifásico, 3 = Bifásico): ");
        string opcionFase = Console.ReadLine() ?? "1";

        switch (opcionFase)
        {
            case "2":
                motorAC1.Fase = "Trifásico";
                break;
            case "3":
                motorAC1.Fase = "Bifásico";
                break;
            case "1":
            default: // Por defecto será Monofásico si ingresan un valor inválido
                motorAC1.Fase = "Monofásico";
                break;
        }

        Console.WriteLine();
        Console.WriteLine("DATOS DEL MOTOR AC");
        Console.WriteLine($"Motor: {motorAC1.Identificador}");
        Console.WriteLine($"Temperatura: {motorAC1.Temperatura} °C");
        Console.WriteLine($"Corriente: {motorAC1.Corriente} A");
        Console.WriteLine($"Velocidad: {motorAC1.Velocidad} rpm");
        Console.WriteLine($"Fase: {motorAC1.Fase}");
        Console.WriteLine($"Estado: {motorAC1.ObtenerEstado()}");
        Console.WriteLine($"Revisión de temperatura: {motorAC1.RevisarTemperatura()}");
        Console.WriteLine();

        // 3. SERVOMOTOR 
        Console.WriteLine("--- SERVOMOTOR ---");
        Servomotor servo1 = new Servomotor();
        Console.Write("Ingrese el identificador del motor: ");
        servo1.Identificador = Console.ReadLine() ?? "Sin identificador";
        Console.Write("Ingrese la temperatura del motor: ");
        servo1.Temperatura = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese la corriente del motor: ");
        servo1.Corriente = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese la velocidad del motor en rpm: ");
        servo1.Velocidad = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese el ángulo de posición en grados: ");
        servo1.Angulo = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("DATOS DEL SERVOMOTOR");
        Console.WriteLine($"Motor: {servo1.Identificador}");
        Console.WriteLine($"Temperatura: {servo1.Temperatura} °C");
        Console.WriteLine($"Corriente: {servo1.Corriente} A");
        Console.WriteLine($"Velocidad: {servo1.Velocidad} rpm");
        Console.WriteLine($"Ángulo: {servo1.Angulo} °");
        Console.WriteLine($"Estado: {servo1.ObtenerEstado()}");
        Console.WriteLine($"Revisión de temperatura: {servo1.RevisarTemperatura()}");
    }
}

// CLASE BASE
class Motor
{
    // Propiedades comunes
    public string Identificador { get; set; } = "";
    public double Temperatura { get; set; }
    public double Corriente { get; set; }
    public double Velocidad { get; set; }

    // Método para determinar el estado
    public string ObtenerEstado()
    {
        if (Velocidad > 0)
            return "Motor en marcha";
        else
            return "Motor detenido";
    }

    // Método para revisar la temperatura
    public string RevisarTemperatura()
    {
        if (Temperatura > 70)
            return "ALERTA: Temperatura elevada";

        return "Temperatura normal";
    }
}

// CLASES DERIVADAS
class MotorCD : Motor
{
    public double Voltaje { get; set; }
}

class MotorAC : Motor
{
    public string Fase { get; set; } = "";
}

class Servomotor : Motor
{
    public double Angulo { get; set; }
}