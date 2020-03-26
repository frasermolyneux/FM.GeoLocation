﻿using System;
using System.Collections.Generic;
using FM.GeoLocation.Client;
using Microsoft.Extensions.Configuration;

namespace FM.GeoLocation.ClientTestHarness
{
    internal class GeoLocationClientConfiguration : IGeoLocationClientConfiguration
    {
        private readonly IConfiguration _configuration;

        public GeoLocationClientConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string BaseUrl => _configuration["GeoLocationService:BaseUrl"];

        public string ApiKey => _configuration["GeoLocationService:ApiKey"];

        public bool UseMemoryCache { get; } = true;
        public int CacheEntryLifeInMinutes { get; } = 60;

        public IEnumerable<TimeSpan> RetryTimespans
        {
            get
            {
                var random = new Random();

                return new[]
                {
                    TimeSpan.FromSeconds(random.Next(1)),
                    TimeSpan.FromSeconds(random.Next(3)),
                    TimeSpan.FromSeconds(random.Next(5))
                };
            }
        }
    }
}