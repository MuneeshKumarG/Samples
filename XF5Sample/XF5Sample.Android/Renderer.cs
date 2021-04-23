using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Forms = Xamarin.Forms;
using XF5Sample;
using Xamarin.Forms.Platform.Android;
using XF5Sample.Droid;

[assembly: Forms.ExportRenderer(typeof(CustomView), typeof(CustomViewRenderer))]
namespace XF5Sample.Droid
{
    public class CustomViewRenderer : ViewRenderer<CustomView, View>
    {
        private CustomView customView;

        public CustomViewRenderer(global::Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomView> e)
        {
            base.OnElementChanged(e);

            var element = e.NewElement;
            customView = element as CustomView;
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            if (Platform.GetRenderer(customView.Input) == null)
            {
                Platform.SetRenderer(customView.Input, Platform.CreateRendererWithContext(customView.Input, Context));
            }

            var renderer = Platform.GetRenderer(customView.Input);

            if (renderer != null)
            {
                var nativeEditText = GetNativeEditText(renderer as ViewGroup);

                if (nativeEditText != null && nativeEditText.Handle != IntPtr.Zero)
                {

                }
            }
        }

        internal static EditText GetNativeEditText(ViewGroup viewGroup)
        {
            EditText editText = null;
            if (editText == null && viewGroup is ViewGroup)
            {
                var childCount = viewGroup.ChildCount;
                for (int i = 0; i < childCount; i++)
                {
                    var child = viewGroup.GetChildAt(i);
                    if (child is EditText)
                    {
                        editText = child as EditText;
                    }
                    else if (child is ViewGroup)
                    {
                        editText = GetNativeEditText(child as ViewGroup);
                    }
                    else
                    {
                        return editText;
                    }

                    if (editText != null)
                    {
                        break;
                    }
                }
            }

            return editText;
        }
    }
}