﻿using Prometheus;

namespace UserAPI.MetricReporting;

public class RequestMetricReporter : IRequestMetricReporter
{
    private readonly Counter _requestCounter;
    private readonly Histogram _responseTimeHistogram;

    public RequestMetricReporter()
    {
        _requestCounter = Metrics.CreateCounter("total_requests", "The total number of requests serviced by this API.");

        _responseTimeHistogram = Metrics.CreateHistogram("request_duration_seconds", "The duration in seconds between the response to a request.", new HistogramConfiguration
        {
            Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
            LabelNames = new string[] { "status_code", "method" }
        });
    }

    public void RegisterRequest(int code)
    {
        _requestCounter.Inc();
    }

    public void RegisterResponseTime(int statusCode, string method, TimeSpan elapsed)
    {
        _responseTimeHistogram
            .WithLabels(statusCode.ToString(), method)
            .Observe(elapsed.TotalSeconds);
    }
}
