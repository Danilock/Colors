namespace Game.Player.Finite_State_Machine
{
    public abstract class CharacterBaseState
    {
        public abstract void EnterState(Character character);
        public abstract void Update(Character character);
        public abstract void FixedUpdate(Character character); 
        public abstract void ExitState(Character character);
    }
}
