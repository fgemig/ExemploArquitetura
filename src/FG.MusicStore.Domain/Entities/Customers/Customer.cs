using System;
using FG.MusicStore.Domain.Shared.Entities;
using FG.MusicStore.Domain.Shared.Validation;

namespace FG.MusicStore.Domain.Entities.Customers
{
    public class Customer : Entity<Customer>
    {

        public Customer(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        protected Customer()
        {
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public void ChangeName(string newName)
        {
            Name = newName;
        }        

        public override bool IsValid()
        {
            return Assert.Length(Name, 3, 150) && Assert.ValidEmail(Email);
        }
    }
}
