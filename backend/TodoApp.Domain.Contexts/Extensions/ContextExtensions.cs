using System;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Domain.Contexts.Extensions
{
    public static class DbContextExtensions
    {
		public static void Detach<TEntity>(this DbContext dbContext, TEntity entity) {
			dbContext.Entry(entity).State = EntityState.Detached;
		}
    }
}
