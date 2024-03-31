using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindEntities.Exceptions
{
    public class GeneralExceptions : Exception
    {
        public string Detail { get; set; }

        public GeneralExceptions()
        {

        }

        public GeneralExceptions(string message) : base(message)
        {

        }
        public GeneralExceptions(string message, Exception innerException) : base(message, innerException)
        {

        }

        public GeneralExceptions(string title, string detail) : base(title) => Detail = detail;

    }
}
