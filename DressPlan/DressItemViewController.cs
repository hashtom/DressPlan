using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DressPlan
{
    public partial class DressItemViewController : UITableViewController
    {
		List<DressItem> dressitems;

        public DressItemViewController (IntPtr handle) : base (handle)
        {
				dressitems = new List<DressItem> {
				new DressItem {ItemName="シャツ1",DressPhotoFile="Shirt_sample.jpg",Category = ItemCategory.Shirt},
				new DressItem {ItemName="パンツ1",DressPhotoFile="Pants_sample.jpg",Category = ItemCategory.Pants},
				new DressItem {ItemName="智明",DressPhotoFile="Tomo_sample.jpg",Category = ItemCategory.Other},
				new DressItem {ItemName="シャツ2",DressPhotoFile="Shirt_sample.jpg",Category = ItemCategory.Shirt},
				new DressItem {ItemName="パンツ2",DressPhotoFile="Pants_sample.jpg",Category = ItemCategory.Pants},
				new DressItem {ItemName="パンツ3",DressPhotoFile="Pants_sample.jpg",Category = ItemCategory.Pants},
				new DressItem {ItemName="シャツ3",DressPhotoFile="Shirt_sample.jpg",Category = ItemCategory.Shirt},
				new DressItem {ItemName="智明",DressPhotoFile="Tomo_sample.jpg",Category = ItemCategory.Other}
			};
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = NSBundle.MainBundle.LocalizedString("Dress Plan", "Dress Plan2");

			// Perform any additional setup after loading the view, typically from a nib.
			NavigationItem.LeftBarButtonItem = EditButtonItem;

			var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
			addButton.AccessibilityLabel = "addButton";
			NavigationItem.RightBarButtonItem = addButton;

			TableView.Source = new DataSource(this);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			TableView.Source = new DressItemTableSource(dressitems.ToArray());

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void AddNewItem(object sender, EventArgs args)
		{
			//dataSource.Objects.Insert(0, DateTime.Now);

			using (var indexPath = NSIndexPath.FromRowSection(0, 0))
				TableView.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			//if (segue.Identifier == "ItemSegue")
			//{
			//	var indexPath = TableView.IndexPathForSelectedRow;
			//	var item = dataSource.Objects[indexPath.Row];

			//	((DetailViewController)segue.DestinationViewController).SetDetailItem(item);
			//}
			if (segue.Identifier == "ItemSegue")
			{
				var navctlr = segue.DestinationViewController as ItemDetailViewController;
				if (navctlr != null)
				{
					var source = TableView.Source as DressItemTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetItem(this, item); // defined on the ItemDetailViewController
				}
			}
		}

		public void CreateItem()
		{
			// first, add the task to the underlying data
			var newId = dressitems[dressitems.Count - 1].Id + 1;
			var newItem = new DressItem() { Id = newId };
			dressitems.Add(newItem);

			// then open the detail view to edit it
			var detail = Storyboard.InstantiateViewController("detail") as ItemDetailViewController;
			detail.SetItem(this, newItem);
			NavigationController.PushViewController(detail, true);
		}

		public void SaveItem(DressItem item)
		{
			//var oldTask = dressitems.Find(t => t.Id == item.Id);
			NavigationController.PopViewController(true);
		}

		public void DeleteItem(DressItem item)
		{
			var oldItem = dressitems.Find(t => t.Id == item.Id);
			dressitems.Remove(oldItem);
			NavigationController.PopViewController(true);
		}

		class DataSource : UITableViewSource
		{
			static readonly NSString CellIdentifier = new NSString("Cell");
			readonly List<object> objects = new List<object>();
			readonly DressItemViewController controller;

			public DataSource(DressItemViewController controller)
			{
				this.controller = controller;
			}

			public IList<object> Objects
			{
				get { return objects; }
			}

			// Customize the number of sections in the table view.
			public override nint NumberOfSections(UITableView tableView)
			{
				return 1;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return objects.Count;
			}

			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

				cell.TextLabel.Text = objects[indexPath.Row].ToString();

				return cell;
			}

			public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return true;
			}

			public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete)
				{
					// Delete the row from the data source.
					objects.RemoveAt(indexPath.Row);
					controller.TableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
				}
				else if (editingStyle == UITableViewCellEditingStyle.Insert)
				{
					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
				}
			}


		}

	}
}