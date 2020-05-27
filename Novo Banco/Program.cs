using System;

namespace Novo_Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int sair = 0;
                while (sair == 0)
                {
                    ImprimeTipoConta();
                    int tipo = int.Parse(Console.ReadLine());

                    if (tipo == 0)
                    {
                        sair = 1;
                    }
                    else if (tipo == 1)
                    {
                        ContaChequeEspecial conta = new ContaChequeEspecial();
                        Console.Clear();
                        int menu = 0;
                        while (menu == 0)
                        {
                            ImprimeOpcoes();
                            int opcao = int.Parse(Console.ReadLine());
                            if (opcao == 0)
                            {
                                menu = 1;
                                Console.Clear();
                            }
                            else if (opcao == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("======Abertura de nova conta=======");
                                Console.WriteLine("Digite o nome do novo correntista: ");
                                string nome = Console.ReadLine();
                                Console.WriteLine("Digite o valor do primeiro depósito: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Digite o valor do limite do Cheque Especial: ");
                                decimal limite = decimal.Parse(Console.ReadLine());
                                conta = new ContaChequeEspecial(nome, valor, limite);
                                Console.WriteLine($" Numero da nova conta é {conta.Conta} de {conta.Nome} com saldo de {conta.Saldo} e limite de cheque especial de {conta.Limite}");
                            }
                            else if (opcao == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("======Novo Depósito=======");
                                Console.WriteLine("Digite o valor a ser depositado: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta.Deposito(valor, DateTime.Now, "Deposito        ");
                                Console.WriteLine("Deposito realizado com sucesso! ");
                            }
                            else if (opcao == 3)
                            {
                                Console.Clear();
                                Console.WriteLine("======Novo Saque=======");
                                Console.WriteLine("Digite o valor a ser Sacado: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta.Saque(valor, DateTime.Now, "Saque             ");
                                Console.WriteLine("Saque o realizado com sucesso! ");
                            }
                            else if (opcao == 4)
                            {
                                Console.Clear();
                                Console.WriteLine(conta.Extrato());
                            }
                        }
                    }
                    else if (tipo == 2)
                    {
                        ContaBancaria conta = new ContaBancaria();
                        Console.Clear();
                        int menu = 0;
                        while (menu == 0)
                        {
                            ImprimeOpcoes();
                            int opcao = int.Parse(Console.ReadLine());
                            if (opcao == 0)
                            {
                                menu = 1;
                                Console.Clear();
                            }
                            if (opcao == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("======Abertura de nova conta=======");
                                Console.WriteLine("Digite o nome do novo correntista: ");
                                string nome = Console.ReadLine();
                                Console.WriteLine("Digite o valor do primeiro depósito: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta = new ContaBancaria(nome, valor);
                                Console.WriteLine($" Numero da nova conta é {conta.Conta} de {conta.Nome} com saldo de {conta.Saldo}");
                            }
                            else if (opcao == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("======Novo Depósito=======");
                                Console.WriteLine("Digite o valor a ser depositado: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta.Deposito(valor, DateTime.Now, "Deposito        ");
                                Console.WriteLine("Deposito realizado com sucesso! ");
                            }
                            else if (opcao == 3)
                            {
                                Console.Clear();
                                Console.WriteLine("======Novo Saque=======");
                                Console.WriteLine("Digite o valor a ser Sacado: ");
                                decimal valor = decimal.Parse(Console.ReadLine());
                                conta.Saque(valor, DateTime.Now, "Saque             ");
                                Console.WriteLine("Saque o realizado com sucesso! ");
                            }
                            else if (opcao == 4)
                            {
                                Console.Clear();
                                Console.WriteLine(conta.Extrato());
                            }
                        }
                    }
                }
            } 
            catch (ArgumentOutOfRangeException e) 
            {
                Console.WriteLine(e.ToString());
            }
        }
        static public void ImprimeOpcoes()
        {
            Console.WriteLine("============Opções==============");
            Console.WriteLine("0 - Voltar ao menu anterior");
            Console.WriteLine("1 - Criar nova conta");
            Console.WriteLine("2 - Depósito");
            Console.WriteLine("3 - Saque");
            Console.WriteLine("4 - Extrato");
            Console.WriteLine("================================");
            Console.WriteLine("Escolha uma das opções: ");
        }
        static public void ImprimeTipoConta() 
        {
            Console.WriteLine("========Selecionar Conta=========");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Conta com Cheque Especial");
            Console.WriteLine("2 - Conta Bancária");
            Console.WriteLine("================================");
            Console.WriteLine("Escolha uma das opções: ");
        }
    }
}
