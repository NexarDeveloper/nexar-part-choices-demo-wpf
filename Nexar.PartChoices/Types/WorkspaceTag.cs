using Nexar.Client;

namespace Nexar.PartChoices.Types
{
    sealed class WorkspaceTag : TagType<IMyWorkspace>
    {
        public WorkspaceTag(IMyWorkspace tag) : base(tag)
        {
        }

        public override string ToString()
        {
            return Tag.Name;
        }
    }
}
