using System;
using System.Diagnostics;

namespace Eventing.Handling
{
    public class DefaultEventingExceptionHandler : IEventingExceptionHandler
    {
        public void Handle(Exception ex)
        {
            Debug.WriteLine($"Exception publishing event(s) : {ex.Message}");
        }
    }
}
