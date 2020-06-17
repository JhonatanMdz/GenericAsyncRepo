using GenericRepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryPattern.Entities
{
    public class Customer : IEntityId
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        //Navigation props
        public List<Order> Orders { get; set; }
    }
}
