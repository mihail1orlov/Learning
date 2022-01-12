// https://ru.stackoverflow.com/questions/1178026/%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0-%D1%81-cookie-%D0%B2-httpclient-%D0%B4%D0%BB%D1%8F-%D0%BF%D0%B0%D1%80%D1%81%D0%B8%D0%BD%D0%B3%D0%B0-%D1%81-%D0%B0%D0%B2%D1%82%D0%BE%D1%80%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D0%B5%D0%B9
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace DevAzureReaderApp
{
    public class Program
    {
        private const string filename = "cookies.bin";

        static async Task Main(string[] args)
        {
            await HttpManager.LoadCookiesAsync(filename);

            string html = await HttpManager.GetPageAsync("https://ru.stackoverflow.com/");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            if (doc.DocumentNode.QuerySelector(".top-bar ol").HasClass("user-logged-out"))
            {
                html = await HttpManager.GetPageAsync("https://ru.stackoverflow.com/users/login?ssrc=head&returnurl=https://ru.stackoverflow.com/");
                doc = new HtmlDocument();
                doc.LoadHtml(html);
                string fkey = doc.DocumentNode.QuerySelector("form#login-form input[name=fkey]").Attributes["value"].Value;
                string ssrc = doc.DocumentNode.QuerySelector("form#login-form input[name=ssrc]").Attributes["value"].Value;
                //Console.Write("Login: ");
                //string login = Console.ReadLine();
                string login = "kipish3wot@gmail.com";
                //Console.Write("Password: ");
                //string password = ReadPassword();
                string password = "Rasmus34383438";
                Dictionary<string, string> formData = new Dictionary<string, string>
                {
                    {"fkey", fkey},
                    {"ssrc", ssrc},
                    {"email", login},
                    {"password", password},
                    {"oauth_version", ""},
                    {"oauth_server", ""}
                };
                html = await HttpManager.PostFormAsync("https://ru.stackoverflow.com/users/login?ssrc=head&returnurl=https%3a%2f%2fru.stackoverflow.com%2f", formData);
                doc = new HtmlDocument();
                doc.LoadHtml(html);
            }

            string user = doc.DocumentNode.QuerySelector(".top-bar ol .my-profile span.v-visible-sr").InnerText;
            Console.WriteLine(user);
            string rep = HtmlEntity.DeEntitize(doc.DocumentNode.QuerySelector(".top-bar ol .my-profile div.-rep").Attributes["title"].Value);
            Console.WriteLine(rep);
            string badges = string.Join(Environment.NewLine, doc.DocumentNode.QuerySelectorAll(".top-bar ol .my-profile div.-badges span.v-visible-sr").Select(x => x.InnerText));
            Console.WriteLine(badges);

            await HttpManager.SaveCookiesAsync(filename);
            Console.ReadKey();
        }

        private static string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }
    }

    public static class HttpManager
    {
        private static readonly HttpClientHandler handler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli,
            AllowAutoRedirect = true
        };

        private static readonly HttpClient client = new HttpClient(handler)
        {
            DefaultRequestVersion = new Version(2, 0)
        };

        static HttpManager()
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:80.0) Gecko/20100101 Firefox/80.0");
            client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br");
        }

        // GET
        public static async Task<string> GetPageAsync(string url)
        {
            using HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            return await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }

        // POST
        public static async Task<string> PostFormAsync(string url, Dictionary<string, string> data)
        {
            using HttpContent content = new FormUrlEncodedContent(data);
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url) { Content = content };
            using HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }

        // Загрузить и расшифровать Cookie из файла
        public static async Task LoadCookiesAsync(string filename)
        {
            if (File.Exists(filename))
            {
                using FileStream fs = File.OpenRead(filename);
                byte[] IV = new byte[16];
                fs.Read(IV);
                byte[] protectedKey = new byte[178];
                fs.Read(protectedKey);
                using AesManaged aes = new AesManaged
                {
                    Key = ProtectedData.Unprotect(protectedKey, IV, DataProtectionScope.CurrentUser),
                    IV = IV
                };
                using CryptoStream cs = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read, true);
                CookieCollection cookies = await JsonSerializer.DeserializeAsync<CookieCollection>(cs);
                foreach (Cookie cookie in cookies)
                {
                    // не загружать, если кука заэкспайрилась
                    if (!cookie.Expired && (cookie.Expires == DateTime.MinValue || cookie.Expires > DateTime.Now))
                        handler.CookieContainer.Add(cookie);
                }
            }
        }

        // Зашифровать и сохранить Cookie в файл
        public static async Task SaveCookiesAsync(string filename)
        {
            using AesManaged aes = new AesManaged();
            using FileStream fs = File.Create(filename);
            fs.Write(aes.IV);
            fs.Write(ProtectedData.Protect(aes.Key, aes.IV, DataProtectionScope.CurrentUser));
            using CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write, true);
            await JsonSerializer.SerializeAsync(cs, handler.CookieContainer.GetAllCookies());
        }
    }

    public static class CookieContainerExtensions
    {
        // Забирает все куки из контейнера
        public static CookieCollection GetAllCookies(this CookieContainer container)
        {
            CookieCollection allCookies = new CookieCollection();
            IDictionary domains = (IDictionary)container.GetType()
                .GetRuntimeFields()
                .FirstOrDefault(x => x.Name == "m_domainTable")
                .GetValue(container);

            foreach (object field in domains.Values)
            {
                IDictionary values = (IDictionary)field.GetType()
                    .GetRuntimeFields()
                    .FirstOrDefault(x => x.Name == "m_list")
                    .GetValue(field);

                foreach (CookieCollection cookies in values.Values)
                {
                    allCookies.Add(cookies);
                }
            }
            return allCookies;
        }
    }
}