namespace MyCompany.Store.Core.Domain.SeedWork
{
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; init; }

        public string Message { get; init; }

        public BusinessRuleValidationException(IBusinessRule brokenRule)
            : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Message = brokenRule.Message;
        }
    }
}
