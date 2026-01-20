using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using di.proyecto.clase._2025.Backend.Servicios_Repositorio_;
using di.proyecto.clase._2025.Frontend.Mensajes;
using di.proyecto.clase._2025.Frontend.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace di.proyecto.clase._2025.MVVM
{

    public class MVArticulo : MVBase
    {
        #region Campos y propiedades privadas
        /// <summary>
        /// Objeto que guarda el modelo de artículo actual
        /// Está vinculado a la vista para mostrar y editar los datos del artículo
        /// </summary>

        private Modeloarticulo _modeloArticulo;

        private Articulo _articulo;

        private Usuario _usuario;
        /// <summary>
        /// Repositorio para gestionar las operaciones de datos relacionadas con los modelos de artículo
        /// </summary>
        private ModeloArticuloRepository _modeloArticuloRepository;

        private ArticuloRepository _articuloRepository;

        /// <summary>
        /// Repositorio para gestionar las operaciones de datos relacionadas con los tipos de artículo
        /// </summary>
        private TipoArticuloRepository _tipoArticuloRepository;

        private UsuarioRepository _usuarioRepository;
        private DepartamentoRepository _departamentoRepository;
        private EspacioRepository _espacioRepository;

        private TipoUsuarioRepository _tipoUsuarioRepository;
        private GrupoRepository _grupoRepository;
        private RolRepository _rolRepository;
        /// <summary>
        /// lista de tipos de artículos disponibles
        /// </summary>
        private List<Tipoarticulo> _listaTipoArticulos;

        private List<Usuario> _listaUsuarios;
        private List<Modeloarticulo> _listaModeloArticulo;
        private List<string> _listaEstado;
        private List<Departamento> _listaDepartamento;
        private List<Espacio> _listaEspacio;

        private List<Tipousuario> _listaTipoUsuario;
        private List<Rol> _listaRol;

        //para la creacion de la lista de articulos:
        private List<Articulo> _listaArticulos;
        #endregion
        #region Getters y Setters
        public List<Tipoarticulo> listaTiposArticulos => _listaTipoArticulos;

        public List<Usuario> listaUsuarios => _listaUsuarios;
        public List<Modeloarticulo> listaModelo => _listaModeloArticulo;
        public List<string> listaEstado => _listaEstado;
        public List<Departamento> listaDepartamento => _listaDepartamento;
        public List<Espacio> listaEspacio => _listaEspacio;

        public List<Tipousuario> listaTipoUsuario => _listaTipoUsuario;
        public List<Rol> listaRol => _listaRol;

        public List<Articulo> listaArticulos => _listaArticulos;
        //"modeloArticulo" será el nombre que pongamos en el binding para que se guarden los datos
        public Modeloarticulo modeloArticulo
        {
            get => _modeloArticulo;
            set => SetProperty(ref _modeloArticulo, value);
        }

        public Articulo articulo
        {
            get => _articulo;
            set => SetProperty(ref _articulo, value);
        }

        public Usuario usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }
        #endregion
        // Aquí puedes añadir propiedades y métodos específicos para el ViewModel de Artículo
        //Anotacion importante!!! si da error es porque no estan los repositorios 
        public MVArticulo(ModeloArticuloRepository modeloArticuloRepository,
                            TipoArticuloRepository tipoArticuloRepository,

                            ArticuloRepository articuloRepository,
                            UsuarioRepository usuarioRepository,
                            DepartamentoRepository departamentoRepository,
                            EspacioRepository espacioRepository,

                            RolRepository rolRepository,
                            TipoUsuarioRepository tipoUsuarioRepository

            )
        {
            _modeloArticuloRepository = modeloArticuloRepository;
            _tipoArticuloRepository = tipoArticuloRepository;
            _modeloArticulo = new Modeloarticulo();

            _articuloRepository = articuloRepository;
            _usuarioRepository = usuarioRepository;
            _departamentoRepository = departamentoRepository;
            _espacioRepository = espacioRepository;
            _articulo = new Articulo();
            _articulo.Fechaalta = DateTime.Now;

            _rolRepository = rolRepository;
            _tipoUsuarioRepository = tipoUsuarioRepository;
            _usuario = new Usuario();
        }

        public async Task Inicializa()
        {
            try
            {
                _listaTipoArticulos = await GetAllAsync<Tipoarticulo>(_tipoArticuloRepository);

                _listaDepartamento = await GetAllAsync<Departamento>(_departamentoRepository);
                _listaEspacio = await GetAllAsync<Espacio>(_espacioRepository);
                _listaModeloArticulo = await GetAllAsync(_modeloArticuloRepository);
                _listaUsuarios = await _usuarioRepository.GetAllAsync();


                _listaEstado = new List<string> { "Nuevo", "Usado", "Reparado", "Baja" };

                _listaTipoUsuario = await GetAllAsync<Tipousuario>(_tipoUsuarioRepository);
                _listaRol = await GetAllAsync<Rol>(_rolRepository);

                //para la lista de articulos
                _listaArticulos = await GetAllAsync<Articulo>(_articuloRepository);

            }
            catch (Exception ex)
            {
                MensajeError.Mostrar("GESTIÓN ARTÍCULOS", "Error al cargar los tipos de artículos\nNo puedo conectar con la base de datos", 0);

            }
        }

        public async Task<bool> GuardarModeloArticuloAsync()
        {

            bool correcto = true;
            try
            {
                if (modeloArticulo.Idmodeloarticulo == 0)
                {
                    await _modeloArticuloRepository.AddAsync(modeloArticulo);
                }
                else
                {
                    await _modeloArticuloRepository.UpdateAsync(modeloArticulo);
                }
            }
            catch (Exception ex)
            {
                correcto = false;
            }
            return correcto;
        }


        public async Task<bool> GuardarArticuloAsync()
        {
            bool correcto = true;
            try
            {
                if (articulo.Idarticulo == 0)
                {
                    articulo.Idarticulo = await IncrementoIdArticulo();
                    await _articuloRepository.AddAsync(articulo);
                }
                else
                {
                    await _articuloRepository.UpdateAsync(articulo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                correcto = false;
            }
            return correcto;
        }

        public async Task<bool> GuardarUsuarioAsync()
        {


            bool correcto = true;

            try
            {
                if (usuario.Idusuario == 0)
                {
                    await _usuarioRepository.AddAsync(usuario);
                }
                else
                {
                    await _usuarioRepository.UpdateAsync(usuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario:\n" + ex.Message);
                correcto = false;
            }

            return correcto;
        }

        //Articulo no es autoincrementable...
        private async Task<int> IncrementoIdArticulo()
        {
            int? ultimoId = await _articuloRepository.GetUltimoIdAsync();
            return ((int)ultimoId + 1);
        }

       



    }
}
