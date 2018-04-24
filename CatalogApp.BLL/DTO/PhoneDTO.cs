using System.Collections.Generic;

namespace CatalogApp.BLL.DTO
{
    public class PhoneDto
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
        public BrandDto Brand { get; set; }

        public int OsId { get; set; }
        public OsDto Os { get; set; }


        public int ScreenResolutionId { get; set; }
        public ScreenResolutionDto ScreenResolution { get; set; }

        public List<PhotoDto> Photos { get; set; }
        public List<CommentDto> Comments { get; set; }

    }
}
