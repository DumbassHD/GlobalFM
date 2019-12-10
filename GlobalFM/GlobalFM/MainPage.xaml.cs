using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GlobalFM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlobalFM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        IAudio audioService = DependencyService.Get<IAudio>();
        public MainPage()
        {
            InitializeComponent();
        }
        private int current_id = 0;
        private static bool isPlaying;
        public IList<string> Stations320 => new[]{
            "http://air.radiorecord.ru:805/rr_320",
            "http://air.radiorecord.ru:805/deep_320",
            "http://air.radiorecord.ru:805/trap_320",
            "http://air.radiorecord.ru:805/gold_320",
            "http://air.radiorecord.ru:805/ibiza_320",
            "http://air.radiorecord.ru:805/mf_320",
            "http://air.radiorecord.ru:805/elect_320",
            "http://air.radiorecord.ru:805/mt_320",
            "http://air.radiorecord.ru:805/edmhits_320",
            "http://air.radiorecord.ru:805/progr_320",
            "http://air.radiorecord.ru:805/househits_320",
            "http://air.radiorecord.ru:805/bighits_320",
            "http://air.radiorecord.ru:805/synth_320",
            "http://air.radiorecord.ru:805/dream_320",
            "http://air.radiorecord.ru:805/rock_320"
            };
        public IList<string> Image => new[]{
            "st_rr.png","st_deep.png","st_trap.png",
            "st_gold.png","st_ibiza.png","st_mf.png",
            "st_elect.png","st_mt.png","st_edmhits.png",
            "st_progr.png","st_househits.png","st_bighits.png",
            "st_synth.png","st_dream.png","st_rock.png"
            };

        public void PlayStation(int id)
        {
            current_id = id;
            audioService.PlayAudio(Stations320[id]);
            isPlaying = audioService.IsPlaying();
            play.Source = new FileImageSource { File = "pause.png" };
            ChangeImage(id);
        }
        public void ChangeImage(int id)
        {
            ImageCS.Source = Image[id];
        }
        private void Rr_Clicked(object sender, EventArgs e)
        {
            PlayStation(0);
            station.Text = "Radio Record";
        }
        private void Deep_Clicked(object sender, EventArgs e)
        {
            PlayStation(1);
            station.Text = "Deep";
        }
        private void Trap_Clicked(object sender, EventArgs e)
        {
            PlayStation(2);
            station.Text = "Trap";
        }
        private void Gold_Clicked(object sender, EventArgs e)
        {
            PlayStation(3);
            station.Text = "Gold";
        }
        private void Ibiza_Clicked(object sender, EventArgs e)
        {
            PlayStation(4);
            station.Text = "Innocence";
        }
        private void Mf_Clicked(object sender, EventArgs e)
        {
            PlayStation(5);
            station.Text = "Маятник Фуко";
        }
        private void Elect_Clicked(object sender, EventArgs e)
        {
            PlayStation(6);
            station.Text = "Electro";
        }
        private void Mt_Clicked(object sender, EventArgs e)
        {
            PlayStation(7);
            station.Text = "Midtempo";
        }
        private void Edmhits_Clicked(object sender, EventArgs e)
        {
            PlayStation(8);
            station.Text = "EDM Hits";
        }
        private void Progr_Clicked(object sender, EventArgs e)
        {
            PlayStation(9);
            station.Text = "Progressive";
        }
        private void Househits_Clicked(object sender, EventArgs e)
        {
            PlayStation(10);
            station.Text = "House Hits";
        }
        private void Bighits_Clicked(object sender, EventArgs e)
        {
            PlayStation(11);
            station.Text = "Big Hits";
        }
        private void Synthwave_Clicked(object sender, EventArgs e)
        {
            PlayStation(12);
            station.Text = "Synthwave";
        }
        private void Dream_Clicked(object sender, EventArgs e)
        {
            PlayStation(13);
            station.Text = "Dream Dance";
        }
        private void Rock_Clicked(object sender, EventArgs e)
        {
            PlayStation(14);
            station.Text = "Rock";
        }
        private void Play_Clicked(object sender, EventArgs e)
        {
            isPlaying = audioService.IsPlaying();
            if (isPlaying == true)
            {
                audioService.Stop();
                play.Source = new FileImageSource { File = "play.png" };
            }
            else if (isPlaying == false)
            {
                audioService.PlayAudio(Stations320[current_id]);
                play.Source = new FileImageSource { File = "pause.png" };
            }
        }
    }
}
