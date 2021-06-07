﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Dominio.MetaData
{
    public interface ITipoEvento
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo es obligatorio")]
        [StringLength(100, ErrorMessage = "El Campo {0} no puede pasar los {1} digitos.")]
        //[Index("Index_TipoEvento_Descripcion", IsUnique = true)]
        string Descripcion { get; set; }
    }
}
