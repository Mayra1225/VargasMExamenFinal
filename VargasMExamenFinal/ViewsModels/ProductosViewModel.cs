using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VargasMExamenFinal.Models;
using VargasMExamenFinal.Services;

namespace VargasMExamenFinal.ViewsModels
{
    public class ProductosViewModel : INotifyPropertyChanged
    {
        private ProductosService _service;

        private string _nombre;
        private string _categoria;
        private int _cantidad;
        private decimal _precioEstimado;

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        public string Categoria
        {
            get => _categoria;
            set
            {
                _categoria = value;
                OnPropertyChanged();
            }
        }

        public int Cantidad
        {
            get => _cantidad;
            set
            {
                _cantidad = value;
                OnPropertyChanged();
            }
        }

        public decimal PrecioEstimado
        {
            get => _precioEstimado;
            set
            {
                _precioEstimado = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Producto> Productos { get; set; } = new();
        public ICommand SaveCommand { get; }

        public ProductosViewModel(ProductosService service)
        {
            _service = service;
            SaveCommand = new Command(async () => await SaveProducto());
            LoadProducto();
        }

        private async Task SaveProducto()
        {
            if (Categoria.ToLower()  != "ropa" && Cantidad < 1)
            {
                await  Shell.Current.DisplayAlert("Error", "La cantidad debe ser mayor a 0 para productos que no son ropa.", "OK");
                return;
            }

            var newProducto = new Producto
            {
                Nombre = Nombre,
                Categoria = Categoria,
                Cantidad = Cantidad,
                PrecioEstimado = PrecioEstimado
            };

            await _service.SaveProdcutoAsync(newProducto);
            Productos.Add(newProducto);

            var log = $"Se incluyó el registro [{Nombre}] el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            File.AppendAllText(Path.Combine(FileSystem.AppDataDirectory, "Logs_Vargas.txt"), log);

            Nombre = Categoria = string.Empty;
            Cantidad = 0;
            PrecioEstimado = 0;
        }
        private async void LoadProducto()
        {
            var productos = await _service.GetProductoAsync();
            Productos.Clear();
            foreach (var producto in productos)
            {
                Productos.Add(producto);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
    
   
