﻿using KoreanNewsDownloader.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KoreanNewsDownloader.Downloaders
{
    internal class BreaknewsDownloader : DownloaderBase
    {
        public BreaknewsDownloader(HttpClient httpClient)
        {
            HostUrls = new List<string>
            {
                "www.breaknews.com"
            };
            HttpClient = httpClient;
        }

        public override IEnumerable<string> GetArticleImages()
        {
            return Document.DocumentNode
                           .SelectSingleNode("//*[@id=\"img_pop_view\"]")
                           .GetAttributeValue("src", "").Yield();
        }

        public override Encoding GetEncoding()
        {
            return Encoding.GetEncoding("EUC-KR");
        }
    }
}
