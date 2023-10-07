namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A quantidade de hopedes excede a capacidade da suite!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {            
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            
            decimal valor = Suite.ValorDiaria * DiasReservados;

            decimal desconto = valor * 0.10M;
            if (DiasReservados >= 10)
            {
                valor -= desconto;
            }

            return valor;
        }
    }
}