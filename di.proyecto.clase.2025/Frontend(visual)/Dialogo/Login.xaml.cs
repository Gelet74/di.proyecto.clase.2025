using Castle.Core.Logging;
using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.Frontend.Mensajes;
using MahApps.Metro.Controls;
using Microsoft.Extensions.Logging;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        //Añadimos
        private readonly UsuarioRepository _usuarioRepository;
        private readonly MainWindow _mainWindow;
        //private UsuarioRepository _usuarioRepository;
        public Login(UsuarioRepository usuarioRepository,
                    MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _usuarioRepository = usuarioRepository;
        }

        /*
         * el boton de login hará que abra otra ventana del main windows
         * añadimos async para poder validar por la BBDD
         */
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passClave.Password))
            {
                //Añadimos el accesoPermitido para poder validar el usuario y la contraseña
                //y solo si esta en la base de datos podrá iniciar sesion
                // Validación directa usando los controles txtUsuario y passClave
                bool accesoPermitido = await _usuarioRepository.LoginAsync(txtUsuario.Text, passClave.Password);
                //Tambien añadimos este if
                if (accesoPermitido)
                {
                    _mainWindow.Show();
                    this.Close();
                }

                //y añadimos el else en el caso de que no este en la bbdd
                else
                {
                    MessageBox.Show("Por favor introduce usuario y clave.", "Error de autenticación",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
            }
            else
            {
                MessageBox.Show("Por favor introduce usuario y clave.", "Error de autenticación",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
