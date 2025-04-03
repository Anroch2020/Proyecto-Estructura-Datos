using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Proyecto.Services
{
    /// <summary>
    /// Proporciona funcionalidad de temporizador de juego con soporte para pausar, reanudar y reiniciar
    /// </summary>
    public class GameTimer
    {
        #region Campos privados

        /// <summary>
        /// Cronómetro que mide el tiempo transcurrido
        /// </summary>
        private readonly Stopwatch _cronometro = new();

        /// <summary>
        /// Timer de Windows Forms que actualiza la UI
        /// </summary>
        private readonly System.Windows.Forms.Timer _timer;

        /// <summary>
        /// Etiqueta donde se muestra el tiempo
        /// </summary>
        private readonly Label _labelTiempo;

        /// <summary>
        /// Indica si el temporizador está en pausa
        /// </summary>
        private bool _isPaused = false;

        /// <summary>
        /// Formato estándar para mostrar el tiempo
        /// </summary>
        private const string FormatoTiempo = "hh\\:mm\\:ss";

        #endregion

        #region Propiedades públicas

        /// <summary>
        /// Obtiene si el temporizador está actualmente en pausa
        /// </summary>
        public bool IsPaused => _isPaused;

        /// <summary>
        /// Obtiene el tiempo transcurrido
        /// </summary>
        public TimeSpan ElapsedTime => _cronometro.Elapsed;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de un temporizador de juego
        /// </summary>
        /// <param name="timer">Timer de Windows Forms a utilizar</param>
        /// <param name="labelTiempo">Etiqueta donde mostrar el tiempo</param>
        public GameTimer(System.Windows.Forms.Timer timer, Label labelTiempo)
        {
            _timer = timer ?? throw new ArgumentNullException(nameof(timer));
            _labelTiempo = labelTiempo ?? throw new ArgumentNullException(nameof(labelTiempo));

            // Actualizar display inicial
            ActualizarDisplay();
        }

        #endregion

        #region Métodos de control de tiempo

        /// <summary>
        /// Inicia el temporizador
        /// </summary>
        public void Start()
        {
            if (!_cronometro.IsRunning)
            {
                _cronometro.Start();
                _timer.Start();
                _isPaused = false;
            }
        }

        /// <summary>
        /// Detiene el temporizador
        /// </summary>
        public void Stop()
        {
            if (_cronometro.IsRunning)
            {
                _cronometro.Stop();
                _timer.Stop();
            }
        }

        /// <summary>
        /// Pausa el temporizador si no está ya pausado
        /// </summary>
        public void Pause()
        {
            if (!_isPaused && _cronometro.IsRunning)
            {
                _cronometro.Stop();
                _timer.Stop();
                _isPaused = true;

                // Actualizamos una última vez al pausar
                ActualizarDisplay();
            }
        }

        /// <summary>
        /// Reanuda el temporizador si está pausado
        /// </summary>
        public void Resume()
        {
            if (_isPaused)
            {
                _cronometro.Start();
                _timer.Start();
                _isPaused = false;
            }
        }

        /// <summary>
        /// Reinicia el temporizador a cero y lo inicia
        /// </summary>
        public void Reset()
        {
            _cronometro.Reset();
            _cronometro.Start();
            _timer.Start();
            _isPaused = false;

            // Actualizamos inmediatamente tras reiniciar
            ActualizarDisplay();
        }

        #endregion

        #region Métodos de visualización

        /// <summary>
        /// Actualiza la etiqueta de tiempo con el formato adecuado
        /// </summary>
        public void ActualizarDisplay()
        {
            if (_labelTiempo.IsDisposed)
                return;

            try
            {
                // Utilizamos un formato constante precompilado para mejor rendimiento
                _labelTiempo.Text = $"Tiempo: {_cronometro.Elapsed.ToString(FormatoTiempo)}";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar display de tiempo: {ex.Message}");
            }
        }

        #endregion
    }
}
/* Copyright (C) 2025 
 
             - Esmeralda Janeth Hernández Alfaro
             - Rosa Hayde Durón Brito
             - Ángel Roberto Chinchilla Erazo
             - Kennet Hernández Valle
             - Selvin Omar Castañeda
             - Ricardo Jose Pinto Mejia

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.*/