using System;
class ejercicio
{
    static void Main()
    {
        float [] numeros = new float [5];
        Console.WriteLine("Introduzca 5 numeros");
        
        numeros [0] = Convert.ToSingle(Console.ReadLine());
        numeros [1] = Convert.ToSingle(Console.ReadLine());
        numeros [2] = Convert.ToSingle(Console.ReadLine());
        numeros [3] = Convert.ToSingle(Console.ReadLine());
        numeros [4] = Convert.ToSingle(Console.ReadLine());
        
        for (int i = 4; i >= 0; i--)
        {
            Console.Write("{0},  ",numeros [i]);
        }
    }
}
 
