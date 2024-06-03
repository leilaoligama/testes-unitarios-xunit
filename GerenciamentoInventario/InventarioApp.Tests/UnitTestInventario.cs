using System;
using Xunit;
using InventarioApp;

namespace InventarioApp.Tests
{
    public class InventarioTests
    {
        [Fact]
        public void AdicionarItem_DeveAumentarQuantidade_QuandoNovoItemAdicionado()
        {
            // Arrange
            Inventario inventario = new Inventario();

            // Act
            inventario.AdicionarItem("Laptop", 5);

            // Assert
            Assert.Equal(5, inventario.ObterQuantidadeItem("Laptop"));
        }

        [Fact]
        public void AdicionarItem_DeveAumentarQuantidade_QuandoItemExistenteAdicionado()
        {
            // Arrange
            Inventario inventario = new Inventario();
            inventario.AdicionarItem("Laptop", 5);

            // Act
            inventario.AdicionarItem("Laptop", 3);

            // Assert
            Assert.Equal(8, inventario.ObterQuantidadeItem("Laptop"));
        }

        [Fact]
        public void RemoverItem_DeveDiminuirQuantidade_QuandoItemExistente()
        {
            // Arrange
            Inventario inventario = new Inventario();
            inventario.AdicionarItem("Laptop", 5);

            // Act
            inventario.RemoverItem("Laptop", 2);

            // Assert
            Assert.Equal(3, inventario.ObterQuantidadeItem("Laptop"));
        }

        [Fact]
        public void RemoverItem_DeveLancarExcecao_QuandoQuantidadeMaiorQueEstoque()
        {
            // Arrange
            Inventario inventario = new Inventario();
            inventario.AdicionarItem("Laptop", 5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => inventario.RemoverItem("Laptop", 6));
        }

        [Fact]
        public void RemoverItem_DeveLancarExcecao_QuandoItemNaoExistir()
        {
            // Arrange
            Inventario inventario = new Inventario();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => inventario.RemoverItem("Laptop", 1));
        }

        [Fact]
        public void AdicionarItem_DeveLancarExcecao_QuandoQuantidadeNaoPositiva()
        {
            // Arrange
            Inventario inventario = new Inventario();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => inventario.AdicionarItem("Laptop", 0));
            Assert.Throws<ArgumentException>(() => inventario.AdicionarItem("Laptop", -1));
        }

        [Fact]
        public void RemoverItem_DeveLancarExcecao_QuandoQuantidadeNaoPositiva()
        {
            // Arrange
            Inventario inventario = new Inventario();
            inventario.AdicionarItem("Laptop", 5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => inventario.RemoverItem("Laptop", 0));
            Assert.Throws<ArgumentException>(() => inventario.RemoverItem("Laptop", -1));
        }
    }
}
