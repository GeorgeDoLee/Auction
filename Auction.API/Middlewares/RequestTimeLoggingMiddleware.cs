﻿
using System.Diagnostics;

namespace Auction.API.Middlewares;

public class RequestTimeLoggingMiddleware : IMiddleware
{
    private readonly ILogger<RequestTimeLoggingMiddleware> _logger;
    public RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopWatch = Stopwatch.StartNew();
        await next.Invoke(context);
        stopWatch.Stop();

        if(stopWatch.ElapsedMilliseconds > 4000)
        {
            _logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms", 
                context.Request.Method, 
                context.Request, 
                stopWatch.ElapsedMilliseconds);
        }
    }
}
