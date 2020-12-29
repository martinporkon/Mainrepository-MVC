using System;
using Sooduskorv_MVC.Aids.Logging;

namespace Sooduskorv_MVC.Aids.Methods
{
    public static class Safe
    {
        private static readonly object key = new object();
        public static T Run<T>(Func<T> function, T valueOnException,
            bool useLock = false)
        {
            return useLock
                ? lockedRun(function, valueOnException)
                : run(function, valueOnException);
        }
        public static void Run(Action action, bool useLock = false)
        {
            if (useLock) lockedRun(action);
            else run(action);
        }

        private static T run<T>(Func<T> function, T valueOnException)
        {
            try
            {
                return function();
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return valueOnException;
            }
        }

        private static T lockedRun<T>(Func<T> function, T valueOnException)
        {
            lock (key) { return run(function, valueOnException); }
        }
        private static void run(Action action)
        {
            try { action(); } catch (Exception e) { Log.Exception(e); }
        }
        private static void lockedRun(Action action)
        {
            lock (key) { run(action); }
        }

        public static T Run<T>(T deserialize)// TODO for ConvertToBase64String;
        {
            try
            {
                /*return DoSomething()*/// TODO
                throw new ApplicationException();// return null võimalus.
            }
            catch (Exceptions e)// TODO
            {
                Log.Exception(e);
                throw;
            }
        }

        /*public static void Run<T>(Func<T> function, T valueOnException)// TODO
        {
            try
            {
                /*return DoSomething()#1#// TODO
                throw new ApplicationException();
            }
            catch (OperationCanceledException e)// TODO
            {
                Log.Exception(e);
            }
        }*/
    }
}