using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Domain.Repositories.Abstractions.Writable;

namespace TodoApp.Domain.Handlers.Commands.Board
{
	public class BoardCommandsHandler :
		ICommandHandler<CreateNewBoardCommand, CreateNewBoardResult>,
		ICommandHandler<UpdateBoardTitleCommand, UpdateBoardTitleResult>,
		ICommandHandler<UpdateBoardDescriptionCommand, UpdateBoardDescriptionResult>,
		ICommandHandler<DeleteBoardCommand, DeleteBoardResult>
	{
		private IWritableBoardRepository boardRepository;

		public BoardCommandsHandler(IWritableBoardRepository boardRepository)
		{
			this.boardRepository = boardRepository;
		}

		public async Task<CreateNewBoardResult> Handle(CreateNewBoardCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.Title)) {
				throw new ArgumentException("Cannot create new board with null or empty title");
			}

			if (string.IsNullOrWhiteSpace(request.Description)) {
				request.Description = null;
			}

			var board = new Models.Board
			{
				Title = request.Title,
				Description = request.Description
			};

			var result = await boardRepository.AddBoardAsync(board);

			return new CreateNewBoardResult {
				BoardId = result.Id,
				CreationDate = result.CreationDate ?? new DateTime(0)
			};
		}

		public async Task<DeleteBoardResult> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("Cannot delete board with BoardId set to null or empty space");
			}

			var board = new Models.Board
			{
				Id = request.BoardId
			};

			var result = await boardRepository.DeleteBoardAsync(board);

			return new DeleteBoardResult
			{
				BoardId = result.Id
			};
		}

		public async Task<UpdateBoardTitleResult> Handle(UpdateBoardTitleCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("Cannot update board info when BoardId is set to empty or null");
			}

			if (string.IsNullOrWhiteSpace(request.Title)) {
				throw new ArgumentException("Cannot update board Title to null or empty string");
			}

			var board = new Models.Board
			{
				Id = request.BoardId,
				Title = request.Title
			};

			var result = await boardRepository.UpdateBoardTitleAsync(board);

			return new UpdateBoardTitleResult {
				BoardId = result.Id
			};
		}

		public async Task<UpdateBoardDescriptionResult> Handle(UpdateBoardDescriptionCommand request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.BoardId)) {
				throw new ArgumentException("Cannot update board info when BoardId is set to empty or null");
			}

			if (string.IsNullOrWhiteSpace(request.Description)) {
				request.Description = null;
			}

			var board = new Models.Board
			{
				Id = request.BoardId,
				Description = request.Description
			};

			var result = await boardRepository.UpdateBoardDescriptionAsync(board);

			return new UpdateBoardDescriptionResult {
				BoardId = result.Id
			};
		}
	}
}
