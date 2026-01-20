using di.proyecto.clase._2025.MVVM;
using System.Windows;
using System.Windows.Controls;

namespace di.proyecto.clase._2025.Frontend_visual_.UC
{
    /// <summary>
    /// Lógica de interacción para UCListadoArtículos.xaml
    /// </summary>
    public partial class UCListadoArtículos : UserControl
    {
        private MVArticulo _mvArticulo;
        public UCListadoArtículos(MVArticulo mVArticulo)
        {
            InitializeComponent();
            _mvArticulo = mVArticulo;
        }
        private async void ucListadoArtículos_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            this.DataContext = _mvArticulo;
        }
    }
}
