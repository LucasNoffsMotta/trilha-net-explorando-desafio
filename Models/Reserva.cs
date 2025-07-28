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
            bool capacidadeValida = hospedes.Count > Suite.Capacidade ? true : false;

            if (capacidadeValida)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Numero de hospedes maior que capacidade da suite");
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
            decimal valor = DiasReservados * Suite.ValorDiaria;
            decimal desconto = DiasReservados >= 10 ? valor - (valor * 0.1m) : 0;
            valor -= desconto;
            return valor;
        }
    }
}