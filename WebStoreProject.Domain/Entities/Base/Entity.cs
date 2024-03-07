
using System.ComponentModel.DataAnnotations;
using WebStoreProject.Domain.Entities.Base.Interfaces;

namespace WebStoreProject.Domain.Entities.Base
{
	public abstract class Entity : IEntity
	{
		[Required]
		[Key]
		public int Id { get; set; }

	}
}
