using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

public class SanitizeInputMiddleware
    {
    private readonly RequestDelegate _next;

    public SanitizeInputMiddleware(RequestDelegate next)
        {
        _next = next;
        }

    public async Task InvokeAsync(HttpContext context)
        {
        if (context.Request.HasFormContentType)
            {
            var form = await context.Request.ReadFormAsync();
            var sanitized = new Dictionary<string, StringValues>();

            foreach (var field in form)
                {
                sanitized[field.Key] = WebUtility.HtmlEncode(field.Value);
                }

            context.Request.Form = new FormCollection(sanitized);
            }

        await _next(context);
        }
    }
