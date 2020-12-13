using MarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
