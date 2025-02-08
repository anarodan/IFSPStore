using IFSPStore.Domain.Entities;
using System.Diagnostics;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IFSPStore.test
{
    [TestClass]
    public class UnitTestDomain
    {
        [TestMethod]
        public void TestCidade()
        {
            Cidade cidade = new Cidade( 1, "Birigui", "SP");

            Debug.WriteLine(JsonSerializer.Serialize(cidade));

            Assert.AreEqual(cidade.Nome, "Birigui");
            Assert.AreEqual(cidade.Estado, "SP");
        }

        [TestMethod]
        public void TestUsuario()
        {
            DateTime dataCadastro = new DateTime(2024, 10, 20);
            DateTime dataLogin = new DateTime(2024, 10, 22);

            Usuario usuario = new Usuario(1, "Bruna", "be2505", "brunabarreto", "brunasantos@gmail.com", dataCadastro, dataLogin, true );

            Debug.WriteLine(JsonSerializer.Serialize(usuario));

            Assert.AreEqual(usuario.Nome, "Bruna");
            Assert.AreEqual(usuario.Senha, "be2505");
            Assert.AreEqual(usuario.Login, "brunabarreto");
            Assert.AreEqual(usuario.Email, "brunasantos@gmail.com");
            Assert.AreEqual(usuario.DataCadastro, dataCadastro);
            Assert.AreEqual(usuario.DataLogin, dataLogin);
            Assert.IsTrue(usuario.Ativo);

        }

        [TestMethod]

        public void TestGrupo()
        {
            Grupo grupo = new Grupo(1, "Eletronico");

            Debug.WriteLine(JsonSerializer.Serialize(grupo));

            Assert.AreEqual(grupo.Nome, "Eletronico");
        }

        [TestMethod]
        public void TestProduto()
        {
           
            DateTime dataCompra = new DateTime(2024, 10, 24);
            Grupo grupo = new Grupo(1, "Eletronico");

            Produto produto = new Produto(1, "TV Samsung", 4000, 2,dataCompra, "Loja 01", grupo);

            Debug.WriteLine(JsonSerializer.Serialize(produto));

            Assert.AreEqual(produto.Nome, "TV Samsung");
            Assert.AreEqual(produto.Preco, 4000);
            Assert.AreEqual(produto.Quantidade, 2);
            Assert.AreEqual(produto.DataCompra, dataCompra);
            Assert.AreEqual(produto.UnidadeVenda, "Loja 01");
        
        } 

        [TestMethod]
        public void TestCliente()
        {
            Cidade cidade = new Cidade(1, "Birigui", "SP");

            Cliente cliente = new Cliente(1, "Bruna", "Rua Wilson Troncoso,570", "Toselar", "63145262X", cidade);

            Debug.WriteLine(JsonSerializer.Serialize(cliente));

            Assert.AreEqual(cliente.Nome, "Bruna");
            Assert.AreEqual(cliente.Endereco, "Rua Wilson Troncoso,570");
            Assert.AreEqual(cliente.Bairro, "Toselar");
            Assert.AreEqual(cliente.Documento, "63145262X");
        }

        [TestMethod]
        public void TestVendas()
        {
            // Arrange
            DateTime data = DateTime.Now;
            float valorTotal = 200.0f;
            Usuario usuario = new Usuario(1, "Bruna", "be2505", "brunabarreto", "brunasantosut@gmail.com", DateTime.Now, DateTime.Now, true);
            Cliente cliente = new Cliente(1, "Carlos", "Rua A, 123", "Centro", "12345678901", new Cidade(1, "Birigui", "SP"));

            List<VendaItem> items = new List<VendaItem>
            {
                new VendaItem(1, new Produto(1, "TV Samsung", 4000, 2, DateTime.Now, "Loja 01", new Grupo(1, "Eletrônicos")), 1, 4000, 4000, null),
                new VendaItem(2, new Produto(2, "Celular XYZ", 1500, 5, DateTime.Now, "Loja 01", new Grupo(1, "Eletrônicos")), 2, 1500, 3000, null)
            };

            // Act
            Venda venda = new Venda(1, data, valorTotal, usuario, cliente, items);

            // Assert
            Debug.WriteLine("Venda: " + JsonSerializer.Serialize(venda));

            foreach (var item in venda.Items)
            {
                Debug.WriteLine("VendaItem: " + JsonSerializer.Serialize(item));
            }
            Assert.AreEqual(valorTotal, venda.ValorTotal);
            Assert.AreEqual(usuario, venda.Usuario);
            Assert.AreEqual(cliente, venda.Cliente);
            Assert.IsNotNull(venda.Items);
            Assert.AreEqual(2, venda.Items.Count);
            Assert.AreEqual(4000, venda.Items[0].ValorUnitario);
            Assert.AreEqual(3000, venda.Items[1].ValorTotal);
        }


    }
}