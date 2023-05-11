using System;
using BugTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerApi.Models
{
	public class BugEntityContext : DbContext
	{
		public BugEntityContext(DbContextOptions<BugEntityContext> options) : base(options)
		{

		}

		public DbSet<BugEntity> BugEntities { get; set; } = null!;

	}
}
