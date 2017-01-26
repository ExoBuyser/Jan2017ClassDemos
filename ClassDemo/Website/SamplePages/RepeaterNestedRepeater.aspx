<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RepeaterNestedRepeater.aspx.cs" Inherits="SamplePages_RepeaterNestedRepeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br /><br />

    <div class="col-sm-6">
    <asp:Repeater ID="ArtisitAlbumReleasesList" runat="server" DataSourceID="ArtistAlbumReleasesODS">
        <HeaderTemplate>
          <h4>Albums Releases for Artist</h4>
        </HeaderTemplate>
        <ItemTemplate>
            <strong><%# Eval("Artist") %></strong><br />
            <asp:Repeater ID="Albums" runat="server" DataSource='<%# Eval("Albums") %>'>
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Year</th>
                            <th>Label</th>
                            <th>Title</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("RYear") %></td>
                        <td><%# Eval("Label") %></td>
                        <td><%# Eval("Title") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
        </ItemTemplate>
    </asp:Repeater>
    </div>

    <div class="col-sm-6">
    <asp:Repeater ID="ArtistAlbumReleasesB" runat="server" DataSourceID="ArtistAlbumReleasesODS"
        ItemType="Chinook.Data.DTOs.ArtistAlbumReleases">
        <HeaderTemplate>
          <h4>Albums Releases for Artist</h4>
        </HeaderTemplate>
        <ItemTemplate>
            <strong><%# Item.Artist %></strong><br />
            <asp:Repeater ID="AlbumsB" runat="server" DataSource='<%# Item.Albums%>'
                ItemType="Chinook.Data.POCOs.AlbumRelease">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Year</th>
                            <th>Label</th>
                            <th>Title</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Item.RYear %></td>
                        <td><%# Item.Label %></td>
                        <td><%# Item.Title %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
        </ItemTemplate>
    </asp:Repeater>
    </div>

    <asp:ObjectDataSource ID="ArtistAlbumReleasesODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="ArtistAlbumReleases_List" 
        TypeName="ChinookSystem.BLL.AlbumController">
    </asp:ObjectDataSource>
</asp:Content>

