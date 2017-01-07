using System;
using System.Collections.Generic;

namespace DressPlan
{
	public class ItemLaundry
	{
		public string LaundryShopName { get; set; }
		public DateTime DateBrought { get; set; }
		public DateTime DateReturn { get; set; }
		public bool HasReturned { get; set; }

		public ItemLaundry()
		{
		}
	}
}
