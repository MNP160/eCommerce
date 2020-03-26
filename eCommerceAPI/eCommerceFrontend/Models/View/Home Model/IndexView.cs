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
        public List<CathegoryResponse> SelectedCategories = new List<CathegoryResponse>();
        public List<int> SelectedIds = new List<int>();

        public IndexView(List<CathegoryResponse> allCategories, List<CathegoryResponse> selectedCategories, List<int> selectedIds)
        {
            AllCategories = allCategories;
            SelectedIds = selectedIds;
            SelectedCategories = selectedCategories;
        }
    }
}
