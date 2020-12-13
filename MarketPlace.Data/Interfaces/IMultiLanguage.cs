using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Data.Interfaces
{
    public interface IMultiLanguage<T>
    {
        T LanguageId { set; get; }
    }
}
