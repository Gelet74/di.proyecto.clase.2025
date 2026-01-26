using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Frontend_visual_.Dialogo;
using di.proyecto.clase._2025.Frontend_visual_.UC;
using Fluent;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace di.proyecto.clase._2025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private DialogoArticulo _dialogoArticulo;
        private DialogoModeloArticulo _dialogoModeloArticulo;
        private DialogoUsuario _dialogoUsuario;
        private readonly IServiceProvider _serviceProvider;
        private UCListadoModelos _ucListadoModelos;
        private UCListadoArtículos _ucListadoArtículos;
        private UCListadoUsuarios _ucListadoUsuarios;
        //serviceprovider se encarga de crear los new automaticamente
        public MainWindow(DialogoModeloArticulo dialogoModeloArticulo,
                          DialogoArticulo dialogoArticulo,
                          DialogoUsuario dialogoUsuario,
                          IServiceProvider serviceProvider,
                          UCListadoModelos ucListadoModelos,
                          UCListadoArtículos ucListadoArtículos,
                          UCListadoUsuarios ucListadoUsuarios)
        {
            InitializeComponent();
            _dialogoArticulo = dialogoArticulo;
            _dialogoModeloArticulo = dialogoModeloArticulo;
            _dialogoUsuario = dialogoUsuario;
            _serviceProvider = serviceProvider;
            _ucListadoModelos = ucListadoModelos;
            _ucListadoArtículos = ucListadoArtículos;
            _ucListadoUsuarios = ucListadoUsuarios;
        }

        private async void btnAddModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            _dialogoModeloArticulo = _serviceProvider.GetRequiredService<DialogoModeloArticulo>();
            await _dialogoModeloArticulo.Inicializa(new Modeloarticulo());
            _dialogoModeloArticulo.ShowDialog();
        }

        private void btnAddArticulo_Click(object sender, RoutedEventArgs e)
        {
            _dialogoArticulo = _serviceProvider.GetRequiredService<DialogoArticulo>();
            _dialogoArticulo.ShowDialog();
        }

        private void btnAddUsuario_Click(object sender, RoutedEventArgs e)
        {
            _dialogoUsuario = _serviceProvider.GetRequiredService<DialogoUsuario>();
            _dialogoUsuario.ShowDialog();
        }

        private void btnlistaModelosArticulo_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(_ucListadoModelos);
        }

        private void btnListadoArticulos_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(_ucListadoArtículos);
        }
        private void btnlistaUsuario_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipal.Children.Clear();
            panelPrincipal.Children.Add(_ucListadoUsuarios);
        }
    }
}