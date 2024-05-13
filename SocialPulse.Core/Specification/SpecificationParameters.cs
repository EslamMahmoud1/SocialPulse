using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Core.Specification
{
    public class SpecificationParameters
    {
        private string? _search;

        public string? Search
        {
            get => _search;
            set { _search = value?.Trim().ToLower(); }
        }
    }
}
