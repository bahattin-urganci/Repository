using PawPos.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Model
{
    [WillBeMap("WorkPeriod")]
    public class WorkPeriodDTO :BaseDTO
    {
        public DateTime? Start { get; set; }
        public string StartDescription { get; set; }
        public DateTime? End { get; set; }
        public string EndDescription { get; set; }
    }

}
