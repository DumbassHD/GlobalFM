using GlobalFM.Droid;
using System;
using Xamarin.Forms;

using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Extractor;
using Com.Google.Android.Exoplayer2.Metadata;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Trackselection;
using Com.Google.Android.Exoplayer2.Upstream;
using Com.Google.Android.Exoplayer2.Util;

[assembly: Dependency(typeof(AudioService))]
namespace GlobalFM.Droid
{
    public class AudioService : IAudio
    {
        public bool isPlaying = false;
        SimpleExoPlayer player;
        string current_url;
        public AudioService() { }
        public void PlayAudio(string url)
        {
            if (isPlaying)
            { Stop(); }
            current_url = url;
            var context = Android.App.Application.Context;
            var mediaUri = Android.Net.Uri.Parse(url);
            var userAgent = Util.GetUserAgent(context, "GlobalFM");
            var defaultHttpDataSourceFactory = new DefaultHttpDataSourceFactory(userAgent);
            var defaultDataSourceFactory = new DefaultDataSourceFactory(context, null, defaultHttpDataSourceFactory);
            var extractorMediaSource = new ExtractorMediaSource(mediaUri, defaultDataSourceFactory, new DefaultExtractorsFactory(), null, null);
            var defaultBandwidthMeter = new DefaultBandwidthMeter();
            var adaptiveTrackSelectionFactory = new AdaptiveTrackSelection.Factory(defaultBandwidthMeter);
            var defaultTrackSelector = new DefaultTrackSelector(adaptiveTrackSelectionFactory);

            player = ExoPlayerFactory.NewSimpleInstance(context, defaultTrackSelector);
            player.Prepare(extractorMediaSource);
            player.PlayWhenReady = true;
            isPlaying = true;
        }

        public bool IsPlaying()
        {
            return isPlaying;
        }
        public void Stop()
        {
            player.Stop();
            isPlaying = false;
        }
    }
}