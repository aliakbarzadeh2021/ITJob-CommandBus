using SAF.SSN.Kernel.CommandBus.Messages;

namespace ITJob.Commands.SeedWorks.Core.Validators
{
    using System;
    using System.Globalization;
    using System.Linq.Expressions;
    using FluentValidation;

    /// <summary>
    /// کلاس پایه برای کلیه ی ولیدیتوهای کامند
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CommonValidator<T> : AbstractValidator<T> where T : CommandBase
    {
        #region Const Variable

        private const string NotNull = "{0} نمی تواند تهی باشد";
        private const string NotEmpty = "{0} نمی تواند خالی باشد";
        private const string LenOnlyxVerb = "طول رشته {0} فقط {1} حرف می تواند باشد";
        private const string InvalidValue = "مقدار {0} نامعتبر می باشد";
        private const string LenBetween2Werb = "طول رشته {0} از {1} تا {2} حرف می تواند باشد";
        private const string ValueMustBe = "مقدار {0} باید {1} باشد";

        #endregion

        #region Constractor

        internal CommonValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
        }

        #endregion

        #region Private Functions

        private IRuleBuilderOptions<T, TProperty> GeneralRuleFor<TProperty>(Expression<Func<T, TProperty>> expression,
            string fieldName)
        {
            if (typeof(TProperty).IsValueType)
                return RuleFor(expression)
                    .NotNull().WithMessage(string.Format(NotNull, fieldName));

            return RuleFor(expression)
                .NotEmpty().WithMessage(string.Format(NotEmpty, fieldName))
                .NotNull().WithMessage(string.Format(NotNull, fieldName));
        }

        #endregion

        #region CustomRuleFor Functions

