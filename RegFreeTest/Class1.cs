using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace RegFreeTest
{
    [Guid("6AF7104A-5727-49E4-B63F-DB7A7CD0260A")]
    public interface IRegFreeTestClass
    {
        string Version();
    }

    [Guid("3039FD47-71BD-4F7B-8CC6-D81742CA29FD")]
    [ComSourceInterfaces(typeof(IRegFreeEvents))]
    public class RegFreeTestClass : IRegFreeTestClass
    {
        public event EventDelegates.DoSomethingHandler DoSomething;

        public string Version()
        {
            if (DoSomething != null)
            {
                DoSomething();
                return "Event done.";
            }
            else
            {
                return "1.0.0-C#";
            }
        }
    }

    [ComVisible(false)]
    public class EventDelegates
    {
        public delegate void DoSomethingHandler();
    }

    [Guid("2EC3F02B-1617-4DB9-A721-22A695D23E87")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRegFreeEvents
    {
        [DispId(1)]
        void DoSomething();
    }
}
