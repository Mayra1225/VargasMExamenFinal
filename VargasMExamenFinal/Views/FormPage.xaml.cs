using VargasMExamenFinal.ViewsModels;

namespace VargasMExamenFinal.Views;

public partial class FormPage : ContentPage
{
	public FormPage(ProductosViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}