<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/HeadSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LandLyst._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="NavMenu" class="navBar">
        <div>
            <a href="#">Forside</a>
            <a href="booking">Book</a>
            <a href="test">Test</a>
            <i class="fa fa-times" onclick="NavBarFunc('0px', '0', '-150px')"></i>
        </div>
    </div>
    <div class="menuClass">
        <button type="button" id="menuButton" onclick="NavBarFunc('150px', '1', '0px')" class="menuButton btn btn-light">
            <i class="fas fa-bars"></i> Menu
        </button>
    </div>
    <div class="center Header1">
        <h1 class="display-4">Hotel LandLyst</h1>
    </div>
    <div class="bottomBar">
        <div class="Middlebutton">
            <a href="Booking">
                <p>Book<br>Værelse</p>
            </a>
        </div>
        <p>Lorem Ipsum er ganske enkelt fyldtekst fra print- og typografiindustrien. Lorem Ipsum har været standard fyldtekst siden 1500-tallet, hvor en ukendt trykker sammensatte en tilfældig spalte for at trykke en bog til sammenligning af forskellige skrifttyper. Lorem Ipsum har ikke alene overlevet fem århundreder, men har også vundet indpas i elektronisk typografi uden væsentlige ændringer. Sætningen blev gjordt kendt i 1960'erne med lanceringen af Letraset-ark, som indeholdt afsnit med Lorem Ipsum, og senere med layoutprogrammer som Aldus PageMaker, som også indeholdt en udgave af Lorem Ipsum.</p>
        <p>I modsætning til hvad mange tror, er Lorem Ipsum ikke bare tilfældig tekst. Det stammer fra et stykke litteratur på latin fra år 45 f.kr., hvilket gør teksten over 2000 år gammel. Richard McClintock, professor i latin fra Hampden-Sydney universitet i Virginia, undersøgte et af de mindst kendte ord "consectetur" fra en del af Lorem Ipsum, og fandt frem til dets oprindelse ved at studere brugen gennem klassisk litteratur. Lorem Ipsum stammer fra afsnittene 1.10.32 og 1.10.33 fra "de Finibus Bonorum et Malorum" (Det gode og ondes ekstremer), som er skrevet af Cicero i år 45 f.kr. Bogen, som var meget populær i renæssancen, er en afhandling om etik. Den første linie af Lorem Ipsum "Lorem ipsum dolor sit amet..." kommer fra en linje i afsnit 1.10.32.

Standardafsnittet af Lorem Ipsum, som er brugt siden 1500-tallet, er gengivet nedenfor for de, der er interesserede. Afsnittene 1.10.32 og 1.10.33 fra "de Finibus Bonorum et Malorum" af Cicero er også gengivet i deres nøjagtige udgave i selskab med den engelske udgave fra oversættelsen af H. Rackham fra 1914.

</p>
    </div>
    <script>
        function NavBarFunc(height, opacity, top) {
            document.getElementById("NavMenu").style.height = height;            
            document.getElementById("NavMenu").style.opacity = opacity;
            document.getElementById("NavMenu").style.top = top;
        }
    </script>
</asp:Content>
