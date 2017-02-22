using System;
using System.Collections.Generic;
using System.IO;
using AppKit;
using Foundation;

namespace CommentTest
{
	public partial class ViewController : NSViewController
	{
		NSUrl _img1;
		NSUrl _img2;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		public override void PrepareForSegue (NSStoryboardSegue segue, NSObject sender)
		{
			var vc = segue.DestinationController as ImageInfoVC;

			var items = new List<NSUrl> ();
			items.Add (_img1);
			items.Add (_img2);
			vc.SetData (items);

			base.PrepareForSegue (segue, sender);
		}

		partial void InfoClicked (NSObject sender)
		{
			ShowInfoWindow (_img1, _img2);
		}

		partial void ViewComment1 (NSObject sender)
		{
			ShowInfoWindow (_img1);
		}

		partial void ViewComment2 (NSObject sender)
		{
			ShowInfoWindow (_img2);
		}

		partial void UploadClicked (NSObject sender)
		{
			UploadImage (0);
		}

		partial void UploadSecond (NSObject sender)
		{
			UploadImage (1);
		}

		void UploadImage (int index)
		{
			var openPanel = new NSOpenPanel ();

			openPanel.AllowedFileTypes = new [] { "png", "jpeg", "jpg", "gif" };

			openPanel.BeginSheet (this.View.Window, (obj) => {
				if (obj == 1 && openPanel.Urls != null) {
					foreach (var url in openPanel.Urls) {
						if (url != null) {
							if (!File.Exists (url.Path)) {
								continue;
							}
							if (index == 0) {
								_img1 = url;
								ImgView1.Image = new NSImage (url);
							} else {
								_img2 = url;
								ImgView2.Image = new NSImage (url);
							}


						}
					}
				}
			});
		}

		void ShowInfoWindow (NSUrl url, NSUrl url2 = null)
		{
			var vc = Storyboard.InstantiateControllerWithIdentifier (typeof (ImageInfoVC).Name) as ImageInfoVC;

			var items = new List<NSUrl> ();
			items.Add (url);
			if (url2 != null) {
				items.Add (url2);
			}
			vc.SetData (items);

			PresentViewControllerAsModalWindow (vc);
		}
	}
}
