using CoreAnimation;
using CoreGraphics;
using DomusMe.Controls;
using DomusMe.iOS.Renderers;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace DomusMe.iOS.Renderers
{
    public class ImageEntryRenderer : EntryRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var textField = this.Control;
            var element = (ImageEntry)this.Element;

            CALayer bottomBorder = new CALayer
            {
                Frame = new CGRect(0.0f, this.Frame.Height - 2, this.Frame.Width, this.Frame.Height),
                BorderWidth = 2.0f,
                BackgroundColor = element.TextColor.ToCGColor(),
                BorderColor = element.TextColor.ToCGColor()
            };

            textField.Layer.AddSublayer(bottomBorder);
            textField.Layer.MasksToBounds = true;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //run once when element is first initialized
            if (e.OldElement != null || e.NewElement == null)
            {
                return;
            }

            var element = (ImageEntry)this.Element;

            //if there is no image there is no customization
            if (element.Image == ImageEntryImage.None)
            {
                return;
            }

            var textField = this.Control;

            switch (element.ImageAlignment)
            {
                case ImageEntryImageAlignment.Left:
                    textField.LeftViewMode = UITextFieldViewMode.Always;
                    textField.LeftView = GetImageView(element.Image);
                    break;
                case ImageEntryImageAlignment.Right:
                    textField.RightViewMode = UITextFieldViewMode.Always;
                    textField.RightView = GetImageView(element.Image);
                    break;
                default:
                    throw new ArgumentException(
                         "Unknown option for {typeof(ImageEntryImageAlignment).Name} in {typeof(ImageEntryRenderer).Name}", new Exception("error"));
            }

            textField.BorderStyle = UITextBorderStyle.None;

            //needed to customize the placeholder color
            NSAttributedString attributedString = new NSAttributedString(this.Element.Placeholder, new UIStringAttributes() { ForegroundColor = this.Element.TextColor.ToUIColor() });
            textField.AttributedPlaceholder = attributedString;
        }

        private UIView GetImageView(ImageEntryImage imageEntryImage)
        {
            string path = "";
            if (imageEntryImage == ImageEntryImage.Letter)
                path = "Letter";
            else if (imageEntryImage == ImageEntryImage.Lock)
                path = "Lock";
            else
                path = "Letter";

            return new UIImageView(GetImage(path));
        }

        private UIImage GetImage(string imagePath)
        {
            var uiImage = new UIImage(imagePath);
            return uiImage.Scale(new CGSize(this.Control.Font.LineHeight, this.Control.Font.LineHeight));
        }
    }
}
