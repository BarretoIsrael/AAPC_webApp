using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AAPC.Models
{
    public class TreinoTerca
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Display(Name = "Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        
    }
}
