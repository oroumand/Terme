using System;
using System.Collections.Generic;
using System.Text;

namespace Terme.Framework.Commands
{
    public class CommandResult
    {
        /// <summary>
        /// پیامی که نیاز است در اختیار کاربر قرار گیرد.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// نتیجه انجام عملیات به کمک این متغیر بازگشت داده می‌شود.
        /// </summary>
        public bool IsSuccess { get; set; }
        private readonly List<string> _errors = new List<string>();
        /// <summary>
        /// در صورتی که در طول انجام عملیات خطایی از نظر منطقی و عملیاتی وجود داشته باشد، در این متغیر ثبت می‌شود.
        /// </summary>
        public IEnumerable<string> Errors => _errors;
        /// <summary>
        /// یک خطا به لیست خطا‌ها اضافه می‌کند.
        /// </summary>
        /// <param name="error"></param>
        internal void AddError(string error)
        {
            IsSuccess = false;
            _errors.Add(error);
        }
        /// <summary>
        /// لیست خطا‌های ثبت شده را خالی می‌کند
        /// </summary>
        internal void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
