﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Permissions;
using PagedList.Mvc;

namespace WebApplication1.Models.ViewModel
{
    public class ProductDetailsVM
    {
        public Product product { get; set; }
        public int quantity { get; set; } = 1;
        public decimal estimatedValue => quantity * product.ProductPrice;
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 3;
        public List<Product> RelatedProducts { get; set; }
        public PagedList.IPagedList<Product> TopProducts { get; set; }

    }
}