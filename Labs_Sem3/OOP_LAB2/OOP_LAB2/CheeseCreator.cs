using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB2
{

    interface Point
    {
        string qualitative
        {
            get;
            set;
        }
        string view
        {
            get;
            set;
        }
    }

    interface Mark
    {
        int mark
        {
            get;
            set;
        }
    }
    interface customerPersonalView<T>
    {
        T getView();
    }
    class Handler 
    {
        public void Message()
        {
            Console.WriteLine(" Nice cheese");
        }
    }

    class EArgs //Клас аргументів для обробника помилок
    {
        public String message;
        public Exception exception;
        public EArgs(String p_message, Exception e)
        {
            message = p_message;

            exception = e;

        }

    }

    class MyException : Exception
    {
        //Constructors. It is recommended that at least all the
        //constructors of
        //base class Exception are implemented
        public MyException() : base() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception e) : base(message, e) { }
        public MyException(EArgs args) : base(args.message, args.exception)
        {

        }
        //If there is extra error information that needs to be captured
        //create properties for them.

        private string strExtraInfo;
        public string ExtraErrorInfo
        {
            get
            {
                return strExtraInfo;
            }

            set
            {
                strExtraInfo = value;
            }
        }
    }


        class CheeseCreator : Point, Mark, customerPersonalView<int>
    {

        public delegate void MethodContainer();
        public event MethodContainer MarkAnswer;

        private string _qualitative;
        private string _view;
        private int _mark;

        public int getView()
        {
            return _mark;
        }
        public string qualitative
        {
            get
            {
                return _qualitative;
            }
            set
            {
                _qualitative = value;
            }
        }

        public int mark
        {
            get
            {
                return _mark;
            }
            set
            {
                if (_mark < 6 && _mark > -1)
                    _mark = value;
            }
        }

        public string view
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
            }
        }

        public CheeseCreator(string qualitative, string view, int mark)
        {
            _qualitative = qualitative;
            _view = view;
            _mark = mark;
        }

        public void PrintPoint()
        {
            Console.Write("Points of cheese : ");
            if (_mark > 2)
                MarkAnswer();
            Console.Write("qualitative of cheese is - {0}, view - {1}, ", _qualitative, _view);
            Console.WriteLine("Mark - {0}/5", _mark);
        }

    }

}
