using System;
using UIKit;
using System.Collections.Generic;

namespace DressPlan
{
	public enum ItemCategory
	{
		Tops,
		Jacket,
		Shirt,
		Pants,
		Cardigan,
		Sweater,
		Cutsew,
		Tie,
		Bottoms,
		Skirt,
		OnePiece,
		Suits,
		Other
	}

	public enum ItemBrand
	{
		None,
		Brand,
		Uniqro
	}

	public enum ItemMaterial
	{
		None,
		Cutton
	}

	public class DressItem
	{
		public int Id { get; set; }
		public String DressPhotoFile { get; set; }
		public string ItemName { get; set; }
		public ItemCategory Category { get; set; }
		public ItemMaterial Material { get; set; }
		public ItemBrand Brand { get; set; }
		public int PurchasePrice { get; set; }
		public DateTime PurchaseDate { get; set; }
		public List<DressPair> DressPairs;
		public List<ItemLaundry> LaundryPlans;

		public DressItem()
		{
			DressPairs = new List<DressPair>();
			LaundryPlans = new List<ItemLaundry>();
		}

		//public UIImage DressPhoto()
		//{
		//	return UIImage.FromFile(DressPhotoFile);
		//}

	}
}
