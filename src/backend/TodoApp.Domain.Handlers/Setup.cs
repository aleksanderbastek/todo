using System;
using System.Reflection;

namespace TodoApp.Domain.Handlers
{
    public static class TodoDomainHandlers
    {
		public static Assembly GetAssembly() {
			return typeof(TodoDomainHandlers).Assembly;
		}
    }
}
