using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsAdvanced
{
    public class CalculationImpossibleException : ArgumentException
    {
        private string _invalidParameter;

        public CalculationImpossibleException(string invalidParameter)
            : base()
        {
            _invalidParameter = invalidParameter;
        }

        public override string Message
        {
            get 
            {
                return $"Parameter '{_invalidParameter}' hat einen ungültigen Inhalt.";
            }
        }
    }
}
