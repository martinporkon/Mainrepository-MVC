using System.Threading.Tasks;
using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;
using Quantity.Infra;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass]
    public class MeasureTermTests : SealedTests<MeasureTerm, Term<MeasureTermData>>
    {

        private MeasureData dMaster;
        private MeasureData dTerm;
        private MeasuresRepository r;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            dMaster = GetRandom.Object<MeasureData>();
            fixData(dMaster, obj.MasterMeasureId, MeasureType.Derived);
            dTerm = GetRandom.Object<MeasureData>();
            fixData(dTerm, obj.TermMeasureId, MeasureType.Base);
            r = GetRepository.Instance<IMeasuresRepository>() as MeasuresRepository;
        }

        //[TestMethod]
        //public void MasterMeasureIdTest() => isReadOnlyProperty(obj, nameof(obj.MasterMeasureId), obj.Data.MasterId);

        //[TestMethod]
        //public void TermMeasureIdTest() => isReadOnlyProperty(obj, nameof(obj.TermMeasureId), obj.Data.TermId);

        //[TestMethod]
        //public async Task MasterMeasureTest()
        //{
        //    await r.Add(MeasureFactory.Create(dMaster));
        //    var m = isReadOnlyProperty(obj, nameof(obj.MasterMeasure)) as Measure;
        //    Assert.IsNotNull(m);
        //    arePropertiesEqual(dMaster, m.Data);
        //}

        //[TestMethod]
        //public async Task TermMeasureTest()
        //{
        //    await r.Add(MeasureFactory.Create(dTerm));
        //    var m = isReadOnlyProperty(obj, nameof(obj.TermMeasure)) as Measure;
        //    Assert.IsNotNull(m);
        //    arePropertiesEqual(dTerm, m.Data);
        //}

        [TestMethod]
        public void FormulaTest()
        {
            Assert.AreEqual($"{obj.TermMeasure.Code}^{obj.Power}", obj.Formula());
            Assert.AreEqual($"{obj.TermMeasure.Name}^{obj.Power}", obj.Formula(true));
        }

        //[TestMethod]
        //public void InternalFormulaTest()
        //{
        //    var s = GetRandom.String();
        //    var actual = obj.formula(s);
        //    var expected = $"{s}^{obj.Power}";
        //    Assert.AreEqual(expected, actual);
        //}

        private static void fixData(MeasureData d, string id, MeasureType t)
        {
            d.Id = id;
            d.MeasureType = t;
        }


    }

}