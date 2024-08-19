using MarketMAUI.Models;

namespace MarketMAUI.Pages;

public partial class CurrentProductPage : ContentPage
{
	public CurrentProductPage(Product product)
	{
		InitializeComponent();
        SizeChanged += CurrentProductPage_SizeChanged;
		Content.BindingContext = product;
	}

    private void CurrentProductPage_SizeChanged(object? sender, EventArgs e)
    {
        if (CVImages.ItemsLayout is GridItemsLayout gridLayout)
        {
            double width = this.Width;
            int columns = (int)(width / 310); 
            if (columns < 1) columns = 1;
            gridLayout.Span = columns;
        }
    }
}