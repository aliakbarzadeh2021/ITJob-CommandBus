using SAF.SSN.Kernel.CommandBus;
using SAF.SSN.Kernel.CommandBus.Messages;

namespace ITJob.ApiService.SeedWorks.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Helpers;
    using Models;
    using Commands.SeedWorks.Exceptions;

    public abstract class ApiControllerBase : ApiController
    {
        private readonly ICommandBus _bus;

        protected ApiControllerBase()
        {
        }

        protected ApiControllerBase(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// شناسه کاربر
        /// </summary>
        protected Guid UserId => Request.Headers.Contains("personId")
            ? Guid.Parse(Request.Headers.GetValues("personId").First())
            : Guid.Empty;

        protected ICommandBus Bus => _bus;

        protected ResponseModel CreateResponseModel(string message, ResponseMessageType type, bool success = false,
            object content = null)
        {
            return (content != null
                ? new ResponseContentModel
                {
                    Content = content,
                    Message = message,
                    Success = success,
                    Type = type
                }
                : new ResponseModel
                {
                    Message = message,
                    Success = success,
                    Type = type
                });
        }

        /// <summary>
        /// پاسخ انجام شدن با موفقیت به درخواست ارسالی
        /// </summary>
        /// <param name="actionName">شرح درخواست</param>
        /// <param name="content">محتوای مورد نیاز جهت بازگرداندن</param>
        /// <returns></returns>
        protected HttpResponseMessage OkResult(string actionName, object content = null)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                CreateResponseModel($"{actionName} با موفقیت انجام شد", ResponseMessageType.Success,
                    true, content));
        }

        /// <summary>
        /// پاسخ بروز خطا به درخواست ارسالی
        /// </summary>
        /// <param name="errors">فهرست خطاهای شناسایی شده</param>
        /// <returns></returns>
        protected HttpResponseMessage BadRequestResult(IEnumerable<string> errors)
        {
            if (errors == null) return null;

            var errorMessage = ((string[]) errors)[0];
            if (errorMessage.Contains("is already taken"))
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    CreateResponseModel("نام کاربری این کاربر قبلا ایجاد شده است", ResponseMessageType.Error));
            }

            var message = errors.Aggregate("", (current, error) => current + (error + "\n"));
            return Request.CreateResponse(HttpStatusCode.OK, CreateResponseModel(message, ResponseMessageType.Error));
        }

        protected HttpResponseMessage BadRequestResult(string error)
        {
            return BadRequestResult(new[] {error});
        }

        protected HttpResponseMessage BadRequestResult()
        {
            return BadRequestResult(string.Empty);
        }

        #region Handel And Send command for POST & PUT & DELETE

        protected HttpResponseMessage HandleAndSend<T, TReturn>(T command, string commandTitle,
            TReturn returnObject, Action action = null) where T : CommandBase
        {
            try
            {
                if (action == null)
                {
                    command.Validate();
                    Bus.Send(command);
                }
                else
                {
                    action.Invoke();
                }

                return OkResult(commandTitle, returnObject);
            }
            catch (CommandValidationException ex)
            {
                return BadRequestResult(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequestResult($"{commandTitle} با مشکل مواجه گردید\n{ex.Message}");
            }
        }

        protected HttpResponseMessage HandleAndSend<T>(T command, string commandTitle, Action action = null) where T : CommandBase
        {
            return HandleAndSend<T, string>(command, commandTitle, null, action);
        }

        #endregion

        protected async Task<DataSet> HandleAndGetFromExcelFile()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new Exception("فرمت اطلاعات درخواستی اشکال دارد");
            }
            var tempFolder = "C:\\Temp";
            var streamProvider = new MultipartFormDataStreamProvider(tempFolder);

            await Request.Content.ReadAsMultipartAsync(streamProvider);
            var originalFileName = streamProvider.FileData[0].Headers.ContentDisposition.FileName;
            if (originalFileName.StartsWith("\"") && originalFileName.EndsWith("\""))
            {
                originalFileName = originalFileName.Trim('"');
            }
            if (originalFileName.Contains(@"/") || originalFileName.Contains(@"\"))
            {
                originalFileName = Path.GetFileName(originalFileName);
            }
            var localFileName = streamProvider.FileData[0].LocalFileName;

            //var excelData = ExcelHelper.GetExcelData(localFileName, originalFileName);
            return new DataSet();
        }

        //protected async Task<HttpResponseMessage> HandleAndSendExcelFile<TDto, TCommand>(Func<TDto, TCommand> func)
        //    where TDto : class, new()
        //    where TCommand : CommandBase, new()
        //{
        //    try
        //    {
        //        var data = await HandleAndGetFromExcelFile();
        //        var colList = data.Tables[0].Columns.OfType<DataColumn>().Select(c=>c.ColumnName);
        //        var dtoCount = typeof(TDto).GetProperties().Count();
        //        if (colList.Count() != dtoCount)
        //        {
        //            return BadRequestResult("فایل اکسل شما معتبر نمی باشد");
        //        }
        //       // var dtoData = ExcelHelper.GetDtosFromTable<TDto>(data.Tables[0]);
        //        var dtoData = IList<TDto>();
        //        var invalidData = dtoData.Item2.ToList();
        //        var validDataCount = dtoData.Item1.Count();
                
        //        foreach (var dto in dtoData.Item1)
        //        {
        //            var command = func.Invoke(dto);
        //            try
        //            {
        //                Bus.Send(command);
        //            }
        //            catch (Exception ex)
        //            {
        //                var invalidString = string.Empty;
        //                var props = dto.GetType().GetProperties();
        //                invalidString = props.Aggregate(invalidString,
        //                    (current, prop) => current + $"{prop.GetValue(dto)}; ");

        //                invalidData.Add($"{invalidString} {ex.Message}");
        //                validDataCount--;
        //            }
        //        }

        //        var result = new { InvalidData = invalidData, Headers = colList, ValidDataCount = validDataCount };
        //        return OkResult("دریافت و ثبت اطلاعات فایل اکسل بدون خطا پایان یافت", result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequestResult($"اشکال در فراخوانی اطلاعات فایل اکسل\r\n{ex.Message}");
        //    }
        //}
    }
}