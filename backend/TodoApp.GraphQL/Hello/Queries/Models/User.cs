using System;

namespace TodoApp.GraphQL.Hello.Queries.Models
{
    public class User {
        public string Id { get; set; }
		public UserInfo Info { get; set; }
        public AccountDetails AccountDetails { get; set; }
	}
}
