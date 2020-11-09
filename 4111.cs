using System;
class ejercicio
{
    static void Main()
    {
        float [] numeros = new float [4];
       
        float media;
        
        Console.WriteLine("Introduzca 4 numeros");
        numeros [0] = Convert.ToInt32(Console.ReadLine());
        numeros [1] = Convert.ToInt32(Console.ReadLine());
        numeros [2] = Convert.ToInt32(Console.ReadLine());
        numeros [3] = Convert.ToInt32(Console.ReadLine());
        
        media = ((numeros[0]+numeros[1]+numeros[2]+numeros[3])/4);
        
        Console.WriteLine("La media es {0} los numeros introducidos son: {1}, {2}, {3} y {4}.", 
        media.ToString("N2"), numeros[0], numeros[1], numeros[2], numeros[3]);
    }
}

        
        
        
        
    
