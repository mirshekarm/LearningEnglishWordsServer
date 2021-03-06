namespace Infrustructrue.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		public AuthorizeAttribute(params UserRoles[] roles) : base()
		{
			Roles = roles;
		}

		public ICollection<UserRoles> Roles { get; }

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var user =
				context.HttpContext.Items["User"] as UserInformationInToken;

			if (user == null)
			{
				context.Result =
					new JsonResult(new ErrorViewModel() { Message = "Unauthorized" })
					{
						StatusCode = StatusCodes.Status401Unauthorized
					};

				return;
			}

			if (Roles.Contains(UserRoles.All) && Roles.Count > 1)
				throw new Exception(message: "When to use All please not use another enum in authorize attribute");


			foreach (var role in Roles)
			{
				if (role == UserRoles.All)
				{
					if (user.RoleId >= 1)
						return;
				}
				else
				{
					if (user.RoleId == (int)role)
						return;
				}
			}

			context.Result =
				new JsonResult(new ErrorViewModel() { Message = "Unauthorized" })
				{
					StatusCode = StatusCodes.Status401Unauthorized
				};
		}
	}
}
