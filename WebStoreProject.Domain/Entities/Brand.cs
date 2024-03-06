﻿using WebStoreProject.Domain.Entities.Base;
using WebStoreProject.Domain.Entities.Base.Interfaces;

namespace WebStoreProject.Domain.Entities
{
	public class Brand : NamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
	}
}
