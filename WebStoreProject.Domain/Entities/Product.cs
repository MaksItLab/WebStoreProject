﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreProject.Domain.Entities.Base;
using WebStoreProject.Domain.Entities.Base.Interfaces;

namespace WebStoreProject.Domain.Entities
{
	[Index(nameof(Name))]
	public class Product : NamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
		public int SectionId { get; set; }

		[ForeignKey(nameof(SectionId))]
		public Section Section { get; set; }
		public int? BrandId { get; set; }

		[ForeignKey(nameof(BrandId))]
		public Brand Brand { get; set; }
		public string ImageUrl { get; set; }

		[Column(TypeName ="decimal(18,2)")]
		public decimal Price { get; set; }
		
	}
}
