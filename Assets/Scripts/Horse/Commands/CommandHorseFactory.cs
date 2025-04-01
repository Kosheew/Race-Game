

namespace Commands
{
    public class CommandHorseFactory
    {
        private CommandInvoker _invoker;

        private IHorseCommand _commandRaseHorce;
        private IHorseCommand _commandIdleHorce;
        
        public void Inject(DependencyContainer container)
        {
            _invoker = container.Resolve<CommandInvoker>();
            
            _commandRaseHorce = new RaceCommand(container);
            _commandIdleHorce = new IdleCommand(container);
        }
        
        public void CreateIdleCommand(HorseContext horse)
        {
            _commandIdleHorce.HorseContext  = horse;
            _invoker.SetCommand(_commandIdleHorce);
            _invoker.ExecuteCommands();
        }

        public void CreateRaceCommand(HorseContext horse)
        {
            _commandRaseHorce.HorseContext = horse;
            _invoker.SetCommand(_commandRaseHorce);
            _invoker.ExecuteCommands();
        }
        
    }
}