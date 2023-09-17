using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebShop.Helper.Interfaces;
using WebShop.Infrastructure;
using WebShop.Repository.Interfaces;

namespace WebShop.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly object _lockObj = new object();
		//private readonly IDbHelper _dbHelper;
		protected readonly WebShopDbContext _dbContext;

		public Repository(WebShopDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void Add(T entity)
		{
			lock(_lockObj)
			{
				 _dbContext.Set<T>().Add(entity);
			}
		}

		public void Delete(T entity)
		{
			lock (_lockObj)
			{
				_dbContext.Set<T>().Remove(entity);
			}
		}

		public T FindFirst(Expression<Func<T, bool>> expression)
		{
			lock (_lockObj)
			{
				var res = _dbContext.Set<T>().Where(expression).FirstOrDefault();
				return res;
			}
		}

		public IEnumerable<T> GetAll()
		{
			lock (_lockObj)
			{
				var result = _dbContext.Set<T>().ToList();

				return result;
			}
		}

		public T GetById(long id)
		{
			lock (_lockObj)
			{
				var result = _dbContext.Set<T>().Find(id);

				return result;
			}
		}

		public void Update(T entity)
		{
			lock (_lockObj)
			{
				_dbContext.Set<T>().Update(entity);
			}
		}
	}
}
