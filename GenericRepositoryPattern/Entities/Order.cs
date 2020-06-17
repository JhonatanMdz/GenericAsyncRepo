using GenericRepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace GenericRepositoryPattern.Entities
{
    public class Order : IEntityId 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }

        //Navigation properties
        public Customer Customer { get; set; }
    }
}
