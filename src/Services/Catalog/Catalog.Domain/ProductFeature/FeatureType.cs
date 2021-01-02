using Sooduskorv_MVC.Aids.Reflection;
using Catalog.Data.ProductFeature;
using Catalog.Domain.Catalog;
using Catalog.Domain.Common;
using System.Collections.Generic;

namespace Catalog.Domain.ProductFeature
{
    public sealed class FeatureType : DescribedEntity<FeatureTypeData>
    {

        internal static string field => GetMember.Name<PossibleFeatureValueData>(x => x.FeatureTypeId);

        public FeatureType(FeatureTypeData d = null) : base(d) { }

        public string ProductTypeId => Data?.ProductTypeId ?? Unspecified;

        public bool IsMandatory => Data?.IsMandatory ?? false;

        public IReadOnlyList<PossibleFeatureValue> PossibleValues => new GetFrom<IPossibleFeatureValuesRepository, PossibleFeatureValue>()
            .ListBy(field, Id);
        public int NumericCode => data?.NumericCode ?? UnspecifiedInteger;

    }
}
