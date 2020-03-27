using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Cathegory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.View.Home_Model
{
    public class IndexView
    {
        public List<CathegoryResponse> AllCategories = new List<CathegoryResponse>();
        public List<ProductResponse> Products = new List<ProductResponse>();
        public int PageNum { get; private set; }
        public int PageSize { get; private set; }
        public int? SelectedCategory { get; private set; }
        public int TotalPages { get; private set; }
        public string? SearchTerm { get; private set; }

        public IndexView(List<CathegoryResponse> allCategories, List<ProductResponse> products, int pageNum, int pageSize, int? selectedCategory, int totalPages, string? searchTerm)
        {
            AllCategories = allCategories;
            Products = products;
            PageNum = pageNum;
            PageSize = pageSize;
            SelectedCategory = selectedCategory;
            TotalPages = totalPages;
            SearchTerm = searchTerm;
        }
    }
}
