using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Partiel01.Lib.Purchases
{
    public class PurchaseResult
    {
        public bool IsValid { get; internal set; }
        public List<string> Errors { get; internal set; } = new List<string>();

        public PurchaseResult(string error)
        {
            Errors = new List<string>
            {
                error
            };
        }

        public PurchaseResult()
        {
            IsValid = true;
        }

        public void AddError(string error)
        {
            Errors.Add(error);
            IsValid = false;
        }

        public void AddError(List<string> errors)
        {
            Errors.AddRange(errors);
            IsValid = false;
        }
    }
}
