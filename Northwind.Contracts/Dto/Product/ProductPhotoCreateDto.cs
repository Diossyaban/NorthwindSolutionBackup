using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Product
{
    public class ProductPhotoCreateDto
    {
        public string PhotoFilename { get; set; }
        public short? PhotoFileSize { get; set; }
        public string PhotoFileType { get; set; }
        public int? PhotoProductId { get; set; }
        public int? PhotoPrimary { get; set; }

    }
}
