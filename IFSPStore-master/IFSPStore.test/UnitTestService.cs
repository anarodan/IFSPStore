
using AutoMapper;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Services;
using IFSPStore.Service.Validators;
using IFSPStory.Repository.Context;
using IFSPStory.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace IFSPStore.test
{
    [TestClass]
    public class UnitTestService
    {
        private ServiceCollection? services;

        public ServiceProvider ConfigureServices()
        {
            services = new ServiceCollection();
            services.AddDbContext<MySqlContext>(options =>
            {
                var server = "127.0.0.1";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "BE2505";
                var strCon = $"Server={server};Port={port};Database={database};" +
                    $"Uid={username};Pwd={password}";
                options.UseMySql(strCon, ServerVersion.AutoDetect(strCon), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            services.AddScoped<IBaseService<Usuario>, BaseService<Usuario>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Usuario, Usuario>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Cidade>, BaseRepository<Cidade>>();
            services.AddScoped<IBaseService<Cidade>, BaseService<Cidade>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Cidade, Cidade>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Grupo>, BaseRepository<Grupo>>();
            services.AddScoped<IBaseService<Grupo>, BaseService<Grupo>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Grupo, Grupo>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Produto, Produto>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();
            services.AddScoped<IBaseService<Cliente>, BaseService<Cliente>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Cliente, Cliente>();
            }).CreateMapper());

            services.AddScoped<IBaseRepository<Venda>, BaseRepository<Venda>>();
            services.AddScoped<IBaseService<Venda>, BaseService<Venda>>();
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Venda, Venda>();
            }).CreateMapper());

            return services.BuildServiceProvider();
        }


        [TestMethod]

        public void TestInsertCidade()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseService<Cidade>>();
            var cidade = new Cidade
            {
                Nome = "Birigui",
                Estado = "SP"
            };

            var result = cidadeService.Add<Cidade, Cidade, CidadeValidator>(cidade);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]

        public void TestInsertCliente()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseService<Cidade>>();
            var cidade = cidadeService.Get<Cidade>().FirstOrDefault(c => c.Id >= 1);
            var clienteService = sp.GetService<IBaseService<Cliente>>();
            var cliente = new Cliente()
            {
                Nome = "Analice",
                Endereco = "Rua Jose Meloni, 539",
                Bairro = "Parque das Nações",
                Documento = "50150150190",
                Cidade = cidade
            };

            var result = clienteService.Add<Cliente, Cliente, ClienteValidator>(cliente);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestInsertGrupo()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseService<Grupo>>();
            var grupo = new Grupo()
            {
                Nome = "Eletrônico"
            };

            var result = grupoService.Add<Grupo, Grupo, GrupoValidator>(grupo);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestInsertProduto()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseService<Grupo>>();
            var grupo = grupoService.Get<Grupo>().FirstOrDefault(g => g.Id >= 1);
            var produtoService = sp.GetService<IBaseService<Produto>>();
            var produto = new Produto()
            {
                Nome = "Notebook Lenovo",
                Preco = 4200,
                Quantidade = 5,
                DataCompra = DateTime.Now,
                UnidadeVenda = "Unidade",
                Grupo = grupo
            };

            var result = produtoService.Add<Produto, Produto, ProdutoValidator>(produto);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]

        public void TestInsertUsuario()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseService<Usuario>>();
            var usuario = new Usuario
            {
                Nome = "Analice Rodrigues",
                Login = "anarodan",
                Email = "anarodan@gmail.com",
                Senha = "Ana123!",
                DataCadastro = DateTime.Now,
                DataLogin = DateTime.Now
            };

            var result = usuarioService.Add<Usuario, Usuario, UsuarioValidator>(usuario);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestInsertVenda()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseService<Usuario>>();
            var usuario = usuarioService.Get<Usuario>().FirstOrDefault(u => u.Id >= 1);
            var clienteService = sp.GetService<IBaseService<Cliente>>();
            var cliente = clienteService.Get<Cliente>().FirstOrDefault(c => c.Id >= 1);
            var produtoService = sp.GetService<IBaseService<Produto>>();
            var produto = produtoService.Get<Produto>().FirstOrDefault(p => p.Id >= 1);
            var vendaService = sp.GetService<IBaseService<Venda>>();
            var venda = new Venda()
            {
                Data = DateTime.Now,
                ValorTotal = 10000,
                Usuario = usuario,
                Cliente = cliente,
                
            };

            var vendaItem = new VendaItem
            {
                Produto = produto,
                Quantidade = 2,
                ValorUnitario = 4200,
                ValorTotal = 8400,
            };

            venda.Items.Add(vendaItem);

            var result = vendaService.Add<Venda, Venda, VendaValidator>(venda);
            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectCidade()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseService<Cidade>>();

            var result = cidadeService.Get<Cidade>();
            Console.Write(JsonSerializer.Serialize(result));

        }

        [TestMethod]
        public void TestSelectCliente()
        {
            var sp = ConfigureServices();
            var clienteService = sp.GetService<IBaseService<Cliente>>();

            var result = clienteService.Get<Cliente>();
            Console.Write(JsonSerializer.Serialize(result));

        }

        [TestMethod]
        public void TestSelectGrupo()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseService<Grupo>>();

            var result = grupoService.Get<Grupo>();
            Console.Write(JsonSerializer.Serialize(result));

        }

        [TestMethod]
        public void TestSelectProduto()
        {
            var sp = ConfigureServices();
            var produtoService = sp.GetService<IBaseService<Produto>>();

            var result = produtoService.Get<Produto>();
            Console.Write(JsonSerializer.Serialize(result));

        }

        [TestMethod]
        public void TestSelectUsuario()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseService<Usuario>>();

            var result = usuarioService.Get<Usuario>();
            Console.Write(JsonSerializer.Serialize(result));

        }

        [TestMethod]
        public void TestSelectVenda()
        {
            var sp = ConfigureServices();
            var vendaService = sp.GetService<IBaseService<Venda>>();

            var result = vendaService.Get<Venda>();
            Console.Write(JsonSerializer.Serialize(result));

        }



    }
}
