using System;
using Sooduskorv_MVC.Aids.Methods;

namespace Sooduskorv_MVC.Aids.Extensions
{
    public static class Bytes
    {
        public static string ConvertToBase64String(this byte[] byteArrayBytes)
            => Safe.Run(Convert.ToBase64String(byteArrayBytes));// TODO fix Safe.Run;








    }
}