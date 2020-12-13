using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Data.Interfaces
{
    public interface IHasOwner
    {
        int OwnerId { set; get; }
    }
}
