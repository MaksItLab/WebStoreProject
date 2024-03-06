
using WebStoreProject.Domain.Entities.Base.Interfaces;

namespace WebStoreProject.Domain.Entities.Base
{
	public abstract class Entity : IEntity
	{
		public int Id { get; set; }

	}
}
