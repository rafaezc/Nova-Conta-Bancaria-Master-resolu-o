using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Novo_Banco
{
    internal class ContaChequeEspecial : ContaBancaria
    {
        public string Conta { get; }
        public string Nome { get; set; }
        public decimal Limite { get; set; }
        public decimal Saldo
        {
            get
            {
                decimal saldo = 0;
                foreach (var item in todasTransacoes)
                {
                    saldo += item.Valor;
                }
                return saldo;
            }
        }

        public decimal CheqEsp { get; set; }

        private static int NumeroSequencia = 86600;

        private List<Transacao> todasTransacoes = new List<Transacao>();

        public ContaChequeEspecial(string nome, decimal valorInicial, decimal limite)
        {
            this.Nome = nome;

            this.Conta = NumeroSequencia.ToString();
            NumeroSequencia++;

            this.Limite = limite;

            Deposito(valorInicial, DateTime.Now, "Deposito Inicial");
        }

        public ContaChequeEspecial()
        {
        }

        public void Deposito(decimal valor, DateTime data, string obs)
        {
            if (valor > 0)
            {
                var deposito = new Transacao(valor, data, obs);
                todasTransacoes.Add(deposito);
                int DepCounter = 0;
                DepCounter++;
                if (DepCounter != 0)
                {
                    this.CheqEsp = this.Limite + Math.Abs(Saldo);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O deposito deve ser positivo");
            }
        }

        public void Saque(decimal valor, DateTime data, string obs)
        {
            if (valor > 0 && valor <= this.Saldo + this.Limite)
            {
                var saque = new Transacao(-valor, data, obs);
                todasTransacoes.Add(saque);
                int SaqCounter = 1;
                SaqCounter++;
                if (SaqCounter > 0)
                {
                    this.CheqEsp = this.Limite - Math.Abs(Saldo);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "o valor do saque nao pode ser 0(zero) e nao pode ser maior que o saldo + o limite do cheque especial");
            }
        }

        public string Extrato()
        {
            var extrato = new System.Text.StringBuilder();
            decimal SaldoConta = 0;
            decimal SaldoLimite;
            extrato.AppendLine("Data\t\tHora\t\tValor\tSaldo\tSaldo+Limite CheqEsp\tOperação\t\tLimite Cheque Especial");
            foreach (var item in todasTransacoes)
            {
                SaldoConta += item.Valor;
                SaldoLimite = this.Limite + SaldoConta;
                extrato.AppendLine($"{item.Data.ToShortDateString()}\t{item.Data.ToLongTimeString()}\t{item.Valor     }\t{SaldoConta     }\t{SaldoLimite}\t\t\t{item.Obs}\t{this.Limite}");
            }
            return extrato.ToString();
        }
    }
}