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


namespace ChinookSystem.BLL
{
    public class PlaylistTrackController
    {
        public List<UserPlaylistTrack> List_TrackForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {
                var results = (from x in context.Playlists
                              where x.Name == playlistname
                              && x.UserName == username
                              select x).FirstOrDefault();

                var theTracks = from x in context.PlaylistTracks
                                where x.PlaylistId == results.PlaylistId
                                select new UserPlaylistTrack
                                {
                                    TrackID = x.TrackId,
                                    TrackNumber = x.TrackNumber,
                                    Trackname = x.Track.Name,
                                    Milliseconds = x.Track.Milliseconds,
                                    UnitPrice = x.Track.UnitPrice
                                };
                return theTracks.ToList();
            }
        }

        public void Add_TrackToPlaylist(string playlistname, string username, int trackid)
        {
            using (var context = new ChinookContext())
            {
                //does the playlist already exist
                Playlist exists = (from x in context.Playlists
                                   where x.UserName.Equals(username)
                                   && x.Name.Equals(playlistname)
                                   select x).FirstOrDefault();

                int tracknumber = 0;
                PlaylistTracks newtrack = null;

                if (exists == null)
                {
                    //create the new Playlist

                    exists = new Playlist();

                    exists.Name = playlistname;
                    exists.UserName = username;
                    exists = context.Playlists.Add(exists);
                    tracknumber = 1;
                }
                else
                {
                    //the playlist already exists
                    //and the query has given as the instance of that playlist from the DB
                    //generate the next tracknumber
                    tracknumber = exists.PlaylistTracks.Count();

                    //on our sample, playlist tracks for a playlist
                    //are unique
                    newtrack = exists.PlaylistTracks.SingleOrDefault(x => x.TrackId == trackid);

                    if(newtrack != null)
                    {
                        throw new Exception("Playlist already has a requested track.");
                    }
                }

                //this is a boom test
                //remove after testing
                //if (playlistname.Equals("Boom"))
                //{
                //    throw new Exception("forced abort, check DB for Boom playlist");
                //}

                //you have a playlist
                //you know the track will be unique
                //create the new track

                newtrack = new PlaylistTracks();
                newtrack.TrackId = trackid;
                newtrack.TrackNumber = tracknumber;
                //since i am using the navigation property of the
                //playlist to get to playlisttrack
                //the savechanges will fill the playlistID
                //from either the hashset or from the existing instance
                exists.PlaylistTracks.Add(newtrack);

                context.SaveChanges();
            }
        }
    }
}
