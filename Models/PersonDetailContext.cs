using Microsoft.EntityFrameworkCore;
using ProjetoCRUDBackend.Models;

namespace ProjetoCRUDBackend.Models
{
	public class PersonDetailContext : DbContext
	{
		public PersonDetailContext(DbContextOptions<PersonDetailContext> options) : base(options)
		{

		}

		public DbSet<PersonDetail> PersonDetails { get; set; }

		public DbSet<ProjetoCRUDBackend.Models.ContactList> ContactList { get; set; }
	}
}
