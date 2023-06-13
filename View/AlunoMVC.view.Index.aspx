<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlunoMVC.view.Index.aspx.cs" Inherits="View.AlunoMVC_view_Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvdUsuarios" runat="server" AutoGenerateColumns="False" OnRowEditing="gvdUsuarios_RowEditing" OnRowUpdating="gvdUsuarios_RowUpdating" OnRowCancelingEdit="gvdUsuarios_RowCancelingEdit" OnRowDeleting="gvdUsuarios_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Código">
                    <EditItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nome">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNome" runat="server" Text='<%# Bind("Nome") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNome" runat="server" Text='<%# Bind("Nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Matricula">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMatricula" runat="server" Text='<%# Bind("Matricula") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMatricula" runat="server" Text='<%# Bind("Matricula") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Curso">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCurso" runat="server" Text='<%# Bind("Curso") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCurso" runat="server" Text='<%# Bind("Curso") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CommandName="Update"></asp:Button>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CommandName="Cancel"></asp:Button>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Edit"></asp:Button>
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="Delete"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>    

        <p></p>
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>                                    
                <td style="width:300px">
                    Nome:<br/>
                    <asp:TextBox ID="txtNovoNome" runat="server" Width="300" />
                </td>
                <td style="width:120px">
                    Matricula:<br/>
                    <asp:TextBox ID="txtNovaMatricula" runat="server" Width="120"/>
                </td>
                <td style="width:180px">
                    Curso:<br/>
                    <asp:TextBox ID="txtNovoCurso" runat="server" Width="180"/>
                </td>
                <td>
                    <asp:Button ID="btnAdicionarNovo" runat="server" Text="Adicionar" style="z-index: 1" OnClick="btnAdicionarNovo_Click"></asp:Button>
                </td>
            </tr>
        </table>   
    </div>
    </form>
</body>
</html>
