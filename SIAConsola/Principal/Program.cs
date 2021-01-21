using SIAConsola.Datos;
using System;
using System.Collections.Generic;


namespace SIAConsola
{
    class Program
    {
        static LogicaDatos logicaDatos = new LogicaDatos();

        static Filtro1 filtro1 = new Filtro1();
        static Filtro2 filtro2 = new Filtro2();
        static Filtro3 filtro3 = new Filtro3();
        static List<List<double>> listaDatos = new List<List<double>>();
        static List<double> listaCantidadAsignaturas = new List<double>();
        static List<List<string>> listaPlanes = new List<List<string>>();
        static int nivel = 0;
        static  double puntaje;
        static bool acceso = true;

        static void Menu()
        {
            int opcion = 0;
            do
            {
                //Console.Clear();
                Console.WriteLine("Por favor, seleccione una de las siguientes opciones: ");
                Console.WriteLine("");
                Console.WriteLine("1º) Registrar Nuevo Usuario");
                Console.WriteLine("2º) Ingresar Usuario");
                Console.WriteLine("3º) Contacto");
                Console.WriteLine("4º) Salir");
                Console.WriteLine("");
                Console.WriteLine("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Ha seleccionado Registrar un nuevo usuario");
                        LogicaDatos.Crearusuario();
                        break;
                    case 2:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Ha seleccionado Acceder");
                        acceso = LogicaDatos.Ingreso();
                        if (acceso)
                        {
                            Console.WriteLine(" Nivel de madurez competitiva de la carreara .....");// Menu despues de acceder a el programa

                        }
                       // Console.Clear();
                        Menu2();
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
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Hasta luego...");
                        Console.WriteLine("--------------------------------------------------");
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();
            } while (opcion != 4);
        }
        static void Menu2()
        {
            int opcion = 0;
            do
            {
                //Console.Clear();
                Console.WriteLine("Por favor, seleccione una de las siguientes opciones: ");
                Console.WriteLine("");
                Console.WriteLine("1º) Filtro 1");
                Console.WriteLine("2º) Filtro 2");
                Console.WriteLine("3º) Filtro 3");
                Console.WriteLine("4º) Salir");
                Console.WriteLine("");
                Console.WriteLine("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Ha seleccionado Filtro 1");
                        //Filtro 1 funcione
                        listaPlanes = logicaDatos.ObtenerPlanes(1);
                        listaDatos = logicaDatos.LeerDatosFiltro(1);
                        nivel = filtro1.getNivel(listaDatos, listaPlanes);
                        puntaje = filtro1.ObtenerPuntaje(listaDatos);

                        for (int i = 0; i < filtro1.getListaPlanes().Count; i++)
                        {
                            Console.WriteLine(filtro1.getListaPlanes()[i]);
                        }

                        break;
                    case 2:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Ha seleccionado Filtro 2");
                        //Filtro 2 funcion
                        /*
                        Console.ReadKey();
                            List<double> factorPrestigioPorÁrea = new List<double>();
                            List<double> listaPromedio = new List<double>();
                            for (int i = 0; i < 2; i++)
                            {
                                int posición = MenuUni();
                                listaCantidadAsignaturas = filtro2.ObtenerCantidadAsignaturas(posición, 2);
                                foreach(double dato in listaCantidadAsignaturas)
                                {
                                    Console.WriteLine(dato);
                                }
                                int posiciónRanking = filtro2.ObtenerPosRanking(posición);
                                Console.WriteLine("posición ranking: "+posiciónRanking);
                                factorPrestigioPorÁrea = filtro2.Calcular_factor_prestigio_por_area(listaCantidadAsignaturas, posiciónRanking);
                                foreach (double dato in factorPrestigioPorÁrea)
                                {
                                    Console.WriteLine("factor: "+dato);
                                }
                                listaPromedio = filtro2.ObtenerPromedio(2);
                                foreach (double dato in listaPromedio)
                                {
                                    Console.WriteLine("Promedio: " + dato);
                                }
                                List<double> porcentaje = filtro2.Determinar_porcentaje_de_competencia(factorPrestigioPorÁrea, listaPromedio);
                                foreach (double dato in porcentaje)
                                {
                                    Console.WriteLine("Porcentaje: " + dato);
                                }
                                double gradoAcadémico = filtro2.ObtenerGradoAcadémico();
                                Console.WriteLine("Grado académico: " + gradoAcadémico);
                                double gradoCompromiso = filtro2.ObtenerGradoCompromiso();
                                Console.WriteLine("gradoCompromiso: " + gradoCompromiso);
                                double coeficienteGradoAcadémico = filtro2.ObtenerCoeficienteGradoAcadémico(gradoAcadémico, gradoCompromiso);
                                Console.WriteLine("Coeficiente Grado académico: " + coeficienteGradoAcadémico);
                                double coeficienteCD = filtro2.Calcular_coeficiente_calidad_docente(coeficienteGradoAcadémico, posiciónRanking);
                                Console.WriteLine("coeficienteCD: " + coeficienteCD);
                                double puntajePlanEstudio = filtro2.ObtenerPuntajePE(i);
                                Console.WriteLine("puntajePlanEstudio: " + puntajePlanEstudio);
                                double indicadorProfundidad = filtro2.Indicador_de_profundidad_de_contenido(puntajePlanEstudio, coeficienteCD);
                                Console.WriteLine("indicadorProfundidad: " + indicadorProfundidad);
                                List<double> porcentajeCompetencia = filtro2.PorcentajeFinalAreas(indicadorProfundidad, porcentaje);
                                foreach (double dato in porcentajeCompetencia)
                                {
                                    Console.WriteLine(" -" +dato);
                                }
                                for (int j = 0; j< porcentajeCompetencia.Count; j++)
                                {
                                    switch (j)
                                    {
                                        case 0: Console.WriteLine("Industrial: " + porcentajeCompetencia[j]);break;
                                        case 1: Console.WriteLine("Computación: " + porcentajeCompetencia[j]); break;
                                        case 2: Console.WriteLine("Matemáticas: " + porcentajeCompetencia[j]); break;
                                        case 3: Console.WriteLine("Ingenieria: " + porcentajeCompetencia[j]); break;
                                        case 4: Console.WriteLine("Ciencias: " + porcentajeCompetencia[j]); break;
                                        case 5: Console.WriteLine("Humanidades: " + porcentajeCompetencia[j]); break;
                       
                                    }
                        
                                }
                            Console.ReadKey();
                        }
                        **/

                        break;
                    case 3:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Ha seleccionado Filtro 3");
                        //Filtro 3 funcion

                        break;
                    case 4:
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Hasta luego...");
                        Console.WriteLine("--------------------------------------------------");
                        //Console.Clear();
                        Menu();
                        //Environment.Exit(0);

                        break;


                }
                Console.ReadKey();
            } while (opcion != 4);
        }
        static int MenuUni()
        {
            int opcion = 0;
           
                //Console.Clear();
                Console.WriteLine("Por favor, seleccione una de las siguientes opciones: ");
                Console.WriteLine("");
                Console.WriteLine("1º) Universidad de La Serena");
                Console.WriteLine("2º) Universidad católica del Norte");
                Console.WriteLine("3º) Universidad de Chile");
                Console.WriteLine("4º) Universidad de Concepción");
                Console.WriteLine("5º) INACAP");
                Console.WriteLine("6º) Universidad Santiago de Chile");
                Console.WriteLine("");
                Console.WriteLine("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                 Console.ReadKey();
                 return opcion;
        }
        static void Main(string[] args)
        {

            //LogicaDatos logicaDatos = new LogicaDatos();
            /*
            Filtro1 filtro1 = new Filtro1();
            Filtro2 filtro2 = new Filtro2();
            Filtro3 filtro3 = new Filtro3();
            List<List<double>> listaDatos = new List<List<double>>();
            List<double> listaCantidadAsignaturas = new List<double>();
            List<List<string>> listaPlanes = new List<List<string>>();
            int nivel = 0;
            double puntaje;*/

           // Menu();
            //logicaDatos.InstanciarArchivos();
            ////////////////////////////////////////////////////////////////////////FILTRO1
            //

            listaPlanes = logicaDatos.ObtenerPlanes(1);
             listaDatos = logicaDatos.LeerDatosFiltro(1);
            nivel = filtro1.getNivel(listaDatos, listaPlanes);
            puntaje = filtro1.ObtenerPuntaje(listaDatos);
            Console.WriteLine("Nivel: " + nivel + ", Puntaje: " + puntaje);
           for (int i = 0; i < filtro1.getListaPlanes().Count; i++)
            {
                Console.WriteLine(filtro1.getListaPlanes()[i]);
            }

            ////////////////////////////////////////////////////////////////////////FILTRO2
            Console.ReadKey();
            
            for (int i = 0; i < 2; i++)
            {
                List<double> factorPrestigioPorÁrea = new List<double>();
                List<double> listaPromedio = new List<double>();
                int posición = MenuUni();
                listaCantidadAsignaturas = filtro2.ObtenerCantidadAsignaturas(posición, 2);
                /*foreach(double dato in listaCantidadAsignaturas)
                {
                    Console.WriteLine(dato);
                }*/
                int posiciónRanking = filtro2.ObtenerPosRanking(posición);
                //Console.WriteLine("posición ranking: "+posiciónRanking);
                factorPrestigioPorÁrea = filtro2.Calcular_factor_prestigio_por_area(listaCantidadAsignaturas, posiciónRanking);
                /*foreach (double dato in factorPrestigioPorÁrea)
                {
                    Console.WriteLine("factor: "+dato);
                }*/
                listaPromedio = filtro2.ObtenerPromedio(2);
                /*foreach (double dato in listaPromedio)
                {
                    Console.WriteLine("Promedio: " + dato);
                }*/
                List<double> porcentaje = filtro2.Determinar_porcentaje_de_competencia(factorPrestigioPorÁrea, listaPromedio);
                foreach (double dato in porcentaje)
                {
                    Console.WriteLine("Porcentaje: " + dato);
                }
                Console.WriteLine();
                double gradoAcadémico = filtro2.ObtenerGradoAcadémico();
                //Console.WriteLine("Grado académico: " + gradoAcadémico);
                double gradoCompromiso = filtro2.ObtenerGradoCompromiso();
                //Console.WriteLine("gradoCompromiso: " + gradoCompromiso);
                double coeficienteGradoAcadémico = filtro2.ObtenerCoeficienteGradoAcadémico(gradoAcadémico, gradoCompromiso);
                //Console.WriteLine("Coeficiente Grado académico: " + coeficienteGradoAcadémico);
                double coeficienteCD = filtro2.Calcular_coeficiente_calidad_docente(coeficienteGradoAcadémico, posiciónRanking);
                //Console.WriteLine("coeficienteCD: " + coeficienteCD);
                double puntajePlanEstudio = filtro2.ObtenerPuntajePE(i);
                //Console.WriteLine("puntajePlanEstudio: " + puntajePlanEstudio);
                double indicadorProfundidad = filtro2.Indicador_de_profundidad_de_contenido(puntajePlanEstudio, coeficienteCD);
                //Console.WriteLine("indicadorProfundidad: " + indicadorProfundidad);
                List<double> porcentajeCompetencia = filtro2.PorcentajeFinalAreas(indicadorProfundidad, porcentaje);
                /*foreach (double dato in porcentajeCompetencia)
                {
                    Console.WriteLine(" -" +dato);
                }*/
                for (int j = 0; j< porcentajeCompetencia.Count; j++)
                {
                    switch (j)
                    {
                        case 0: Console.WriteLine("Industrial: " + porcentajeCompetencia[j]);break;
                        case 1: Console.WriteLine("Computación: " + porcentajeCompetencia[j]); break;
                        case 2: Console.WriteLine("Matemáticas: " + porcentajeCompetencia[j]); break;
                        case 3: Console.WriteLine("Ingenieria: " + porcentajeCompetencia[j]); break;
                        case 4: Console.WriteLine("Ciencias: " + porcentajeCompetencia[j]); break;
                        case 5: Console.WriteLine("Humanidades: " + porcentajeCompetencia[j]); break;
                       
                    }
                        
                    }
                Console.ReadKey();
            }
                
            }

    }
}

