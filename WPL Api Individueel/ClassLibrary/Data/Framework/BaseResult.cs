using System.Collections.Generic;

namespace ClassLibrary.Data.Framework
{
    public abstract class BaseResult
    {
        private List<string> errors = new List<string>();
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors => errors;
        public void AddError(string error)
        {
            errors.Add(error);
        }
    }
}
