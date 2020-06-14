using System;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Contexts
{
    public class TodoDbContext: DbContext
    {
		public TodoDbContext(DbContextOptions<TodoDbContext> options) :
			base(options)
		{ }

		public DbSet<Todo> Todos { get; set; }
        public DbSet<Board> Boards { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			var todo = modelBuilder.Entity<Todo>();

			todo.HasKey(t => t.Id);
			todo
				.Property(t => t.Id)
				.ValueGeneratedOnAdd();

			todo.Property(t => t.Title)
				.IsRequired();

			todo.HasOne<Board>(t => t.Board)
				.WithMany(b => b.Todos)
				.HasForeignKey(t => t.BoardId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			var board = modelBuilder.Entity<Board>();

			board.HasKey(b => b.Id);
			board
				.Property(b => b.Id)
				.ValueGeneratedOnAdd();

			board.HasMany(b => b.Todos)
				.WithOne(t => t.Board);

			board.Property(b => b.Title)
				.IsRequired();

			board.Property(b => b.CreationDate)
				.IsRequired();
		}
	}
}
