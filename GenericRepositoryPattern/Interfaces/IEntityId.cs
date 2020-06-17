using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryPattern.Interfaces
{
    //Any class that implements this interface must have an Id property...
    public interface IEntityId
    {
        int Id { get; set; }
    }
}
