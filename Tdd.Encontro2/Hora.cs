using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Tdd.Encontro2
{
    public class Hora
    {
        private string hora;

        public Hora()
        {
            this.hora = "00:00";
        }

        public Hora(string hora)
        {
            this.ValidarHora(hora);

            this.hora = hora;
        }

        public override string ToString()
        {
            return this.hora;
        }

        public void SomaHoras(string hora)
        {
            this.ValidarHora(hora);

            string[] horaAtual = this.hora.Split(':');
            string[] horaAdicional = hora.Split(':');

            int somenteHoras = Convert.ToInt32(horaAtual[0]);
            int somenteHorasAdicionais = Convert.ToInt32(horaAdicional[0]);

            int somenteMinutos = int.Parse(horaAtual[1]);
            int somenteMinutosAdicionais = int.Parse(horaAdicional[1]);

            DateTime dt = new DateTime();
            TimeSpan ts = new TimeSpan();

            int somaHoras = somenteHoras + somenteHorasAdicionais;
            int somaMinutos = somenteMinutos + somenteMinutosAdicionais;

            this.hora = somaHoras.ToString() + ":" + somaMinutos.ToString().PadLeft(2, '0');
        }

        private void ValidarHora(string hora)
        {
            if (!Regex.IsMatch(hora, "[0-9][0-9]*:[0-5][0-9]"))
            {
                throw (new ArgumentException("Formato de Hora inválido: " + hora));
            }
        }
    }
}
