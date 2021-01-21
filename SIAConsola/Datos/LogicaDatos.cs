using IronXL;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SIAConsola.Datos
{
    class LogicaDatos
    {
        static string Pathlogin = @"C:\Users\di_eg\Desktop\Datos SIA\login.txt";
        static bool acceso = true;

        internal List<List<double>> LeerDatosFiltro(int filtro)
        {
            //String path = InstanciarArchivos();
            String path = @"C:\Users\di_eg\Desktop\Datos SIA\competitividad.xls";
            //SLDocument sl = new SLDocument(path);
            WorkBook workbook = WorkBook.Load(path);
            WorkSheet sheet = workbook.WorkSheets[filtro-1];
            List<List<double>> listaDatos = new List<List<double>>();//xd
            List<double> listaNiveles = new List<double>();// hola helioooo
            List<double> listaImportancia = new List<double>();
            List<double> listaKPA = new List<double>();
            List<double> listaEntrada = new List<double>();
            List<string> listaPlanes = new List<string>();
            for(int i = 1; i < 46; i++)
            {
                double nivel = sheet.GetCellAt(i, 1).Int32Value;
                double impotancia = sheet.GetCellAt(i, 2).Int32Value;
                double kpa = sheet.GetCellAt(i, 3).Int32Value;
                double entrada = sheet.GetCellAt(i, 4).Int32Value;
                listaNiveles.Add(nivel);
                listaImportancia.Add(impotancia);
                listaKPA.Add(kpa);
                listaEntrada.Add(entrada);
            }
            //ImprimirLista1(listaEntrada, "lista entrada");
            listaDatos.Add(listaNiveles);
            listaDatos.Add(listaImportancia);
            listaDatos.Add(listaKPA);
            listaDatos.Add(listaEntrada);

            return listaDatos;
            //ImprimirLista1(listaNiveles, "nivel:");
        }

        internal void ImprimirLista1(List<double> lista, String tipo)
        {
            int i = 0;
            foreach (double t in lista)
            {
                
                Console.WriteLine(tipo + t+ " "+ i);
                i++;
            }
        }

        internal void ImprimirListaDoble(List<List<double>> lista, String tipo)
        {
            foreach(List<double> l in lista)
            {

                foreach(double d in l)
                {
                    Console.Write(d+" ");
                }
            }
        }

        
        public static void Crearusuario()
        {
            Console.WriteLine("Para crear un usuario, debes ingresar tu usuario (correo institucional) luego tu contraseña...");
            Console.WriteLine("--------------------------------------------------");
            string username, password = string.Empty;


            Console.WriteLine("Ingresa correo institucional: ");
            username = Console.ReadLine();

            Console.WriteLine("Ingresa una contraseña: ");
            password = Console.ReadLine();


            using (StreamWriter sv = new StreamWriter(File.Create(Pathlogin)))
            {
                sv.WriteLine(username);
                sv.WriteLine(password);
                sv.Close();

            }
            Console.WriteLine("Felicidades, usuario registrado con exito...");
            Console.WriteLine("--------------------------------------------------");

        }


        public static bool Ingreso()
        {
            String username, password, username1, password1 = string.Empty;
            bool var = true;

            Console.WriteLine("Debes ingresar tu correo institucional junto a tu contraseña...");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Correo institucional: ");
            username = Console.ReadLine();

            Console.Write("Contraseña: ");
            password = Console.ReadLine();


            using (StreamReader sr = new StreamReader(File.Open(Pathlogin, FileMode.Open)))
            {
                username1 = sr.ReadLine();
                password1 = sr.ReadLine();
                sr.Close();
            }
            if (username == username1 && password == password1)
            {
                Console.WriteLine("Hola, Bienvenido..." + username);
                Console.WriteLine("--------------------------------------------------");
                return var;
            }
            else
            {
                Console.WriteLine("Acceso Denegado, porfavor ingresa nuevamente los datos");
                Console.WriteLine("--------------------------------------------------");

                return !var;
            }
        }

        internal void Menu()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Por favor, seleccione una de las siguientes opciones: ");
                Console.WriteLine("");
                Console.WriteLine("1º) Registrar Nuevo Usuario");
                Console.WriteLine("2º) Ingresar Usuario");
                Console.WriteLine("3º) Contacto");
                Console.WriteLine("4º) Manual de Usuario");
                Console.WriteLine("5º) Salir");
                Console.WriteLine("");
                Console.WriteLine("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Ha seleccionado Registrar un nuevo usuario");
                        Crearusuario();
                        break;
                    case 2:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Ha seleccionado Acceder");
                        acceso = Ingreso();
                        if (acceso)
                        {
                            Console.WriteLine(" Nivel de madurez competitiva de la carreara .....");// Menu despues de acceder a el programa
                           
                        }
                        break;
                    case 3:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Ha seleccionado la opción de contacto");
                        Console.WriteLine("");
                        Console.WriteLine("Integrantes: Helio Rivera- Diego Herrera - Marcelo Romo - Sebastian Urrutia - Javier Garcia - Rodrigo Mamani - ");
                        Console.WriteLine("Problematica Aumento de la competitividad academica");
                        Console.WriteLine("Proyecto para SIA");
                        Console.WriteLine("Con fecha 21/01/2021");
                        Console.WriteLine("--------------------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Ha seleccionado la opción de Manual de Usuario:");
                        Console.WriteLine("Paso 1) Para realizar la predicción estudiantil de un estudiante debera registrarse primeramente" + "\n" +
                            "Paso 2) Una vez realizado este proceso. Debera ingresar con su correo electronico junto con su contraseña" + "\n" +
                            "Paso 3) Finalmente, debera ir ingresando los valores del alumno para realizar la predicción de los " + "\n" +
                            "        fenomenos de Retención y Deserción Voluntaria e Involuntaria");
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                        break;
                    case 5:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Hasta luego...");
                        Console.WriteLine("--------------------------------------------------");
                        Environment.Exit(0);
                        break;


                }
                Console.ReadKey();
            } while (opcion != 5);
        }
    }
}
