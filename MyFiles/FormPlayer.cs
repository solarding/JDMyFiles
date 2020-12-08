using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace JD.MF
{
    public partial class FormPlayer : Form
    {
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;
        private string fileName;
        public FormPlayer(string SongFileName = null)
        {
            InitializeComponent();
            wavePlayer = CreateWavePlayer();
            EnableButtons(false);
            PopulateOutputDriverCombo();
            Disposed += SimplePlaybackPanel_Disposed;           
            
            if(SongFileName != null)
            {
                fileName = SongFileName;
                BeginPlayback(fileName);
            }
        }

        private static string FormatTimeSpan(TimeSpan ts)
        {
            return string.Format("{0:D2}:{1:D2}", (int)ts.TotalMinutes, ts.Seconds);
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                labelNowTime.Text = FormatTimeSpan(audioFileReader.CurrentTime) +  " : " + FormatTimeSpan(audioFileReader.TotalTime);
                labelSongName.Text = fileName;
                trackBar1.Value = (int)audioFileReader.CurrentTime.TotalSeconds;
            }
        }

        void SimplePlaybackPanel_Disposed(object sender, EventArgs e)
        {
            CleanUp();
        }

        private void PopulateOutputDriverCombo()
        {
            comboBoxOutputDriver.Items.Add("WaveOut Window Callbacks");
            comboBoxOutputDriver.Items.Add("WaveOut Function Callbacks");
            comboBoxOutputDriver.Items.Add("WaveOut Event Callbacks");
            comboBoxOutputDriver.SelectedIndex = 0;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (fileName == null) fileName = SelectInputFile();
            if (fileName != null)
            {
                BeginPlayback(fileName);
            }
        }

        private static string SelectInputFile()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Audio Files|*.mp3;*.wav;*.aiff;*.wma"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }

            return null;
        }

        private void BeginPlayback(string filename)
        {
            audioFileReader = new AudioFileReader(filename)
            {
                Volume = volumeSlider1.Volume,    
                CurrentTime = TimeSpan.FromSeconds(10)
            };
            
            if (wavePlayer == null) wavePlayer = CreateWavePlayer();
            wavePlayer.Init(audioFileReader);
            trackBar1.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            wavePlayer.PlaybackStopped += OnPlaybackStopped;
            wavePlayer.Play(); 
            EnableButtons(true);
            timer1.Enabled = true; // timer for updating current time label
        }

        private IWavePlayer CreateWavePlayer()
        {
            switch (comboBoxOutputDriver.SelectedIndex)
            {
                case 2:
                    return new WaveOutEvent();
                case 1:
                    return new WaveOut(WaveCallbackInfo.FunctionCallback());
                default:
                    return new WaveOut();
            }
        }

        private void EnableButtons(bool playing)
        {
            buttonPlay.Enabled = !playing;
            buttonStop.Enabled = playing;
            buttonOpen.Enabled = !playing;
        }

        void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            // we want it to be safe to clean up input stream and playback device in the handler for PlaybackStopped
            CleanUp();
            EnableButtons(false);
            timer1.Enabled = false;
            labelNowTime.Text = "00:00";
            if (e.Exception != null)
            {
                MessageBox.Show(String.Format("Playback Stopped due to an error {0}", e.Exception.Message));
            }
        }

        private void CleanUp()
        {
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            wavePlayer.Stop();
            // don't set button states now, we'll wait for our PlaybackStopped to come
        }

        private void OnVolumeSliderChanged(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Volume = volumeSlider1.Volume;
            }
        }

        private void OnButtonOpenClick(object sender, EventArgs e)
        {
            fileName = SelectInputFile() ?? fileName;
        }

       
        private void trackBar1_Scroll(object sender, EventArgs e)
        {           
            Application.DoEvents();
            timer1.Stop();
            wavePlayer.Stop();
            audioFileReader.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
            wavePlayer.Play();
            timer1.Start();
        }
    }
}