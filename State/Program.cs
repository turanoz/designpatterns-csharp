using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context=new Context();
            ModifiedState modifiedState=new ModifiedState();
            modifiedState.DoAction(context);

            DeletedState deleteState=new DeletedState();
            deleteState.DoAction(context);

            Console.WriteLine(context.GetState().ToString());
        }
    }

    interface IState
    {
        void DoAction(Context context);

    }

    class ModifiedState:IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified";
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }

    class AddState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State: Added");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }

    internal class Context
    {
        private IState _state;

        public void SetState(IState state )
        {
            _state=state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}

