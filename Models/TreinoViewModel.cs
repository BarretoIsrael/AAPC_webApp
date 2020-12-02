using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using AAPC.Models;
using System;

namespace AAPC.Models
{
    public class TreinoViewModel
    {
        public List<Participante> LParticipantes { get; set; }
        public List<TreinoTerca> LPTTerca { get; set; }
        public List<TreinoQuinta> LPTQuinta { get; set; }
        public List<TreinoSabado> LPTSabado { get; set; }

        public SelectList Treinos { get; set; }
        public string TreinoParticipante { get; set; }
        public string SearchString { get; set; }
    }
}