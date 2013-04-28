namespace Mvc4Demo.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Mvc4Demo.Models;
    using Mvc4Demo.Services;
    using DataModel;
    using AutoMapper;

    public class CategoriesServices : ICategoriesServices
    {

        private readonly NorthwindEntities db = new NorthwindEntities();

        public IList<CategoriesViewModel> GetAll()
        {
            IList<Categories> categories = db.Categories.ToList();
            IList<CategoriesViewModel> viewModelList = Mapper.Map<IList<Categories>, IList<CategoriesViewModel>>(categories);
            return viewModelList;
        }


        public IEnumerable<CategoriesViewModel> GetLastOne(int id) 
        {
            IEnumerable<Categories> categories = db.Categories.Where(c => c.CategoryID == id).ToList();
            IEnumerable<CategoriesViewModel> last = Mapper.Map<IEnumerable<Categories>, IEnumerable<CategoriesViewModel>>(categories);
            return last;
        }

        public Categories Add(CategoriesViewModel categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException("categories");
            }
            Categories newCategory = new Categories();
            AutoMapper.Mapper.Map(categories, newCategory);
            this.db.Categories.Add(newCategory);
            this.db.SaveChanges();

            return newCategory;
        }

        public CategoriesViewModel Get(int id)
        {
            Categories categories = db.Categories.Find(id);
            Mapper.CreateMap<Categories, CategoriesViewModel>();
            CategoriesViewModel viewid =
                Mapper.Map<Categories, CategoriesViewModel>(categories);

            return viewid;         
        }

        public Categories Update(CategoriesViewModel categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException("categories");
            }
            Categories newCategory = new Categories();
            AutoMapper.Mapper.Map(categories, newCategory);
            this.db.Entry(newCategory).State = EntityState.Modified;
            this.db.SaveChanges();

            return newCategory;
        }

        public CategoriesViewModel Delete(int id)
        {
            Categories categories = db.Categories.Find(id);
            Mapper.CreateMap<Categories, CategoriesViewModel>();
            CategoriesViewModel viewid =
                Mapper.Map<Categories, CategoriesViewModel>(categories);
            this.db.Categories.Remove(categories);
            this.db.SaveChanges();

            return viewid;
        }


    }
}