namespace UserAPI.MetricReporting;

public interface IRequestMetricReporter
{
    void RegisterRequest(int code);
    void RegisterResponseTime(int statusCode, string method, TimeSpan elapsed);
}
