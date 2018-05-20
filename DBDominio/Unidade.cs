using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBDominio
{
    public class Unidade
    {

        [DisplayName("ID Unidade")]
        public int UnidadeId { get; set; }

        [DisplayName("Bloco")]
        [Required(ErrorMessage = "Campo BLOCO é obrigatório")]
        [Index("IX_Unidade_BlocoNumero", 1, IsUnique = true)]
        public string Bloco { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Campo NÚMERO é obrigatório")]
        [Index("IX_Unidade_BlocoNumero", 2, IsUnique = true)]
        public string Numero { get; set; }

        [NotMapped]
        [DisplayName("Bloco/Unidade")]
        public string BlocoUnidade { get { return Bloco + "/" + Numero; } }

        public virtual ICollection<Morador> Moradores { get; set; }

    }
}