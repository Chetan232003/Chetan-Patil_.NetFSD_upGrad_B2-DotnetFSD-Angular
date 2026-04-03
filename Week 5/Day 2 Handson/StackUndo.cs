using System;
using System.Collections.Generic;

class StackUndo
{
    private List<string> stack = new List<string>();

    public void Push(string action)
    {
        stack.Add(action);
        Console.WriteLine("Action Added: " + action);
    }

    public void Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Nothing to undo!");
            return;
        }

        string removed = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        Console.WriteLine("Undo Action: " + removed);
    }

   
    public bool IsEmpty()
    {
        return stack.Count == 0;
    }

    public void Display()
    {
        Console.WriteLine("Current State: " + string.Join(", ", stack));
    }
}
class Program
{
    static void Main()
    {
        StackUndo editor = new StackUndo();

        editor.Push("Type A");
        editor.Push("Type B");
        editor.Push("Type C");

        editor.Pop(); // Undo
        editor.Pop(); // Undo

        editor.Display();
    }
}

