using System;
using ITJob.ApiService;
using Microsoft.Owin.Hosting;

namespace ITJob.ApiService
{
    /// <summary>
    /// آغاز کننده ی إی-پی-آی
    /// </summary>
    public class ApiStart
    {
        /// <summary>
        /// آدرس پایه ی إی-پی-آی محلی
        /// </summary>
        private readonly string _baseAddress = "http://localhost:9000"; //HostSettings.Default.HostApiAddress;

        /// <summary>
        /// سرور إی-پی-آی محلی
        /// </summary>
        private IDisposable _server;

        /// <summary>
        /// شروع به کار سرور إی-پی-آی
        /// </summary>
        public void Start()
        {
            _server = WebApp.Start<Startup>(url: _baseAddress);
            Console.WriteLine("Listening on: " + _baseAddress);
        }

        /// <summary>
        /// متوقف نمودن سرور إی-پی-آی
        /// </summary>
        public void Stop()
        {
            _server.Dispose();
        }
    }
}