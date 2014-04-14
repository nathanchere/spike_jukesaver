﻿using System;
using System.Windows.Forms;
using NAudio.Dsp;
using NAudio.Wave;

namespace NAudio.SpectrumAnalyser
{
    public partial class frmMain : Form
    {
        private const string MP3_PATH = @"doowackadoo.mp3";
        const int FFT_SIZE = 2048;

        readonly IWavePlayer device;
        readonly AudioFileReader audio;

        float max;
        float min;
        Complex[] fft;

        public frmMain()
        {
            InitializeComponent();

            device = new DirectSoundOut();
            audio = new AudioFileReader("doowackadoo.mp3");
            ;
            device.Init(GetAggregator(audio));

            numSpectrumDetail_ValueChanged(null, null);

            var timer = new Timer();
            timer.Interval = 1000 / 30; // second number = desired FPS
            timer.Tick += (sender, args) => Render();
            timer.Start();
        }

        private SampleAggregator GetAggregator(AudioFileReader audio)
        {
            var result = new SampleAggregator(audio, FFT_SIZE) {
                NotificationCount = (int)(audio.WaveFormat.SampleRate * 0.01),
                PerformFFT = true,
            };

            result.FftCalculated += (sender, args) => fft = args.Result;
            result.MaximumCalculated += (sender, args) => {
                max = args.MaxSample;
                min = args.MinSample;
            };

            return result;
        }        

        private void Render()
        {
            //int spectrumSize = (int)Math.Pow(2,(double) numSpectrumDetail.Value);
            //int waveSize = (int)numWaveDetail.Value;

            //var spectrum = new float[spectrumSize];
            //var wavedata = new float[waveSize];

            //var result = new VisData();
            //fmod.GetWaveData(wavedata, waveSize, 0);
            //fmod.GetSpectrum(spectrum, spectrumSize, 0, FFTWindow.Max);
            //result.WaveData = wavedata.ToList();
            //result.SpectrumData = spectrum.ToList();

            //picVisualisation.UpdateData(result);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            device.Play();
        }

        private void btnPause(object sender, EventArgs e)
        {
            device.Pause();
        }

        ~frmMain()
        {
            // TODO: Dispose
        }

        private void numSpectrumDetail_ValueChanged(object sender, EventArgs e)
        {
            lblSpectrum.Text = string.Format("({0})", Math.Pow(2, (double)numSpectrumDetail.Value));
        }
    }
}
