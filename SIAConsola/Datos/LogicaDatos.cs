using IronXL;
using SIAConsola.Datos;
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
            WorkSheet sheet = workbook.WorkSheets[filtro - 1];
            List<List<double>> listaDatos = new List<List<double>>();
            List<double> listaNiveles = new List<double>();
            List<double> listaImportancia = new List<double>();
            List<double> listaKPA = new List<double>();
            List<double> listaEntrada = new List<double>();
            List<string> listaPlanes = new List<string>();
            for (int i = 1; i < 46; i++)
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
        
        internal List<List<string>> ObtenerPlanes(int filtro)
        {
            //String path = InstanciarArchivos();
            String path = @"C:\Users\di_eg\Desktop\Datos SIA\competitividad.xls";
            //SLDocument sl = new SLDocument(path);
            WorkBook workbook = WorkBook.Load(path);
            WorkSheet sheet = workbook.WorkSheets[filtro - 1];
            List<List<string>> listaEstrategia = new List<List<string>>();
            List<string> listaIndicador = new List<string>();
            List<string> listaPlanes = new List<string>();
            for (int i = 1; i < 46; i++)
            {
                string plan = sheet.GetCellAt(i, 5).ToString();
                string indicador = sheet.GetCellAt(i, 6).ToString();
                listaPlanes.Add(plan);
                listaIndicador.Add(indicador);
            }
            listaEstrategia.Add(listaPlanes);
            listaEstrategia.Add(listaIndicador);
            return listaEstrategia;
        }
        

        internal void ImprimirLista1(List<double> lista, String tipo)
        {
            int i = 0;
            foreach (double t in lista)
            {

                Console.WriteLine(tipo + t + " " + i);
                i++;
            }
        }

        internal void ImprimirListaDoble(List<List<double>> lista, String tipo)
        {
            foreach (List<double> l in lista)
            {

                foreach (double d in l)
                {
                    Console.Write(d + " ");
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


    }
}
