using System.Windows.Media;
using Xamarin.Forms.Platform.WinPhone;
using XamarinSA.Locator.Misc;
using XamarinSA.Locator.Views.Cells;
using XamarinSA.Locator.WinPhone.Renderers;

[assembly: Xamarin.Forms.ExportRenderer(typeof(AmbassadorCell), typeof(AmbassadorCellRenderer))]
namespace XamarinSA.Locator.WinPhone.Renderers
{
    public class AmbassadorCellRenderer : ImageCellRenderer
    {
        public override System.Windows.DataTemplate GetTemplate(Xamarin.Forms.Cell cell)
        {
            var template = base.GetTemplate(cell);
            SolidColorBrush scb = new SolidColorBrush(Color.FromArgb(0,0,0,0));
            var background = ColorStyles.XamarinDark;
            template.SetValue(CellControl.BorderBrushProperty, scb);
            template.SetValue(CellControl.BorderThicknessProperty, 1);
            template.SetValue(CellControl.BackgroundProperty, background);
            return template;
        }
    }
}
