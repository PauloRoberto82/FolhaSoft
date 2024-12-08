<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notificacoes.aspx.cs" Inherits="pimWeb.notificacoes" %>

<!doctype html>
<html lang="en">
<head>
   <title>Folha Software</title>
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;500;600&display=swap" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="wwwroot/js/site.js"></script>    
    <link rel="stylesheet" href="wwwroot/css/site.css">

</head>
<body>
<div class="wrapper d-flex align-items-stretch">
<nav id="sidebar">
<div class="p-4 pt-5">
                <a href="#" class="img logo rounded-circle mb-5"
                    style="background-image: url(wwwroot/imagens/user.png);"></a>
<ul class="list-unstyled components mb-5">
<li class="active">
<a id="inicio" href="telainicio.aspx"><i class="fas fa-home"></i> Inicio</a>
</li>
<li>
                        <a id="meusdados" href="meusDados.aspx"><i class="fas fa-user"></i> Meus dados</a>
</li>
<li>
                        <a id="notifica" href="notificacoes.aspx"><i class="fas fa-bell"></i> Notificações</a>
</li>
<li>
                        <a id="holerite" href="holerites.aspx"><i class="fas fa-file-alt"></i> Holerites</a>
</li>
<li>
                        <a id="fale" href="fale.aspx"><i class="fas fa-comments"></i> Fale com RH</a>
</li>
<li>
<a href="login.aspx" id="sair">
    <i class="fas fa-sign-out-alt"></i> Sair
</a>
</li>
</ul>
<div class="footer">
<p>
</p>
</div>
</div>
</nav>
<div id="content" class="p-4 p-md-5">

<br>
    <br>
    <br>
    <div id="inicio-content" class="center-content">
         <header>   <h1>Notificações</h1> </header>
        <div id="">
<%--            <table>
                <tr>
                    <th>Data <i class="fas fa-barcode"></i></th>
                    <th>Assunto</th>
                    <th>Situação</th>
                    <th>Situação</th>
                    <th>Checkbox</th>
                </tr>
                <tr>
                    <td>22/10/10 <i class="fas fa-id-card"></i></td>
                    <td>Venc. Férias</td>
                    <td>Pendente</td>
                    <td>Situação</td>
                    <td class="center-div"><input type="checkbox" class="message-checkbox"></td>
                </tr>
                <tr>
                    <td>22/10/20 <i class="fas fa-user"></i></td>
                    <td>Aviso de Ferias</td>
                    <td>Concluído</td>
                    <td>Situação</td>
                    <td class="center-div"><input type="checkbox" class="message-checkbox"></td>
                </tr>
            </table>--%>
            <form id="formGridview" runat="server" style=" color:black; border-color:black; height: auto; width: auto; background-color: transparent; position: static; transform: none; top: auto; left: auto; border-radius: 0; backdrop-filter: none; border: none; box-shadow: none;">
                <asp:GridView ID="notificacao" runat="server" ForeColor="#999999" style="color:black !important;" AlternatingRowStyle-BackColor="#999999" BackColor="#999999" AlternatingRowStyle-ForeColor="#999999" EditRowStyle-BackColor="#999999" EditRowStyle-ForeColor="#999999" EmptyDataRowStyle-BackColor="#999999" EmptyDataRowStyle-ForeColor="#999999" RowStyle-BackColor="#999999" PagerStyle-ForeColor="#999999">
                </asp:GridView>
            </form>
            <input id="status-message" type="text" value="Status: Você tem uma mensagem () Não lida" disabled>
        </div>
    <br>
    <br>
    <br>
    </div>
       
</div>
</body>
</html>