using SIAConsola.Datos;
using System;
using System.Collections.Generic;


namespace SIAConsola
{
    class Program
    {
        
        static void Main(string[] args)
        {
            LogicaDatos logicaDatos = new LogicaDatos();
            Filtro1 filtro1 = new Filtro1();
            Filtro2 filtro2 = new Filtro2();
            Filtro3 filtro3 = new Filtro3();
            List<List<double>> listaDatos = new List<List<double>>();
            int nivel = 0;
            double puntaje;
            //logicaDatos.InstanciarArchivos();
            listaDatos = logicaDatos.LeerDatosFiltro(1);
            //nivel = filtro1.getNivel2(listaDatos);
            nivel = filtro1.getNivel(listaDatos);
            puntaje = filtro1.ObtenerPuntaje(listaDatos);
            //logicaDatos.Menu();



            Console.WriteLine("Nivel: "+nivel+ ", Puntaje: "+puntaje);
        }
    }
}
