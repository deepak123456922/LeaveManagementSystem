namespace LeaveManagementSystem.Web.Service.Periods
{
    public interface IPeriodsService
    {
        Task<Period> GetCurrentPeriod();
    }
}