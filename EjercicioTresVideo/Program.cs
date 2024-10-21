namespace TuplasListas
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Tuple<string, string>> diccionario = CrearDiccionario();

            Traducir(diccionario);
            Console.ReadKey();
        }

        public static List<Tuple<string, string>> CrearDiccionario() { 
            List<Tuple<string, string>> diccionario = new List<Tuple<string, string>>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Introduzca la palabra {i + 1} en ingles");
                string palabra1 = Console.ReadLine();
                Console.WriteLine($"Inroduzca la palabra {i + 1} en español");
                string palabra2 = Console.ReadLine();
                diccionario.Add(new Tuple<string, string>(palabra1, palabra2));
            }

            return diccionario;
        }

        public static void Traducir(List<Tuple<string, string>> diccionario)
        {
            Console.Write("Introduzca la palabra a traducir: ");
            string palabra = Console.ReadLine();

            bool encontrado = false;

            foreach (var duo in diccionario)
            {
                if (duo.Item1.Equals(palabra, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"La palabra traducida es: {duo.Item2}");
                    encontrado = true;
                    break; 
                }
                else if (duo.Item2.Equals(palabra, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"La palabra traducida es: {duo.Item1}");
                    encontrado = true;
                    break; 
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("La palabra no está en el diccionario.");
            }
        }
    }
}
