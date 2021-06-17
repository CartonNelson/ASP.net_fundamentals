<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Agenda._Default" %>

<asp:Content ID="BodyForm" ContentPlaceHolderID="ContentForm" runat="server">
    <br />
    <div runat="server" class="container">
      <h2>
        <small class="text-muted">Consulta de Agenda</small>
      </h2>  
    </div>
    <div runat="server" class="container">
    <br />
    <form  id="FilterForm">
      <%-- Nivel 1 --%>  
      <div runat="server" class="form-row">
        <div runat="server" class="form-group col-md-4">
          <asp:label runat="server" for="inputNombre">Apellido y Nombre</asp:label>
          <input runat="server" type="text" class="form-control" id="inputNombre" placeholder="">
        </div>

        <div runat="server" class="form-group col-md-4">
          <asp:label runat="server" for="selPais">Pais</asp:label>
             <select runat="server" class="form-control" id="selPais">
               <option value="-1">Todos</option>  
                <option value="1">Argentina</option>
                <option value="2">Uruguay</option>
                <option value="3">Brasil</option>
                <option value="4">Chile</option>
                 <option value="5">Italia</option>
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
         <asp:CustomValidator ValidationGroup="ValidarCampos" ID="FingDesdeValidator"  OnServerValidate="ValidarFechas" ControlToValidate="inputFingDesde"  runat="server"></asp:CustomValidator>                

        </div>
        
        <div  runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="inputFingHasta">Fecha ingreso hasta</asp:label>
          <input  runat="server" type="date" class="form-control" id="inputFingHasta" placeholder="">
        </div>

        <div  runat="server" class="form-group col-md-4">
         <asp:label  runat="server" for="selCinterno">Contacto interno</asp:label>
         <select runat="server" class="form-control" id="selCinterno" onchange="ConInternoAction(this);">
                <option value="-1" selected="selected">Todos</option>
                <option value="2">SI</option>
                <option value="3">NO</option>
            </select>
        </div>
      </div>
      <%-- Nivel 3 --%>
      <div runat="server" class="form-row">
        <div runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="inputOrg" ID="lblOrganizacion">Organizacion</asp:label>
          <input  runat="server" type="text" class="form-control" id="inputOrg" placeholder=""  >
        </div>

        <div  runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="selArea">Area</asp:label>
          <select runat="server"  class="form-control" id="selArea">
              <option value="10">Todos</option>  
              <%--
                <option>Marketing</option>
                <option>Finanzas</option>
                <option>RRHH</option>
                <option>Operaciones</option>--%>
            </select>
        </div>

        <div  runat="server" class="form-group col-md-4">
         <asp:label  runat="server" for="selActivo">Activo</asp:label>
            <select  runat="server" class="form-control" id="selActivo">
                <option value="-1">Todos</option>
                <option value="2">SI</option>
                <option value="3">NO</option>
            </select>
        </div>
      </div>
      <%-- Botones --%>
      <div class="form-row"  runat="server">
           <div class="form-group col-md-8"  runat="server">
               <asp:ImageButton ToolTip="Limpiar Filtros" OnClick="LimpiarFiltros" runat="server" ID="limpiarFiltrosBtn"  ImageUrl="Images/clearFilter.png"/>  
               <%--CommandName="Limpiar" OnClick="limpiarFiltros" --%>
           </div>  
           <div class="form-group col-md-4"  runat="server">
               <asp:Button runat="server" type="submit" class="btn btn-success" Text="Buscar" ValidationGroup="ValidarCampos" OnClick="Consultar" ></asp:Button>
               <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Nuevo Contacto" OnClick="AltaContacto"></asp:Button>

           </div> 
          
      </div>  

    </form>

</div>
    <div runat="server"  class="container" >
        <div id="ErrorContainer" runat="server" class="alert alert-danger" role="alert">
          <p><%=Application["MsjError"]%></p> 
        </div>
    </div>
    <script >
        function ConInternoAction(conInterno) {
            
            if (conInterno.value == '2') {
                 
                $("#<%=inputOrg.ClientID%>").attr('disabled', 'disabled');
                $("#<%=inputOrg.ClientID%>").val('');
                //area          
                $( "#<%=selArea.ClientID%>").removeAttr('disabled');

            } else {
                $('#<%=selArea.ClientID%>').val('10'); //Todos
                $("#<%=inputOrg.ClientID%>").removeAttr('disabled'); 
                $("#<%=selArea.ClientID%>").attr('disabled', 'disabled');
               
            }
        }
        function myFunc() {
            $('#<%=selArea.ClientID%>').val('10');
            $('#<%=selArea.ClientID%>').attr('disabled', 'disabled');
            $('#<%=inputOrg.ClientID%>').removeAttr('disabled');
        }
    </script>
