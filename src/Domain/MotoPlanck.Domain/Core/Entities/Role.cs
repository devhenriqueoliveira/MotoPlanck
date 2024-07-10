using MotoPlanck.Domain.Primitives;
using MotoPlanck.Domain.Utils;

namespace MotoPlanck.Domain.Core.Entities
{
    public sealed class Role : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        
        public Role(string name, string description, bool active)
        {
            Ensure.NotEmptyOrNull(name, "The name is required", nameof(name));
            Ensure.NotEmptyOrNull(description, "The description is required", nameof(description));

            Name = name;
            Description = description;
            Active = active;
        }

        public Role(Guid id, string name, string description, bool active)
        {
            Ensure.NotNull(id, "The identificator is required", nameof(id));
            Ensure.NotEmptyOrNull(name, "The name is required", nameof(name));
            Ensure.NotEmptyOrNull(description, "The description is required", nameof(description));

            Id = id;
            Name = name;
            Description = description;
            Active = active;
        }

        public Role(Guid id)
        {
            Id = id;
        }
        public Role()
        {
                
        }
        public void SetRoleId(Guid id) => Id = id;
    }
}
