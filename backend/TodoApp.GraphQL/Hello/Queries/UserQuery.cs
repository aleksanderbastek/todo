using System;
using HotChocolate.Types;
using TodoApp.GraphQL.Hello.Queries.Models;

namespace TodoApp.GraphQL.Hello.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class UserQuery {
        /// <summary>
        /// Returns fake user data.
        /// This is example of complex query type.
        /// </summary>
        /// <param name="id">Fake ID string of the user. Use whatever you want. Ex: "blablabla".</param>
        /// <returns>User data.</returns>
        public User GetUserDataById(string id) {
			var user = new User()
			{
				Id = id,
				Info = new UserInfo()
				{
					Name = "Jan Kowalski",
					Age = 18
				},
				AccountDetails = new AccountDetails()
				{
					IsAdministrator = false,
					CreationDate = new DateTime(2000, 6, 1),
					LastLoginTime = DateTime.Now
				}
			};

			return user;
		}
    }
}
