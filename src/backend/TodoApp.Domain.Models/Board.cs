using System.Collections.Generic;
using System;

namespace TodoApp.Domain.Models
{
    public class Board
    {
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime? CreationDate { get; set; }
		public List<Todo> Todos { get; set; }
	}
}
