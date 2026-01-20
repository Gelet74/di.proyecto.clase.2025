using di.proyecto.clase._2025.MVVM;
using System.Windows;
using System.Windows.Controls;

namespace di.proyecto.clase._2025.Frontend_visual_.UC
{
    /// <summary>
    /// Lógica de interacción para UCListadoUsuarios.xaml
    /// </summary>
    public partial class UCListadoUsuarios : UserControl
    {
        private MVArticulo _mvArticulo;
        public UCListadoUsuarios(MVArticulo mvArticulo)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
        }

        private async void ucListadoUsuarios_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            this.DataContext = _mvArticulo;
        }
    }
}
