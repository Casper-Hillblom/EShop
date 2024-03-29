﻿namespace EShop.Models.Product
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;

        public int ArticleNumber { get; set; } 

        public string Description { get; set; } = null!;

        public int Price { get; set; }

        public string CategoryName { get; set; } = null!;
    }
}
