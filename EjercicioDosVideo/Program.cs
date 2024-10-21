namespace EjercicioDosVideo
{
    class Program
    {
        private static List<(double monto, string descripcionPrincipal, string descripcionAdicional)> transacciones = new List<(double, string, string)>();
        private static double saldo = 0.0;

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
                            ConsultarSaldo();
                            break;
                        case 2:
                            DepositarDinero();
                            break;
                        case 3:
                            RetirarDinero();
                            break;
                        case 4:
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

            } while (opcion != 4);
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\n=== Menú de Cuenta Bancaria ===");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");
        }

        private static void ConsultarSaldo()
        {
            Console.WriteLine($"\n--- Saldo Actual: C${saldo} ---");
            Console.WriteLine("\n--- Historial de transacciones ---");
            if (transacciones.Count > 0)
            {
                foreach (var (monto, descripcionPrincipal, descripcionAdicional) in transacciones)
                {
                    Console.WriteLine($"{descripcionPrincipal}: C${monto} | Descripción adicional: {descripcionAdicional}");
                }
            }
            else
            {
                Console.WriteLine("No hay transacciones registradas.");
            }
        }

        private static void DepositarDinero()
        {
            Console.WriteLine("\n--- Depositar Dinero ---");
            Console.Write("Monto a depositar: ");
            double monto = double.Parse(Console.ReadLine());

            Console.Write("Descripción adicional del depósito: ");
            string descripcionAdicional = Console.ReadLine();

            if (monto > 0)
            {
                saldo += monto;
                transacciones.Add((monto, "Depósito", descripcionAdicional));
                Console.WriteLine($"Has depositado C${monto}. Saldo actual: C${saldo}");
            }
            else
            {
                Console.WriteLine("El monto debe ser mayor a 0.");
            }
        }

        private static void RetirarDinero()
        {
            Console.WriteLine("\n--- Retirar Dinero ---");
            Console.Write("Monto a retirar: ");
            double monto = double.Parse(Console.ReadLine());

            Console.Write("Descripción adicional del retiro: ");
            string descripcionAdicional = Console.ReadLine();

            if (monto > 0 && monto <= saldo)
            {
                saldo -= monto;
                transacciones.Add((-monto, "Retiro", descripcionAdicional));
                Console.WriteLine($"Has retirado C${monto}. Saldo actual: C${saldo}");
            }
            else if (monto > saldo)
            {
                Console.WriteLine("No tienes suficiente saldo para realizar este retiro.");
            }
            else
            {
                Console.WriteLine("El monto debe ser mayor a 0.");
            }
        }
    }
}