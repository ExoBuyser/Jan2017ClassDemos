using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ChinookSystem.BLL;
using Chinook.Data.POCOs;
 
public partial class SamplePages_ManagePlaylist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        //PreRenderComplete occurs just after databinding page events
        //load a pointer to point to your DataPager control
        DataPager thePager = TracksSelectionList.FindControl("DataPager1") as DataPager;

        if (thePager != null)
        {
            //this code will check StartRowIndex to see if is greater than the total count of the collection

            if (thePager.StartRowIndex > thePager.TotalRowCount)
            {
                thePager.SetPageProperties(0, thePager.MaximumRows, true);
            }
        }
    }

    protected void ArtistFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            TracksBy.Text = "Artist";
            SearchArgID.Text = ArtistDDL.SelectedValue;
            TracksSelectionList.DataBind();//will force the ODS to execute
        });
    }
    protected void MediaTypeFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            TracksBy.Text = "MediaType";
            SearchArgID.Text = MediaTypeDDL.SelectedValue;
            TracksSelectionList.DataBind();//will force the ODS to execute
        });
    }
    protected void GenreFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            TracksBy.Text = "Genre";
            SearchArgID.Text = GenreDDL.SelectedValue;
            TracksSelectionList.DataBind();//will force the ODS to execute
        });
    }
    protected void AlbumFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
        {
            TracksBy.Text = "Album";
            SearchArgID.Text = AlbumDDL.SelectedValue;
            TracksSelectionList.DataBind();//will force the ODS to execute
        });
    }
    protected void PlaylistFetch_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(PlaylistName.Text))
        {
            MessageUserControl.ShowInfo("Warning", "Playlist Name is Required.");
        }
        else
        {
            MessageUserControl.TryRun(() =>
            {
                string username = User.Identity.Name;
                PlaylistTrackController sysmgr = new PlaylistTrackController();
                List<UserPlaylistTrack> playlist = sysmgr.List_TrackForPlaylist(
                    PlaylistName.Text, username);

                PlayList.DataSource = playlist;
                PlayList.DataBind();

            });
        }
    }
}