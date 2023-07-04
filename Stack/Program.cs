// реалізація стеку за допомогою масиву та листа

ArrayStack<int> stack = new ArrayStack<int>(10);

ListStack<int> listStack = new ListStack<int>();

listStack.Push(0);
listStack.Push(1);
listStack.Push(2);

Console.WriteLine(listStack.Peek());

Console.WriteLine(listStack.Pop());

