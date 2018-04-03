using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.DTO
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Storage { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float ScreenSize { get; set; }
        public int Battery { get; set; }
        public bool Fingerprint { get; set; }

        public BrandDTO Brand { get; set; }
        public OSDTO OS { get; set; }
        public ScreenResolutionDTO ScreenResolution { get; set; }
        public List<PhotoDTO> Photos { get; set; }
    }
}
