using System.Collections.Generic;
using System.Linq;

namespace SimpleValidator
{
    public abstract class Validator<T> : IValidator {

        protected Validator(T elemToValidate) => _elementToValidate = elemToValidate;

        protected readonly T _elementToValidate;
        protected readonly List<(bool valid, string errInfo)> _validationRules = new();
        protected IEnumerable<string> Bledy => _validationRules.Where(r => !r.valid).Select(r => r.errInfo);
        //
        public bool IsValid => _validationRules.All(r => r.valid);

        public Validator<T> AddValidationRule(bool valid, string errInfo) {
            _validationRules.Add((valid, errInfo));
            return this;
        }
        // abstract:
        public abstract void AddValidationRules();
        public abstract string CreateErrInfo();
    }

    public static class ValidatorStatic {
        public static bool Validate(IValidator validator, out string errInfo) {
            validator.AddValidationRules();
            errInfo = validator.IsValid ? string.Empty : validator.CreateErrInfo();
            return validator.IsValid;
        }
    }
}
