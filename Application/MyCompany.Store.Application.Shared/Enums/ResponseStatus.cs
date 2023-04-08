namespace MyCompany.Store.Application.Shared.Enums
{
    public enum ResponseStatus
    {
        Unknown = 0,
        Ok = 1,
        ValidationErrors = 2,
        Unauthorized = 3,
        Forbidden = 4,
        Created = 5,
        Conflict = 6,
        NotFound = 7,
    }
}
