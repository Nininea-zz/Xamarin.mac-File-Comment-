// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CommentTest
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSImageView ImgView1 { get; set; }

		[Outlet]
		AppKit.NSImageView ImgView2 { get; set; }

		[Action ("InfoClicked:")]
		partial void InfoClicked (Foundation.NSObject sender);

		[Action ("UploadClicked:")]
		partial void UploadClicked (Foundation.NSObject sender);

		[Action ("UploadSecond:")]
		partial void UploadSecond (Foundation.NSObject sender);

		[Action ("ViewComment1:")]
		partial void ViewComment1 (Foundation.NSObject sender);

		[Action ("ViewComment2:")]
		partial void ViewComment2 (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (ImgView1 != null) {
				ImgView1.Dispose ();
				ImgView1 = null;
			}

			if (ImgView2 != null) {
				ImgView2.Dispose ();
				ImgView2 = null;
			}
		}
	}
}
