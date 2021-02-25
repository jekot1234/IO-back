using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Model.Tables
{
    public class TableAccessibilityEntity
    {
        public bool IsBusy { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
