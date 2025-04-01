using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Services
{
    public class GameTimer
    {
        private Stopwatch _cronometro = new();
        private System.Windows.Forms.Timer _timer;
        private Label _labelTiempo;
        private bool _isPaused = false;

        public bool IsPaused => _isPaused;
        public TimeSpan ElapsedTime => _cronometro.Elapsed;

        public GameTimer(System.Windows.Forms.Timer timer, Label labelTiempo)
        {
            _timer = timer;
            _labelTiempo = labelTiempo;
        }

        public void Start()
        {
            _cronometro.Start();
            _timer.Start();
            _isPaused = false;
        }

        public void Stop()
        {
            _cronometro.Stop();
            _timer.Stop();
        }

        public void Pause()
        {
            if (!_isPaused)
            {
                _cronometro.Stop();
                _timer.Stop();
                _isPaused = true;
            }
        }

        public void Resume()
        {
            if (_isPaused)
            {
                _cronometro.Start();
                _timer.Start();
                _isPaused = false;
            }
        }

        public void Reset()
        {
            _cronometro.Reset();
            _cronometro.Start();
            _timer.Start();
            _isPaused = false;
        }

        public void ActualizarDisplay()
        {
            _labelTiempo.Text = $"Tiempo: {_cronometro.Elapsed:hh\\:mm\\:ss}";
        }
    }

}
