using BlogAPI.Src.Contextos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogTeste.Contextos
{
    ///<summary>
    ///
    /// </summary>
    [TestClass]
    public class UsuarioContextoTeste
    {
        #region Atributos

        private BlogPessoalContexto _contexto;

        #endregion

        #region Métodos
        [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT1")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Beatriz Trindade",
                Email = "beazinha@email.com",
                Senha = "123456",
                Foto = "UrlFotoBea",
            });
            _contexto.SaveChanges();

            // QUANDO - Quando eu pesquiso pelo e-mail do usuario adicionado
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email == "beazinha@email.com");

            // ENTÃO - Então deve retornar resultado não nulo
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void LerListaDeUsuariosRetornaTresUsuarios()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Rafa",
                Email = "rafifa@email.com",
                Senha = "1234567",
                Foto = "UrlFotoRafa"
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Ana Luh",
                Email = "hobbits@email.com",
                Senha = "123456",
                Foto = "UrlFotoLuh"
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Mauricio",
                Email = "maumau@email.com",
                Senha = "12345678",
                Foto = "UrlFotoMauri"
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.ToList();

            Assert.AreEqual(3, resultado.Count);
        }

        [TestMethod]
        public void AtualizarUsuarioRetornaUsuarioAtualizado()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT3")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Beatriz Trindade",
                Email = "beazinha@email.com",
                Senha = "123456",
                Foto = "UrlFotoBea",
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email == "beazinha@email.com");
            auxiliar.Nome = "Beatriz Trindade";
            _contexto.Usuarios.Update(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Beatriz Trindade");

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void DeletaUsurarioRetornaUsuarioInserido()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT4")
                .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Beatriz Trindade",
                Email = "beazinha@email.com",
                Senha = "123456",
                Foto = "UrlFotoBea",
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email == "beazinha@email.com");
            _contexto.Usuarios.Remove(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Beatriz Trindade");

            Assert.IsNull(resultado);
        }
        #endregion
    }
}