<%--</asp:Content>
<asp:Content ID="BodyGrilla" ContentPlaceHolderID="ContentGrilla" runat="server">--%>
 
    


   
    <div class="div-grilla" runat="server">
        
        <asp:GridView   CssClass="table table-condensed table-hover"
                        ID="GridContactos" runat="server" Text="Texto" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center" UseAccessibleHeader="true"
                         HeaderStyle-CssClass ="TextoConsulta" Width="100%" GridLines="Horizontal" OnRowCommand="GridEventClick" 
                            AllowPaging="true" OnPageIndexChanging="gdview_PageIndexChanging" PageSize="5">
       
                
                <Columns>
                    
                    <asp:BoundField  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="id_contacto" DataField="id_contacto" /> 
                    <asp:BoundField HeaderText="Apellido y Nombre" DataField="apellido_nombre" />
                    <asp:BoundField  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="id_genero" DataField="id_genero" /> 
                    <%--<asp:BoundField  Visible = "false" HeaderText="id_genero" DataField="id_genero" />--%>
                    <asp:BoundField HeaderText="Genero" DataField="d_genero" />
                    <asp:BoundField  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="id_pais" DataField="id_pais" />
                    <%--<asp:BoundField Visible = "false" HeaderText="id_pais" DataField="id_pais" />--%>
                    <asp:BoundField HeaderText="Pais" DataField="d_pais" />
                    <asp:BoundField HeaderText="Localidad" DataField="localidad" />
                    <asp:BoundField  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="id_cont_int" DataField="id_cont_int" />
                    <%--<asp:BoundField Visible = "false" HeaderText="id_con_int" DataField="id_cont_int" />--%>
                    <asp:BoundField HeaderText="Contacto Interno" DataField="d_con_int" />
                    <asp:BoundField HeaderText="Organizacion" DataField="organizacion" />
                    <asp:BoundField  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="id_area" DataField="id_area" />
                    <%--<asp:BoundField Visible = "false" HeaderText="id_area" DataField="id_area" />--%>
                    <asp:BoundField HeaderText="Area" DataField="d_area" />
                    <asp:BoundField HeaderText="Fecha Ingreso" DataField="fecha_ingreso" />
                    <asp:BoundField  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="id_activo" DataField="id_activo" />
                    <%--<asp:BoundField Visible = "false" HeaderText="id_activo" DataField="id_activo" />--%>
                    <asp:BoundField HeaderText="Activo" DataField="d_activo" />
                    <asp:BoundField HeaderText="Direcc." DataField="direccion" />
                    <asp:BoundField HeaderText="Tel. Fijo-Iterno" DataField="Tel_fijo" />
                    <asp:BoundField HeaderText="Tel. Celular" DataField="tel_cel" />
                    <asp:BoundField HeaderText="Email" DataField="e_mail" />
                    <asp:BoundField HeaderText="Cuenta Skype" DataField="skype" />
                    <%-- Acciones --%>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:ImageButton ToolTip="Consultar"  ImageUrl="/Images/zoom.png" ID="BtnConsultar" CommandName="DetalleContacto"  OnClick="ConsultarContacto"  runat="server"></asp:ImageButton>
                            <asp:ImageButton ToolTip="Editar" ImageUrl="/Images/edit.png" ID="BtnEditar" CommandName="EditarContacto" OnClick="EditarContacto" runat="server"></asp:ImageButton>
                            <asp:ImageButton ToolTip="Eliminar" ImageUrl="/Images/delete.png" ID="BtnEliminar" OnClick="eliminarContacto" OnClientClick ="return window.confirm('¿Seguro que desea Eliminar el Contacto?');" CommandName="Eliminar" runat="server"></asp:ImageButton>
                            <asp:ImageButton ToolTip="Pausar/Activar" ImageUrl="/Images/play_pause.png" ID="BtnActivar"  CommandName="Activar" runat="server" OnClick="activarContacto" OnClientClick ="return window.confirm('¿Seguro que desea Actualizar el Contacto?');"></asp:ImageButton>          
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            <%--<PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle"/>--%>
                <PagerStyle CssClass="paginationStyle"  HorizontalAlign="Center" VerticalAlign="Middle" />
           </asp:GridView>
        

        <style type="text/css"> 
            /*.hiddencol { display: none; } HorizontalAlign ="Center"*/
            

        </style>
    </div>
 
 
</asp:Content>


 <%--<asp:ImageButton ID="ActivarContacto" CommandName="Activar" runat="server" OnClick="ActivarContacto" 
                                             OnClientClick="return window.confirm('¿Seguro que desea Actualizar el Contacto?');">
                            </asp:ImageButton>--%>