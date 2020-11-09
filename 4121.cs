using System;
class ejercicio
{
    static void Main()
    {
        int mes;
        int[] meses = {31,28,31,30,31,30,31,31,30,31,30,31};
        Console.WriteLine("Indique un numero de mes");
        mes = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("{0} dias",meses[mes]);
    }
}
        
        
       
