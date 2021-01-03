using Sooduskorv_MVC.Aids.Methods;
using Web.Domain.Common;
using Web.Domain.DTO.Common;

namespace Web.Facade.Common
{
    public abstract class AbstractViewFactory<TData, TObject, TView>
        where TData : PeriodEntityDto, new()
        where TView : PeriodView, new()
        where TObject : IDto<TData>
    {

        public virtual TObject Create(TView v)
        {
            var d = new TData();
            copyMembers(v, d);
            return toObject(d);
        }
        internal protected abstract TObject toObject(TData d);
        internal protected virtual void copyMembers(TView v, TData d) => Copy.Members(v, d);
        internal protected virtual void copyMembers(TData d, TView v) => Copy.Members(d, v);
        public virtual TView Create(TObject o)
        {
            var v = new TView();
            copyMembers(o.Data, v);
            return v;
        }
    }
}