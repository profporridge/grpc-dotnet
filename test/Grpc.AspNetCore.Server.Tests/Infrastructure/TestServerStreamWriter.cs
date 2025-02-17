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

using Grpc.Core;

namespace Grpc.AspNetCore.Server.Tests.Infrastructure
{
    public class TestServerStreamWriter<T> : IServerStreamWriter<T>
    {
        // TODO(JamesNK): Remove nullable override after Grpc.Core.Api update
#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public WriteOptions? WriteOptions { get; set; }
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public List<T> Responses { get; } = new List<T>();
        public Func<T, Task>? OnWriteAsync { get; set; }

        public async Task WriteAsync(T message)
        {
            Responses.Add(message);
            if (OnWriteAsync != null)
            {
                await OnWriteAsync(message);
            }
        }
    }
}
