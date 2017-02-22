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
	[Register ("ImageInfoVC")]
	partial class ImageInfoVC
	{
		[Outlet]
		AppKit.NSTextView TxtComment { get; set; }

		[Action ("SaveClicked:")]
		partial void SaveClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TxtComment != null) {
				TxtComment.Dispose ();
				TxtComment = null;
			}
		}
	}
}
