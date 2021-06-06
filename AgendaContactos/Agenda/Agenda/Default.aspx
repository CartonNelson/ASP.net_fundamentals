<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Agenda._Default" %>

<asp:Content ID="BodyForm" ContentPlaceHolderID="ContentForm" runat="server">
    <div runat="server" class="container">
    <br />
    <form id="FilterForm">
      <%-- Nivel 1 --%>  
      <div runat="server" class="form-row">
        <div runat="server" class="form-group col-md-4">
          <asp:label runat="server" for="inputNombre">Apellido y Nombre</asp:label>
          <input runat="server" type="text" class="form-control" id="inputNombre" placeholder="">
        </div>

        <div runat="server" class="form-group col-md-4">
          <asp:label runat="server" for="selPais">Pais</asp:label>
             <select class="form-control" id="selPais">
                <option>Argentina</option>
                <option>Uruguay</option>
                <option>Brasil</option>
                <option>Chile</option>
            </select>
        </div>

        <div runat="server" class="form-group col-md-4">
         <asp:label runat="server" for="inputLocal">Localidad</asp:label>
         <input runat="server" type="text" class="form-control" id="inputLocal" placeholder="">
        </div>
      </div>
      <%-- Nivel 2 --%>
        <div runat="server" class="form-row">
        <div runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="inputFingDesde">Fecha ingreso desde</asp:label>
         <input  runat="server" type="date" class="form-control" ID="inputFingDesde" placeholder="" value="">
         <asp:CustomValidator ID="FingDesdeValidator"  OnServerValidate="ValidarFechas" ControlToValidate="inputFingDesde"  runat="server"></asp:CustomValidator>                

        </div>
        
        <div  runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="inputFingHasta">Fecha ingreso hasta</asp:label>
          <input  runat="server" type="date" class="form-control" id="inputFingHasta" placeholder="">
        </div>

        <div  runat="server" class="form-group col-md-4">
         <asp:label  runat="server" for="selCinterno">Contacto interno</asp:label>
         <select runat="server" class="form-control" id="selCinterno"   onchange="">
                <option>Todos</option>
                <option>SI</option>
                <option>NO</option>
            </select>
        </div>
      </div>
      <%-- Nivel 3 --%>
      <div runat="server" class="form-row">
        <div runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="inputOrg">Organizacion</asp:label>
          <input  runat="server" type="text" class="form-control" id="inputOrg" placeholder="">
        </div>

        <div  runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="selArea">Area</asp:label>
          <select class="form-control" id="selArea">
                <option>Todos</option>
                <option>Marketing</option>
                <option>Finanzas</option>
                <option>RRHH</option>
                <option>Operaciones</option>
            </select>
        </div>

        <div  runat="server" class="form-group col-md-4">
         <asp:label  runat="server" for="selActivo">Activo</asp:label>
            <select class="form-control" id="selActivo">
                <option>Todos</option>
                <option>SI</option>
                <option>NO</option>
            </select>
        </div>
      </div>
      <%-- Botones --%>
      <div class="form-row"  runat="server">
           <div class="form-group col-md-8"  runat="server">
               <asp:ImageButton ToolTip="Limpiar Filtros" runat="server" ID="limpiarFiltrosBtn"  ImageUrl="Images/clearFilter.png" OnClientClick="this.form.reset();return false;"/>
               <%--CommandName="Limpiar" OnClick="limpiarFiltros" --%>
           </div>  
           <div class="form-group col-md-4"  runat="server">
               <asp:Button runat="server" type="submit" class="btn btn-success" Text="Buscar" ValidationGroup="ValidarCampos" OnClick="Consultar"></asp:Button>
               <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Nuevo Contacto" OnClick="redirigir"></asp:Button>

           </div> 
          
      </div>  

    </form>
 
</div>
    <div runat="server"  class="container" >
    <div id="ErrorContainer" runat="server" class="alert alert-danger" role="alert">
      <p>Error al filtrar busqueda: <%=msjVal%></p> 
    </div>
</div>
</asp:Content>
<asp:Content ID="BodyGrilla" ContentPlaceHolderID="ContentGrilla" runat="server">
    <div class="div-grilla" runat="server">
        <asp:GridView   CssClass="table table-condensed table-hover"
                        ID="GridContactos" runat="server" Text="Texto" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center" UseAccessibleHeader="true"
                         HeaderStyle-CssClass ="TextoConsulta" Width="100%" GridLines="Horizontal" OnRowCommand="GridEventClick">
                <Columns>                   
                    <asp:BoundField HeaderText="Apellido y Nombre" DataField="ApellidoNombre" />
                    <asp:BoundField HeaderText="Genero" DataField="Genero" />
                    <asp:BoundField HeaderText="Pais" DataField="Pais" />
                    <asp:BoundField HeaderText="Localidad" DataField="Localidad" />
                    <asp:BoundField HeaderText="Contacto Interno" DataField="Contacto_int" />
                    <asp:BoundField HeaderText="Organizacion" DataField="Organizacion" />
                    <asp:BoundField HeaderText="Area" DataField="Area" />
                    <asp:BoundField HeaderText="Fecha Ingreso" DataField="F_ingresoD" />
                    <asp:BoundField HeaderText="Activo" DataField="Activo" />
                    <asp:BoundField HeaderText="Direcc." DataField="Direccion" />
                    <asp:BoundField HeaderText="Tel. Fijo-Iterno" DataField="Telefono_fijo" />
                    <asp:BoundField HeaderText="Tel. Celular" DataField="Celular" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Cuenta Skype" DataField="Skype" />
                    <%-- Acciones --%>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:ImageButton ToolTip="Consultar"  ImageUrl="~/Images/zoom.png" ID="BtnConsultar" CommandName="Consultar" runat="server"></asp:ImageButton>
                            <asp:ImageButton ToolTip="Editar" ImageUrl="~/Images/edit.png" ID="BtnEditar" CommandName="Editar" runat="server"></asp:ImageButton>
                            <asp:ImageButton ToolTip="Eliminar" ImageUrl="~/Images/delete.png" ID="BtnEliminar" OnClientClick ="return window.confirm('¿Seguro que desea Eliminar el Contacto?');" CommandName="Eliminar" runat="server"></asp:ImageButton>
                            <asp:ImageButton ToolTip="Pausar/Activar" ImageUrl="~/Images/play_pause.png" ID="BtnActivar" CommandName="Activar" runat="server" OnClientClick ="return window.confirm('¿Seguro que desea Actualizar el Contacto?');"></asp:ImageButton>          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
           </asp:GridView>
        
    </div>
</asp:Content>
