using System;
using System.Diagnostics;

namespace Eventing.UnitTests
{
    public class TestExceptionHandler : IEventingExceptionHandler
    {
        public void Handle(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
