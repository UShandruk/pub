using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationSimplificator.Models
{
    public class Summand
    {
        public bool Negative { get; set; }
        public decimal? Multiplier { get; set; }
        public string Variable { get; set; }
        public int? Power { get; set; }

        public int Index { get; set; }

        public string GetFullString()
        {
            string result = Negative ? "-" : String.Empty;
            result = Multiplier.GetValueOrDefault(0) > 1 ? result + Multiplier.Value.ToString(CultureInfo.InvariantCulture) : result;
            result = result + GetPoweredVariableString();

            return result;
        }

        public string GetPoweredVariableString()
        {
            string result = Variable;
            result = Power.GetValueOrDefault(0) > 0 ? result + "^" + Power : result;

            return result;
        }

        public decimal? GetSignedMultiplier()
        {
            return Negative ? Multiplier.GetValueOrDefault(0) * -1 : Multiplier.GetValueOrDefault(0);
        }

        public int SortOrder()
        {
            var weight = 0;

            if (Power.GetValueOrDefault(0) > 1)
                weight += 8;

            if (Variable.Length > 0)
                weight += 4;

            if (Multiplier.GetValueOrDefault(0) > 1)
                weight += 2;

            if (!Negative)
                weight += 1;

            return weight;
        }
    }
}
