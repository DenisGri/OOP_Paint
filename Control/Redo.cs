using System.Collections.Generic;
using System.Linq;
using Paint_Lab.ShapesClasses;

namespace Paint_Lab.Control
{
    public class Redo
    {
        private readonly Stack<Shape> _shapesStack;

        public Redo()
        {
            _shapesStack = new Stack<Shape>();
        }

        public void Push(Shape shape)
        {
            _shapesStack.Push(shape);
        }

        public Shape Pop()
        {
            return _shapesStack.Pop();
        }

        public void CleanStack()
        {
            _shapesStack.Clear();
        }

        public bool IsEmpty()
        {
            return _shapesStack.Count != 0;
        }

        public List<Shape> FillList()
        {
            return _shapesStack.ToList();
        }
    }
}