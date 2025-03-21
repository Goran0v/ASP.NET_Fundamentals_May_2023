﻿using MVCIntroDemo.ViewModels.Product;

namespace MVCIntroDemo.Seeding
{
    public static class ProductData
    {
        public static IEnumerable<ProductViewModel> Products =
            new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheese",
                    Price = 7.00m
                },
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ham",
                    Price = 5.50m
                },
                new ProductViewModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bread",
                    Price = 1.50m
                }
            };
    }
}
