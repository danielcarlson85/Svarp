using Svarp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWarp.Models
{
    public class Method
    {
        public string MenthodName { get; set; }

        public List<CodeRow> CodeRows { get; set; } = new();


    }
}
