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
using Xamarin.Forms;
using DomusMe.Controls;
using DomusMe.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Graphics;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace DomusMe.Droid.Renderers
{
     public class ImageEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //run once when element is first initialized
            if (e.OldElement != null || e.NewElement == null)
            {
                return;
            }

            var element = (ImageEntry)this.Element;
            var editText = this.Control;

            switch (element.ImageAlignment)
            {
                case ImageEntryImageAlignment.Left:
                    editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                    break;
                case ImageEntryImageAlignment.Right:
                    editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                    break;
                default:
                    throw new ArgumentException(
                         "Unknown option for {typeof(ImageEntryImageAlignment).Name} in {typeof(ImageEntryRenderer).Name}", new Exception("error"));
            }
        }

        private Drawable GetDrawable(ImageEntryImage imageEntryImage)
        {
            switch (imageEntryImage)
            {
                case ImageEntryImage.Letter:
                    return GetSizedImage(Resource.Drawable.Letter);
                case ImageEntryImage.Lock:
                    return GetSizedImage(Resource.Drawable.Lock);
                case ImageEntryImage.None:
                    throw new ArgumentException(
                           "Unknown option for {typeof(ImageEntryImageAlignment).Name} in {typeof(ImageEntryRenderer).Name}", new Exception("error"));
                default:
                    throw new ArgumentException("Unknown option for {typeof(ImageEntryImageAlignment).Name} in {typeof(ImageEntryRenderer).Name}", new Exception("error"));
            }
        }

        private Drawable GetSizedImage(int id)
        {
            var drawable = ContextCompat.GetDrawable(this.Context, id);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;
            var heightAndWidth = this.Control.LineHeight * 2;
            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, heightAndWidth, heightAndWidth, true));
        }
    }
}