using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Recursividad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Factorial(8));
            //Console.WriteLine(factorialConFor(8));
            //Console.WriteLine(sumarArreglo([1, 2, 3, 4, 5, 6, 7], 7));
            //Console.WriteLine(Fibonacci(10));
            var rutainicial = Path.Combine("C:", "Carpetas");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            contarArchivos(rutainicial);
            stopwatch.Stop();
            Console.WriteLine($"Tiempo De Busqueda es: {stopwatch.ElapsedMilliseconds} ms");



            stopwatch.Restart();
            stopwatch.Start();
            archivosConExtencion(rutainicial, ".txt");
            stopwatch.Stop();
            Console.WriteLine($"Tiempo De Busqueda es: {stopwatch.ElapsedMilliseconds} ms");

        }

        static int Factorial(int numero)
        {
            {
                if (numero == 0)

                    return 1;

                return numero * Factorial(numero - 1);



            }

        }
        static int factorialConFor(int numero)
        {
            int resultado = 1;

            for (int i = 0; i < numero; i++)
                resultado = resultado * i;
            return resultado;


        }
        static int sumarArreglo(int[] arreglo, int indice)
        {
            //caso base
            if (indice < 0)
                return 0;
            //llamada recursiva
            return arreglo[indice - 1] + sumarArreglo(arreglo, indice - 1);
        }

        static int Fibonacci(int numero)
        {
            int a = 0, b = 1;
            for (int i = 2; i < numero; i++) ;
            int temp = a;
            a = b;
            b = temp + b;
            return a;


        }
        static void ExplorarCarpetas(string ruta)
        {
            try
            {
                string[] archivos = Directory.GetFiles(ruta);
                for (int i = 0; i < archivos.Length;i++)
                {
                    Console.WriteLine($"Archivo: {archivos[i]}"); 
                }
                string[] carpetas = Directory.GetDirectories(ruta);
                for (int i = 0;i < carpetas.Length;i++)
                {
                    Console.WriteLine($"Carpeta: {carpetas[i]}");

                }
            }
            catch ( UnauthorizedAccessException)
            {
                Console.WriteLine($"Acceso denegado a la carpeta{ruta}");
            }



        }

        static void archivosConExtencion(string ruta, string txt)
        {
            foreach (var archivo in Directory.GetFiles(ruta, $"{txt}"))
                Console.WriteLine($"el archivo es: {archivo}");

            foreach (var dir in Directory.GetDirectories(ruta))
                archivosConExtencion(dir, txt);
            Console.WriteLine($"La ruta es: {ruta}");
        }
        static int contarArchivos(string ruta)
        {
            int count = 0;

            foreach (var _ in Directory.GetFiles(ruta)) count++;
            foreach (var dir in Directory.GetDirectories(ruta))
            {
                count++;
                count += contarArchivos(dir);
            }

            return count;
        }
    }
}
