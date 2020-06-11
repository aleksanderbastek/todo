using System;

namespace TodoApp.GraphQL.Hello.Queries.Models
{
    public class AccountDetails {
        public bool IsAdministrator { get; set; }
		public DateTime CreationDate { get; set; }
        public DateTime LastLoginTime { get; set; }
	}
}
