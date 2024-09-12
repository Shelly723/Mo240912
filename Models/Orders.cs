﻿using System;
using System.Collections.Generic;

namespace Mo240912.Models;

public partial class Orders
{
    public int OrderID { get; set; }

    public int UserID { get; set; }

    public int ShowtimeID { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime CreatedAt { get; set; }
}
