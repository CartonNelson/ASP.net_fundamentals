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
    <form   id="ABMForm">
      <%-- Nivel 1 --%>  
      <div runat="server" class="form-row">
        <div runat="server" class="form-group col-md-4">
          <asp:label runat="server" for="inputNombre">Apellido y Nombre</asp:label>
          <input runat="server" type="text" class="form-control" id="inputNombre" placeholder="">
             <asp:RequiredFieldValidator ValidationGroup="ValidarCampos" ID="RequiredFieldValidatorUserName"   runat="server"   ControlToValidate="inputNombre"
                                        Display="Dynamic" SetFocusOnError="True" CssClass="alert-text" />
        </div>
         
        <div runat="server" class="form-group col-md-4">
          <asp:label runat="server" for="selGenero">Genero</asp:label>
             <select runat="server" class="form-control" id="selGenero">
                <option value="1">Masculino</option>
                <option value="2">Femenino</option>
             </select>
            
        </div>
        <div runat="server" class="form-group col-md-4">
          <asp:label runat="server" for="selPais">Pais</asp:label>
             <select class="form-control" id="selPais" runat="server">  
                <option value="1">Argentina</option>
                <option value="2">Uruguay</option>
                <option value="3">Brasil</option>
                <option value="4">Chile</option>
                 <option value="5">Italia</option>
            </select>
        </div>
      </div>
      <%-- Nivel 2 --%>
        <div runat="server" class="form-row">
        <div runat="server" class="form-group col-md-4">
         <asp:label runat="server" id="lblLocal" for="inputLocal">Localidad</asp:label>
         <input runat="server" type="text" class="form-control" id="inputLocal" placeholder="">
        </div>
        <div  runat="server" class="form-group col-md-4">
         <asp:label  runat="server" for="selCinterno">Contacto interno</asp:label>
         <select runat="server" class="form-control" id="selCinterno" onchange="ConInternoAction(this);">
                <%--<option value="1" selected="selected">Todos</option>--%>
                <option value="2">SI</option>
                <option selected="selected" value="3">NO</option>
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
          <select runat="server"  class="form-control" id="selArea">
                <option value="10"></option>
                <%--<option>Marketing</option>
                <option>Finanzas</option>
                <option>RRHH</option>
                <option>Operaciones</option>--%>
            </select>
        </div>

        <div  runat="server" class="form-group col-md-4">
         <asp:label  runat="server" for="selActivo">Activo</asp:label>
            <select class="form-control" id="selActivo"  runat="server">
                <option value="1">SI</option>
                <option value="2">NO</option>
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
              <asp:label  runat="server" for="inpEmail" ID="EmailLbl">Email</asp:label>
              <input type="text" runat="server"  class="form-control" id="inpEmail" aria-describedby="emailHelp">
              <asp:RequiredFieldValidator ValidationGroup="ValidarCampos" ID="RequiredFieldValidator2"   runat="server"   ControlToValidate="inpEmail"
                                            Display="Dynamic" SetFocusOnError="True" CssClass="alert-text" />
              <asp:CustomValidator ValidationGroup="ValidarCampos" ID="EmailValidator"  OnServerValidate="ValidarEmail" ControlToValidate="inpEmail"  runat="server"></asp:CustomValidator>                

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
     <%-- <asp:ValidationSummary  DisplayMode="SingleParagraph" /> --%>
     <div runat="server" class="col-md-8">
                </div>
           <div class="col-md-4"  runat="server">
               <asp:Button id="btnAccion" runat="server" type="submit" class="btn btn-success" Text="Guardar" ValidationGroup="ValidarCampos" onClick="Accion"></asp:Button>
               <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Salir" OnClick="VolverAinicio"></asp:Button>

           </div> 
    
 </div>
<br />
    <div runat="server"  class="container" >
        <div id="ErrorContainer" runat="server" class="alert alert-danger" role="alert">
          <p>Error: <%=Application["MsjError"]%></p> 
        </div>

       <asp:ValidationSummary ValidationGroup="ValidarCampos" runat="server" ID="ValidationSummary" HeaderText="Existen campos requeridos no ingresados"  DisplayMode="BulletList" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
    </div>
    <script>
        function ConInternoAction(conInterno) {
            if (conInterno.value == '2') {
                 
                $("#<%=inputOrg.ClientID%>").attr('disabled', 'disabled');
                $("#<%=inputOrg.ClientID%>").val('');
                //area          
                $( "#<%=selArea.ClientID%>").removeAttr('disabled');

            } else {
                $('#<%=selArea.ClientID%>').val('10'); //Todos
                $("#<%=inputOrg.ClientID%>").removeAttr('disabled');
                $(" #<%=selArea.ClientID%>").attr('disabled', 'disabled');
            }
        }
        
    </script>
 </asp:Content>   

