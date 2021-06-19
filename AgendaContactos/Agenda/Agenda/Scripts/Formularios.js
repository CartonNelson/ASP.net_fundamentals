function ConInternoAction(conInterno) {
    if (conInterno.value == 'SI') {

        $("#'<%=inputOrg.ClientID%>'").attr('disabled', 'disabled');
        $("#'<%=inputOrg.ClientID%>'").val('');
        //area          
        $("#<%=selArea.ClientID%>").removeAttr('disabled');

    } else {

        $("#'<%=inputOrg.ClientID%>'").removeAttr('disabled');
        $(" #'<%=selArea.ClientID%>'").attr('disabled', 'disabled');
    }
}
function myFunc() {
    $('#<%=selArea.ClientID%>').val('TODOS');
    $('#<%=selArea.ClientID%>').attr('disabled', 'disabled');
    $('#<%=inputOrg.ClientID%>').removeAttr('disabled');
}