using System;

namespace MarketPlace.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime DateCreated { set; get; }
        DateTime DateModified { set; get; }
    }
}