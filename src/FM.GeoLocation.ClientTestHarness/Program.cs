﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using FM.GeoLocation.Client;
using Microsoft.Extensions.Configuration;

namespace FM.GeoLocation.ClientTestHarness
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), false)
                .Build();


            var geoLocationClientOptions = new GeoLocationClientOptions(config);
            var geoLocationClient = new GeoLocationClient(null, geoLocationClientOptions);

            var value = await geoLocationClient.LookupAddress("8.8.8.8");

            var addresses = new[] {"google.com", "sky.com", "bbc.co.uk"};
            var batchValue = await geoLocationClient.LookupAddressBatch(new List<string>(addresses));

            Console.ReadKey();
        }
    }
}