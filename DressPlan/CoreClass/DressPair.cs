using System;
using System.Collections.Generic;

namespace DressPlan
{
	public class DressPair
	{
		public DateTime DateDressed { get; set; }
		public List<DressItem> DressItems;
		public string DressMemo { get; set; }

		public DressPair()
		{
			DressItems = new List<DressItem>();
		}
	}
}
