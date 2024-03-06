using WebStoreProject.Domain.Entities.Base;
using WebStoreProject.Domain.Entities.Base.Interfaces;

namespace WebStoreProject.Domain.Entities
{
	public class Section : NamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
		public int? ParentId { get; set; } = null;
	}
}
