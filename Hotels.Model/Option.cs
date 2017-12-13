using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Option
    {
        public int Id { get; set; }
        public bool Estakhr { get; set; }
        public bool Internet { get; set; }
        public bool Masaj { get; set; }
        public bool Parking { get; set; }

        public List<Suit> Suits { get; set; }
        public int SuitId { get; set; }

    }
}
