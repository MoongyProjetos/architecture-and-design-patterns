var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Seguradora>("seguradora");

builder.Build().Run();
