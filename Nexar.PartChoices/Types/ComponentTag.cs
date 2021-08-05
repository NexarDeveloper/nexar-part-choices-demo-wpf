using Nexar.Client;

namespace Nexar.PartChoices.Types
{
    sealed class ComponentTag : TagType<IMyComponent>
    {
        public ComponentTag(IMyComponent tag) : base(tag)
        {
        }

        public override string ToString()
        {
            return Tag.Name;
        }
    }
}
