using Prometheus;

namespace UserAPI.MetricReporting;

public class RequestMetricReporter : IRequestMetricReporter
{
    private readonly Counter _totalRequestCounter;
    private readonly Histogram _responseTimeHistogram;
    private readonly Summary _statusCodeSummary;

    public RequestMetricReporter()
    {
        _totalRequestCounter = Metrics.CreateCounter("total_requests", "The total number of requests serviced by this API.");

        _responseTimeHistogram = Metrics.CreateHistogram("request_duration_seconds", "The duration in seconds between the response to a request.", new HistogramConfiguration
        {
            Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
            LabelNames = new string[] { "status_code", "method" }
        });

        _statusCodeSummary = Metrics.CreateSummary("response_code_summary", "A summary of all response codes created by the application.", new SummaryConfiguration
        {
            LabelNames = new string[] { "status_code" },
        });

    }

    public void RegisterRequest(int code)
    {
        _totalRequestCounter.Inc();
        _statusCodeSummary
            .WithLabels(code.ToString())
            .Observe(1);
    }

    public void RegisterResponseTime(int statusCode, string method, TimeSpan elapsed)
    {
        _responseTimeHistogram
            .WithLabels(statusCode.ToString(), method)
            .Observe(elapsed.TotalSeconds);
    }
}
