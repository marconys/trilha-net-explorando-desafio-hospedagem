using System;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Seja Bem Vindo Ao Sistema De Hospedagem !");

Console.Write("Gostaria de fazer uma reserva para uma ou duas pessoas? (Digite Apenas Números): ");
int quantidaDeHospedes = int.Parse(Console.ReadLine() ?? "0");

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
Pessoa pessoa = new Pessoa();

for (int i = 0; i < quantidaDeHospedes; i++)
{
    Console.Write($"Digite o nome do {i + 1}º hóspede: ");
    pessoa.Nome = Console.ReadLine();
    hospedes.Add(pessoa);
}

Console.Write("Qual o tipo de suite deseja?\n(1) Premium: Até duas pessoas.\n(2) Econômica: Uma pessoa\n(Opção 1 ou 2:): ");
int categoriaSuite = int.Parse(Console.ReadLine() ?? "2");


Suite suite = new Suite();
int diasReservados = 0;

if (categoriaSuite == 1)
{
    suite.TipoSuite = "Premium";
    suite.Capacidade = 2;
    suite.ValorDiaria = 30;
    Console.WriteLine("Quantos dias?");
    diasReservados = int.Parse(Console.ReadLine());

} else
{
    suite.TipoSuite = "Econômica";
    suite.Capacidade = 1;
    suite.ValorDiaria = 40;
    Console.WriteLine("Quantos dias?");
    diasReservados = int.Parse(Console.ReadLine());
}

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: diasReservados);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Tipo da suite: {reserva.ObterTipoDaSuite()}");
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");