using System;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Handlers.Queries.Board;
using TodoApp.Domain.Models;

namespace TodoApp.Api.Query
{
	public class TodoQueryType
	{
		private readonly string boardId;
		private readonly IQueryProcessor processor;

		public TodoQueryType(
			string id,
			string boardId,
			string title,
			DateTime creationDate,
			DateTime? doneDate,
			DateTime? deadline,
			IQueryProcessor processor
		) {
			Id = id;
			Title = title;
			CreationDate = creationDate;
			DoneDate = doneDate;
			Deadline = deadline;
			IsDone = DoneDate != null;
			IsExpired = Deadline != null ? Deadline < DateTime.Now : false;
			
			this.boardId = boardId;
			this.processor = processor;
		}

		public TodoQueryType(Todo todo, IQueryProcessor processor) :
			this(
				todo.Id,
				todo.BoardId,
				todo.Title,
				todo.CreationDate,
				todo.DoneDate,
				todo.Deadline,
				processor
			)
		{ }
		
		public string Id { get; }
		public string Title { get; }
		public DateTime CreationDate { get; }
		public DateTime? DoneDate { get; }
		public DateTime? Deadline { get; }
		public bool IsDone { get; }
		public bool IsExpired { get; }

		public async Task<BoardQueryType> Board() {
			var request = new BoardInfoQuery
			{
				BoardId = boardId
			};

			var queryResult = await processor.Query(request);

			return new BoardQueryType(queryResult, processor);
		}
	}
}
