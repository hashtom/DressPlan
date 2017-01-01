using System;
using System.Collections.Generic;

namespace DressPlan
{
	public class DressPairs
	{
		public DateTime DressDate { get; set; }
		public List<DressItem> DressItems;

		public DressPairs()
		{
			DressItems = new List<DressItem>();
		}
	}
}
