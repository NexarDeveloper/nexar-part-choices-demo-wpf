using Nexar.Client;

namespace Nexar.PartChoices.Types
{
    sealed class WorkspaceTag : TagType<IMyWorkspace>
    {
        private NexarClient _nexarClient;

        public WorkspaceTag(IMyWorkspace tag) : base(tag)
        {
        }

        public override string ToString()
        {
            return Tag.Name;
        }

        public NexarClient GetNexarClient()
        {
            if (_nexarClient == null)
                _nexarClient = NexarClientFactory.CreateClient(Tag.Location.ApiServiceUrl, Config.AccessToken);

            return _nexarClient;
        }
    }
}
