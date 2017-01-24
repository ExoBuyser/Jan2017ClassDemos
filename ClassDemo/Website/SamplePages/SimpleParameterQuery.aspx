﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SimpleParameterQuery.aspx.cs" Inherits="SamplePages_SimpleParameterQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
    <asp:Label ID="Label1" runat="server" Text="Enter Artist Name (partial)"></asp:Label>&nbsp;&nbsp;
    <asp:TextBox ID="ArtistName" runat="server"></asp:TextBox>&nbsp;&nbsp;
    <asp:LinkButton ID="GetArtistAlbums" runat="server">Get Artist Albums</asp:LinkButton>
    </div>

    <br />

    <div class="row">
        <asp:GridView ID="ArtistNameGVList" runat="server" AutoGenerateColumns="False" DataSourceID="ArtistNameODS" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="Albumid" HeaderText="Album" SortExpression="Albumid">
                    <HeaderStyle HorizontalAlign="Center" BackColor="#9966FF"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                <asp:BoundField DataField="ArtistId" HeaderText="Artist" SortExpression="ArtistId">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ReleaseYear" HeaderText="Released" SortExpression="ReleaseYear">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ReleaseLabel" HeaderText="Label" SortExpression="ReleaseLabel"></asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                Nothing to display for current artist Name.
            </EmptyDataTemplate>
        </asp:GridView>
    </div>


    <asp:ObjectDataSource ID="ArtistNameODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Albums_GetForArtistbyName" TypeName="ChinookSystem.BLL.AlbumController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ArtistName" PropertyName="Text" Name="name" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
