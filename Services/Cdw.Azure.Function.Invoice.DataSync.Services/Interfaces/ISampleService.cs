namespace Cdw.Azure.Function.Sample.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISampleService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<Domain.Sample> GetAsync();
    }
}
