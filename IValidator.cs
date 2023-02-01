namespace SimpleValidator
{
    public interface IValidator {
        void AddValidationRules();
        string CreateErrInfo();
        bool IsValid { get; }
    }
}
