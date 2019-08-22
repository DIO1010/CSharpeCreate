using System;
using States;
using System.Collections.Generic;

public class StateManage
{
    private Stack<State> stack_;
    public StateManage()
    {
        stack_ = new Stack<State>();
    }

    public void Push(State s)
    {
        if(stack_.Count > 0)
        {
            stack_.Peek().Control = false;
        }
        s.Control = true;
        stack_.Push(s);
    }

    // public State Pop()
    // {
    //     State s = stack_.Pop();
    //     s.Control = false;
    //     return s;
    // }

    public void Pop()
    {
        stack_.Pop().Control = false;
        stack_.Peek().Control = true;
        return;
    }

    public State Peek()
    {
        return stack_.Peek();
    }

    public int Count
    {
        get
        {
            return stack_.Count;
        }
    }
}