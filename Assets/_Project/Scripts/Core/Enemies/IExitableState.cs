namespace _Project.Scripts.Core.Enemies {
    public interface IExitableState : IState {
        public void OnExit();
    }
}