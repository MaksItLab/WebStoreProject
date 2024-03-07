using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreProject.Domain.Entities.Base;
using WebStoreProject.Domain.Entities.Base.Interfaces;

namespace WebStoreProject.Domain.Entities
{
	[Index(nameof(Name), IsUnique = true)]
	public class Section : NamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
		public int? ParentId { get; set; } = null;

		[ForeignKey(nameof(ParentId))]
		public Section Parent { get; set; }

		public ICollection<Product> Products { get; set; }

	}
}
