using di.proyecto.clase._2025.Frontend.Mensajes;
using di.proyecto.clase._2025.MVVM;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace di.proyecto.clase._2025.Frontend_visual_.Dialogo
{
    /// <summary>
    /// Interaction logic for DialogoUsuario.xaml
    /// </summary>
    public partial class DialogoUsuario : MetroWindow
    {
        private MVArticulo _mvArticulo;
        public DialogoUsuario(MVArticulo mvArticulo)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
        }

        private async void diagUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            DataContext = _mvArticulo;
        }

        private async void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (await _mvArticulo.GuardarUsuarioAsync())
            {

                MensajeInformacion.Mostrar("Exito","Usuario guardado correctamente");
            }
            else
            {
                MensajeInformacion.Mostrar("Error", "Error al guardar ");
            }
        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
