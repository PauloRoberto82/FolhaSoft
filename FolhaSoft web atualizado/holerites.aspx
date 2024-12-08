<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="holerites.aspx.cs" Inherits="pimWeb.holerites" %>

<style>
#inicio-content {
    box-shadow: 0px 4px 6px 0px rgba(0, 0, 0, 0.1); 
}
</style>

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
<br>
    <br>
    <br>
   <style>
#inicio-content {
    box-shadow: 0px 4px 6px 0px rgba(0, 0, 0, 0.1); 
}
</style>
   
<body >
    <br>
    <br>
    <br>
    <div id="inicio-content">
      <header>
            <h1>Holerite Software Empresarial <i class="fas fa-file-alt"></i> </h1>
        </header>



    <div id='pegatudo' style="position: relative; left: 0%;" > 
    <div class="absolute">FOLHA SOFTWARE EMPRESARIAL<br> RUA DA INTERFACE,90 CNPJ:12.345.678/0001-35</div>
    <div class="absolute2"><center>RECIBO DE PAGAMENTO MENSAL</center></div>
   <div class="absolute3"><center> <%=data %></center></div>
   <div class="absolute4">CODIGO:<%=codigo_func %> </div>
   <div class="absolute5">NOME: <%=nome %></div>
   <div class="absolute6">CARGO: <%=cargo %></div>
   <div class="absolute7">Código Descricao Nome Salario  INSS  IRRF Descontos Faltas</div>
   <div class="absolute8">
   <div class="absolute12" style="position: absolute; !important; top: 0px !important; right: 0 !important; left: -1px !important; width: 142px !important; height: 24px !important; border: 1px solid #000000 !important;" id="codigo1"><center ><%=codigo_pagamento %></center></div>
   <div class="absolute13" id="descricao1"><center><%=nome %></center></div>
   <div class="absolute14" id="nome1"> <center><%=referencia %></center></div>
   <div class="absolute15"><center id="vencimento1"><%=total_vencimentos %></center></div>
   <div class="absolute16"><center><%=aliquota_inss %></center> </div>
   <div class="absolute22"><center><%=faltas %></center> </div>
   <div class="absolute23"><center><%=aliquota_irrf %></center> </div>
   <div class="absolute24"><center><%=total_descontos %></center> </div>       


   </div>
    <div class="absolute9">TOTAL DE VENCIMENTOS <center> <%=total_vencimentos %> </center></div>
    <div class="absolute10">TOTAL DE DESCONTOS  <center><%=total_descontos %> </center></div>
    <div class="absolute11"> TOTAL LIQUIDO<center><%=total_liquido %> </center></div>
    </div>
        <p style="position: absolute; top: 700px; right: 156px;font-size: 23px;">Exibição do holerite atual. Para visualizar holerites anteriores acesse o aplicativo mobile</p>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    </div>
   
</body>
</html>
