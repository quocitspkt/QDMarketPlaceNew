using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Infrastructure.SharedKernel
{
    public class DomainEntity<T>
    {
        public T Id { get; set; }

        //True if DomainEntity has an identity
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}
