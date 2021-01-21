using IronXL;
using SIAConsola.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIAConsola
{
    class Filtro2
    {
        //LogicaDatos2 logicaDatos = new LogicaDatos2();
        public static void cargarDatos(string Dir)
        {

        }
        static double func(int x)
        {
            double valor = 0, a = 5, m = 140;
            if (x <= a)
            {
                valor = 1;
            }
            else if (a < x && x <= m)
            {
                valor = (x - m) / (a - m);
            }
            else
            {
                valor = 0;
            }

            return valor;
        }
        public List<double> Calcular_factor_prestigio_por_area(List<double> asignatura_por_areas, int posicion_ranking)
        {
            /* el vector asignatura por area contiene la cantidad de asignaturas por area
             ya clasificadas. dentro de esta lista se presentan en el siguiente orden 
            0 pIndustrial, 1 aComputación, 2 aMatemática, 3 pIngeniería, 4 aCiencias, 5 phumanidades 
            ;*/

            double peso_obtenido_ranking = func(posicion_ranking);
            List<double> factor_prestigio_por_area = new List<double>();

            for (int i = 0; i < asignatura_por_areas.Count; i++)
            {
                factor_prestigio_por_area.Add(asignatura_por_areas[i] * peso_obtenido_ranking);
            }
            return factor_prestigio_por_area;

        }

        internal int ObtenerPosRanking(int opc)
        {
            int posición = 0;
            switch (opc)
            {
                case 1: posición = 23; break;
                case 2: posición = 12; break;
                case 3: posición = 1; break;
                case 4: posición = 3; break;
                case 5: posición = 41; break;
                case 6: posición = 4; break;
            }

            return posición;
        }

        internal double ObtenerGradoCompromiso()
        {
            Random r = new Random();
            int rand = r.Next(1, 3);
            double compromiso = 0;
            switch (rand)
            {
                case 1: compromiso = 0.2; break;
                case 2: compromiso = 0.5; break;
                case 3: compromiso = 1; break;
            }

            return compromiso;
        }

        internal double ObtenerGradoAcadémico()
        {
            Random r = new Random();
            int rand = r.Next(1, 3);
            double grado = 0;
            switch (rand)
            {
                case 1: grado = 0.4; break;
                case 2: grado = 0.7; break;
                case 3: grado = 1; break;
            }

            return grado;
        }

        internal double Calcular_coeficiente_calidad_docente(double coeficienteGA, double posición)
        {
            return coeficienteGA * posición;
        }

        internal List<double> Determinar_porcentaje_de_competencia(List<double> factorPrestigioPorÁrea, List<double> listaPromedio)
        {
            //Console.WriteLine("entra");
            List<double> porcentaje_de_competencia = new List<double>();
            for (int i = 0; i < listaPromedio.Count; i++)
            {
                double dato = factorPrestigioPorÁrea[i] * 100;
                double dato2 = listaPromedio[i];
                porcentaje_de_competencia.Add(dato / dato2);
            }

            /*foreach(double dato in porcentaje_de_competencia)
            {
                Console.WriteLine("%%%%" + dato);
            }*/
            return porcentaje_de_competencia;
        }

        public List<double> ObtenerPromedio(int filtro)
        {
            List<double> listaPromedio = new List<double>();
            String path = @"C:\Users\di_eg\Desktop\Datos SIA\competitividad.xls";
            //SLDocument sl = new SLDocument(path);
            WorkBook workbook = WorkBook.Load(path);
            WorkSheet sheet = workbook.WorkSheets[filtro - 1];
            double pIndustrial = sheet.GetCellAt(7, 1).Int32Value;
            double pComputación = sheet.GetCellAt(7, 2).Int32Value;
            double pMatemática = sheet.GetCellAt(7, 3).Int32Value;
            double pIngeniería = sheet.GetCellAt(7, 4).Int32Value;
            double pCiencias = sheet.GetCellAt(7, 5).Int32Value;
            double pHumanidades = sheet.GetCellAt(7, 6).Int32Value;
            listaPromedio.Add(pIndustrial);
            listaPromedio.Add(pComputación);
            listaPromedio.Add(pMatemática);
            listaPromedio.Add(pIngeniería);
            listaPromedio.Add(pCiencias);
            listaPromedio.Add(pHumanidades);

            return listaPromedio;
        }

        internal List<double> ObtenerCantidadAsignaturas(int posición, int filtro)
        {
            List<double> listaCantidadAsignatura = new List<double>();
            String path = @"C:\Users\di_eg\Desktop\Datos SIA\competitividad.xls";
            WorkBook workbook = WorkBook.Load(path);
            WorkSheet sheet = workbook.WorkSheets[filtro - 1];
            double aIndustrial = sheet.GetCellAt(posición, 1).Int32Value;
            double aComputación = sheet.GetCellAt(posición, 2).Int32Value;
            double aMatemática = sheet.GetCellAt(posición, 3).Int32Value;
            double aIngeniería = sheet.GetCellAt(posición, 4).Int32Value;
            double aCiencias = sheet.GetCellAt(posición, 5).Int32Value;
            double aHumanidades = sheet.GetCellAt(posición, 6).Int32Value;

            listaCantidadAsignatura.Add(aIndustrial);
            listaCantidadAsignatura.Add(aComputación);
            listaCantidadAsignatura.Add(aMatemática);
            listaCantidadAsignatura.Add(aIngeniería);
            listaCantidadAsignatura.Add(aCiencias);
            listaCantidadAsignatura.Add(aHumanidades);

            return listaCantidadAsignatura;
        }


        internal double ObtenerCoeficienteGradoAcadémico(double gradoAcadémicoDocente, double gradoCompromiso)
        {
            double coeficiente = gradoAcadémicoDocente * 0.8 + gradoCompromiso * 0.2;
            return coeficiente;
        }

        internal double ObtenerPuntajePE(int competidor)
        {
            String path = @"C:\Users\di_eg\Desktop\Datos SIA\competitividad.xls";
            WorkBook workbook = WorkBook.Load(path);
            WorkSheet sheet = workbook.WorkSheets[2];
            double puntaje = 0;
            if (competidor == 0)
            {
                puntaje = sheet.GetCellAt(10, 2).Int32Value;
                //Console.WriteLine("competidor1: "+puntaje);
            }
            else

                puntaje = sheet.GetCellAt(10, 4).Int32Value;
        
            return puntaje;
        }

    internal double Indicador_de_profundidad_de_contenido(double CCD, double CPE)
    {
        return CCD * CPE;
    }

    internal List<double> PorcentajeFinalAreas(double indicadorProfundidad, List<double> porcentaje)
    {
        List<double> listaPorcentaje = new List<double>();
        for (int i = 0; i < porcentaje.Count; i++)
        {
            listaPorcentaje.Add(porcentaje[i] * indicadorProfundidad);
        }
        /*foreach(double dato in listaPorcentaje)
            {
                Console.WriteLine("Porcentaje final: "+dato);
            }
        */
        return listaPorcentaje;
    }
}
}

