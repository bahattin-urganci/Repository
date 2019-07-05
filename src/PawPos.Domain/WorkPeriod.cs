using PawPos.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain
{
    [WillBeMap("WorkPeriod")]
    public class WorkPeriod :BaseEntity
    {
        public DateTime Start { get; set; }
        public string StartDescription { get; set; }
        public DateTime? End { get; set; }
        public string EndDescription { get; set; }

    }
}
