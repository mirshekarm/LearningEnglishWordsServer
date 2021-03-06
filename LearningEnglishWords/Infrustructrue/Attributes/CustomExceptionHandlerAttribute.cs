using System.Text;

namespace Infrustructrue.Attributes
{
	public class CustomExceptionHandlerAttribute : ActionFilterAttribute
	{
		private readonly Dtat.Logging.ILogger<CustomExceptionHandlerAttribute> _logger;

		public CustomExceptionHandlerAttribute(Dtat.Logging.ILogger<CustomExceptionHandlerAttribute> logger)
		{
			_logger = logger;
		}

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.Exception != null)
			{
				var actionName =
					context.RouteData.Values["action"]?.ToString();

				_logger.LogCritical
					(exception: context.Exception, message: context.Exception.Message,
						methodName: actionName, classType: context.Controller.GetType());

				var result = new Result();

				string errorMessage = string.Format
					(Resources.Messages.ErrorMessages.UnkonwnError);

				result.AddErrorMessage(errorMessage);

				context.Result =
					new BadRequestObjectResult(result);

				context.ExceptionHandled = true;
			}

			base.OnActionExecuted(context);
		}
	}
}
