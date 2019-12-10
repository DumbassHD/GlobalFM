using System;

namespace GlobalFM
{
    public interface IAudio
    {
        void PlayAudio(string url);
        void Stop();
        bool IsPlaying();
    }
}