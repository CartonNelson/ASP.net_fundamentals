<%@ Page Title="Crear/Actualizar contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCreateUpdate.aspx.cs" Inherits="Agenda.FormCreateUpdate" %>

 
<asp:Content ID="FormCreateUpdate" ContentPlaceHolderID="ContentForm" runat="server">
    
    <br />
    <div runat="server" class="container">
      <h2>
        <small class="text-muted"><%=Titulo%></small>
      </h2>  
    </div>
    <br />
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
          <asp:label runat="server" for="selGenero">Genero</asp:label>
             <select class="form-control" id="selGenero">
                <option>Masculino</option>
                <option>Femenino</option>
             </select>
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
      </div>
      <%-- Nivel 2 --%>
        <div runat="server" class="form-row">
        <div runat="server" class="form-group col-md-4">
         <asp:label runat="server" for="inputLocal">Localidad</asp:label>
         <input runat="server" type="text" class="form-control" id="inputLocal" placeholder="">
        </div>
        <div  runat="server" class="form-group col-md-4">
         <asp:label  runat="server" for="selCinterno">Contacto interno</asp:label>
         <select runat="server" class="form-control" id="selCinterno" onchange="ConInternoAction(this);">
                <option selected="selected">Todos</option>
                <option>SI</option>
                <option>NO</option>
            </select>
        </div>
        <div runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="inputOrg" ID="lblOrganizacion">Organizacion</asp:label>
          <input  runat="server" type="text" class="form-control" id="inputOrg" placeholder="" value="">
        </div>
      </div>
      <%-- Nivel 3 --%>
      <div runat="server" class="form-row">    
        <div  runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="selArea">Area</asp:label>
          <select runat="server"  class="form-control" id="selArea" disabled>
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
        <div runat="server" class="form-group col-md-4">
          <asp:label  runat="server" for="Direccion" ID="DireccionLbl">Direccion</asp:label>
          <input  runat="server" type="text" class="form-control" id="Direccion" placeholder="">
        </div>
        <%-- Nivel 4 --%>
          <div runat="server" class="form-row">
             <div runat="server" class="form-group col-md-4">
               <asp:label  runat="server" for="TelFijo" ID="TfijoLbl">Telefono Fijo - Interno</asp:label>
               <input  runat="server" type="text" class="form-control" id="TelFijo" placeholder="">
            </div>
            <div runat="server" class="form-group col-md-4">
              <asp:label  runat="server" for="TelCelular" ID="CelularLbl">Telefono Celular</asp:label>
              <input  runat="server" type="text" class="form-control" id="TelCelular" placeholder="">
            </div>
             <div runat="server" class="form-group col-md-4">
              <asp:label  runat="server" for="Email" ID="EmailLbl">Email</asp:label>
              <input type="email" class="form-control" id="Email" aria-describedby="emailHelp">
            </div>
          </div>
        <%-- Nivel 5 --%>
           <div runat="server" class="form-row">
             <div runat="server" class="form-group col-md-4">
               <asp:label  runat="server" for="Skype" ID="SkypeLbl">Skype</asp:label>
               <input  runat="server" type="text" class="form-control" id="Skype" placeholder="">
             </div>
           </div>
      </div>
      

    </form>
    <%-- Botones --%>
      
</div>
 <div runat="server" class="container">
             <div runat="server" class="col-md-8">
                </div>
           <div class="col-md-4"  runat="server">
               <asp:Button runat="server" type="submit" class="btn btn-success" Text="Guardar" ValidationGroup="ValidarCampos" ></asp:Button>
               <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Salir" OnClick="VolverAinicio"></asp:Button>

           </div> 
    
 </div>
 </asp:Content>   

