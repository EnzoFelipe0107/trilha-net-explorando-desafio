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
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de adicionar hóspedes.");
            }

            if (Suite.Capacidade < hospedes.Count)
            {
                throw new ArgumentException("O número de hóspedes não pode ser maior que a capacidade da suíte.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada para calcular o valor da diária.");
            }

            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valorTotal *= 0.90m;
            }

            return valorTotal;
        }
    }
}
