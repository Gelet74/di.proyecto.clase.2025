using di.proyecto.clase._2025.MVVM;
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
        public UCListadoModelos(MVArticulo mvArticulo)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
        }
        private async void ucListadoModelos_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            this.DataContext = _mvArticulo;
        }
    }
}
