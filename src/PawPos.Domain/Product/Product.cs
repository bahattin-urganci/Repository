using PawPos.Infrastructure.Attributes;
using PawPos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Domain.Product
{
    //[WillBeMap("Product")]
    public class Product : BaseEntity
    {
        public string SectionId { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Barcode { get; set; }
        public string[] Tags { get; set; }
        public Portion Portion { get; set; }
    }

    
}
