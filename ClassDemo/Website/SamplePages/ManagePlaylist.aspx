<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManagePlaylist.aspx.cs" Inherits="SamplePages_ManagePlaylist" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Manage Playlist (UX TRX Sample)</h1>
    </div>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <div class="row">

        <div class="col-sm-2">
            <asp:Label ID="Label1" runat="server" Text="Artist"></asp:Label>
            <asp:DropDownList ID="ArtistDDL" runat="server"></asp:DropDownList>
            <asp:Button ID="ArtistFetch" runat="server" Text="Fetch" />
            <br /><br />

            <asp:Label ID="Label2" runat="server" Text="Media"></asp:Label>
            <asp:DropDownList ID="MediaTypeDDL" runat="server"></asp:DropDownList>
            <asp:Button ID="MediaTypeFetch" runat="server" Text="Fetch" />
            <br /><br />

            <asp:Label ID="Label3" runat="server" Text="Genre"></asp:Label>
            <asp:DropDownList ID="GenreDDL" runat="server"></asp:DropDownList>
            <asp:Button ID="GenreFetch" runat="server" Text="Fetch" />
            <br /><br />

            <asp:Label ID="Label4" runat="server" Text="Album"></asp:Label>
            <asp:DropDownList ID="AlbumDDL" runat="server"></asp:DropDownList>
            <asp:Button ID="AlbumFetch" runat="server" Text="Fetch" />
            <br /><br />
        </div>

        <div class="col-sm-10">

        </div>
    </div>
</asp:Content>

