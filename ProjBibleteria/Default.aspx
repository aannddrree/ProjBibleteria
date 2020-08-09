﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjBibleteria.Default" %>

<!DOCTYPE html>

<script type="text/javascript">
    function MostrarModal() {
        $("#modalMsg").modal('show');
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="js/jquery.validate.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/script.js" type="text/javascript"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bilheteria</title>
</head>
<body>
    <div style="padding-top:2%"></div>
    <div class="col-sm-8">
    <h2>Bilheteria</h2>
    </div>
    <form id="form1" runat="server">



        <div>
            <div class="col-sm-8">
                <div class="form-group">
                    <asp:Button ID="BtnInserir" runat="server" CssClass="btn btn-primary" Text="Inserir" OnClick="BtnInserir_Click" />
                    <br />
                </div>
            
            <asp:GridView ID="GDVBilhete" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GDVBilhete_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="Local" HeaderText="Local" />
                    <asp:BoundField DataField="qtd_pessoas" HeaderText="Qtd. Pessoas" />
                    <asp:BoundField DataField="dt_evento" HeaderText="Data do Evento" />
                    <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Alterar" CommandName="A" >
<ControlStyle CssClass="btn btn-warning"></ControlStyle>
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Excluir" CommandName="E" >
<ControlStyle CssClass="btn btn-danger"></ControlStyle>
                    </asp:ButtonField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
          </div>
            <br />
        </div>

        
<div class="modal fade" id="modalMsg" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Deseja Excluir?</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
        <asp:Button ID="btnConfirm" CssClass="btn btn-danger" runat="server" Text="Confirmar" OnClick="btnConfirm_Click" />
        <asp:Label ID="lblExcluir" runat="server"></asp:Label>
      </div>
    </div>
  </div>
</div>



    </form>


</body>
</html>
