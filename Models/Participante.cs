using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAPC.Models
{
    public class Participante
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Display(Name = "Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        
        public string DiaDoTreino { get; set; }
        //public DayOfWeek DayOfWeek { get; set; }

       // public string Telefone { get; set; }
       // public string Endereco { get; set; }
       // public string Bairro { get; set; }
       // public string Cidade { get; set; }
       // public string CEP { get; set; }
       
    }
}
