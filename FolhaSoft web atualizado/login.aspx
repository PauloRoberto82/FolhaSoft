<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="pimWeb.login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <title>Folha Software</title>
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;500;600&display=swap" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="wwwroot/css/site.css">
</head>

<body class="bg-login">
    <div class="left">

        <h1>FOLHA SOFT</h1>
        <img src="wwwroot/imagens/folha.png" alt="Descrição da Imagem" />
    </div>

    <div class="right">
        <div class="background">
            <div class="shape"></div>
            <div class="shape"></div>
        </div>
        <form runat="server">
            <h3 style="color: black;">ACESSAR</h3>

            <label for="username">Email</label>
            <input runat="server" type="text" placeholder="Insira seu e-mail" id="email">

            <label for="password">Senha</label>
            <input runat="server" type="password" placeholder="Digite sua Senha" id="senha">

            <asp:Button ID="botaoLogin" CssClass="btn-login" Text="Entrar" OnClick="ButtonLogin_Click" runat="server" BorderStyle="None" UseSubmitBehavior="False" />
        </form>
    </div>
</body>

</html>

