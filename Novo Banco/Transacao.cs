using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;

namespace Novo_Banco
{
    class Transacao
    {
        public decimal Valor { get; }
        public DateTime Data { get; }
        public string Obs { get; }
        public Transacao(decimal valor, DateTime data, string obs)
        {
            this.Valor = valor;
            this.Data = data;
            this.Obs = obs;
        }

    }
}
