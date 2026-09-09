using EapLab.Transport.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EapLab.Transport.Connection
{
    public abstract class StateMachineBase<TState> where TState : struct,Enum
    {
        private TState _state;
        private readonly ILogSink _log;
        protected StateMachineBase(TState state ,ILogSink logSink)
        {
            _state = state;
            _log = logSink;
        }

        public TState Current => _state;

        protected bool ChangeState(TState state ,string resason ="")
        {
            if (EqualityComparer<TState>.Default.Equals(_state , state))
            {
                _log.Log(LogDir.ERR ,$"State is equal ,Can not Change! Current state is :{_state},to state :{state}");
                return false;
            }
            if (!CanTransition(_state ,state))
            {
                _log.Log(LogDir.ERR, $"非法状态迁移! Current state is :{_state},to state :{state}");
                return false;
            }
            var prev = _state;
            _state = state;
            _log.Log(LogDir.EVT, $"状态迁移! Current state is :{_state},to state :{state}");
            OnChanged(prev, _state);
            return true;
        }

        protected abstract bool CanTransition(TState from, TState to);
        protected virtual void OnChanged(TState from ,TState to) { }
    }
}
