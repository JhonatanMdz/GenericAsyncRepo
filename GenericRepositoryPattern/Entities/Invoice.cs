using GenericRepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryPattern.Entities
{
    public class Invoice : IEntityId
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
