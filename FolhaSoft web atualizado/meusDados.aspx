<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meusDados.aspx.cs" Inherits="pimWeb.meusDados" %>

<!doctype html>
<html lang="pt-br">
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

             <br>
        <br>
        <br>
            <div id="inicio-content">

        <header><h1 style="text-align: center;">Meus Dados <i class="fas fa-user"></i> </h1> </header>
        <br>
        <br>
            <table id="tabela-meusdados"> 
                <tr>
                    <th> Codigo <i class="fas fa-barcode"></i></th>
                    <th><%= matricula %></th>
                </tr>
                <tr>
                    <td> Matricula <i class="fas fa-id-card"></i></td>
                    <td><%= matricula %></td>
                </tr>
                <tr>
                    <td> Nome <i class="fas fa-user"></i></td>
                    <td><%= nome %></td>
                </tr>
                <tr>
                    <td> CPF <i class="fas fa-id-card"></i> </td>
                    <td><%= cpf %></td>
                </tr>
                <tr>
                    <td> RG <i class="fas fa-address-card"></i></td>
                    <td><%= rg %></td>
                </tr>
                <tr>
                    <td> Email <i class="fas fa-envelope"></i></td>
                    <td><%= email %></td>
                </tr>
                <tr>
                    <td> Data de Nascimento <i class="fas fa-birthday-cake"></i></td>
                    <td><%= data_nascimento %></td>
                </tr>
                <tr>
                    <td> Sexo <i class="fas fa-venus-mars"></i></td>
                    <td><%= sexo %></td>
                </tr>
                <tr>
                    <td> Estado Civil <i class="fas fa-ring"></i></td>
                    <td><%= estado_civil %></td>
                </tr>
                <tr>
                    <td> Carteira de Trabalho <i class="fas fa-briefcase"></i> </td>
                    <td><%= carteira_trabalho %></td>
                </tr>
                <tr>
                    <td> NIS/PIS <i class="fas fa-list-ol"></i></td>
                    <td><%= nis_pis %></td>
                </tr>
                <tr>
                    <td> Carga Horária <i class="fas fa-clock"></i></td>
                    <td><%= carga_horaria %>/semana</td>
                </tr>
                <tr>
                    <td> Cargo <i class="fas fa-building"></i></td>
                    <td><%= cargo %></td>
                </tr>

                <tr>
                    <td>Salário <i class="fas fa-money-bill-wave"></i> </td>
                    <td><%= salario %></td>
                </tr>
            </table>
            <br>
            <br>
            <br>
            
        </div>     
</div>
</body>
</html>