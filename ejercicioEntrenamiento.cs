using System;
class ejercicioEntrenamiento
{
	static int Main(String[]args)
	{
		
		if (args[0] == "triple")
		{
			if (args.Length < 2)
			{
				Console.WriteLine("Faltan parámetros");
				return 2;
			}
			else
			{
				int numero = Convert.ToInt32(args [1]);
				Console.WriteLine(Triplicar(numero));
				return 0;
			}
		}
		else if (args[0] == "maxmin")
		{
			 if (args.Length < 4)
			 {
				 
				 Console.WriteLine("Faltan parámetros");
				 return 2;
			 }
			 else
			 {
				 int maximo, minimo;
				 
				 int[]datos = new int [3];
				 
				 for (int i = 0; i < 3; i++)
					datos[i] = Convert.ToInt32(args[i + 1]);
				
				 GetMaxMin(datos, out maximo, out minimo);
				 Console.WriteLine("Maximo = {0} Minimo = {1}",
				  maximo, minimo);
				 return 0;
			 }
			 
		}
		else if (args[0] == "multi")
		{
			if (args.Length < 3)
			{
				
				Console.WriteLine("Faltan parámetros");
				return 2;
			}
			else
			{
				int factor1 = Convert.ToInt32(args[1]);
				int factor2 = Convert.ToInt32(args[2]);
				
				Console.WriteLine("{0} x {1} = {2}",
				  factor1, factor2, Multiplicar(factor1, factor2));
				return 0;
			}
		}
		else 
		{
			Console.WriteLine("Uso: triple / maxmin / multi");
			return 1;
		}
	}
	
	static int Triplicar(int numero) //ejercicio90
    {
        int resultado = numero * 3;
        return resultado;
    }
    
    public static void GetMaxMin(int[] numeros, out int maximo, out int minimo) //ejercicio 93
    {
        maximo = numeros[0];
        minimo = numeros[0];
        
        for(int i = 1; i < numeros.Length; i++)
        {
            if(numeros[i] > maximo)
            {
                maximo = numeros[i];
            }
        }
        for(int i = 1; i < numeros.Length; i++)
        {
            if(numeros[i] < minimo)
            {
                minimo = numeros[i];
            }
        }
    }
    
    static int Multiplicar(int num1, int num2) //ejercicio 96
    {
        int resultado = 0;

        for(int i = 0; i < num2; i++)
        {
            resultado += num1;
        }

        return resultado;
    }
}
    
