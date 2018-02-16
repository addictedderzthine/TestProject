using System.Collections.Generic;

namespace TestProject.Model
{
    public class ValidationErrors
    {
        //stores validation errors
        private readonly List<ValidationError> _errors;
        public ValidationErrors() => _errors = new List<ValidationError>();
        public IList<ValidationError> Items => _errors;

        public void Add(string propertyName) => _errors.Add(new ValidationError(propertyName, propertyName + " is required."));

        public void Add(string propertyName, string message) => _errors.Add(new ValidationError(propertyName, message));

        public void AddRange(IList<ValidationError> errors) => _errors.AddRange(errors);
        internal void Clear() => _errors.Clear();
    }
}