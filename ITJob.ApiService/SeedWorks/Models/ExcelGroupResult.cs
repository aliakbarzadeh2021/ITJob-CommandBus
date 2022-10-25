namespace ITJob.ApiService.SeedWorks.Models
{
    using System;

    /// <summary>
    /// مدل برای پارامترهای ارسالی برای دریافت نتایج گروهی در قالب فایل اکسل
    /// </summary>
    public class ExcelGroupResult
    {
        /// <summary>
        /// شناسه آزمون
        /// </summary>
        public Guid ExamId { get; set; }

        /// <summary>
        /// فهرست شناسه افراد
        /// </summary>
        public Guid[] Persons { get; set; }

        /// <summary>
        /// شناسه پرسشنامه
        /// </summary>
        public int QuestionnaireTypes { get; set; }
    }
}