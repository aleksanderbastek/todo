using System;

namespace TodoApp.Domain.Handlers.Queries.Board
{
    public class BoardInfoResult
    {
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreationDate { get; set; }
    }
}
