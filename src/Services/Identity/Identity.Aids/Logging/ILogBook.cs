using System;

namespace Identity.Aids.Logging
{

    public interface ILogBook
    {
        void WriteEntry(string message);

        void WriteEntry(Exception e);
    }

}