using System;
using System.Collections.Generic;

namespace PortafolioBlog.Models
{
    public class PostMetadata
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Resumen { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Autor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty; 
        public List<string> Etiquetas { get; set; } = new();
        public bool EsComponente { get; set; } = false;
    }
}