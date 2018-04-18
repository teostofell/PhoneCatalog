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
        public string Slug { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int Storage { get; set; }
        public decimal Price { get; set; }
        public int ReleaseYear { get; set; }
        public float ScreenSize { get; set; }
        public int Battery { get; set; }
        public bool Fingerprint { get; set; }
        public int Grade { get; set; }

        public int BrandId { get; set; }
        public BrandDTO Brand { get; set; }

        public int OSId { get; set; }
        public OSDTO OS { get; set; }


        public int ScreenResolutionId { get; set; }
        public ScreenResolutionDTO ScreenResolution { get; set; }

        public List<PhotoDTO> Photos { get; set; }
        public List<CommentDTO> Comments { get; set; }

    }
}
