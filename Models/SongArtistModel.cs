using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ModernSoftwareDevelopmentAssignment5.Models
{
    public class SongArtistModel
    {
        public List<Song>? Songs { get; set; }
        public SelectList? Artists { get; set; }
        public string? SongArtist { get; set; }
        public string? SearchString { get; set; }
    }
}
