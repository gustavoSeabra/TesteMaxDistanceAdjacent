using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxDistanceAdjacent
{
    class Program
    {
        private
        static void Main(string[] args)
        {
            string opcao = string.Empty;
            var mat = new List<int>();
            int index1 = 0;
            int index2 = 0;

            Console.WriteLine("Calculate Adjacent Max Distance");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Enter 1 to inform the matrix or 2 to use the existing model?");
            opcao = Console.ReadLine();

            while(opcao != "2")
            {
                if (opcao == "1")
                {
                    ExecutarOpcao1(ref mat);
                }
                else
                {
                    Console.WriteLine(string.Empty);
                    Console.WriteLine("Invalid option");
                    Console.WriteLine(string.Empty);
                    System.Threading.Thread.Sleep(4000);
                    Console.Clear();
                    Console.WriteLine("Enter 1 to inform the matrix or 2 to use the existing model?");
                    opcao = Console.ReadLine();
                }
            }

            if (opcao == "2")
            {
                Console.WriteLine("The example matrix will be:  0 | 3 | 3 | 12 | 5 | 3 | 7 | 1");
                
                // Matriz Exemplo 2:
                mat.Add(0);
                mat.Add(3);
                mat.Add(3);
                mat.Add(12);
                mat.Add(5);
                mat.Add(3);
                mat.Add(7);
                mat.Add(1);
            }

            do
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Enter the first index:");
                opcao = Console.ReadLine();
                int.TryParse(opcao, out index1);

                if (index1 <= 0 || index1 > mat.Count())
                {
                    Console.WriteLine("Invalid option");
                    Console.WriteLine(string.Empty);
                }
            } while (index1 <= 0 || index1 > mat.Count());

            do
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Enter the second index:");
                opcao = Console.ReadLine();
                int.TryParse(opcao, out index2);

                if (index2 <= 0 || index2 > mat.Count())
                {
                    Console.WriteLine("Invalid option");
                    Console.WriteLine(string.Empty);
                }
            } while (index2 <= 0 || index2 > mat.Count());


            var distancia = new AdjacentMaxDistance();

            Console.WriteLine($"The maximum distance between the indexes are: { distancia.Solucao(mat, index1 - 1, index2 - 1) }");
        }

        private static void ExecutarOpcao1(ref List<int> mat)
        {
            var valor = -1;
            var novoItem = string.Empty;

            do
            {
                Console.WriteLine("Enter an element for the matrix: ");
                
                if(int.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < int.MinValue || valor > int.MaxValue)
                    {
                        Console.WriteLine("Invalid array value");
                        Console.WriteLine(string.Empty);
                        novoItem = "S";
                    }
                    else
                    {
                        mat.Add(valor);
                        do
                        {
                            Console.WriteLine(string.Empty);
                            Console.WriteLine("Do you want to add one more element? ('S' or 'N')");
                            novoItem = Console.ReadLine();

                            if (novoItem != "s" || novoItem != "S" || novoItem != "n" || novoItem != "N")
                            {
                                Console.WriteLine(string.Empty);
                                Console.WriteLine("Invalid option. Enter 'S' or 'N'");
                            }
                        }
                        while (novoItem == "s" || novoItem == "S" || novoItem == "n" || novoItem == "N");
                    }
                }                
                else
                {
                    Console.WriteLine("Invalid array value");
                    Console.WriteLine(string.Empty);
                    novoItem = "S";
                }

                if (mat.Count == 40000)
                    novoItem = "N";
            }
            while (novoItem == "s" || novoItem == "S");
        }
    }
}
