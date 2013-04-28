namespace Mvc4Demo.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Mvc4Demo.Models;
    using DataModel;
    using System.Text;

    public interface ICategoriesServices
    {

        IList<CategoriesViewModel> GetAll();

        Categories Add(CategoriesViewModel categories);

        CategoriesViewModel Get(int id);

        Categories Update(CategoriesViewModel categories);

        CategoriesViewModel Delete(int id);

        IEnumerable<CategoriesViewModel> GetLastOne(int id); 
    }
}