        /// <summary>
        /// RuleFor(expression).NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد);
        /// </summary>
        /// <typeparam name="TProperty">همه انواع فیلدها</typeparam>
        /// <param name="expression">field => field.x</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, TProperty> CustomRuleFor<TProperty>(Expression<Func<T, TProperty>> expression,
            string fieldName)
        {
            return GeneralRuleFor(expression, fieldName);
        }

        /// <summary>
        /// RuleFor(expression).NotNull().WithMessage(فیلد الف نمی تواند خالی باشد);
        /// </summary>
        /// <param name="expression">field => field.x</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, bool> CustomRuleFor(Expression<Func<T, bool>> expression, string fieldName)
        {
            return RuleFor(expression).NotNull().WithMessage(string.Format(NotNull, fieldName));
        }

        /// <summary>
        /// RuleFor(expression).NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد);
        /// </summary>
        /// <param name="expression">field => field.x</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, DateTime> CustomRuleFor(Expression<Func<T, DateTime>> expression,
            string fieldName)
        {
            return RuleFor(expression)
                .GreaterThan(DateTime.MinValue)
                .WithMessage(string.Format(InvalidValue, fieldName))
                .LessThan(DateTime.MaxValue)
                .WithMessage(string.Format(InvalidValue, fieldName));
        }

        /// <summary>
        /// RuleFor(expression).NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد);
        /// </summary>
        /// <param name="expression">field => field.x</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, Guid> CustomRuleFor(Expression<Func<T, Guid>> expression, string fieldName)
        {
            return
                GeneralRuleFor(expression, fieldName)
                    .NotEqual(Guid.Empty)
                    .WithMessage(string.Format(InvalidValue, fieldName));
        }

        /// <summary>
        /// NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد).Length(len).WithMessage(طول رشته فیلد فقط {1} حرف می تواند باشد);
        /// </summary>
        /// <param name="expression">field => field.stringField</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <param name="len">
        ///     Validation will fail if the length of the string is not equal to the length specified.
        /// </param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, string> CustomRuleFor(Expression<Func<T, string>> expression, string fieldName,
            int len)
        {
            return
                CustomRuleFor(expression, fieldName)
                    .Length(len)
                    .WithMessage(string.Format(LenOnlyxVerb, fieldName, len));
        }

        /// <summary>
        /// NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد).LessThan.GreaterThan.WithMessage(مقدار فیلد نامعتبر می باشد);
        /// </summary>
        /// <param name="expression">field => field.intField</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <param name="lessThan">
        ///     The validation will succeed if the property value is less than the specified value.
        ///     The validation will fail if the property value is greater than or equal to the specified value.
        /// </param>
        /// <param name="greaterThan">
        ///     The validation will succeed if the property value is greater than the specified value. 
        ///     The validation will fail if the property value is less than or equal to the specified value.
        /// </param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, int> CustomRuleFor(Expression<Func<T, int>> expression, string fieldName,
            int lessThan, int greaterThan)
        {
            return CustomRuleFor(expression, fieldName)
                .LessThan(lessThan)
                .WithMessage(string.Format(InvalidValue, fieldName))
                .GreaterThan(greaterThan)
                .WithMessage(string.Format(InvalidValue, fieldName));
        }

        /// <summary>
        /// NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد).LessThan.GreaterThan.WithMessage(مقدار فیلد نامعتبر می باشد);
        /// </summary>
        /// <param name="expression">field => field.doubleField</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <param name="lessThan">
        ///     The validation will succeed if the property value is less than the specified value.
        ///     The validation will fail if the property value is greater than or equal to the specified value.
        /// </param>
        /// <param name="greaterThan">
        ///     The validation will succeed if the property value is greater than the specified value. 
        ///     The validation will fail if the property value is less than or equal to the specified value.
        /// </param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, double> CustomRuleFor(Expression<Func<T, double>> expression, string fieldName,
            double lessThan, double greaterThan)
        {
            return CustomRuleFor(expression, fieldName)
                .LessThan(lessThan)
                .WithMessage(string.Format(InvalidValue, fieldName))
                .GreaterThan(greaterThan)
                .WithMessage(string.Format(InvalidValue, fieldName));
        }

        /// <summary>
        /// NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد).Length(fromLen, toLen).WithMessage(طول رشته {0} از {1} تا {2} حرف می تواند باشد);
        /// </summary>
        /// <param name="expression">field => field.stringField</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <param name="fromLen">
        ///     Defines a length validator on the current rule builder, but only for string
        ///     properties.  Validation will fail if the length of the string is outside
        ///     of the specifed range. The range is inclusive.
        /// </param>
        /// <param name="toLen">
        ///     Defines a length validator on the current rule builder, but only for string
        ///     properties.  Validation will fail if the length of the string is outside
        ///     of the specifed range. The range is inclusive.
        /// </param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, string> CustomRuleFor(Expression<Func<T, string>> expression, string fieldName,
            int fromLen, int toLen)
        {
            return CustomRuleFor(expression, fieldName)
                .Length(fromLen, toLen)
                .WithMessage(string.Format(LenBetween2Werb, fieldName, fromLen, toLen));
        }

        /// <summary>
        /// NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد).NotEqual(notEqual).WithMessage(مقدار {0} باید {1} باشد);
        /// </summary>
        /// <param name="expression">field => field.intField</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <param name="equal">
        ///   Validation will fail if the specified value is not equal to the value of the property.
        /// </param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, int> CustomRuleFor(Expression<Func<T, int>> expression, string fieldName,
            int equal)
        {
            return CustomRuleFor(expression, fieldName)
                .LessThanOrEqualTo(equal)
                .WithMessage(string.Format(ValueMustBe, fieldName, equal))
                .GreaterThanOrEqualTo(equal)
                .WithMessage(string.Format(ValueMustBe, fieldName, equal));
        }

        /// <summary>
        /// NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد).NotEqual(notEqual).WithMessage(مقدار {0} باید {1} باشد);
        /// </summary>
        /// <param name="expression">field => field.intField</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <param name="year">
        ///   Validation will fail if the specified value is not equal to the value of the property.
        /// </param>
        /// <param name="message">
        ///   If validation on year failes! this message apears.
        /// </param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, DateTime> CustomRuleFor(Expression<Func<T, DateTime>> expression,
            string fieldName, int year, string message)
        {
            var p = new PersianCalendar();
            var dt = p.ToDateTime(year, 1, 1, 0, 0, 0, 0);
            var dt1 = p.ToDateTime(year + 1, 1, 1, 0, 0, 0, 0).AddDays(-1);
            return CustomRuleFor(expression, fieldName)
                .LessThanOrEqualTo(dt1).WithMessage(message)
                .GreaterThanOrEqualTo(dt).WithMessage(message);
        }

        /// <summary>
        /// NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد).When(when).WithMessage();
        /// </summary>
        /// <typeparam name="TProperty">همه انواع فیلدها</typeparam>
        /// <param name="expression">field => field.intField</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <param name="must">Validation will succeed if the specifed lambda returns true.</param>
        /// <param name="message">If 'must' failes, message throws.</param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, TProperty> CustomRuleFor<TProperty>(Expression<Func<T, TProperty>> expression,
            string fieldName, Func<T, TProperty, bool> must, string message)
        {
            return CustomRuleFor(expression, fieldName).Must(must).WithMessage(message);
        }

        /// <summary>
        /// NotEmpty().NotNull().WithMessage(فیلد الف نمی تواند خالی باشد).When(when).WithMessage();
        /// </summary>
        /// <param name="expression">field => field.intField</param>
        /// <param name="fieldName">نام فارسی فیلد</param>
        /// <param name="must">Validation will succeed if the specifed lambda returns true.</param>
        /// <param name="message">If 'must' failes, message throws.</param>
        /// <returns>RuleFor return value</returns>
        protected IRuleBuilderOptions<T, DateTime> CustomRuleFor(Expression<Func<T, DateTime>> expression,
            string fieldName, Func<T, DateTime, bool> must, string message)
        {
            return CustomRuleFor(expression, fieldName).Must(must).WithMessage(message);
        }

        /// <summary>
        /// بررسی صحت یک فیلد مقدار - Enum
        /// از این متد جهت فیلدهایی که مقدار منفی هم قبول می کنند استفاده ننمائید
        /// </summary>
        /// <typeparam name="TEnum">نوع متغیر مقداری</typeparam>
        /// <param name="expression">عبارت لامبدای فیلد مورد بررسی</param>
        /// <param name="fieldName">نام فیلد</param>
        /// <returns></returns>
        protected IRuleBuilderOptions<T, object> CustomRuleFor<TEnum>(Expression<Func<T, object>> expression,
            string fieldName)
        {
            return RuleFor(expression)
                .NotNull().WithMessage(string.Format(NotNull, fieldName))
                .Must(f => Enum.IsDefined(typeof(TEnum), f)).WithMessage(string.Format(InvalidValue, fieldName));
        }

        #endregion
    }
}