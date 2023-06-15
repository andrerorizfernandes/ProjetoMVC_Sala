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

        private void PrepararEdicao(GridViewEditEventArgs pGridViewEditEventArgs)
        {
            gvdUsuarios.EditIndex = pGridViewEditEventArgs.NewEditIndex;
            AtualizarDados();
        }

        private void CancelarEdicao(GridViewCancelEditEventArgs pGridViewCancelEditEventArgs)
        {
            gvdUsuarios.EditIndex = INDICE_INEXISTENTE;
            AtualizarDados();
        }

        private void Editar(GridViewUpdateEventArgs pGridViewUpdateEventArgs)
        {
            int index = pGridViewUpdateEventArgs.RowIndex;

            Label lblId = gvdUsuarios.Rows[index].FindControl("lblId") as Label;
            TextBox txtNome = gvdUsuarios.Rows[index].FindControl("txtNome") as TextBox;
            TextBox txtMatricula = gvdUsuarios.Rows[index].FindControl("txtMatricula") as TextBox;
            TextBox txtCurso = gvdUsuarios.Rows[index].FindControl("txtCurso") as TextBox;

            //ajustando os valores 
            if (lblId != null)
            {
                txtNome.Text = (txtNome == null) ? "" : txtNome.Text;
                txtMatricula.Text = (txtMatricula == null) ? "" : txtMatricula.Text;
                txtCurso.Text = (txtCurso == null) ? "" : txtCurso.Text;

                IAluno a = new Aluno(
                    Convert.ToInt32(lblId.Text),
                    txtNome.Text,
                    txtMatricula.Text,
                    txtCurso.Text);

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
                            Editar(a))
                    {
                        Mensagem("Aluno editado com sucesso");
                    }
                    else
                    {
                        Mensagem("Falha ao editar aluno");
                    }
                }
            }

            gvdUsuarios.EditIndex = INDICE_INEXISTENTE; //indicando que a linha não está mais em edição
            AtualizarDados();
        }

        private void Excluir(GridViewDeleteEventArgs pGridViewDeleteEventArgs)
        {
            int index = pGridViewDeleteEventArgs.RowIndex;
            Label lblId = gvdUsuarios.Rows[index].FindControl("lblId") as Label;

            if (lblId != null)
            {

                IAluno a = new Aluno(Convert.ToInt32(lblId.Text));
                if( AlunoController.
                    NovaInstancia().
                        Excluir(a))
                {
                    Mensagem("Aluno excluído com sucesso");
                }
                else
                {
                    Mensagem("Falha ao excluir aluno");
                }
            }

            gvdUsuarios.EditIndex = INDICE_INEXISTENTE;
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
            CancelarEdicao(e);
        }

        protected void gvdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Excluir(e);
        }

        protected void gvdUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PrepararEdicao(e);
        }

        protected void gvdUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Editar(e);
        }

        protected void btnAdicionarNovo_Click(object sender, EventArgs e)
        {
            Inserir();
        }
    }
}