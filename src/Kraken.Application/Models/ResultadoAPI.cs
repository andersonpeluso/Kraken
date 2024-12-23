﻿using System.Net;
using System.Text.Json.Serialization;

namespace Kraken.Application.Models
{
    public sealed class ResultadoAPI<T> where T : class
    {
        public HttpStatusCode Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mensagem { get; set; } = string.Empty;

        public T? Dados { get; set; }

        public ResultadoAPI(HttpStatusCode status, T? dados = default, string? mensagem = null)
        {
            Status = status;
            Mensagem = mensagem;
            Dados = dados;
        }
    }
}