﻿using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace GEIN.Models
{
    public class Marca
    {
        [DisplayName("Código de Marca")]
        [AllowNull]
        public int IdMarca { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

    }
}
