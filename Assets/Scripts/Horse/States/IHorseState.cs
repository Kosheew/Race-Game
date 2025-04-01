namespace Horse.States
{
    public interface IHorseState
    {
        public void EnterState(HorseContext horseContext);
        public void UpdateState(HorseContext horseContext);
        public void ExitState(HorseContext horseContext);
    }
}