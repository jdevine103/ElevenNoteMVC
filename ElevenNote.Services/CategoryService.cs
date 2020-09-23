using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    Id = model.Id,
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categorys.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Category> GetCategorys()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categorys.ToList();
                        

                return query;
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categorys
                        .Single(e => e.Id == id);
                return
                    new CategoryDetail
                    {
                        Name = entity.Name,
                    };
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categorys
                        .Single(e => e.Id == model.Id);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categorys
                        .Single(e => e.Id == categoryId);

                ctx.Categorys.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

