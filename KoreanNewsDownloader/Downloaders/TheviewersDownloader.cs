﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader.Downloaders
{
    internal class TheviewersDownloader : DownloaderBase
    {
        public TheviewersDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "theviewers.co.kr", "www.theviewers.co.kr", "viewers.heraldcorp.com"
            };
            HttpClient = httpClient;
        }

        public override async Task<IList<string>> GetImageUrlsAsync(Uri uri)
        {
            HtmlDocument doc = await GetDocumentAsync(uri);
            var images = doc.DocumentNode
                    .SelectNodes("//figure/img")
                    .Select(x => x.GetAttributeValue("src", "").StartsWith("/news/") ? $"http://cds.theviewers.co.kr{x.GetAttributeValue("src", "")}" : x.GetAttributeValue("src", ""))
                    .ToList();

            Console.WriteLine(uri.AbsoluteUri);
            Console.WriteLine("Found: " +images.Count());


            return images;
        }
    }
}
