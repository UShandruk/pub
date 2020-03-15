using QuadraticEquationSimplificator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuadraticEquationSimplificator.Services
{
    public class MathParserService
    {
        public string[] Parse(string[] polynomArray)
        {
            string[] parsedPolynomArray = new string[polynomArray.Length];
            int i = 0;

            foreach (string polynom in polynomArray)
            {
                parsedPolynomArray[i]=Parse(polynom);
                i++;
            }

            return parsedPolynomArray;
        }

        public string Parse(string polynom)
        {
            polynom = OpenBraces(polynom);

            var equalityPos = polynom.IndexOf("=");

            string result = String.Empty;
            var parsedSummands = ParseSummands(polynom);

            foreach (var summand in parsedSummands)
                if (summand.Index > equalityPos)
                    summand.Negative = !summand.Negative;

            var similarSummands = parsedSummands.GroupBy(s => s.GetPoweredVariableString());

            List<Summand> resultingSummands = new List<Summand>();

            foreach (var summandGroup in similarSummands)
            {
                var multiplierSum = summandGroup.Sum(g => g.GetSignedMultiplier());
                if (multiplierSum != 0)
                {
                    var summand = summandGroup.First();

                    var resultingSummand = new Summand { Negative = multiplierSum < 0, Multiplier = multiplierSum < 0 ? multiplierSum * -1 : multiplierSum, Variable = summand.Variable, Power = summand.Power };
                    resultingSummands.Add(resultingSummand);
                }
            }

            result = String.Join("+", resultingSummands.OrderByDescending(s => s.SortOrder()).Select(s => s.GetFullString()).ToArray()).Replace("+-", "-") + "=0";

            return result;
        }

        public string OpenBraces(string polynom)
        {
            string bracesPattern = @"(\-*\d*\.*\d*\([^\(\)]*\))";
            Regex bracesReg = new Regex(bracesPattern);

            string multiplierPattern = @"(-?\d*(?:\.\d+)?)\(";
            Regex multiplierReg = new Regex(multiplierPattern);

            var braces = bracesReg.Matches(polynom);

            foreach (Match brace in braces)
            {
                var openBrasePos = brace.Value.IndexOf('(');

                string multiplierStr = brace.Value.Substring(0, openBrasePos);

                decimal multiplier = 0;

                if (multiplierStr.Length == 0)
                {
                    multiplier = 1;
                }
                else if (multiplierStr == "-")
                {
                    multiplier = -1;
                }
                else
                {
                    multiplier = Convert.ToDecimal(multiplierStr, CultureInfo.InvariantCulture);
                }

                bool negate = multiplier < 0;

                if (negate)
                    multiplier *= -1;

                var openBracePos = brace.Value.IndexOf("(");
                var closeBracePos = brace.Value.IndexOf(")");

                var bracePolynom = brace.Value.Substring(openBracePos + 1, closeBracePos - openBracePos);

                var summands = ParseSummands(bracePolynom);

                foreach (var summand in summands)
                {
                    summand.Multiplier *= multiplier;
                    summand.Negative = negate ? !summand.Negative : summand.Negative;
                }

                var openedBraces = String.Join("+", summands.Select(s => s.GetFullString()).ToArray()).Replace("+-", "-");// + "=0";

                //openedBraces = String.Format("{0}{1}", negate ? "-" : String.Empty, openedBraces);

                polynom = polynom.Replace(brace.Value, openedBraces);
            }

            return polynom;
        }

        public List<Summand> ParseSummands(string polynom)
        {
            string polynomPattern = @"(\-?\d*(?:\.\d+)?[a-zA-Z]*(?:\^?\d+)?)";
            string summandPattern = @"(?'negation'\-+)*\s*(?'multiplier'\d+\.*\d*)*\s*(?'variable'[a-zA-Z]+)*\s*(?'power'\^{1}\d+)*";

            Regex mainReg = new Regex(polynomPattern);
            Regex summandReg = new Regex(summandPattern);

            var summands = mainReg.Matches(polynom);

            List<Summand> parsedSummands = new List<Summand>();

            foreach (Match summand in summands)
            {
                if (summand.Value.Length == 0)
                    continue;

                var summandParts = summandReg.Match(summand.ToString()).Groups;
                var negation = summandParts["negation"].Value.Length > 0;

                decimal? multiplier = summandParts["multiplier"].Value.Length > 0 ? (decimal?)Convert.ToDecimal(summandParts["multiplier"].Value.Replace(',', '.'), CultureInfo.InvariantCulture) : null;

                var variable = summandParts["variable"].Value;
                int? power = summandParts["power"].Length > 0 ? (int?)Int32.Parse(summandParts["power"].Value.Substring(1)) : null;

                if (variable.Length > 0 && multiplier.GetValueOrDefault(0) == 0)
                    multiplier = 1;

                var parsedSummand = new Summand { Negative = negation, Multiplier = multiplier, Variable = variable, Power = power, Index = summand.Index };

                parsedSummands.Add(parsedSummand);
            }

            return parsedSummands;
        }
    }
}
