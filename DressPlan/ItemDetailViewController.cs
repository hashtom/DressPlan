using Foundation;
using System;
using UIKit;

namespace DressPlan
{
    public partial class ItemDetailViewController : UITableViewController
    {

		public DressItem currentItem { get; set; }
		public DressItemViewController Delegate { get; set; }

		public ItemDetailViewController (IntPtr handle) : base (handle)
        {
        }

		public void SetItem(DressItemViewController d, DressItem item)
		{
			Delegate = d;
			currentItem = item;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//SaveButton.TouchUpInside += (sender, e) =>
			//{
			//	currentItem.ItemName = ItemNameText.Text;r
			//	Delegate.SaveItem(currentItem);
			//}
			DeleteButton.TouchUpInside += (sender, e) => Delegate.DeleteItem(currentItem);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			ItemNameText.Text = currentItem.ItemName;
			ItemPhoto.Image =  UIImage.FromFile(currentItem.DressPhotoFile);
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