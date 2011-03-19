using System;
using FubuMVC.Core.Registration.Nodes;

namespace CodeCampOverflow.Behaviors
{
    public class ValidationNode : Wrapper
    {
        public ValidationNode(Type modelType) :
            base(typeof(ValidationBehavior<>).MakeGenericType(modelType))
        {
            ModelType = modelType;
        }

        public Type ModelType { get; private set; }

        public bool Equals(ValidationNode other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.ModelType, ModelType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ValidationNode)) return false;
            return Equals((ValidationNode) obj);
        }

        public override int GetHashCode()
        {
            return (ModelType != null ? ModelType.GetHashCode() : 0);
        }
    }
}