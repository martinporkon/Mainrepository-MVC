namespace Sooduskorv_MVC.Aids.Methods
{

    public static class Copy
    {

        public static void Members(object from, object to)
        {
            //foreach (var property in from.GetType().GetProperties()) {
            //    var name = property.Name;
            //    var p = to.GetType().GetProperty(name);
            //    var v = property.GetValue(from);
            //    p?.SetValue(to, v);
            //}
            if (from is null) return;
            if (to is null) return;
            foreach (var property in from.GetType().GetProperties())
            {
                if (!property.CanWrite) continue;
                var name = property.Name;
                var p = to.GetType().GetProperty(name);
                var v = property.GetValue(from);
                Safe.Run(() => p?.SetValue(to, v));
            }
        }
    }
}