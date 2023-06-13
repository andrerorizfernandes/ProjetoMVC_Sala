using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class AlunoMVC_view_Index : System.Web.UI.Page
    {
        private const int INDICE_INEXISTENTE = -1;

        private void LimparCampos()
        {
            txtNovoNome.Text = string.Empty;
            txtNovoCurso.Text = string.Empty;
            txtNovaMatricula.Text = string.Empty;
        }

        private void Mensagem(string pMessagem)
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "alert('" + pMessagem + "');";
            sJavaScript += "\n";
            sJavaScript += "</script>";
            ClientScript.RegisterStartupScript(typeof(string), "MessageBox", sJavaScript);
        }

        private void AtualizarDados()
        {
            gvdUsuarios.DataSource =
                AlunoController.
                    NovaInstancia().
                        Listar();

            gvdUsuarios.DataBind();
        }

        private void Inserir()
        {
            int lIdentificadorAluno =
                AlunoController.
                    NovaInstancia().
                        ProximoIdentificadorDeAluno().
                            Id;

            IAluno a = new Aluno(
                lIdentificadorAluno,
                txtNovoNome.Text,
                txtNovaMatricula.Text,
                txtNovoCurso.Text);

            if (a.Nome == string.Empty)
            {
                Mensagem("Informe o nome");
            }
            else if (a.Matricula == string.Empty)
            {
                Mensagem("Informe a matrícula");
            }
            else if (a.Curso == string.Empty)
            {
                Mensagem("Informe o curso");
            }
            else
            {
                if (AlunoController.
                    NovaInstancia().
                        Inserir(a))
                {
                    Mensagem("Aluno inserido com sucesso");
                    LimparCampos();
                }
                else
                {
                    Mensagem("Falha ao inserir aluno");
                }
            }

            AtualizarDados();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AtualizarDados();
            }
        }

        protected void gvdUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvdUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvdUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnAdicionarNovo_Click(object sender, EventArgs e)
        {
            Inserir();
        }
    }
}