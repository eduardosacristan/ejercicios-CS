/* Eduardo Sacristan Beltri
 * 
 * Crea un programa que muestre la información almacenada en un archivo MP3 
 * (que tenga una cabecera en formato "ID3 TAG V1"): título, artista, álbum, 
 * año. Deberás comprobar el contenido de los últimos 128 bytes del fichero. 
 * En caso de tratarse de un MP3 con cabecera en dicho formato, deberías 
 * encontrar:
 * 
 * - Los caracteres TAG (3 caracteres)
 * - Título: 30 caracteres.
 * - Artista: 30 caracteres.
 * - Álbum: 30 caracteres.
 * - Año: 4 caracteres.
 * - Un comentario: 30 caracteres.
 * - Género (musical): un byte.
 * 
 * Todas las etiquetas usan caracteres ASCII (terminados en caracteres nulos o 
 * quizá en espacios), excepto el género, que es un número entero almacenado en 
 * un único byte.
 */

using System;
using System.IO;

class ejercicio180
{
    static void Main()
    {
        string nombre;
        FileStream fichero;
        const byte TAMANYO_BUFFER = 128;

        Console.WriteLine("Indique el nombre del archivo MP3");
        nombre = Console.ReadLine();

        if (!File.Exists(nombre))
        {
            Console.WriteLine("Archivo no encontrado");
            return;
        }

        try
        {
            fichero = File.OpenRead(nombre);
            
            fichero.Seek(-TAMANYO_BUFFER, SeekOrigin.End);
            
            estosDatos("CARACTERES TAG: ", 3, fichero);
                                  
            estosDatos("TITULO: ", 30, fichero);

            estosDatos("ARTISTA: ", 30, fichero);

            estosDatos("ALBUM: ", 30, fichero);

            estosDatos("AÑO: ", 4, fichero);

            estosDatos("COMETARIOS: ", 30, fichero);

            estosDatos("GENERO: ", 1, fichero);

            fichero.Close();

            static void estosDatos(string texto, int max, FileStream fichero)
            {
                Console.WriteLine();
                Console.Write(texto);

                for (int i = 0; i < max; i++)
                {
                    int dato;
                    dato = fichero.ReadByte();
                    if (dato != ' ')
                        Console.Write((char)dato);
                }
            }
        }

        catch (PathTooLongException)
        {
            Console.WriteLine("Ruta de archivo demasiado larga");
        }

        catch (IOException)
        {
            Console.WriteLine("Error de lectura/escritura");
        }

        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
    }
}


