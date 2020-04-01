
using System.Collections.Generic;

public class ObjectStateMachine
{

    private State state;

    public ObjectStateMachine(State start)
    {
        state = start;
    }

    public State getState()
    {
        return state;
    }

    public void setState(State s)
    {
        state = s;
    }

    public void updateState(Dictionary<string, bool> input)
    {
        state.transition(this, input);
    }

}

