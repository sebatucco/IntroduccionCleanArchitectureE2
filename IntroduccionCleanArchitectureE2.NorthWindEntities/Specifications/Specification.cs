using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindEntities.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> Expression { get; }
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> ExpressionnDelegate = Expression.Compile();
            return ExpressionnDelegate(entity);
        }
    }
}
