using McMaster.Extensions.CommandLineUtils;

namespace milestone_merger_console
{
    public class MilestoneMergerApplication : CommandLineApplication
    {

        public MilestoneMergerApplication()
        {
            HelpOption("-h|--help");

            CommandOption group = Option("-g|--group <group>", "The group where the milestone is located", CommandOptionType.SingleValue);
            CommandOption milestoneName = Option("-m| --milestone <milestone>", "The name of the milestone", CommandOptionType.SingleValue);
            CommandOption option = Option("-t|--token <token>", "Personal access token to use to access gitlab.com", CommandOptionType.SingleValue);
        }
    }
}