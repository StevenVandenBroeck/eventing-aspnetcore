using System;

namespace Eventing
{
    public interface IEventingExceptionHandler
    {
        void Handle(Exception ex);
    }
}
