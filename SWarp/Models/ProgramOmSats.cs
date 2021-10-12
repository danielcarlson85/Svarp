using Svarp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWarp.Models
{
    class ProgramOmSats
    {
        public List<Variables> Variables { get; set; } = new();

        public List<ProgramCodeOnRow> ProgramCodeOnRow { get; set; } = new();

        public string OmOperator { get; set; } = string.Empty;
    }

    class ProgramOmInteSats
    {
        public Variables Variables { get; set; } = new();

        public List<ProgramCodeOnRow> ProgramCodeOnRow { get; set; } = new();
    }

    class ProgramAnnarsSats
    {
        public Variables Variables { get; set; } = new();

        public List<ProgramCodeOnRow> ProgramCodeOnRow { get; set; } = new();

    }

    class Slutligen
    {
        public Variables Variables { get; set; } = new();

        public List<ProgramCodeOnRow> ProgramCodeOnRow { get; set; } = new();
    }

}
