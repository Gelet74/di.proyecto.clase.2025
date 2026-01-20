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
            //Habilitamos la validación
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvArticulo.OnErrorEvent));

            //Esta linia enlaza la interfaz con el MV
            //SI NO SE PONE DATACONTEXT NO FUNCIONARÁ EL ITEMSOURCE
            DataContext = _mvArticulo;
        }

        private async void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (!_mvArticulo.IsValid(this))
            {
                MessageBox.Show("Hay errores de validación en el formulario. Por favor, corríjalos antes de continuar.",
                                "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                bool guardado = await _mvArticulo.GuardarUsuarioAsync();
                if (guardado)
                {
                    MessageBox.Show("Usuario guardado correctamente",
                                    "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Error al guardar el usuario",
                                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
