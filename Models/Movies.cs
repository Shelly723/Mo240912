using System;
using System.Collections.Generic;

namespace Mo240912.Models;

public partial class Movies
{
    public int MovieID { get; set; }

    public string MovieTitle { get; set; } = null!;

    public string? MovieGenre { get; set; }

    public int? MovieDuration { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public string? MovieDescription { get; set; }

    public string? MoviePicture { get; set; }
}
