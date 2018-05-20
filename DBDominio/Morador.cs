using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBDominio
{
    public class Morador
    {

        [Key]
        [DisplayName("ID Morador")]
        public int MoradorId { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo NOME é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        public string DataNascimento { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [DisplayName("E-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Digite um E-MAIL válido")]
        public string Email { get; set; }

        [DisplayName("Responsável")]
        public char Responsavel { get; set; }

        [DisplayName("Bloco/Unidade")]
        [Required(ErrorMessage = "Campo BLOCO/UNIDADE é obrigatório")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Campo BLOCO/UNIDADE é obrigatório")]
        public int UnidadeId { get; set; }

        public virtual Unidade Unidade { get; set; }

    }
}