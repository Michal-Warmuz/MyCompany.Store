namespace MyCompany.Store.Application.Shared.Queries
{
    public interface IPagedQuery
    {
        int Page { get; init; }

        int PerPage { get; init; }
    }
}
