using BLL;
using EjemploAzure.Regitro;
using EjemploAzure.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EjemploAzure.Consulta
{
    public partial class cSugerencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void buscarLinkButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Entidades.Sugerencias, bool>> filtros = x => true;
            RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();

            DateTime Desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime Hasta = Utils.ToDateTime(HastaTextBox.Text);

            int id;
            id = Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todo
                    break;
             
            

            }
            UsuarioGrid.DataSource = repositorio.GetList(filtros);
            UsuarioGrid.DataBind();
        }
    }
    }
