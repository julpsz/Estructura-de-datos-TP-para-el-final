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
                    "9. SALIR\n\n");


                Console.WriteLine("Ingrese Opcion: ");
                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Queue objeto;
                        objeto = Crear_cola();
                        cola = objeto;
                        Console.WriteLine("Cola creada con exito. Presione una tecla para continuar...\n");
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


                Console.WriteLine("Ingrese Pedido a borrar:\n");
                borrar = Convert.ToInt32(Console.ReadLine());   //Guardo el Pedido a borrar.
                posicion = lista.IndexOf(borrar);               //Obtengo la posicion del Pedido a borrar.
                if (posicion == -1)
                {
                    Console.WriteLine("Pedido inexistente.");
                    Console.WriteLine("Presione una tecla para continuar...\n");
                    Console.ReadKey();
                    Console.Clear();
                    return ref cola;
                }
                else
                {
                    Console.WriteLine("Pedido encontrado en la posicion {0}. BORRAR ? (s/n):\n", posicion);
                    sel = Convert.ToString(Console.ReadLine());
                    if (sel == "s")
                    {
                        lista.RemoveAt(posicion);                   //Borro el Pedido.

                        Console.WriteLine("Pedido borrado.\n");
                        Console.WriteLine("Presione una tecla para continuar...\n");
                        Console.ReadKey();
                        Console.Clear();
                        /*foreach (int l in lista)
                            Console.WriteLine(l);*/
                    }
                    else
                    {
                        Console.WriteLine("Pedido NO borrado.\n");
                        Console.WriteLine("Presione una tecla para continuar...\n");
                        Console.ReadKey();
                        Console.Clear();
                        /*foreach (int l in lista)
                            Console.WriteLine(l);*/
                    }
                    foreach (int copiar in lista)                   //Paso los datos de la lista actualizada a la COLA.
                        cola.Enqueue(copiar);
                    /*Console.WriteLine("Lista -> Cola. Contenido COLA actualizado\n");
                    foreach (int m in cola)
                        Console.WriteLine(m);*/

                    return ref cola;
                }
            }
            catch (NullReferenceException)
            {

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
            //cola.Clear();

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

                Console.WriteLine("Ingrese Pedido (Solo numeros)\n");

                //string pattern = @"^[0-9]{1,3}$";
                //string dato = @"";
                dato = Convert.ToInt32(Console.ReadLine());
                /* RegexOptions options = RegexOptions.Multiline;

                 foreach (Match m in Regex.Matches(Convert.ToString(dato), pattern, options))
                 {
                     Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                 }*/
                bool convertir = int.TryParse(Convert.ToString(dato), out i);

                if (convertir == true && dato < 1000 && dato >= 0)
                {
                    cola.Enqueue(dato);
                    Console.WriteLine("Pedido cargado.\n");
                    Console.WriteLine("Presione una tecla para continuar...\n");
                    Console.ReadLine();
                    Console.Clear();
                    return ref cola;
                }
                else
                {
                    Console.WriteLine("El valor ingresado NO es valido.\n");
                    Console.WriteLine("Presione una tecla para continuar...\n");
                    Console.ReadKey();
                    Console.Clear();
                    return ref cola;
                }
            }

            catch (NullReferenceException)
            {

                Console.WriteLine("La COLA aun no esta creada, primero debe crearla y luego cargue el dato.\n");
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadLine();
                Console.Clear();
                return ref cola;

            }
            catch (FormatException)
            {
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
                Console.Clear();

                Console.WriteLine("Lista de Pedidos ingresados\n");
                foreach (int dato in cola)  //Copio la cola en una lista y muestro el contenido de la lista.
                {
                    lista_pedidos.Add(dato);
                    Console.WriteLine(dato);
                }
                Console.WriteLine("Presione un tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }


            catch (NullReferenceException)
            {

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

                foreach (int dato in cola)                     //Copio la cola en una lista y muestro el contenido de la lista.
                {
                    lis.Add(dato);
                }
                Console.WriteLine("Ultimo Pedido cargado: {0}\n", lis[posicion_ultima]);
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
            catch (NullReferenceException)
            {

                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
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
                Console.WriteLine("Primer Pedido cargado: {0}\n", primer);
                Console.WriteLine("Presione una tecla para continuar...\n");
                Console.ReadKey();
                Console.Clear();
                return ref cola;
            }
            catch (NullReferenceException)
            {

                Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
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
                    Console.WriteLine("Cantidad total de Pedidos cargados hasta el momento: {0}", cant);
                    Console.WriteLine("Presione una tecla para continuar...\n");
                    Console.ReadKey();
                    Console.Clear();
                    return ref cola;
                }
                catch (NullReferenceException)
                {

                    Console.WriteLine("La COLA aun no esta creada, primero debe crearla.\n");
                    Console.WriteLine("Presione una tecla para continuar...\n");
                    Console.ReadLine();
                    Console.Clear();
                    return ref cola;
                }
        }



        
    }
}