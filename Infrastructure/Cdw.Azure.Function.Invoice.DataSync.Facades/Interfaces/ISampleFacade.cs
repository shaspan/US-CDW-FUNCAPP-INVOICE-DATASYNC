using Cdw.Azure.Function.Sample.Facades.Models;

namespace Cdw.Azure.Function.Sample.Facades.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISampleFacade
    {
        Task<SampleFacadeModel> GetAsync();
    }
}
