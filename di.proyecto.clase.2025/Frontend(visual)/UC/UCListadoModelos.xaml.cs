using di.proyecto.clase._2025.Frontend_visual_.Dialogo;
using di.proyecto.clase._2025.MVVM;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace di.proyecto.clase._2025.Frontend_visual_.UC
{
    /// <summary>
    /// Interaction logic for UCListadoModelos.xaml
    /// </summary>
    public partial class UCListadoModelos : UserControl
    {
        private MVArticulo _mvArticulo;
        private readonly IServiceProvider _serviceProvider;
        public UCListadoModelos(MVArticulo mvArticulo, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
            _serviceProvider = serviceProvider;
        }
        private async void ucListadoModelos_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            this.DataContext = _mvArticulo;
        }

        private async void miEditarModeloArtículo_Click(object sender, RoutedEventArgs e)
        {
          var  _dialogoModeloArticulo=_serviceProvider.GetRequiredService<DialogoModeloArticulo>();
            await _dialogoModeloArticulo.Inicializa(_mvArticulo.modeloArticulo);
            _dialogoModeloArticulo.ShowDialog();
            if (_dialogoModeloArticulo.DialogResult == true)
            {
                //Refrescamos la lista
                _mvArticulo.listaModelosArticulos.Refresh();
            }
        }

        private void miEliminarModeloArtículo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
