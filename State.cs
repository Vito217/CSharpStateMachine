using System.Collections.Generic;

public class State
{
    private Dictionary<string, State> map;

    public State() { 
    }

    public State(Dictionary<string, State> m)
    {
        map = m;
    }

    public void setMap(Dictionary<string, State> m) {
        map = m;
    }

    public void transition(ObjectStateMachine sm, Dictionary<string, bool> input)
    {
        foreach (KeyValuePair<string, bool> pair in input)
        {
            string key = pair.Key;
            bool condition = pair.Value;
            if (condition)
            {
                sm.setState(map[key]);
                return;
            }
        }
    }
}