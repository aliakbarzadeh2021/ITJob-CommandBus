using System.Collections.Generic;
using System.Net.Http;
using ITJob.ApiService.SeedWorks.Core;
using ITJob.Commands.Modules.AdvertisementModule.Commands;
using ITJob.QueryModels.Interfaces.AdvertisementModule;
using ITJob.QueryService.Implements.AdvertisementModule.Dtos;
using ITJob.QueryService.Interfaces.AdvertisementModule;
using SAF.SSN.Kernel.CommandBus;

namespace ITJob.ApiService.Controllers.AdvertisementModule
{
    /// <summary>
    /// خدمات مربوط به محاسبه نتیجه پاسخ نامه آپلود شده
    /// </summary>
    public class AdvertisementController : ApiControllerBase
    {
        private readonly IAdvertisementQueryService _adQueryService;

        /// <summary>
        /// سازنده کلاس ای پی ای محاسبه نتیجه پاسخ نامه آپلود شده
        /// </summary>
        /// <param name="bus">باس</param>
        /// <param name="adQueryService">کوئری سرویس آزمون</param>
        public AdvertisementController(ICommandBus bus, IAdvertisementQueryService adQueryService) : base(bus)
        {
            _adQueryService = adQueryService;
        }

        /// <summary>
        /// متد محاسبه نتیجه پاسخ نامه آپلود شده
        /// </summary>
        /// <param name="command">command</param>
        /// <returns>پیام سیستم</returns>
        public HttpResponseMessage Post(CreateAdvertisementCommand command)
        {
            return HandleAndSend(command, "محاسبه نتیجه پاسخنامه آپلود شده");
        }

        public IEnumerable<IAdvertisementDto> Get()
        {
            return _adQueryService.SearchAdvertisement(i => true);
        }
    }
}