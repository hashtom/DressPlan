using Foundation;
using System;
using UIKit;

namespace DressPlan
{
    public partial class ItemDetailPrototypeViewController : UITableViewController
    {

		public DressItem currentItem { get; set; }
		public DressItemViewController Delegate { get; set; }

		public ItemDetailPrototypeViewController (IntPtr handle) : base (handle)
        {
        }

		public void SetItem(DressItemViewController d, DressItem item)
		{
			Delegate = d;
			currentItem = item;
		}


		//public void SetItem(DressItem newItem)
		//{
		//	if (currentItem != newItem)
		//	{
		//		currentItem = newItem;
		//		ConfigureView();
		//	}
		//}

//		void ConfigureView()
//		{/
//			if (IsViewLoaded && currentItem != null)
//			{
//				ItemNameText.Text = currentItem.ItemName;
//				ItemPhoto.Image = UIImage.FromFile(currentItem.DressPhotoFile);
				//ItemCategoryPick = currentItem.Category.ToString();y
				//ItemCategoryPick   = currentItem.Material.ToString()/
//			}
//		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//ConfigureView();

			SaveButton.TouchUpInside += (sender, e) =>
			{
				currentItem.ItemName = ItemNameText.Text;
				Delegate.SaveItem(currentItem);
			};

			DeleteButton.TouchUpInside += (sender, e) => Delegate.DeleteItem(currentItem);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			ItemNameText.Text = currentItem.ItemName;
			if (currentItem.DressPhotoFile != null ) ItemPhoto.Image =  UIImage.FromFile(currentItem.DressPhotoFile);
			//ItemCategoryPick = currentItem.Category.ToString();y
			//ItemCategoryPick   = currentItem.Material.ToString();

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

	}
}