﻿using KoreanNewsDownloader.Downloaders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KoreanNewsDownloader
{
    public class KDownloader
    {
        private readonly IServiceProvider _services;
        private readonly IDownloaderResolver _resolver;

        public KDownloader()
        {
            _services = ConfigureServices();
            _resolver = _services.GetRequiredService<IDownloaderResolver>();
        }

        public async Task DownloadArticleImagesAsync(Uri uri, string filePath, bool overwrite = false)
        {
            var downloader = GetDownloader(uri.Host);
            await downloader.DownloadArticleImagesAsync(uri, filePath, overwrite);
        }

        private IDownloader GetDownloader(string host)
        {
            return _resolver.GetDownloaderByName(host);
        }

        private ServiceProvider ConfigureServices()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36");

            return new ServiceCollection()
                // HttpClient
                .AddSingleton(httpClient)
                // RepositoryResolver
                .AddSingleton<IDownloaderResolver, DownloaderResolver>()
                // NewsDownloaders
                .AddTransient<IDownloader, AjunewsDownloader>()
                .AddTransient<IDownloader, AsiatodayDownloader>()
                .AddTransient<IDownloader, HeraldcorpDownloader>()
                .AddTransient<IDownloader, HankyungDownloader>()
                .AddTransient<IDownloader, BreaknewsDownloader>()
                .AddTransient<IDownloader, GetnewsDownloader>()
                .AddTransient<IDownloader, ThebigdataDownloader>()
                .AddTransient<IDownloader, DailianDownloader>()
                .AddTransient<IDownloader, DailypopDownloader>()
                .AddTransient<IDownloader, DispatchDownloader>()
                .AddTransient<IDownloader, DtDownloader>()
                .AddTransient<IDownloader, EdailyDownloader>()
                .AddTransient<IDownloader, EgnDownloader>()
                .AddTransient<IDownloader, ImbcDownloader>()
                .AddTransient<IDownloader, TvingDownloader>()
                .AddTransient<IDownloader, EtodayDownloader>()
                .AddTransient<IDownloader, FnnewsDownloader>()
                .AddTransient<IDownloader, DcinsideDownloader>()
                .AddTransient<IDownloader, GetitkDownloader>()
                .AddTransient<IDownloader, IlyoseoulDownloader>()
                .AddTransient<IDownloader, Inews24Downloader>()
                .AddTransient<IDownloader, InsightDownloader>()
                .AddTransient<IDownloader, IntronewsDownloader>()
                .AddTransient<IDownloader, JoinsDownloader>()
                .AddTransient<IDownloader, IssuedailyDownloader>()
                .AddTransient<IDownloader, Joynews24Downloader>()
                .AddTransient<IDownloader, KookjeDownloader>()
                .AddTransient<IDownloader, KukinewsDownloader>()
                .AddTransient<IDownloader, LiveenDownloader>()
                .AddTransient<IDownloader, NaverDownloader>()
                .AddTransient<IDownloader, ChosunDownloader>()
                .AddTransient<IDownloader, MdprDownloader>()
                .AddTransient<IDownloader, MediasrDownloader>()
                .AddTransient<IDownloader, MetroseoulDownloader>()
                .AddTransient<IDownloader, MtDownloader>()
                .AddTransient<IDownloader, MydailyDownloader>()
                .AddTransient<IDownloader, NbnnewsDownloader>()
                .AddTransient<IDownloader, AsiaeDownloader>()
                .AddTransient<IDownloader, NewdailyDownloader>()
                .AddTransient<IDownloader, NewsreportDownloader>()
                .AddTransient<IDownloader, ImaeilDownloader>()
                .AddTransient<IDownloader, KstyleDownloader>()
                .AddTransient<IDownloader, TfDownloader>()
                .AddTransient<IDownloader, News1Downloader>()
                .AddTransient<IDownloader, NewsinsideDownloader>()
                .AddTransient<IDownloader, NewspimDownloader>()
                .AddTransient<IDownloader, NewsshareDownloader>()
                .AddTransient<IDownloader, NewstomatoDownloader>()
                .AddTransient<IDownloader, NewsenDownloader>()
                .AddTransient<IDownloader, NocutnewsDownloader>()
                .AddTransient<IDownloader, OhmynewsDownloader>()
                .AddTransient<IDownloader, OriconDownloader>()
                .AddTransient<IDownloader, OsenDownloader>()
                .AddTransient<IDownloader, PolinewsDownloader>()
                .AddTransient<IDownloader, SedailyDownloader>()
                .AddTransient<IDownloader, SegyeDownloader>()
                .AddTransient<IDownloader, SeoulDownloader>()
                .AddTransient<IDownloader, SisajournalDownloader>()
                .AddTransient<IDownloader, SporbizDownloader>()
                .AddTransient<IDownloader, DongaDownloader>()
                .AddTransient<IDownloader, HankookiDownloader>()
                .AddTransient<IDownloader, KhanDownloader>()
                .AddTransient<IDownloader, MkDownloader>()
                .AddTransient<IDownloader, SportsqDownloader>()
                .AddTransient<IDownloader, SportsseoulDownloader>()
                .AddTransient<IDownloader, SpotvnewsDownloader>()
                .AddTransient<IDownloader, HankookilboDownloader>()
                .AddTransient<IDownloader, StardailynewsDownloader>()
                .AddTransient<IDownloader, TheceluvDownloader>()
                .AddTransient<IDownloader, TheviewersDownloader>()
                .BuildServiceProvider();
        }
    }
}
