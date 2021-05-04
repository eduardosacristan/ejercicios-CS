/* Eduardo Sacristán Beltri
 * 
 * Debes crear una aplicación que permita llevar el control de una colección de 
 * música en formato MP3. De cada canción o similar (que será un objeto de la 
 * clase "Musica") querremos anotar el titulo (por ejemplo, "The bell"), el 
 * intérprete ("Mike Oldfield"), el nombre del fichero ("thebell.mp3"), la 
 * ubicación ("MikeOldfield/tubularBells"), el tamaño del fichero (en MB, quizá 
 * con decimales, como en "3,070"). Otros detalles que podrían ser 
 * interesantes, como la categoría, el álbum al que pertenece o la valoración 
 * personal, hemos decidido aplazarlos para una versión posterior 2.0.
 */

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

[Serializable]
class Musica
{
    protected string titulo;
    protected string interprete;
    protected string fichero;
    protected float tamanyo;
    
    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Interprete
    {
        get { return interprete; }
        set { interprete = value; }
    }

    public string Fichero
    {
        get { return fichero; }
        set { interprete = value; }
    }

    public float Tamanyo
    {
        get { return tamanyo; }
        set { tamanyo = value; }
    }

    public Musica (string titulo, string interprete, string fichero, 
         float tamanyo)
    {
        this.titulo = titulo;
        this.interprete = interprete;
        this.fichero = fichero;
        this.tamanyo = tamanyo;
    }
    public override string ToString()
    {
        return "Titulo: " + titulo + " - Intérprete: " + interprete + 
            " Nombre del fichero: " + fichero + "(" + tamanyo + " MB)";
    }

    public static void Guardar(string nombre, Musica objeto) 
    {
        IFormatter formatter = new BinaryFormatter(); 
        FileStream stream = new FileStream(nombre, FileMode.Create, 
            FileAccess.Write, FileShare.None); 
        formatter.Serialize(stream, objeto); 
        stream.Close();
    }

    public static Musica Cargar(string nombre) 
    { 
        Musica objeto; 
        IFormatter formatter = new BinaryFormatter(); 
        FileStream stream = new FileStream(nombre, FileMode.Open, 
            FileAccess.Read, FileShare.Read); 
        objeto = (Musica)formatter.Deserialize(stream); 
        stream.Close(); 
        return objeto; 
    }
}

//------------------------------------------------

[Serializable]
class Programa
{
    public void Run()
    {
        List<Musica> canciones = new List<Musica>();
        string opcion;
        
        do
        {
            Menu();
            opcion = Console.ReadLine();
            Opciones(opcion, canciones);
        }
        while (opcion != "0");
    }

