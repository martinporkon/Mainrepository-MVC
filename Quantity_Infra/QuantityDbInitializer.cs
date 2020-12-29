using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quantity.Core.Units;
using Quantity.Data;
using Sooduskorv_MVC.Data.CommonData;
using UnitData = Quantity.Data.UnitData;

namespace Quantity.Infra {

    public class QuantityDbInitializer: DbInitializer {

        internal static QuantityDbContext db;

        public static void Initialize(QuantityDbContext c) {
            db = c;
            initialize(SystemOfUnits.Units);
            initialize(Area.Measure, Area.Units);
            initialize(Counter.Measure, Counter.Units);
            initialize(Current.Measure, Current.Units);
            initialize(Distance.Measure, Distance.Units);
            initialize(Luminos.Measure, Luminos.Units);
            initialize(ManHour.Measure, ManHour.Units);
            initialize(Mass.Measure, Mass.Units);
            initialize(Persentage.Measure, Persentage.Units);
            initialize(Substance.Measure, Substance.Units);
            initialize(Temperature.Measure, Temperature.Units);
            initialize(Time.Measure, Time.Units);
            initialize(Volume.Measure, Volume.Units);
            initialize(Density.Measure, Density.Units);
            initialize(Acidity.Measure, Acidity.Units);
        }

        internal static void initialize(IEnumerable<UnitInfo> data) {
            foreach (var d in from d in data
                let o = db.SystemsOfUnits.FirstOrDefaultAsync(m => m.Id == d.Id).GetAwaiter().GetResult()
                where o is null
                select d) {
                addItem(
                    new SystemOfUnitsData {
                        Id = d.Id,
                        Code = d.Code,
                        Name = d.Name,
                        Definition = d.Definition
                    }, db);
            }
        }

        internal static void initialize(UnitInfo measure, List<UnitInfo> units) {
            addMeasure(measure);
            addTerms(measure, db.MeasureTerms);
            addUnits(units, measure.Id);
            addTerms(units);
            addUnitFactors(units, SystemOfUnits.SiSystemId);
        }

        internal static void addUnitFactors(List<UnitInfo> units, string siSystemId) {
            foreach (var d in units) {
                if (Math.Abs(d.Factor) < double.Epsilon) continue;
                var o = db.UnitFactors.FirstOrDefaultAsync(
                    m => m.SystemOfUnitsId == siSystemId && m.UnitId == d.Id).GetAwaiter().GetResult();

                if (!(o is null)) continue;
                addItem(
                    new UnitFactorData() {
                        SystemOfUnitsId = siSystemId,
                        UnitId = d.Id,
                        Factor = d.Factor
                    }, db);
            }
        }

        internal static void addTerms(List<UnitInfo> units) {
            foreach (var d in units)
                addTerms(d, db.UnitTerms);
        }

        internal static void addTerms<T>(UnitInfo measure, DbSet<T> set) where T : CommonTermData, new() {
            foreach (var d in measure.Terms) {
                var o = set.FirstOrDefaultAsync(
                    m => m.MasterId == measure.Id && m.TermId == d.TermId).GetAwaiter().GetResult();

                if (!(o is null)) continue;
                addItem(
                    new T {
                        MasterId = measure.Id,
                        TermId = d.TermId,
                        Power = d.Power
                    }, db);
            }
        }

        internal static void addMeasure(UnitInfo measure) {
            var o = getItem(db.Measures, measure.Id);

            if (!(o is null)) return;
            addItem(
                new MeasureData {
                    Id = measure.Id,
                    Code = measure.Code,
                    Name = measure.Name,
                    Definition = measure.Definition
                }, db);
        }

        internal static T getItem<T>(IQueryable<T> set, string id) where T : UniqueEntityData
            => set.FirstOrDefaultAsync(m => m.Id == id).GetAwaiter().GetResult();

        internal static void addUnits(IEnumerable<UnitInfo> units, string measureId) {
            foreach (var d in from d in units
                let o = getItem(db.Units, d.Id)
                where o is null
                select d) {
                addItem(
                    new UnitData {
                        MeasureId = measureId,
                        Id = d.Id,
                        Code = d.Code,
                        Name = d.Name,
                        Definition = d.Definition
                    }, db);
            }
        }

    }

}
