using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.Backend.Servicios_Repositorio_;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.proyecto.clase._2025.Frontend_visual_.Dialogo
{
    /// <summary>
    /// Interaction logic for DialogoArticulo.xaml
    /// </summary>
    public partial class DialogoArticulo : MetroWindow
    {
        private MVArticulo _mvArticulo;
        public DialogoArticulo(MVArticulo mvArticulo)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
        }


        private async void diagArticulo_Loaded(object sender, RoutedEventArgs e)
        { 
            // Estado: valores fijos o tabla auxiliar
            cmbEstado.ItemsSource = new List<string> { "Nuevo", "Usado", "Dañado" };
            await _mvArticulo.Inicializa();
            DataContext = _mvArticulo;
        }


     

        private async void btnGuardarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (await _mvArticulo.GuardarArticuloAsync())
            {
                MessageBox.Show("Artículo guardado correctamente");
            } else { 
                MessageBox.Show("Error al guardar ","", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
