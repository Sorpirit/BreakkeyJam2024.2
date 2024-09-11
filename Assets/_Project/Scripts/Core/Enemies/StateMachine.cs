using System;
using System.Collections.Generic;

namespace _Project.Scripts.Core.Enemies {
    public class StateMachine {
        public IState CurrentState { get; private set; }

        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

        public void RegisterState<TState>(TState state) where TState : IState =>
            _states.Add(typeof(TState), state);

        public void SwitchState<TState>() where TState : IState {
            if (CurrentState is IExitableState exitableState)
                exitableState.OnExit();

            CurrentState = _states[typeof(TState)];

            CurrentState.OnEnter();
        }
    }
}