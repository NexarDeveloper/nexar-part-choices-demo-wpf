using Nexar.Client;
using System.Collections.Generic;

namespace Nexar.PartChoices.Types
{
    sealed class FolderTag
    {
        public string Name { get; }
        public WorkspaceTag Workspace { get; }
        public IEnumerable<IMyComponent> Components { get; }

        public FolderTag(string name, WorkspaceTag workspace, IEnumerable<IMyComponent> components)
        {
            Name = name;
            Workspace = workspace;
            Components = components;
        }

        public override string ToString()
        {
            return Name ?? "<No folder>";
        }
    }
}
