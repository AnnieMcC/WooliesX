using System;

namespace WooliesX.Core.Models
{
    public abstract class BaseId<T>
    {
        public virtual T Id { get; set; }
    }
}
