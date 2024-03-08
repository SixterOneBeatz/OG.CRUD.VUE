namespace OG.CRUD.VUE.Application.Common.Exceptions
{
    public class NotFoundException(string name, object key) : ApplicationException($"Resource \"{name}\" ({key}) not found")
    {
    }
}
