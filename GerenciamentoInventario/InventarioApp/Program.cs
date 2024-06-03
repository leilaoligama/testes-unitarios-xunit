using System;
using System.Collections.Generic;

namespace InventarioApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            inventario.AdicionarItem("Laptop", 5);
            inventario.RemoverItem("Laptop", 2);

            Console.WriteLine($"Estoque de Laptops: {inventario.ObterQuantidadeItem("Laptop")}");
        }
    }

    public class Inventario
    {
        private Dictionary<string, int> _itens = new Dictionary<string, int>();

        public void AdicionarItem(string nome, int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (_itens.ContainsKey(nome))
                _itens[nome] += quantidade;
            else
                _itens[nome] = quantidade;
        }

        public void RemoverItem(string nome, int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (!_itens.ContainsKey(nome) || _itens[nome] < quantidade)
                throw new InvalidOperationException("Estoque insuficiente ou item não existe.");

            _itens[nome] -= quantidade;

            if (_itens[nome] == 0)
                _itens.Remove(nome);
        }

        public int ObterQuantidadeItem(string nome)
        {
            if (_itens.ContainsKey(nome))
                return _itens[nome];

            return 0;
        }
    }
}
