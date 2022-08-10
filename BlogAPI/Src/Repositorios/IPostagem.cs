using BlogAPI.Src.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Src.Repositorios
{
    /// <summary> 
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para> 
    /// <para>Versão: 1.0</para>
    public interface IPostagem
    {
        Task<List<Postagem>> PegarTodasPostagemAsync();
        Task<Postagem> PegarPostagemPeloIdAsync(int id);
        Task NovaPostagemAsync(Postagem postagem);
        Task AtualizarPostagemAsync(Postagem postagem);
        Task DeletarPostagemAsync(int id);
    }
}