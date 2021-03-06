﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace KoreanNewsDownloader.Downloaders
{
    internal class EdailyDownloader : DownloaderBase
    {
        public EdailyDownloader(HttpClient httpClient, ProxyHttpClient proxyHttpClient) : base(httpClient, proxyHttpClient) 
        {
            HostUrls = new List<string>
            {
                "www.edaily.co.kr", "starin.edaily.co.kr"
            };
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                .SelectSingleNode("//*[@class=\"news_body\"]")
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", ""));
        }
    }
}
