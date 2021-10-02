using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Validate(TEntity entity)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(entity);

            StringBuilder stringBuilder = new StringBuilder();
            if (!Validator.TryValidateObject(entity, validationContext, results,validateAllProperties:true))
            {
                stringBuilder.Append("Fix these errors");
                stringBuilder.Append("\n\n");
                
                foreach (var result in results)
                {
                    stringBuilder.AppendLine($"{(char)9210} {result.ErrorMessage}");
                }
            }

            if (stringBuilder.ToString().Length > 0)
            {
                throw new ArgumentException(stringBuilder.ToString());
            }
        }
        public void Add(TEntity entity)
        {
            try
            {
                Validate(entity);
                Context.Set<TEntity>().Add(entity);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            
            Context.Set<TEntity>().AddRange(entities);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Find(predicate);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            Validate(entity);
            Context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(TEntity entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
