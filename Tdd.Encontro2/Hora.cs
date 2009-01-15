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

            TimeSpan tsHoraAtual = new TimeSpan(int.Parse(horaAtual[0]), int.Parse(horaAtual[1]), 0);
            TimeSpan tsHoraAdicional = new TimeSpan(int.Parse(horaAdicional[0]), int.Parse(horaAdicional[1]), 0);

            this.hora = FormataSoma(tsHoraAtual.Add(tsHoraAdicional));

        }

        private void ValidarHora(string hora)
        {
            if (!Regex.IsMatch(hora, "[0-9][0-9]*:[0-5][0-9]"))
            {
                throw (new ArgumentException("Formato de Hora inválido: " + hora));
            }
        }

        private string FormataSoma(TimeSpan tsSomaHoras)
        {
            string horaFormatadas = ((tsSomaHoras.Days * 24) + (tsSomaHoras.Hours)).ToString();
            string minutosFormatados = ((tsSomaHoras.Minutes < 0)? (tsSomaHoras.Minutes * -1): tsSomaHoras.Minutes).ToString().PadLeft(2, '0');

            return hora = string.Format("{0}:{1}", horaFormatadas, minutosFormatados);
        }
    }
}
