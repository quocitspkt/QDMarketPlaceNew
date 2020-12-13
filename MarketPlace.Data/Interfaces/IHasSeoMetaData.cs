using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTitle { set; get; }
        string SeoAlias { set; get; }
        string SeoKeyWord { set; get; }
        string SeoDescription { set; get; }
    }
}
