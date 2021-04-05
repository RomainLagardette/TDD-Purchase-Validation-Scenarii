using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Partiel01.Lib
{
    public class PurchaseResult
    {
        public bool IsValid { get; internal set; }
        public string Error { get; internal set; }

        public PurchaseResult(string error)
        {
            Error = error;
        }
    }
}
