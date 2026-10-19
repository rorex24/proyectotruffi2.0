
using System;
namespace Program
{
    class Viaje
    {
        public string Destino;
        public string Transporte;
        public decimal Costo;

        public Viaje(string destino, string transporte, decimal costo)
        {
            Destino = destino;
            Transporte = transporte;
            Costo = costo;
        }
    }

    class RutaBs
    {
        decimal presupuesto;
        decimal saldo;

        List<Viaje> viajes = new List<Viaje>();
        List<string> destinos = new List<string>();
        List<string> favoritos = new List<string>();

        public void Iniciar()
        {
            Console.WriteLine("=== RUTABS ===");
            Console.WriteLine("Ingrese su presupuesto inicial en Bs:");
            presupuesto = LeerMonto();
            saldo = presupuesto;

            int opcion = 0;

            while (opcion != 7)
            {
                Console.WriteLine();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Consultar presupuesto");
                Console.WriteLine("2. Registrar viaje");
                Console.WriteLine("3. Ver historial");
                Console.WriteLine("4. Agregar destino");
                Console.WriteLine("5. Ver destinos");
                Console.WriteLine("6. Agregar transporte favorito");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opcion: ");

                opcion = LeerEntero();

                switch (opcion)
                {
                    case 1:
                        ConsultarPresupuesto();
                        break;
                    case 2:
                        RegistrarViaje();
                        break;
                    case 3:
                        MostrarHistorial();
                        break;
                    case 4:
                        AgregarDestino();
                        break;
                    case 5:
                        MostrarDestinos();
                        break;
                    case 6:
                        AgregarFavorito();
                        break;
                    case 7:
                        Console.WriteLine("Gracias por usar RutaBs.");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            }
        }

        string LeerTexto()
        {
            string texto = Console.ReadLine();

            while (texto == null || texto == "")
            {
                Console.WriteLine("El texto no puede estar vacio. Intente de nuevo:");
                texto = Console.ReadLine();
            }

            return texto.Trim();
        }

        int LeerEntero()
        {
            int numero; 
            Console.WriteLine("Ingrese un numero entero valido:");
           numero = int.Parse(Console.ReadLine());
            return numero;
        }

        

            decimal LeerMonto()
            {
                decimal monto;

                Console.WriteLine("Ingrese el monto:");
                monto = decimal.Parse(Console.ReadLine());

                return monto;
            }

     

        void ConsultarPresupuesto()
        {
            Console.WriteLine("Presupuesto inicial: " + presupuesto + " Bs");
            Console.WriteLine("Saldo disponible: " + saldo + " Bs");
            Console.WriteLine("Total gastado: " + (presupuesto - saldo) + " Bs");
        }

        void RegistrarViaje()
        {
            Console.WriteLine("Ingrese el destino:");
            string destino = LeerTexto();

            Console.WriteLine("Ingrese el transporte utilizado:");
            string transporte = LeerTexto();

            Console.WriteLine("Ingrese el costo del viaje en Bs:");
            decimal costo = LeerMonto();

            if (costo <= 0)
            {
                Console.WriteLine("El costo debe ser mayor que cero.");
                return;
            }

            if (costo > saldo)
            {
                Console.WriteLine("No tiene suficiente saldo.");
                return;
            }

            Viaje nuevoViaje = new Viaje(destino, transporte, costo);
            viajes.Add(nuevoViaje);
            saldo -=costo;

            Console.WriteLine("Viaje registrado correctamente.");
            Console.WriteLine("Saldo restante: " + saldo + " Bs");
        }

        void MostrarHistorial()
        {
            if (viajes.Count == 0)
            {
                Console.WriteLine("Todavia no hay viajes registrados.");
                return;
            }

            decimal totalGastado = 0;

            Console.WriteLine("=== HISTORIAL DE VIAJES ===");

            for (int i = 0; i < viajes.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Viaje " + (i + 1));
                Console.WriteLine("Destino: " + viajes[i].Destino);
                Console.WriteLine("Transporte: " + viajes[i].Transporte);
                Console.WriteLine("Costo: " + viajes[i].Costo + " Bs");
                totalGastado = totalGastado + viajes[i].Costo;
            }

            Console.WriteLine();
            Console.WriteLine("Total gastado: " + totalGastado+ " Bs");
        }

        void AgregarDestino()
        {
            Console.WriteLine("Ingrese el nombre del destino:");
            string destino = LeerTexto();
            destinos.Add(destino);
            Console.WriteLine("Destino agregado correctamente.");
        }

        void MostrarDestinos()
        {
            if (destinos.Count == 0)
            {
                Console.WriteLine("No hay destinos registrados.");
                return;
            }

            Console.WriteLine("=== DESTINOS REGISTRADOS ===");

            for (int i = 0; i < destinos.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + destinos[i]);
            }
        }

        void AgregarFavorito()
        {
            Console.WriteLine("Ingrese el nombre del transporte favorito:");
            string transporte = LeerTexto();
            favoritos.Add(transporte);

            Console.WriteLine("Transporte agregado a favoritos.");
            Console.WriteLine("=== TRANSPORTES FAVORITOS ===");

            for (int i = 0; i < favoritos.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + favoritos[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RutaBs aplicacion = new RutaBs();
            aplicacion.Iniciar();
        }
    }
}