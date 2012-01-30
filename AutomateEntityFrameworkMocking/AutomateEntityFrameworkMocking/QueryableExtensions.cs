﻿namespace AutomateEntityFrameworkMocking
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class QueryableExtensions
	{
		internal static IIncluder Includer = new NullIncluder();

		public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path)
			 where T : class
		{
			return Includer.Include(source, path);
		}

		public interface IIncluder
		{
			IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class;
		}

		internal class NullIncluder : IIncluder
		{
			public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
				 where T : class
			{
				return source;
			}
		}
	}
}
