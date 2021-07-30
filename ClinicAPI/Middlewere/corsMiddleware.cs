using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SS5_BackEnd_API.Middlewere
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class corsMiddleware
	{
		private readonly RequestDelegate _next;

		public corsMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public Task Invoke(HttpContext httpContext)
		{
			httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
			httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
			httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
			httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");
			return _next(httpContext);
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class corsMiddlewareExtensions
	{
		public static IApplicationBuilder UsecorsMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<corsMiddleware>();
		}
	}
}
