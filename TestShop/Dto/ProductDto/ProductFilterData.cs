using System;

namespace IXORA.PlatonovNikita.TestShop.Dto.ProductDto
{
    public class ProductFilterData
    {
        public int? MaxPrice { get; set; }

        public int? MinPrice { get; set; }

        public Guid? ProductTypeId { get; set; }

        public bool? IsInStock { get; set; }

        public bool? IsOrderByAscendungPrice { get; set; }

        public Pagination Pagination { get; set; }
    }
}
