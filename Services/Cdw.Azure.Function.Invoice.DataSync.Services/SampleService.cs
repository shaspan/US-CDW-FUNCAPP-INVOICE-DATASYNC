using Cdw.Azure.Function.Sample.Facades.Interfaces;
using Cdw.Azure.Function.Sample.Services.Interfaces;

namespace Cdw.Azure.Function.Sample.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SampleService: ISampleService
    {
        private readonly ISampleFacade _sampleFacade;

        public SampleService(ISampleFacade sampleFacade)
        {
            _sampleFacade = sampleFacade;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<Domain.Sample> GetAsync()
        {
            var facadeModel = await _sampleFacade.GetAsync();
            var domainModel = new Domain.Sample()
            {
                Name = facadeModel.Name
            };

            return await Task.FromResult(domainModel).ConfigureAwait(false);
        }
    }
}