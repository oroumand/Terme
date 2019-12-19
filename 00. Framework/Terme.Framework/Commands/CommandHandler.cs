using System;
using System.Collections.Generic;
using System.Text;
using Terme.Framework.Resources;

namespace Terme.Framework.Commands
{
    public abstract class CommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly CommandResult _result = new CommandResult();
        private readonly IResourceManager _resourceManager;
        public CommandHandler(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }
        /// <summary>
        /// برای بازگشت نتیجه صحیح از تابع Hanlde از این متد کمکی استفاده می شود و مقادیر پیش‌فرض برای نتیجه صحیح را تنظیم می‌کند
        /// </summary>
        /// <returns></returns>
        protected CommandResult Ok()
        {
            SetOkData();
            return _result;
        }
        /// <summary>
        /// برای بازگشت نتیجه صحیح از تابع Hanlde از این متد کمکی استفاده می شود و مقادیر پیش‌فرض برای نتیجه صحیح را تنظیم می‌کند
        /// در این متد باید پیامی نیز جهت بازگشت به استفاده کننده اضافه شود.
        /// </summary>
        /// <returns></returns>
        protected CommandResult Ok(string message)
        {
            SetOkData();
            _result.Message = _resourceManager[message];
            return _result;
        }
        protected CommandResult Ok(string message, params string[] arguments)
        {
            SetOkData();
            _result.Message = _resourceManager[message, arguments];
            return _result;
        }
        private void SetOkData()
        {
            _result.ClearErrors();
            _result.IsSuccess = true;
        }
        protected CommandResult Failure()
        {
            SetFailureData();
            return _result;
        }
        protected CommandResult Failure(string message)
        {
            SetFailureData();
            _result.Message = _resourceManager[message];
            return _result;
        }
        protected CommandResult Failure(string message, params string[] arguments)
        {
            SetFailureData();
            _result.Message = _resourceManager[message, arguments];
            return _result;
        }
        private void SetFailureData()
        {
            _result.IsSuccess = false;
        }
        protected void AddError(string error)
        {
            _result.AddError(_resourceManager[error]);
        }
        protected void AddError(string error, params string[] arguments)
        {
            _result.AddError(_resourceManager[error, arguments]);
        }
        public abstract CommandResult Handle(TCommand command);

    }
}
