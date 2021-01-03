using CommonTests.InfraTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Infra;
using Sooduskorv_MVC.Aids.Random;
using System.Collections.Generic;
using System.Linq;

namespace Quantity.Tests.Infra {

    [TestClass] public class QuantityDbInitializerTests : DbInitializerTests<QuantityDbContext> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(QuantityDbInitializer);
            db = new QuantityDbContext(options);
            QuantityDbInitializer.db = db;
            removeAll(db.MeasureTerms);
            removeAll(db.Measures);
            removeAll(db.UnitTerms);
            removeAll(db.UnitFactors);
            removeAll(db.Units);
            removeAll(db.SystemsOfUnits);
        }

        [TestMethod] public void InitializeTest() {
            QuantityDbInitializer.Initialize(db);
            Assert.AreEqual(4, db.MeasureTerms.Count());
            Assert.AreEqual(14, db.Measures.Count());
            Assert.AreEqual(43, db.UnitTerms.Count());
            Assert.AreEqual(92, db.UnitFactors.Count());
            Assert.AreEqual(129, db.Units.Count());
            Assert.AreEqual(2, db.SystemsOfUnits.Count());
        }

        [TestMethod] public void InitializeDataTest() {
            QuantityDbInitializer.initialize(Core.Units.SystemOfUnits.Units);
            Assert.AreEqual(2, db.SystemsOfUnits.Count());
        }

        [TestMethod] public void InitializeMeasureTest() {
            QuantityDbInitializer.initialize(Core.Units.Area.Measure, Core.Units.Area.Units);
            Assert.AreEqual(1, db.MeasureTerms.Count());
            Assert.AreEqual(1, db.Measures.Count());
            Assert.AreEqual(17, db.UnitTerms.Count());
            Assert.AreEqual(0, db.UnitFactors.Count());
            Assert.AreEqual(16, db.Units.Count());
            Assert.AreEqual(0, db.SystemsOfUnits.Count());
        }

        [TestMethod] public void AddUnitFactorsTest() {
            var count = GetRandom.UInt8(5, 15);
            var l = new List<Core.Units.UnitInfo>();

            for (var i = 0; i < count; i++) {
                var d = GetRandom.Object<Core.Units.UnitInfo>();
                d.Factor = GetRandom.Double(-10000, 10000);
                l.Add(d);
            }

            var s = GetRandom.String();
            QuantityDbInitializer.addUnitFactors(l, s);
            Assert.AreEqual(0, db.MeasureTerms.Count());
            Assert.AreEqual(0, db.Measures.Count());
            Assert.AreEqual(0, db.UnitTerms.Count());
            Assert.AreEqual(count, db.UnitFactors.Count());
            Assert.AreEqual(0, db.Units.Count());
            Assert.AreEqual(0, db.SystemsOfUnits.Count());
            foreach (var e in db.UnitFactors) Assert.AreEqual(s, e.SystemOfUnitsId);
        }

        [TestMethod] public void AddTermsTest() {
            var expected = GetRandom.Object<Core.Units.UnitInfo>();
            var count = GetRandom.UInt8(5, 15);

            for (var i = 0; i < count; i++)
                expected.Terms.Add(GetRandom.Object<Core.Units.TermInfo>());
            QuantityDbInitializer.addTerms(expected, db.MeasureTerms);
            QuantityDbInitializer.addTerms(expected, db.UnitTerms);
            db.SaveChanges();
            Assert.AreEqual(count, db.MeasureTerms.Count());
            Assert.AreEqual(0, db.Measures.Count());
            Assert.AreEqual(count, db.UnitTerms.Count());
            Assert.AreEqual(0, db.UnitFactors.Count());
            Assert.AreEqual(0, db.Units.Count());
            Assert.AreEqual(0, db.SystemsOfUnits.Count());
        }

        [TestMethod] public void AddItemTermsTest() {
            var expected = new List<Core.Units.UnitInfo>();
            var count = GetRandom.UInt8(5, 15);

            for (var i = 0; i < count; i++) {
                var d = GetRandom.Object<Core.Units.UnitInfo>();
                for (var j = 0; j < count; j++)
                    d.Terms.Add(GetRandom.Object<Core.Units.TermInfo>());
                expected.Add(d);
            }

            QuantityDbInitializer.addTerms(expected);
            Assert.AreEqual(0, db.MeasureTerms.Count());
            Assert.AreEqual(0, db.Measures.Count());
            Assert.AreEqual(count * count, db.UnitTerms.Count());
            Assert.AreEqual(0, db.UnitFactors.Count());
            Assert.AreEqual(0, db.Units.Count());
            Assert.AreEqual(0, db.SystemsOfUnits.Count());
        }

        [TestMethod] public void AddMeasureTest() {
            var expected = GetRandom.Object<Core.Units.UnitInfo>();
            QuantityDbInitializer.addMeasure(expected);
            Assert.AreEqual(0, db.MeasureTerms.Count());
            Assert.AreEqual(1, db.Measures.Count());
            Assert.AreEqual(0, db.UnitTerms.Count());
            Assert.AreEqual(0, db.UnitFactors.Count());
            Assert.AreEqual(0, db.Units.Count());
            Assert.AreEqual(0, db.SystemsOfUnits.Count());
            var actual = db.Measures.First();
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Code, actual.Code);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Definition, actual.Definition);
        }

        [TestMethod] public void GetItemTest() {
            QuantityDbInitializer.Initialize(db);
            var expected = GetRandom.Object<MeasureData>();
            db.Measures.Add(expected);
            db.SaveChanges();
            var actual = QuantityDbInitializer.getItem(db.Measures, expected.Id);
            arePropertiesEqual(expected, actual);
        }

        [TestMethod] public void AddUnitsTest() {
            var s = GetRandom.String();
            QuantityDbInitializer.addUnits(Core.Units.Counter.Units, s);
            Assert.AreEqual(0, db.MeasureTerms.Count());
            Assert.AreEqual(0, db.Measures.Count());
            Assert.AreEqual(0, db.UnitTerms.Count());
            Assert.AreEqual(0, db.UnitFactors.Count());
            Assert.AreEqual(7, db.Units.Count());
            Assert.AreEqual(0, db.SystemsOfUnits.Count());

            foreach (var e in db.Units) Assert.AreEqual(s, e.MeasureId);
        }

    }

}
