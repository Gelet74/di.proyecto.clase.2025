using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.MVVM;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace di.proyecto.clase._2025.Frontend_visual_.Dialogo
{
    /// <summary>
    /// Interaction logic for DialogoModeloArticulo.xaml
    /// </summary>
    public partial class DialogoModeloArticulo : MetroWindow
    {
        private MVArticulo _mvArticulo;
        public DialogoModeloArticulo(MVArticulo mvArticulo)
        {
            InitializeComponent();
            _mvArticulo = mvArticulo;
            
        }

        /*private async void diagModeloArticulo_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();

            //Habilitamos la validación
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvArticulo.OnErrorEvent));

            //Esta linia enlaza la interfaz con el MV
            //SI NO SE PONE DATACONTEXT NO FUNCIONARÁ EL ITEMSOURCE
            DataContext = _mvArticulo;
        }*/

        public async Task Inicializa(Modeloarticulo modeloarticulo)
        {
            await _mvArticulo.Inicializa();
            _mvArticulo.modeloArticulo = modeloarticulo;
            //Habilitamos la validación
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvArticulo.OnErrorEvent));
            //Esta linia enlaza la interfaz con el MV
            //SI NO SE PONE DATACONTEXT NO FUNCIONARÁ EL ITEMSOURCE
            DataContext = _mvArticulo;
        }

        //Botones por activar
        private async void btnAnyadirModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (!_mvArticulo.IsValid(this))
            {
                MessageBox.Show("Hay errores de validación en el formulario. Por favor, corríjalos antes de continuar.",
                                "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                bool guardado = await _mvArticulo.GuardarModeloArticuloAsync();
                if (guardado)
                {
                    MessageBox.Show("Modelo de artículo guardado correctamente",
                                    "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Error al guardar el modelo de artículo",
                                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        


        private void btnCancelarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        
    }
}
