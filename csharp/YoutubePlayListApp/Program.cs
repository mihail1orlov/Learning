using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos.Streams;

{
    var youtube = new YoutubeClient();

    // ID відео з YouTube
    var videoId = "https://music.youtube.com/watch?v=cKE4wJMcAkc&si=YqNTTkWb5coydDne";
    var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);

    // Отримання найкращої аудіодоріжки
    var audioStreamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

    if (audioStreamInfo != null)
    {
        // Завантаження аудіо
        var httpClient = new HttpClient();
        var stream = await httpClient.GetStreamAsync(audioStreamInfo.Url);
        var filePath = Path.Combine($"D:\\media\\music\\", "audio.mp3");

        using (var fileStream = File.OpenWrite(filePath))
        {
            await stream.CopyToAsync(fileStream);
        }
    }
}

{
    var youtube = new YoutubeClient();
    var httpClient = new HttpClient();

    var playlistId = "https://music.youtube.com/playlist?list=PLsKGdpIhfdj7v_XCM3_DUCYZX5mnLn5hh&si=H_QzP9_ygn0efnw6";
    var playlist = await youtube.Playlists.GetAsync(playlistId);
    var videos = await youtube.Playlists.GetVideosAsync(playlistId);

    foreach (var video in videos)
    {
        Console.WriteLine($"Downloading: {video.Author} - {video.Title}.mp4");

        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
        var muxedStreamInfos = streamManifest.GetAudioStreams();
        //var muxedStreamInfos = streamManifest.GetMuxedStreams();
        var streamInfo = muxedStreamInfos.GetWithHighestBitrate();

        var dirPath = Path.Combine($"D:\\media\\music\\{playlist.Title}");
        var fileName = $"{video.Author} - {video.Title}.mp4";
        var idFileName = Path.Combine(dirPath, $"{video.Id}.mp4");

        if (streamInfo != null)
        {
            try
            {

                if (File.Exists(Path.Combine(dirPath, fileName)))
                {
                    continue;
                }

                await using var fileStream = File.OpenWrite(idFileName);
                {
                    await using var stream = await httpClient.GetStreamAsync(streamInfo.Url);
                    await stream.CopyToAsync(fileStream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                File.WriteAllText(Path.Combine($"D:\\media\\music\\{playlist.Title}", video.Id), video.Id);
            }
        }

        try
        {
            File.Move(idFileName, Path.Combine(dirPath, fileName));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}