    static void Opciones(string opcion, List<Musica> canciones)
    {
        switch (opcion)
        {
            case "1":
                string titulo = dameDatos("Indique el titulo de la cancion");
                string interprete = dameDatos("Indique el intérprete de la " +
                    "canción");
                string fichero = dameDatos("Indique el nombre del fichero");
                float tamanyo = Convert.ToSingle(dameDatos("Indique el tamaño" +
                    "del archivo"));
                canciones.Add(new Musica(titulo, interprete, fichero, tamanyo));
                break;

            case "2":
                bool encontrado = false;
                string texto = dameDatos("Indique el texto a buscar en título" +
                    "autor");
                foreach (Musica cancion in canciones)
                {
                    if (cancion.Titulo.Contains(texto) ||
                        cancion.Interprete.Contains(texto))
                    {
                        encontrado = true;
                        Console.WriteLine(cancion);
                    }
                }

                if (!encontrado)
                    Console.WriteLine("Texto no encontrado");
                break;

            case "3":
                Console.WriteLine("Indique el número de la canción de la " +
                    "siguiente lista:");
                for (int i = 0; i < canciones.Count; i++)
                {
                    Console.WriteLine(i + " - " + canciones[i].Titulo);
                }
                int seleccion = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ha seleccionado la siguiente cancion:");
                Console.WriteLine(canciones[seleccion - 1]);

                titulo = dameDatos("Nuevo título:");
                interprete = dameDatos("Nuevo intérprete:");
                fichero = dameDatos("Nuevo fichero:");
                tamanyo = Convert.ToSingle(dameDatos("Nuevo tamanyo:"));

                canciones[seleccion - 1].Titulo = titulo;
                canciones[seleccion - 1].Interprete = interprete;
                canciones[seleccion - 1].Fichero = fichero;
                canciones[seleccion - 1].Tamanyo = tamanyo;
                break;

            case "4":
                Console.WriteLine("Seleccione una canción para borrar de" +
                    "la siguiente lista");
                for (int i = 0; i < canciones.Count; i++)
                {
                    Console.WriteLine((i + 1) + " - " + canciones[i].Titulo);
                }
                seleccion = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Va a eliminar la siguiente canción. ¿Seguro? s/n");
                Console.WriteLine(canciones[seleccion - 1]);
                string seguro = Console.ReadLine();

                if (seguro == "si")
                {
                    canciones.RemoveAt(seleccion - 1);
                }
                break;
            case "5":

                Musica joker;

                for (int i = 0; i < canciones.Count - 1; i++)
                {
                    for (int j = i + 1; j < canciones.Count; j++)
                    {
                        if (canciones[i].Titulo.CompareTo(canciones[j].Titulo) < 1)
                        {
                            joker = canciones[i];
                            canciones[i] = canciones[j];
                            canciones[j] = joker;
                        }

                    }
                }
                Console.WriteLine("Lista de canciones ordenada alfabéticamente" +
                    "por titulo");
                break;

            case "6":
                for (int i = 0; i < canciones.Count - 1; i++)
                {
                    for (int j = i + 1; j < canciones.Count; j++)
                    {
                        if (canciones[i].Interprete.
                            CompareTo(canciones[j].Interprete) < 0)
                        {
                            joker = canciones[i];
                            canciones[i] = canciones[j];
                            canciones[j] = joker;
                        }
                    }
                }
                Console.WriteLine("Canciones ordenadas por autor");
                break;

            case "0":
                
                Console.WriteLine("adeuuu");
                break;
            default:
                break;

        }
    }

    static string modificaDato(string texto)
    {
        string dato;
        Console.WriteLine(texto);
        dato = Console.ReadLine();
        return dato;
    }

    static string dameDatos(string texto)
    {
        string dato;
        bool correcto = true; ;
        Console.WriteLine(texto);
        do
        {
            dato = Console.ReadLine();
            if (dato == "")
                correcto = false;
        }
        while (!correcto);
        return dato;
    }

    static void Menu()
    {
        Console.WriteLine("1 - Añadir una nueva canción");
        Console.WriteLine("2 - Buscar canciones por texto");
        Console.WriteLine("3 - Modificar los datos de una canción");
        Console.WriteLine("4 - Eliminar una canción");
        Console.WriteLine("5 - Ordenar alfabéticamente por título");
        Console.WriteLine("6 - Ordenar alfebéticamente por autor");
        Console.WriteLine("0 - Salir");
    }

    public static void Guardar(string nombre, Programa objeto)
    {
        IFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(nombre, FileMode.Create,
            FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, objeto);
        stream.Close();
    }

    public static Programa Cargar(string nombre)
    {
        Programa objeto;
        IFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(nombre, FileMode.Open,
            FileAccess.Read, FileShare.Read);
        objeto = (Programa)formatter.Deserialize(stream);
        stream.Close();
        return objeto;
    }
}

//---------------------------------------------------------------


class Principal
{
    static void Main()
    {
        if(File.Exists("datos.dat"))
        {
            Programa miMusica = Programa.Cargar("datos.dat");
            miMusica.Run();
            Programa.Guardar("datos.dat", miMusica);
        }
        else
        {
            Programa miMusica = new Programa();
            miMusica.Run();
            Programa.Guardar("datos.dat", miMusica);
        }
        
    }

}

