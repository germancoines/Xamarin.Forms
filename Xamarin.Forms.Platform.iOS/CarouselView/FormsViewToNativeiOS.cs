﻿
using UIKit;
using CoreGraphics;

/*
The MIT License(MIT)

Copyright(c) 2016 alexrainman1975@gmail.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software
and associated documentation files (the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL
THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
IN THE SOFTWARE.
 */

namespace Xamarin.Forms.Platform.iOS
{
	public static class FormsViewToNativeiOS
	{
		public static UIView ConvertFormsToNative(Xamarin.Forms.View view, CGRect size)
		{
			//var vRenderer = RendererFactory.GetRenderer (view);

			if (Platform.GetRenderer(view) == null)
				Platform.SetRenderer(view, Platform.CreateRenderer(view));
			var vRenderer = Platform.GetRenderer(view);

			vRenderer.NativeView.Frame = size;

			vRenderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
			vRenderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

			vRenderer.Element.Layout(size.ToRectangle());

			var nativeView = vRenderer.NativeView;

			nativeView.SetNeedsLayout();

			return nativeView;
		}
	}
}

