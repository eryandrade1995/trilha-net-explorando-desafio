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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            int qntHospedes;
            Console.WriteLine("Digite a quantidade de hóspedes: ");
            while (!int.TryParse(Console.ReadLine(), out qntHospedes))
            {
                Console.WriteLine("Digite um número válido para a quantidade de hóspedes: ");
            }
            while (qntHospedes > Suite.Capacidade)
            {
                Console.WriteLine("Quantidade de hóspedes maior que capacidade da suíte, digite uma nova quantidade de hóspedes: ");
                qntHospedes = Convert.ToInt32(Console.ReadLine());
            }

            Hospedes = Enumerable.Repeat(new Pessoa(), qntHospedes).ToList();
            int posicao = 1;
            foreach (var item in Hospedes)
            {
                Console.WriteLine("Digite o nome do " + posicao + "º" + " hóspede: ");
                item.Nome = Console.ReadLine();
                Console.WriteLine("Digite o sobrenome do " + posicao + "º" + " hóspede: ");
                item.Sobrenome = Console.ReadLine();
                posicao++;
            }

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            int quantidadeHospedes = Hospedes.Count;
            // *IMPLEMENTE AQUI*
            return quantidadeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria


            decimal valor = Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor = valor * ((valor / 100) * 10);
            }
            else
            {
                valor = valor * DiasReservados;
            }

            return valor;
        }
    }
}