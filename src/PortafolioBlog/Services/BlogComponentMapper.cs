using System;
using System.Collections.Generic;
using PortafolioBlog.Components;

namespace PortafolioBlog.Services
{
    public static class BlogComponentMapper
    {
        private static readonly Dictionary<string, Type> _mapa = new()
        {
            { "uso-de-formularios", typeof(Components.FormulariosComponent) },
            { "uso-de-enlaces", typeof(Components.EnlacesComponent) },
            { "uso-de-imagenes", typeof(Components.ImagenesComponent) },
            { "uso-de-tablas", typeof(Components.TablasComponent) }
        };

        public static Type? GetTypeById(string id)
        {
            _mapa.TryGetValue(id, out var tipo);
            return tipo;
        }
    }
}