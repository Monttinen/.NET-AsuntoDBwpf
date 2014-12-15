<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AsuntoDBweb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>AsuntoDB</h1>
        <p class="lead">Tervetuloa käyttämään AsuntoDB asuntotietokantaa.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Lisää asuntotyyppejä</h2>
            <p>
                Aloita lisäämällä asuntotyyppejä tai käytä valmiiksi luotuja tyyppejä.
            </p>
            <p>
                <a class="btn btn-default" href="Asuntotyyppi">Asuntotyypit &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Lisää asuntoja</h2>
            <p>
                Voit lisätä myös asuntoja ja valita niille asuntotyypit.
            </p>
            <p>
                <a class="btn btn-default" href="Asunto">Asunto listaus &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Lisää henkilöitä</h2>
            <p>
                Voit myös lisätä erilaisia henkilöitä tietokantaan ja linkittää heille asuntoja.
            </p>
            <p>
                <a class="btn btn-default" href="Henkilo">Henkilö listaus &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
