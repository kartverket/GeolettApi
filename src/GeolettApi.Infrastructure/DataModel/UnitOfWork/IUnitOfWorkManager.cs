namespace GeolettApi.Infrastructure.DataModel.UnitOfWork
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork GetUnitOfWork();
    }
}
