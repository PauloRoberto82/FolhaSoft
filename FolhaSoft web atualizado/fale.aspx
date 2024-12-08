<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fale.aspx.cs" Inherits="pimWeb.fale" %>

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
    <link rel=""

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
    <br>
    <br>
    <br>
    <div id="inicio-content">

        <header>
            <h1>Fale Com RH <i class="fas fa-comments"></i> </h1>
        </header>
        <label for="rh-nome">Nome do Funcionário:</label>
        <input type="text" id="rh-nome" name="nome" value="<%=nome %>" disabled >

        <label for="rh-email">Email do Funcionário:</label>
        <input type="email" id="rh-email" name="email" value="<%=email %>" disabled>

        <label for="rh-assunto">Assunto:</label>
        <input type="text" id="rh-assunto" name="assunto" placeholder="Digite o assunto">

        <label for="rh-mensagem">Mensagem:</label>
        <textarea id="rh-mensagem" name="mensagem" rows="4" placeholder="Digite sua mensagem"></textarea>
        <br>
        <button type="submit" id="rh-enviar-btn" onclick="limpa()" style="position: relative; left: 46%;">
            <span>Enviar</span>
            <i id="rh-icon">📬</i>
        </button>
        <br>
        <br>
        <br>
    </div>        
</div>
</body>
    <script>
        function limpa() {
            document.getElementById('rh-assunto').value = "";
            document.getElementById('rh-mensagem').value = "";
        }
    </script>
</html>


