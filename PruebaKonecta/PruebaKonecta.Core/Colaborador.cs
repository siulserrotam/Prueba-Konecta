using System;

namespace PruebaKonecta.Core
{
    public class Colaborador
    {
        public int IdColaborador { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdArea { get; set; }
        public int IdSexo { get; set; }

        public bool TieneCamposObligatorios()
        {
            return !string.IsNullOrWhiteSpace(NumeroIdentificacion)
                && !string.IsNullOrWhiteSpace(Nombres)
                && !string.IsNullOrWhiteSpace(Apellidos)
                && IdArea > 0
                && IdSexo > 0;
        }

        public bool EsSalarioValido() => Salario > 0;

        public bool EsEmailValido()
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(Email);
                return mail.Address == Email;
            }
            catch
            {
                return false;
            }
        }
    }
}
