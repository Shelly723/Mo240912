using System;
using System.Collections.Generic;

namespace Mo240912.Models;

public partial class OrderSeats
{
    public int OrderSeatID { get; set; }

    public int OrderID { get; set; }

    public int SeatID { get; set; }
}
