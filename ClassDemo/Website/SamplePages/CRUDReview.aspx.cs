using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.BLL;
using Chinook.UI;
#endregion

public partial class SamplePages_CRUDReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SelectedTitle.Text = "";
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        
        Clear_Click(sender, e);

        if (string.IsNullOrEmpty(SearchArg.Text))
        {
            MessageUserControl1.ShowInfo("Enter an album title or part of the title");
        }
        else
        {
            MessageUserControl1.TryRun(() =>
                {
                    AlbumController sysmgr = new AlbumController();
                    List<Album> albumlist = sysmgr.Albums_GetbyTitle(SearchArg.Text);
                    if (albumlist.Count == 0)
                    {
                        MessageUserControl1.ShowInfo("Search Result", "No data for album title or partial title " + SearchArg.Text);
                        AlbumList.DataSource = null;
                        AlbumList.DataBind();
                    }
                    else
                    {
                        MessageUserControl1.ShowInfo("Search Result", "Select the desired album for maintenance.");
                        AlbumList.DataSource = albumlist;
                        AlbumList.DataBind();
                    }
                });
        }
    }

   

    protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow agvrow = AlbumList.Rows[AlbumList.SelectedIndex];

        string albumid = (agvrow.FindControl("AlbumID") as Label).Text;

        string albumtitle = (agvrow.FindControl("Title") as Label).Text;

        string albumyear = (agvrow.FindControl("Year") as Label).Text;

        string albumlabel = (agvrow.FindControl("AlbumLabel") as Label).Text;

        string artistid = (agvrow.FindControl("ArtistID") as Label).Text;


        //displaying on tab find
        SelectedTitle.Text = albumtitle + " release in " + albumyear + " by " + albumlabel;


        //filling controls on tab maintain
        AlbumID.Text = albumid;
        AlbumTitle.Text = albumtitle;
        ArtistList.SelectedValue = artistid;
        AlbumReleaseYear.Text = albumyear;
        AlbumReleaseLabel.Text = albumlabel;

    }

    protected void AddAlbum_Click(object sender, EventArgs e)
    {
        //retest the validation of the incoming data via the validation controls
        if (IsValid)
        {
            //any other business rules
            MessageUserControl2.TryRun(() =>
            {
                AlbumController sysmgr = new AlbumController();
                Album newalbum = new Album();

                newalbum.Title = AlbumTitle.Text;
                newalbum.ArtistId = int.Parse(ArtistList.SelectedValue);
                newalbum.ReleaseYear = int.Parse(AlbumReleaseYear.Text);
                newalbum.ReleaseLabel = string.IsNullOrEmpty(AlbumReleaseLabel.Text) ? null : AlbumReleaseLabel.Text;
                sysmgr.Albums_Add(newalbum);
            },"Add Album", "Album has been successfully added to the database.");
        }
    }
    protected void UpdateAlbum_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            if (string.IsNullOrEmpty(AlbumID.Text))
            {
                MessageUserControl2.ShowInfo("Missing Data", "Missing Album Id. Use Find to locate the album you wish to maintain.");
            }
            else
            {
                int albumid = 0;
                
                if (int.TryParse(AlbumID.Text, out albumid))
                {
                    MessageUserControl2.TryRun(() =>
                    {
                        AlbumController sysmgr = new AlbumController();
                        Album newalbum = new Album();
                        newalbum.AlbumId = albumid;
                        newalbum.Title = AlbumTitle.Text;
                        newalbum.ArtistId = int.Parse(ArtistList.SelectedValue);
                        newalbum.ReleaseYear = int.Parse(AlbumReleaseYear.Text);
                        newalbum.ReleaseLabel = string.IsNullOrEmpty(AlbumReleaseLabel.Text) ? null : AlbumReleaseLabel.Text;
                        sysmgr.Albums_Update(newalbum);
                    }, "Update Album", "Album has been successfully updated to the database.");
                }
                else
                {
                    MessageUserControl2.ShowInfo("Invalid Data", "Album Id. Use Find to locate the album you wish to maintain.");
                }
                
            }
        }
    }
    protected void DeleteAlbum_Click(object sender, EventArgs e)
    {
      
            if (string.IsNullOrEmpty(AlbumID.Text))
            {
                MessageUserControl2.ShowInfo("Missing Data", "Missing Album Id. Use Find to locate the album you wish to maintain.");
            }
            else
            {
                int albumid = 0;

                if (int.TryParse(AlbumID.Text, out albumid))
                {
                    MessageUserControl2.TryRun(() =>
                    {
                        AlbumController sysmgr = new AlbumController();
                       
                        sysmgr.Albums_Delete(albumid);
                    }, "Delete Album", "Album has been successfully deleted to the database.");
                }
                else
                {
                    MessageUserControl2.ShowInfo("Invalid Data", "Album Id. Use Find to locate the album you wish to maintain.");
                }

            }
    }




    protected void Clear_Click(object sender, EventArgs e)
    {
        AlbumID.Text = "";
        AlbumTitle.Text = "";
        AlbumReleaseYear.Text = "";
        AlbumReleaseLabel.Text = "";
        ArtistList.SelectedIndex = 0;
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }
}