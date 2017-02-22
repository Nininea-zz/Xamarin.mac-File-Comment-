using System;
using System.Runtime.InteropServices;
using CoreFoundation;
using Foundation;
using ObjCRuntime;

namespace CommentTest
{
	public class FileHelper
	{
		[DllImport (Constants.CoreServicesLibrary)]
		extern static /* MDItemRef */ IntPtr MDItemCreateWithURL (/* CFAllocatorRef __nullable */ IntPtr allocator, /* CFURLRef */ IntPtr inURL);

		//MD_EXPORT CFTypeRef MDItemCopyAttribute(MDItemRef item, CFStringRef name) MD_AVAIL;
		[DllImport (Constants.CoreServicesLibrary)]
		extern static /* CFTypeRef */ IntPtr MDItemCopyAttribute (/* MDItemRef */ IntPtr item, /* CFStringRef */ IntPtr name);


		[DllImport (Constants.CoreFoundationLibrary, CharSet = CharSet.Unicode)]
		extern static IntPtr CFRelease (IntPtr obj);



		public static string GetImageComment (NSUrl fileURL)
		{
			try {
				var mMDItemRef = MDItemCreateWithURL (IntPtr.Zero, fileURL.Handle);
				var mCFTypeRef = MDItemCopyAttribute (mMDItemRef, new CFString ("kMDItemFinderComment").Handle);
				var finderComment = NSString.FromHandle (mCFTypeRef);

				CFRelease (mCFTypeRef);

				return finderComment;
			} catch (Exception ex) {
				return "";
			}
		}

		public static void SetImageComment (NSUrl filePath, string comment)
		{
			NSMutableString script = new NSMutableString ();
			script.Append (new NSString ("TELL APPLICATION \"FINDER\"\n" +
										 $"SET filePath TO \"{filePath.Path}\" AS POSIX FILE \n" +
							  $"SET COMMENT OF (filePath AS ALIAS) TO \"{comment}\" \n" +
										"END TELL"));
			System.Diagnostics.Debug.WriteLine ("");
			System.Diagnostics.Debug.WriteLine (script);
			System.Diagnostics.Debug.WriteLine ("");

			NSDictionary dictionary;
			NSAppleScript commentScript = new NSAppleScript (script);
			commentScript.ExecuteAndReturnError (out dictionary);
			System.Diagnostics.Debug.WriteLine (dictionary?.ToString ());

			var newcomm = GetImageComment (filePath);

			System.Diagnostics.Debug.WriteLine ("image: " + filePath);
			System.Diagnostics.Debug.WriteLine ("new comment: " + newcomm);
		}
	}
}
