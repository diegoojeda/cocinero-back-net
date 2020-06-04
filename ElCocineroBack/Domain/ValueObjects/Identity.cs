using System;

namespace ElCocineroBack.Domain.ValueObjects
{
    public abstract class Identity : IEquatable<Identity>, IIdentity
    {
        public string Id { get; set; }

        public Identity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Identity(string id)
        {
            Guid.Parse(id); //To validate valid Guid as ID
            Id = id;
        }

        public bool Equals(Identity id)
        {
            if (object.ReferenceEquals(this, id)) return true;
            if (object.ReferenceEquals(null, id)) return false;
            return this.Id.Equals(id.Id);
        }

        public override bool Equals(object anotherObject)
        {
            return Equals(anotherObject as Identity);
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.GetType().Name + " [Id=" + Id + "]";
        }
    }

    public interface IIdentity
    {
        string Id { get; set; }
    }
}