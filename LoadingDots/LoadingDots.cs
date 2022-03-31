using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadingDots
{
    public class Dots
    {
        private int _frame;
        private readonly int _originalCol;
        private readonly int _originalRow;
        private string _action;
        private int _speed;
        private readonly Thread _thread;
        private DateTime _started;
        private DateTime _ended;
        private TimeSpan _elapsed;
        private bool _activeState;

        public Dots(string action, int speed)
        {
            _frame = 0;
            _originalCol = Console.CursorLeft;
            _originalRow = Console.CursorTop;
            _action = action;
            _speed = speed;
            _activeState = false;
            _thread = new Thread(DoAction);
            _started = new DateTime();
            _ended = new DateTime();
            _elapsed = new TimeSpan();
        }

        // PROPERTIES
        public string Action
        {
            get => _action;
            private set => _action = value;
        }

        public int Speed
        {
            get => _speed;
            private set => _speed = value;
        }

        public DateTime Started
        {
            get => _started;
            private set => _started = value;
        }

        public DateTime Ended
        {
            get => _ended;
            private set => _ended = value;
        }

        public TimeSpan Elapsed
        {
            get => _elapsed = _ended.Subtract(_started);
        }

        // METHODS
        public void Start()
        {
            _started = DateTime.Now;
            _activeState = true;
            Console.CursorVisible = false;
            _thread.Start();
        }

        public void End()
        {
            _ended = DateTime.Now;
            _activeState = false;
            Console.CursorVisible = true;
            _thread.Join();
            Console.SetCursorPosition(_originalCol, _originalRow); Console.Write($"{_action} OK ");
            Console.WriteLine("");
            Thread.Sleep(1000);
        }

        private void DoAction()
        {
            while (_activeState)
            {
                Thread.Sleep(_speed);

                switch (_frame)
                {
                    case 0:
                        Console.SetCursorPosition(_originalCol, _originalRow);
                        Console.Write($"{_action}    ");
                        break;
                    case 1:
                        Console.SetCursorPosition(_originalCol, _originalRow);
                        Console.Write($"{_action} .  ");
                        break;
                    case 2:
                        Console.SetCursorPosition(_originalCol, _originalRow);
                        Console.Write($"{_action} .. ");
                        break;
                    case 3:
                        Console.SetCursorPosition(_originalCol, _originalRow);
                        Console.Write($"{_action} ...");
                        _frame = -1;
                        break;
                }

                _frame++;
            }
        }
    }
}
