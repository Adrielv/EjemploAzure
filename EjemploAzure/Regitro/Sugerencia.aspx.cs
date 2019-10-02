using BLL;
using EjemploAzure.Utilitarios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploAzure.Regitro
{
    public partial class Sugerencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                Limpiar();

            }

        }
        public Sugerencias Llenar()
        {
            Sugerencias d = new Sugerencias();
            

            d.SugerenciasId = Utils.ToInt(SugerenciaIdTextBox.Text);

            d.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            d.Descripcion = DescripcionTextBox.Text;

            return d;

        }
       
    
        private void Limpiar()
        {
            SugerenciaIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        
            DescripcionTextBox.Text = string.Empty;
       
        }

        private bool RegSugerenciasExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Sugerencias> Repositorio = new RepositorioBase<Sugerencias>();
            Sugerencias Sugerencias = Repositorio.Buscar(Utils.ToInt(SugerenciaIdTextBox.Text));
            return (Sugerencias != null);
        }
        private void RegSugerenciasLlenaCampo(Sugerencias Sugerencias)
        {
            SugerenciaIdTextBox.Text = Convert.ToString(Sugerencias.SugerenciasId);
            FechaTextBox.Text = Sugerencias.Fecha.ToString("yyyy-MM-dd");
         
            DescripcionTextBox.Text = Convert.ToString(Sugerencias.Descripcion);
      

        
        }
        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Sugerencias> Repositorio = new RepositorioBase<Sugerencias>();

            Sugerencias Sugerencias = new Sugerencias();

            Sugerencias = Repositorio.Buscar(Utils.ToInt(SugerenciaIdTextBox.Text));

            if (Sugerencias != null)
                RegSugerenciasLlenaCampo(Sugerencias);
            else
            {
                Utils.ShowToastr(this.Page, "Error no se pudo buscar", "Error", "error");
                 Limpiar();
            }
        }
        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Sugerencias Sugerencias = new Sugerencias();
            RepositorioBase<Sugerencias> Repositorio = new RepositorioBase<Sugerencias>();
            bool paso = false;

            Sugerencias = Llenar();

            if (Utils.ToInt(SugerenciaIdTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(Sugerencias);
                Limpiar();
            }
            else
            {
                if (!RegSugerenciasExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
                    return;
                }
                paso = Repositorio.Modificar(Sugerencias);
                Limpiar();
            }

            if (paso)
            {
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                return;
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");

            Limpiar();
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Sugerencias> Repositorio = new RepositorioBase<Sugerencias>();

            var Sugerencias = Repositorio.Buscar(Utils.ToInt(SugerenciaIdTextBox.Text));

            if (Sugerencias != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(SugerenciaIdTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utils.ShowToastr(this.Page, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "No se pudo eliminar, usuario no existe", "error", "error");

           Limpiar();
        }
    }
}