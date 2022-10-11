using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Domain.Models
{
    public partial class ProductPhoto
    {
        public int PhotoId { get; set; }
        public string PhotoFilename { get; set; }
        public short? PhotoFileSize { get; set; }
        public string PhotoFileType { get; set; }
        public int? PhotoProductId { get; set; }
        public int? PhotoPrimary { get; set; }

        public virtual Product PhotoProduct { get; set; }
    }
}
