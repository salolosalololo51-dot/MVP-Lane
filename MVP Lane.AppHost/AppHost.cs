var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MVP_Lane_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.MVP_Lane_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
