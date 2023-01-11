using System.Diagnostics;

namespace UserAPI.MetricReporting;

public class ResponseMetricMiddleware
{
    private readonly RequestDelegate _request;

    public ResponseMetricMiddleware(RequestDelegate request)
    {
        _request = request;
    }

    public async Task Invoke(HttpContext httpContext, IRequestMetricReporter reporter)
    {
        var path = httpContext.Request.Path.Value;
        if (path == "/metrics")
        {
            await _request.Invoke(httpContext);
            return;
        }
        var sw = Stopwatch.StartNew();
        
        try
        {
            await _request.Invoke(httpContext);
        }
        finally
        {
            sw.Stop();
            var statusCode = httpContext.Response.StatusCode;
            reporter.RegisterRequest(statusCode);
            reporter.RegisterResponseTime(statusCode, httpContext.Request.Method, sw.Elapsed);
        }
    }
}
