using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.Generic;

public class StateManagement{
	private Stack<State> stack;

	public StateManagement(){
		stack = new Stack<State>();
	}

	public void Push(State state){
		stack.Push(state);
	}

	public void Pop(){
		stack.Pop();
	}

	public void UpDate(){
		stack.Peek().Update();
	}

	public State Peek(){
		return stack.Peek();
	}
}
