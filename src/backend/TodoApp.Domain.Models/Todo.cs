using System;

namespace TodoApp.Domain.Models
{
    public class Todo
    {
		public string Id { get; set; }
		public string BoardId { get; set; }
		public Board Board { get; set; }
		public string Title { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? Deadline { get; set; }
		public DateTime? DoneDate { get; set; }
	}
}
