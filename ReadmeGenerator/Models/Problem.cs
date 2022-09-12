using System;
using System.Collections.Generic;

namespace Quera.Models {
    public class Problem {
        public string Name { get; set; }

        public List<Solution> Solutions { get; set; }

        public DateTime LastSolutionsCommit { get; set; }
    }
}