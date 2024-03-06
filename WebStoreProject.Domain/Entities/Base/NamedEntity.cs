
using WebStoreProject.Domain.Entities.Base.Interfaces;

namespace WebStoreProject.Domain.Entities.Base
{
	public abstract class NamedEntity : Entity, INamedEntity
	{
		public string Name { get; set; }

	}
}
