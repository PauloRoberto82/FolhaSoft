<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="pimWeb.index" %>
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
   <div id="inicio-content">
        <h2 class="mb-4 big-text" runat="server">Bem-vindo, <%= usuario %>!</h2>
        <p class="employee-message big-text"></p>
        <img src="wwwroot/imagens/logofolha.png" alt="Logo da FolhaSoft" class="company-logo"> 
    </div>         
</div>
</body>
</html>
