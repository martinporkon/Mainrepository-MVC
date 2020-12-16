using System;

namespace Sooduskorv_MVC.Aids.Values
{
    public interface ITimeService
    {// mõtteks on võimaldada erinevatesse kohtadesse kellaaegadega seotud tegevusi, mida juba Dates.cs olemas ei ole. Kell Londonis vms.
        DateTime GetCurrentTime { get; }// TODO must do great here.
    }// siin saab arvutada.
}// kõik ühest kohast kätte.