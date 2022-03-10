﻿#region Copyright notice and license

// Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using Grpc.AspNetCore.Server;
using Microsoft.Extensions.DependencyInjection;

namespace Grpc.Tests.Shared
{
    internal static class ServicesHelpers
    {
        public static ServiceCollection CreateServices(
            Action<GrpcServiceOptions>? configureGrpc = null,
            Action<IGrpcServerBuilder>? configureGrpcService = null)
        {
            var services = new ServiceCollection();

            services.AddLogging();

            var serverBuilder = services.AddGrpc(configureGrpc ?? (o => { }));
            configureGrpcService?.Invoke(serverBuilder);

            return services;
        }
    }
}
