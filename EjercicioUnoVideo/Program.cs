namespace EjercicioUnoVideo

{
    struct Articulo
    {
        public int Id;
        public string Nombre;
        public int Stock;
        public decimal Costo;

        public Articulo(int id, string nombre, int stock, decimal costo)
        {
            Id = id;
            Nombre = nombre;
            Stock = stock;
            Costo = costo;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id} | Nombre: {Nombre} | Stock: {Stock} | Costo: C${Costo}");
        }
    }

    class Program
    {
        private static List<Articulo> articulos = new List<Articulo>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                MostrarMenu();

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.Clear();
                    switch (opcion)
                    {
                        case 1:
                            AñadirArticulo();
                            break;
                        case 2:
                            BorrarArticulo();
                            break;
                        case 3:
                            ActualizarArticulo();
                            break;
                        case 4:
                            BuscarArticulo();
                            break;
                        case 5:
                            MostrarInventario();
                            break;
                        case 6:
                            Console.WriteLine("Saliendo del sistema... ¡Adiós!");
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta. Inténtalo de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa una opción válida.");
                }

            } while (opcion != 6);

        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\n=== Menú de Gestión de Inventario ===");
            Console.WriteLine("1. Añadir un nuevo artículo");
            Console.WriteLine("2. Eliminar un artículo");
            Console.WriteLine("3. Actualizar un artículo");
            Console.WriteLine("4. Buscar un artículo");
            Console.WriteLine("5. Listar todos los artículos");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");
        }

        private static void AñadirArticulo()
        {
            Console.WriteLine("\n--- Añadir Nuevo Artículo ---");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Costo: ");
            decimal costo = decimal.Parse(Console.ReadLine());

            articulos.Add(new Articulo(id, nombre, stock, costo));
            Console.WriteLine("Artículo añadido con éxito.");
        }

        private static void BorrarArticulo()
        {
            Console.WriteLine("\n--- Eliminar Artículo ---");
            Console.Write("Introduce el ID del artículo a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            int eliminados = articulos.RemoveAll(a => a.Id == id);

            if (eliminados > 0)
            {
                Console.WriteLine("Artículo eliminado.");
            }
            else
            {
                Console.WriteLine("Artículo no encontrado.");
            }
        }

        private static void ActualizarArticulo()
        {
            Console.WriteLine("\n--- Actualizar Artículo ---");
            Console.Write("Introduce el ID del artículo a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            int index = articulos.FindIndex(a => a.Id == id);

            if (index != -1)
            {
                var articulo = articulos[index];

                Console.Write("Nuevo Nombre (dejar vacío para no cambiar): ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    articulo.Nombre = nuevoNombre;
                }

                Console.Write("Nuevo stock (dejar vacío para no cambiar): ");
                string nuevoStockStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoStockStr))
                {
                    articulo.Stock = int.Parse(nuevoStockStr);
                }

                Console.Write("Nuevo costo (dejar vacío para no cambiar): ");
                string nuevoCostoStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoCostoStr))
                {
                    articulo.Costo = decimal.Parse(nuevoCostoStr);
                }

                articulos[index] = articulo; 
                Console.WriteLine("Artículo actualizado.");
            }
            else
            {
                Console.WriteLine("Artículo no encontrado.");
            }
        }

        private static void BuscarArticulo()
        {
            Console.WriteLine("\n--- Buscar Artículo ---");
            Console.Write("Introduce el ID del artículo a consultar: ");
            int id = int.Parse(Console.ReadLine());

            int index = articulos.FindIndex(a => a.Id == id);

            if (index != -1)
            {
                Console.WriteLine("\n--- Información del Artículo ---");
                articulos[index].MostrarInformacion();
            }
            else
            {
                Console.WriteLine("Artículo no encontrado.");
            }
        }

        private static void MostrarInventario()
        {
            Console.WriteLine("\n--- Inventario de la Tienda ---");
            if (articulos.Count > 0)
            {
                foreach (var articulo in articulos)
                {
                    articulo.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("No hay artículos en el inventario.");
            }
        }
    }
}
