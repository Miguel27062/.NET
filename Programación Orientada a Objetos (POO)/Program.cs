using System;

public class Vehiculo
{

    public string Placa { get; private set; }


    public Vehiculo(string placa)
    {
        Placa = placa;
    }


    public bool TieneRestriccionPicoYPlaca(DateTime fecha)
    {
 
        char ultimoDigito = Placa[Placa.Length - 1];

  
        DayOfWeek diaSemana = fecha.DayOfWeek;

    
        if (diaSemana == DayOfWeek.Saturday || diaSemana == DayOfWeek.Sunday)
        {
            return false; 
        }

      
        int diaRestriccion = 0;

        switch (diaSemana)
        {
            case DayOfWeek.Monday:
                diaRestriccion = 1; // 1 y 2
                break;
            case DayOfWeek.Tuesday:
                diaRestriccion = 2; // 3 y 4
                break;
            case DayOfWeek.Wednesday:
                diaRestriccion = 3; // 5 y 6
                break;
            case DayOfWeek.Thursday:
                diaRestriccion = 4; // 7 y 8
                break;
            case DayOfWeek.Friday:
                diaRestriccion = 5; // 9 y 0
                break;
        }

       
        return ultimoDigito == (char)(diaRestriccion + '0') ||
               ultimoDigito == (char)((diaRestriccion + 1) + '0');
    }
}


public class Program
{
    public static void Main()
    {
       
        Vehiculo miVehiculo = new Vehiculo("ABC123");

      
        DateTime hoy = DateTime.Now;
        bool tieneRestriccion = miVehiculo.TieneRestriccionPicoYPlaca(hoy);

        Console.WriteLine($"El vehículo con placa {miVehiculo.Placa} tiene restricción por pico y placa: {tieneRestriccion}");
    }
}
