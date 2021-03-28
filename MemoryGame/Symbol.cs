using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class Symbol
    {
        public string btnName { get; set; }
        public string unicodeName { get; set; }
        
        public Symbol(string _btnName, string _unicodeName)
        {
            btnName = _btnName;
            unicodeName = _unicodeName;
        }
    }

}
