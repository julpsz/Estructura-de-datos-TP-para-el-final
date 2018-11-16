using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace ConsoleApp10
{
    class Program
    {
        private static Queue cola;

        static void Main(string[] args)
        {
            int opc = 0;


            do
            {
                Console.WriteLine("MENU PRINCIPAL\n\n" +
                    "1. Crear Cola\n" +
                    "2. Borrar Cola\n" +
                    "3. Agregar Pedido\n" +
                    "4. Borrar Pedido\n" +
                    "5. Listar todos los Pedidos\n" +
                    "6. Listar ultimo Pedido\n" +
                    "7. Listar primer Pedido\n" +
                    "8. Cantidad total de Pedidos\n" +
                    "9. SALIR\n\n" +
                    "EXTRAS:\n" +
                    "10. Ordenar Pedidos en orden ascendente\n" +
                    "11. Ordenar Pedidos en orden descendente\n\n");


                Console.WriteLine("Ingrese Opcion: ");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Queue objeto;
                        objeto = Crear_cola();
                        cola = objeto;
                        Console.Clear();
                        Console.WriteLine("Cola creada con exito.\n\nPresione una tecla para continuar...\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        cola = borrar_cola(ref cola);
                        break;
                    case 3:
                        cola = agregar_pedido(ref cola);
                        break;
                    case 4:
                        cola = borrar_pedido(ref cola);
                        break;
                    case 5:
                        cola = listar_pedidos(ref cola);
                        break;
                    case 6:
                        cola = listar_ultimo(ref cola);
                        break;
                    case 7:
                        cola = listar_primer(ref cola);
                        break;
                    case 8:
                        cola = cantidad_total(ref cola);
                        break;
                    case 9:
                        break;
                    case 10:
                        cola = ordenar_pedidos(ref cola);
                        break;
                    case 11:
                        cola = descendente(ref cola);
                        break;
                }

            } while (opc != 9);



        }

        public static ref Queue borrar_pedido(ref Queue cola)
        {
            try
            {
                ArrayList lista = new ArrayList();
                int borrar, posicion;
                string sel;

                foreach (int dato in cola)  //Copio contenido de la cola en una lista
                {
                    lista.Add(dato);
                }


                cola.Clear();   //Borro la cola.

                Console.Clear();
                Console.WriteLine("Ingrese Pedido a borrar:\n");
                borrar = Convert.ToInt32(Console.ReadLine());   //Guardo el Pedido a borrar.
                posicion = lista.IndexOf(borrar);               //Obtengo la posicion del Pedido a borrar.
                if (posicion == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Pedido inexistente.");
                    Console.WriteLine("Presione una tecla para continuar...\n");
                    Console.ReadKey();
                    Console.Clear();
                    return ref cola;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Pedido encontrado en la posicion {0}. BORRAR ? (s/n):\n", posicion + 1);
                    sel = Convert.ToString(Console.ReadLine());
                    if (sel == "s")
                    {
                        lista.RemoveAt(posicion);                   //Borro el Pedido.

                        Console.Clear();
                        Console.WriteLine("Pedido borrado.\n");
                        Console.WriteLine("Presione una tecla para continuar...\n");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Pedido NO borrado.\n");
                        Console.WriteLine("Presione una tecla para continuar...\n");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    foreach (int copiar in lista)                   //Paso los datos de la lista actualizada a la COLA.
                        cola.Enqueue(copiar);


                    return ref cola;
                }
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return ref cola;
            }

        }


        public static Queue Crear_cola()
        {
            Queue cola = new Queue();
            return cola;
        }

        public static Queue borrar_cola(ref Queue cola)
        {


            try
            {
                cola.Clear();
                Console.WriteLine("Cola Vaciada. Presione tecla para continuar\n");
                Console.ReadKey();
                Console.Clear();
                return cola;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return cola;
            }
        }

        public static ref Queue agregar_pedido(ref Queue cola)
        {
            try
            {
                int i;
                int dato;

                Console.Clear();
                Console.WriteLine("Ingrese Pedido (Solo numeros)\n");

                dato = Convert.ToInt32(Console.ReadLine());

                bool convertir = int.TryParse(Convert.ToString(dato), out i);

                if (convertir == true && dato < 1000 && dato >= 0)
                {
                    cola.Enqueue(dato);
                    Console.Clear();
                    Console.WriteLine("Pedido cargado.\n");
                    Console.WriteLine("Presione una tecla para continuar...\n");
                    Console.ReadLine();
                    Console.Clear();
                    return ref cola;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado NO es valido.\n");
                    Console.WriteLine("Presione una tecla para continuar...\n");
                    Console.ReadKey();
                    Console.Clear();
                    return ref cola;
                }
            }

            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla y luego cargue el dato.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return ref cola;

            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Ingreso un caracter no valido.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }

        }

        public static ref Queue listar_pedidos(ref Queue cola)
        {
            try
            {
                ArrayList lista_pedidos = new ArrayList();
                int numero = 1;

                Console.Clear();

                Console.WriteLine("LISTA DE PEDIDOS INGRESADOS\n");
                foreach (int dato in cola)  //Copio la cola en una lista y muestro el contenido de la lista.
                {
                    lista_pedidos.Add(dato);
                    Console.WriteLine("{0}-  {1}", numero, dato);
                    numero++;
                }
                Console.WriteLine("\nPresione un tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }


            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return ref cola;
            }


        }


        public static ref Queue listar_ultimo(ref Queue cola)
        {
            try
            {
                ArrayList lis = new ArrayList();
                int posicion_ultima;

                posicion_ultima = cola.Count - 1;                //Obtengo la posicion del ultimo Pedido.

                foreach (int dato in cola)                     //Copio la cola en una lista.
                {
                    lis.Add(dato);
                }
                Console.Clear();
                Console.WriteLine("Ultimo Pedido cargado:\n\n1-  {0}\n", lis[posicion_ultima]);
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return ref cola;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("La COLA esta vacia.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return ref cola;
            }
        }


        public static ref Queue listar_primer(ref Queue cola)
        {
            try
            {
                int primer;
                primer = Convert.ToInt32(cola.Peek());
                Console.Clear();
                Console.WriteLine("Primer Pedido cargado:\n\n1-  {0}\n", primer);
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return ref cola;
            }
            catch (InvalidOperationException)
            {
                Console.Clear();
                Console.WriteLine("La COLA esta vacia\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return ref cola;
            }
        }

        public static ref Queue cantidad_total(ref Queue cola)
        {
            try
            {
                int cant;
                cant = cola.Count;
                Console.Clear();
                Console.WriteLine("Cantidad total de Pedidos cargados hasta el momento: {0}", cant);
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
        }

        public static ref Queue ordenar_pedidos(ref Queue cola)
        {
            try
            {
                int num = 1;
                ArrayList lista_ord = new ArrayList();
                foreach (int dato in cola)                     //Copio la cola en una lista.
                    lista_ord.Add(dato);

                lista_ord.Sort();                              //Ordeno la lista para mostrarla
                Console.Clear();
                Console.WriteLine("PEDIDOS ORDENADOS DE FORMA ASCENDENTE.\n\n");
                foreach (int mostrar in lista_ord)
                {
                    Console.WriteLine("{0}-  {1}", num, mostrar);
                    num++;
                }
                Console.WriteLine("\n\nPresione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }




        }

        public static ref Queue descendente(ref Queue cola)
        {
            try
            {
                int num = 1;
                ArrayList lista_desc = new ArrayList();
                foreach (int dato in cola)                     //Copio la cola en una lista.
                    lista_desc.Add(dato);

                lista_desc.Sort();                              //Ordeno la lista para mostrarla.
                lista_desc.Reverse();                           //Ordeno de forma descendente la lista.
                Console.Clear();
                Console.WriteLine("PEDIDOS ORDENADOS DE FORMA DESCENDENTE.\n\n");
                foreach (int mostrar in lista_desc)
                {
                    Console.WriteLine("{0}-  {1}", num, mostrar);
                    num++;
                }
                Console.WriteLine("\n\nPresione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
        }

    }

}
