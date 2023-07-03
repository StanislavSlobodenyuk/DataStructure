//// Як стек можна реалізувати за допомогою c#
//Stack<int> defaultStack = new Stack<int>();

//// додавання елемену у стек
//defaultStack.Push(0);
//defaultStack.Push(1);
//defaultStack.Push(2);
//defaultStack.Push(3);

//// видалення елементу з стеку
//Console.WriteLine(defaultStack.Pop() + " pop ");
//Console.WriteLine(defaultStack.Pop() + " pop ");

//// перегляд  останнього елементу в стеку
//Console.WriteLine(defaultStack.Peek() + " peek ");


ArrayStack<int> stack = new ArrayStack<int>(10);

ListStack<int> listStack = new ListStack<int>();

listStack.Push(0);
listStack.Push(1);
listStack.Push(2);

Console.WriteLine(listStack.Peek());

Console.WriteLine(listStack.Pop());

