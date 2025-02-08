using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IFSPStore.test
{
    [TestClass]
    public class UnitTestRepository
    {
        public partial class MyDbContext : DbContext
        {
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Cidade> Cidades { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Grupo> Grupos { get; set; }
            public DbSet<Produto> Produtos { get; set; }
            public DbSet<Venda> Vendas { get; set; }
            public DbSet<VendaItem> VendaItens { get; set; }
            public MyDbContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = "127.0.0.1";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "BE2505";
                var strCon = $"Server={server};Port={port};Database={database};" +
                    $"Uid={username};Pwd={password}";
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySql(strCon, ServerVersion.AutoDetect(strCon));
                }
            }
        }

        [TestMethod]

        public void TestInsertCidades()
        {
            using (var context = new MyDbContext())
            {
                var cidade = new Cidade
                {
                    Nome = "Birigui",
                    Estado = "SP"
                };
                context.Cidades.Add(cidade);

                cidade = new Cidade
                {
                    Nome = "Araçatuba",
                    Estado = "SP"
                };
                context.Cidades.Add(cidade);

                context.SaveChanges();
            }
        }

        [TestMethod]

        public void TestListCidades()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cidade in context.Cidades)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cidade));
                }
            }
        }

        [TestMethod]

        public void TestInsertUsuario()
        {
            using (var context = new MyDbContext())
            {


                var usuario = new Usuario
                {
                    Nome = "Bruna",
                    Senha = "Be2505",
                    Login = "barreto",
                    Email = "brunasantosut@gmail.com",
                    DataCadastro = DateTime.Now,
                    DataLogin = DateTime.Now,
                    Ativo = true
                };
                context.Usuarios.Add(usuario);

                context.SaveChanges();
            }
        }

        [TestMethod]

        public void TestListUsuarios()
        {
            using (var context = new MyDbContext())
            {
                foreach (var usuario in context.Usuarios)
                {
                    Console.WriteLine(JsonSerializer.Serialize(usuario));
                }
            }
        }

        [TestMethod]

        public void TestInsertGrupo()
        {
            using (var context = new MyDbContext())
            {

                var grupo = new Grupo
                {
                    Nome = "Eletronico",

                };
                context.Grupos.Add(grupo);

                context.SaveChanges();
            }
        }

        [TestMethod]

        public void TestListGrupos()
        {
            using (var context = new MyDbContext())
            {
                foreach (var grupo in context.Grupos)
                {
                    Console.WriteLine(JsonSerializer.Serialize(grupo));
                }
            }
        }

        [TestMethod]

        public void TestInsertCliente()
        {
            using (var context = new MyDbContext())
            {
                var cidade = context.Cidades.FirstOrDefault(c => c.Id == 1);
                var cliente = new Cliente
                {
                    Nome = "Bruna Barreto",
                    Cidade = cidade,
                    Documento = "63.145.262-X",
                    Endereco = "Rua Wilson Troncoso, 570",
                    Bairro = "Toselar"
                };
                context.Clientes.Add(cliente);

                context.SaveChanges();

                cidade = context.Cidades.FirstOrDefault(c => c.Id == 2);
                cliente = new Cliente
                {
                    Nome = "Luciana Paulina",
                    Cidade = cidade,
                    Documento = "048.785.944-47",
                    Endereco = "Rua Wilson Troncoso, 574",
                    Bairro = "Toselar"
                };
                context.Clientes.Add(cliente);

                context.SaveChanges();

            }
        }

        [TestMethod]

        public void TestListClientes()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cliente in context.Clientes)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cliente));
                }
            }
        }

        [TestMethod]

        public void TestInsertProduto()
        {
            using (var context = new MyDbContext())
            {
                var grupo = context.Grupos.FirstOrDefault(g => g.Id == 1);
                var produto = new Produto
                {
                    Nome = "Laranja",
                    Preco = 4,
                    Quantidade = 2,
                    DataCompra = DateTime.Now,
                    UnidadeVenda = "Kg",
                    Grupo = grupo
                };
                context.Produtos.Add(produto);

                context.SaveChanges();
            }
        }

        [TestMethod]

        public void TestListProdutos()
        {
            using (var context = new MyDbContext())
            {
                foreach (var produto in context.Produtos)
                {
                    Console.WriteLine(JsonSerializer.Serialize(produto));
                }
            }
        }

        [TestMethod]

        public void TestInsertVenda()
        {
            using (var context = new MyDbContext())
            {
                var usuario = context.Usuarios.FirstOrDefault(u => u.Id == 1);
                var cliente = context.Clientes.FirstOrDefault(c => c.Id == 1);
                var produto = context.Produtos.FirstOrDefault(p => p.Id == 1);
                var venda = new Venda
                {
                    Data = DateTime.Now,
                    ValorTotal = 4000,
                    Usuario = usuario,
                    Cliente = cliente,
                    Items = null
                };
                context.Vendas.Add(venda);

                context.SaveChanges();
                var vendaItem = new VendaItem
                {
                    Produto = produto,
                    Quantidade = 1,
                    ValorUnitario = 4000,
                    ValorTotal = 4000,
                    Venda = venda
                };
                context.VendaItens.Add(vendaItem);

                context.SaveChanges();


            }
        }

        [TestMethod]

        public void TestListVenda()
        {
            using (var context = new MyDbContext())
            {
                foreach (var venda in context.Vendas)
                {
                    Console.WriteLine(JsonSerializer.Serialize(venda));
                }
            }
        }

        [TestMethod]

        public void TestListVendaItens()
        {
            using (var context = new MyDbContext())
            {
                foreach (var vendaItem in context.VendaItens)
                {
                    Console.WriteLine(JsonSerializer.Serialize(vendaItem));
                }
            }
        }

       
    }
}
