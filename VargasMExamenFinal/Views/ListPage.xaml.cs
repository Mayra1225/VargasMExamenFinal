using VargasMExamenFinal.ViewsModels;

namespace VargasMExamenFinal.Views;

public partial class ListPage : ContentPage
{
	public ListPage(ProductosViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}