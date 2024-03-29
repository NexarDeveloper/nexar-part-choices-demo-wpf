﻿namespace Nexar.PartChoices.Types
{
    abstract class TagType<T>
    {
        public T Tag { get; private set; }

        public TagType(T tag)
        {
            Tag = tag;
        }

        public void ReplaceTag(T tag)
        {
            Tag = tag;
        }
    }
}
