<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Sugerencia.aspx.cs" Inherits="EjemploAzure.Regitro.Sugerencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-8">
            <div class="card">
                <div class="card-header text-uppercase text-center text-info"> Registro Sugerencia</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" class="text-info " Text="SugerenciaId"></asp:Label>
                                    <asp:Button class="btn btn-info" CausesValidation ="False" ID="BuscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
                                    <asp:TextBox class="form-control" type="number" ID="SugerenciaIdTextBox" Text="0" runat="server" ValidationGroup="Guardar"></asp:TextBox>
                                  
                                   
                                </div>
                            
                        </div>                      
                    <%--Fecha --%>
                          <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                     <asp:Label ID="Label10" runat="server" class="text-info" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="FechaTextBox" type="date" runat="server"></asp:TextBox>
                            </div>
                            
                         </div>
                        </div>                      

                    <%--Descrpcion  --%>
                 <div class="col-md-12 col-md-offset-3">
                   <div class="container ">
                      <div class="form-group">
                
                             <label for="Descripcion" class="col-sm-6 col-form-label text-info">Descripcion</label>
                            <asp:TextBox ID="DescripcionTextBox" type="text" runat="server" Class="form-control input-sm"></asp:TextBox>
                         
                       </div>
                 </div>
       
   <br>
                    <br>
                    
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button Text="Nuevo" class="btn btn-primary" runat="server" ID="nuevoButton" OnClick="nuevoButton_Click" />
                                    <asp:Button Text="Guardar" class="btn btn-success" runat="server" ID="guadarButton" OnClick="guardarButton_Click" />
                                    <asp:Button Text="Eliminar" class="btn btn-danger" runat="server" ID="eliminarButton" OnClick="eliminarButton_Click" />
                                </div>
                            </div>
                        </div>
    </div>
                    </form>
                </article>
            </div>
            <!-- card.// -->
    </div>
    <br>
</asp:Content>
