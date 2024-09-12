﻿using System;
using System.Collections.Generic;

namespace Mo240912.Models;

public partial class Showtimes
{
    public int ShowtimeID { get; set; }

    public int MovieID { get; set; }

    public int TheaterID { get; set; }

    public DateTime ShowDateTime { get; set; }

    public int AvailableSeats { get; set; }
}
