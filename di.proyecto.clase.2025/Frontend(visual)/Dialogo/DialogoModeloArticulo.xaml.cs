using di.proyecto.clase._2025.Frontend.Mensajes;
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

        private async void diagModeloArticulo_Loaded(object sender, RoutedEventArgs e)
        {
            await _mvArticulo.Inicializa();
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvArticulo.OnErrorEvent));
            //Esta línea enlaza la interfaz con el MV
            //SI NO SE PONE DATACONTEXT NO FUNCIONARÁ EL ITEMSOURCE
            DataContext = _mvArticulo;
           
        }

        //Botones por activar
        private async void btnAnyadirModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (!_mvArticulo.IsValid(this))
            {
                MensajeInformacion.Mostrar("Error de validación", "Hay errores de validación en el formulario. Por favor, corríjalos antes de continuar.");
                return;
            }
            try
            {
                bool guardado = await _mvArticulo.GuardarModeloArticuloAsync();
                if (guardado)
                {
                    MensajeInformacion.Mostrar("Éxito", "Modelo de artículo guardado correctamente");
                    DialogResult = true; // cerrar ventana indicando éxito
                }
                else
                {
                    MensajeError.Mostrar("Error al guardar el modelo de artículo",
                                    "Error");
                }
            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("Error inesperado: " + ex.Message,
                                "Error");
            }
        }


        private void btnCancelarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        
    }
}
