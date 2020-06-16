using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Handlers.Queries.Board;
using TodoApp.Domain.Handlers.Queries.Todo;
using TodoApp.Domain.Models;

namespace TodoApp.Api.Query
{
	public class BoardType
	{
		private readonly IQueryProcessor processor;

		public BoardType(string id, string title, string? description, DateTime creationDate, IQueryProcessor processor)
		{
			Id = id;
			Title = title;
			CreationDate = creationDate;
			Description = description;
			this.processor = processor;
		}

		public BoardType(Board board, IQueryProcessor processor) :
			this(
				board.Id,
				board.Title,
				board.Description,
				board.CreationDate,
				processor
			)
		{ }

		public BoardType(BoardInfoResult info, IQueryProcessor processor) :
			this(
				info.Result,
				processor
			)
		{ }

		public string Id { get; set; }
		public string Title { get; set; }
		public string? Description { get; set; }
		public DateTime CreationDate { get; set; }

		public async Task<List<TodoType>> Todos(int take, int? skip)
		{
			var request = new TodosOfBoardQuery
			{
				BoardId = Id,
				NumberOfRequestedTodos = take,
				NumberOfSkippedTodos = skip ?? 0
			};

			var queryResult = await processor.Query(request);

			var result = from todo in queryResult.Result select new TodoType(todo, processor);

			return result.ToList();
		}

		public async Task<List<TodoType>> DoneTodos(int take, int? skip) {
			var request = new DoneTodosOfBoardQuery
			{
				BoardId = Id,
				Take = take,
				Skip = skip ?? 0
			};

			var queryResult = await processor.Query(request);

			var result = from todo in queryResult.Result select new TodoType(todo, processor);

			return result.ToList();
		}

		public async Task<List<TodoType>> UndoneTodos(int take, int? skip) {
			var request = new UndoneTodosOfBoardQuery
			{
				BoardId = Id,
				Take = take,
				Skip = skip ?? 0
			};

			var queryResult = await processor.Query(request);

			var result = from todo in queryResult.Result select new TodoType(todo, processor);

			return result.ToList();
		}

		public async Task<int> NumberOfTodos() {
			var request = new NumberOfTodosQuery
			{
				BoardId = Id
			};

			var queryResult = await processor.Query(request);

			return queryResult.NumberOfTodos;
		}

		public async Task<int> NumberOfDoneTodos() {
			var request = new NumberOfTodosQuery
			{
				BoardId = Id,
				TodoFilter = NumberOfTodosQuery.Filter.DONE
			};

			var queryResult = await processor.Query(request);

			return queryResult.NumberOfTodos;
		}

		public async Task<int> NumberOfUndoneTodos() {
			var request = new NumberOfTodosQuery
			{
				BoardId = Id,
				TodoFilter = NumberOfTodosQuery.Filter.UNDONE
			};

			var queryResult = await processor.Query(request);

			return queryResult.NumberOfTodos;
		}
	}
}
