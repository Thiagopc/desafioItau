﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Repositories
{
    public interface IHttpRepository
    {
        Task<TConteudo?> ObterAsync<TConteudo>(string url, CancellationToken token = default) where TConteudo : class;
        Task<TConteudo?> EnviarPostAsync<TConteudo>(string url, TConteudo conteudoRequisicao) where TConteudo : class;
        Task EnviarPutAsync<TConteudo>(string url, TConteudo conteudoRequisicao) where TConteudo : class;

    }
}
