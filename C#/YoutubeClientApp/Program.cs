using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

var youtube = new YoutubeClient();

//https://youtu.be/jxiwsaU3SJE?si=lqHdaoAnimhMGB_P
var videoId = "jxiwsaU3SJE";
var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

var httpClient = new HttpClient();
var stream = await httpClient.GetStreamAsync(streamInfo.Url);
var filePath = Path.Combine("D:/tmp/", "video22.mp4");

await using var fileStream = File.OpenWrite(filePath);
await stream.CopyToAsync(fileStream);