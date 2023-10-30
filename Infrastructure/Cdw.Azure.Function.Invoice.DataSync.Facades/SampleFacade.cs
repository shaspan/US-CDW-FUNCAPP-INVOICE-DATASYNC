using Cdw.Azure.Function.Sample.Facades.Interfaces;
using Cdw.Azure.Function.Sample.Facades.Models;

namespace Cdw.Azure.Function.Sample.Facades
{
    /// <summary>
    /// 
    /// </summary>
    public class SampleFacade: ISampleFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<SampleFacadeModel> GetAsync()
        {
            var model = new SampleFacadeModel
            {
                Name = "sample"
            };

            return await Task.FromResult(model).ConfigureAwait(false);
        }
    }
}