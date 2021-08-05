using Nexar.Client;
using System.Collections.Generic;

namespace Nexar.PartChoices.Types
{
    sealed class FolderTag
    {
        public string Name { get; }
        public IEnumerable<IMyComponent> Components { get; }

        public FolderTag(string name, IEnumerable<IMyComponent> components)
        {
            Name = name;
            Components = components;
        }

        public override string ToString()
        {
            return Name ?? "<No folder>";
        }
    }
}
