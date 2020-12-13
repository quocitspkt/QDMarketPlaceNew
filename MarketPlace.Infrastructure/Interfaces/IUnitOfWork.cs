using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call savechange from db Context
        /// </summary>
        void Commit();
    }
}
