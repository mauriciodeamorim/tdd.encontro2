using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class OuExclusivo
    {
        static void Main(string[] args)
        {

            if (true ^ false)
                Console.WriteLine("Verdadeiro");

            if (false ^ true)
                Console.WriteLine("Verdadeiro");

            //ou seja

            DateTime? dataInicial = null;
            DateTime? dataFinal = DateTime.Now;

            if ((dataInicial.HasValue && !dataFinal.HasValue) || (!dataInicial.HasValue && dataFinal.HasValue))
                Console.WriteLine("Verdadeiro, pois são excludentes. Dois IF´s");
            
            //Simplificando com o uso do Ou Exclusivo
            //Se uma de duas expressões comparadas for falsa o retorno será TRUE
            //Se ambas forem iguais retorna FALSE
            if (dataInicial.HasValue ^ dataFinal.HasValue)
                Console.WriteLine("Verdadeiro, pois são excludentes. OU Exclusivo. Null e data ");

            //Invertendo os valores
            dataInicial = DateTime.Now;
            dataFinal = null;

            if (dataInicial.HasValue ^ dataFinal.HasValue)
                Console.WriteLine("Verdadeiro, pois são excludentes. OU Exclusivo. Data e null ");

            //Igualando os valores
            dataInicial = DateTime.Now;
            dataFinal = DateTime.Now;

            if (dataInicial.HasValue ^ dataFinal.HasValue)
                Console.WriteLine("Verdadeiro, pois são excludentes. OU Exclusivo ");
            else
                Console.WriteLine("Falso, pois não são excludentes. Data e data");


            //Anulando os valores
            dataInicial = null;
            dataFinal = null;

            if (dataInicial.HasValue ^ dataFinal.HasValue)
                Console.WriteLine("Verdadeiro, pois são excludentes. OU Exclusivo ");
            else
                Console.WriteLine("Falso, pois não são excludentes. Null e null");
        
        }
    }
}
