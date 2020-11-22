using System;

namespace Sooduskorv_MVC.Aids.Logging
{

    public interface ILogBook
    {
        void WriteEntry(string message);

        void WriteEntry(Exception e);
    }

}