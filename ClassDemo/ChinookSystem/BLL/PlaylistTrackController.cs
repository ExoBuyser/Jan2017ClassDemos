using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion


namespace ChinookSystem.BLL.Security
{
    public class PlaylistTrackController
    {
        public List<UserPlaylistTrack> List_TrackForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Playlists
                              where x.Name == playlistname
                              && x.UserName == username
                              select x).FirstOrDefault();

                var theTracks = from x in context.PlaylistTracks
                                where x.PlaylistId == results.PlaylistId
                                select new UserPlaylistTrack
                                {
                                    TrackID = x.TrackId,
                                    TrackNumber = x.TrackNumber,
                                    TrackName = x.Track.Name,
                                    Milliseconds = x.Track.Milliseconds,
                                    UnitPrice = x.Track.UnitPrice
                                };
                return theTracks.ToList();
            }
        }
    }
}
