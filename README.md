# SzakatsA.ASPUtilities.HealthCheckExtensions

A small extension for ASP.NET Core that maps a `/healthz` endpoint and returns detailed health check results in a clean JSON format.

This package simplifies exposing application health diagnostics in a structured and readable way, making it easier to integrate with monitoring tools or health dashboards.

---

## Features

- Adds a JSON health check endpoint with minimal setup
- Outputs overall status, total duration, and individual check details
- Custom DTOs to simplify and structure the output
- Supports tags, metadata, error messages, and execution duration

---

## Installation

Add a reference to the project or install via NuGet (if published):

    dotnet add package HealthChecks.JsonResponse

## Usage

In your Program.cs or Startup.cs file:

    using HealthChecks.JsonResponse;
    
    var builder = WebApplication.CreateBuilder(args);
    
    // Register health checks service
    builder.Services.AddHealthChecks()
    .AddCheck<ExampleHealthCheck>("example_check");
    
    var app = builder.Build();
    
    // Map the JSON health check endpoint
    app.MapHealthChecksJSON("/healthz");
    
    app.Run();

## Example JSON output

    {
    "status": "Healthy",
    "duration": "00:00:00.0421943",
        "info": [
            {
            "key": "example_check",
            "description": "Example check description",
            "duration": "00:00:00.0012300",
            "status": "Healthy",
            "error": "",
            "data": {},
            "tags": []
            }
        ]
    }

## License
SzakatsA.Result is released under the Unlicense.

This means:
- ✅ You can freely use, modify, distribute, or sell the software
- ❌ No warranties or guarantees are provided
- 💼 Suitable for both personal and commercial use

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <https://unlicense.org/>