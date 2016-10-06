using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomusMe.Controls
{
    public enum ImageEntryImageAlignment
    {
        Left,
        Right
    }
    public enum ImageEntryImage
    {
        None,
        Letter,
        Lock
    }
    public class ImageEntry : Entry
    {
        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create<ImageEntry, ImageEntryImage>(w => w.Image, ImageEntryImage.None);

        public ImageEntryImage Image
        {
            get { return (ImageEntryImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly BindableProperty ImageAlignmentProperty =
            BindableProperty.Create<ImageEntry, ImageEntryImageAlignment>(w => w.ImageAlignment, ImageEntryImageAlignment.Left);

        public ImageEntryImageAlignment ImageAlignment
        {
            get { return (ImageEntryImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }
    }
}
