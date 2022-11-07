using DefinityFirstExercise.Contracts;
using DefinityFirstExercise.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DefinityFirstExercise
{
    class MarblesService
    {
        private IAppConfiguration _appConfiguration;
        public MarblesService(IAppConfiguration appConfiguration)
        {
            this._appConfiguration = appConfiguration;
        }
        public void RunProcess()
        {
            Console.WriteLine("Bob's marbles list");

            string json = @"
                            {
                            marbles: [
                                       { id: 1, color: ""blue"", name: ""Bob"", weight: 0.5 },
                                       { id: 2, color: ""red"", name: ""John Smith"", weight: 0.25 },
                                       { id: 3, color: ""violet"", name: ""Bob O'Bob"", weight: 0.5 },
                                       { id: 4, color: ""indigo"", name: ""Bob Dad-Bob"", weight: 0.75 },
                                       { id: 5, color: ""yellow"", name: ""John"", weight: 0.5 },
                                       { id: 6, color: ""orange"", name: ""Bob"", weight: 0.25 },
                                       { id: 7, color: ""blue"", name: ""Smith"", weight: 0.5 },
                                       { id: 8, color: ""blue"", name: ""Bob"", weight: 0.25 },
                                       { id: 9, color: ""green"", name: ""Bobb Ob"", weight: 0.75 },
                                       { id: 10, color: ""blue"", name: ""Bob"", weight: 0.5 },
                                       ]
                            }
                            ";

            var root = JsonConvert.DeserializeObject<Marbles>(json);

            var order = _appConfiguration.OrderList;

            var orderlist = order.Select(x => new string(x, 1)).ToArray().ToList();

            var filter = root.marbles.Where(w => w.Weight >= 0.5).OrderBy(x => orderlist.IndexOf(x.Color.ToUpper().Substring(0, 1))).Where(x => IsPalindrome(x)).ToList();

            filter.ForEach(item => Console.WriteLine($"{nameof(item.Id)}:{item.Id,-10}{nameof(item.Color)}:{item.Color,-10}{nameof(item.Name)}:{item.Name,-15} {nameof(item.Weight)}:{item.Weight,-10}"));
            

        }

        public static bool IsPalindrome(Marble marble)
        {
            var palindrome = marble.Name;
            var decomposed = palindrome.Normalize(NormalizationForm.FormD);
            var filtered = decomposed.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            palindrome = new String(filtered.ToArray()).ToLower();
            palindrome = Regex.Replace(palindrome, @"[^0-9a-zA-Z]", "");

            return palindrome.SequenceEqual(palindrome.Reverse());

        }

    }
}
