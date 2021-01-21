using System;
using System.Collections.Generic;
using System.Text;
using IronXL;
using System.Linq;

namespace SIAConsola
{
    class Filtro1
    {
        Datos.LogicaDatos datos = new Datos.LogicaDatos();
        List<string> listaPlanes = new List<string>();


        public int getNivel(List<List<double>> kpa, List<List<string>> listaEstrategia)
        {
            //List<List<double>> kpa = datos.LeerDatosFiltro(1);
            List<double> listaKpa = new List<double>();
            List<double> listaNiveles = new List<double>();
            
            int nivel = 5,t=0,i=0;
          
            for(i = 0; i< kpa[0].Count; i++) //45 filas +/-
            {
                double cont = 0;
                if ((int)kpa[3][i]== 0) // si no cumple la kpa
                {
                    
                    if (((int)kpa[0][i] != (int)kpa[0][i - 1] && (int)kpa[3][i] == 0) || ((int)kpa[0][i] == (int)kpa[0][i - 1] && (int)kpa[2][i] != (int)kpa[2][i - 1] && (int)kpa[3][i] == 0) || ((int)kpa[0][i] == (int)kpa[0][i - 1] && (int)kpa[2][i] == (int)kpa[2][i - 1] && (int)kpa[3][i - 1] != 0)) {

                        listaPlanes.Add(listaEstrategia[0][i]);
                        listaPlanes.Add(listaEstrategia[1][i]);

                    }
                    listaKpa.Add((int)kpa[2][i]);
                        listaNiveles.Add((int)kpa[0][i]);
                        //Console.WriteLine(kpa[0][i]+" - " +kpa[2][i]);
                   
                    if ((int)kpa[0][i] < nivel) // si la kpa no cumplida, es menor a la var nivel , guarda el nivel no cumplido
                    {
                        nivel = (int)kpa[0][i]-1;
                    }
                }
               
            }    

         
            return nivel;
        }

        public double ObtenerPuntaje(List<List<double>> kpa)
        {
            int contar2=0, contar3=0, contar4=0, contar5 = 0;
            double puntaje2 = 0, puntaje3 = 0, puntaje4 = 0, puntaje5 = 0;

            for (int i = 0; i < kpa[0].Count; i++)
            {
                if ((int)kpa[3][i] == 1)
                {
                    if ((int)kpa[0][i] == 2)
                    {
                        puntaje2 = puntaje2 + (int)kpa[1][i];
                        contar2 = contar2 + 1 ;
                    }
                    if ((int)kpa[0][i] == 3)
                    {
                        puntaje3 = puntaje3 + (int)kpa[1][i];
                        contar3 = contar3 + 1 ;
                    }
                    if ((int)kpa[0][i] == 4)
                    {
                        puntaje4 = puntaje4 + (int)kpa[1][i];
                        contar4 = contar4 + 1 ;
                    }
                    if ((int)kpa[0][i] == 5)
                    {
                        puntaje5 = puntaje5 + (int)kpa[1][i];
                        contar5 = contar5 + 1 ;
                    }
                }

                
            }
            puntaje2 = puntaje2 * 2/100;
            puntaje3 = puntaje3 * 3 / 100;
            puntaje4 = puntaje4 * 4 / 100;
            puntaje5 = puntaje5 * 5 / 100;
            Console.WriteLine(contar2 + " - " + contar3 + " - " + contar4 + " - " + contar5 );
            Console.WriteLine(puntaje2 + " - " + puntaje3 + " - " + puntaje4 + " - " + puntaje5);
            double puntajeTotal = puntaje2 + puntaje3 + puntaje4 + puntaje5;
            //porcentaje de nivel 2 contar2/cantidadn2

            return puntajeTotal;
        }
        

        public List<string> getListaPlanes()
        {
            return this.listaPlanes;
        }

    }
}
