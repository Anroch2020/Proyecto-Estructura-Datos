using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Proyecto.Services
{
    /// <summary>
    /// Gestiona las estadísticas del juego: errores, partidas ganadas y perdidas
    /// </summary>
    public class GameStats
    {
        #region Campos privados

        /// <summary>
        /// Contador de errores cometidos en la partida actual
        /// </summary>
        private int _errores = 0;

        /// <summary>
        /// Contador de partidas ganadas en la sesión actual
        /// </summary>
        private int _partidasGanadas = 0;

        /// <summary>
        /// Contador de partidas perdidas en la sesión actual
        /// </summary>
        private int _partidasPerdidas = 0;

        /// <summary>
        /// Etiqueta para mostrar el contador de errores
        /// </summary>
        private readonly Label _lblErrores;

        /// <summary>
        /// Etiqueta para mostrar el contador de partidas ganadas
        /// </summary>
        private readonly Label _lblPartidasGanadas;

        /// <summary>
        /// Etiqueta para mostrar el contador de partidas perdidas
        /// </summary>
        private readonly Label _lblPartidasPerdidas;

        /// <summary>
        /// Prefijos para los textos de las etiquetas
        /// </summary>
        private const string PrefixErrores = "Total de errores: ";
        private const string PrefixGanadas = "Partidas Ganadas: ";
        private const string PrefixPerdidas = "Partidas Perdidas: ";

        #endregion

        #region Propiedades públicas

        /// <summary>
        /// Obtiene el número actual de errores
        /// </summary>
        public int Errores => _errores;

        /// <summary>
        /// Obtiene el número actual de partidas ganadas
        /// </summary>
        public int PartidasGanadas => _partidasGanadas;

        /// <summary>
        /// Obtiene el número actual de partidas perdidas
        /// </summary>
        public int PartidasPerdidas => _partidasPerdidas;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de estadísticas de juego
        /// </summary>
        /// <param name="lblErrores">Etiqueta para mostrar los errores</param>
        /// <param name="lblPartidasGanadas">Etiqueta para mostrar partidas ganadas</param>
        /// <param name="lblPartidasPerdidas">Etiqueta para mostrar partidas perdidas</param>
        public GameStats(Label lblErrores, Label lblPartidasGanadas, Label lblPartidasPerdidas)
        {
            _lblErrores = lblErrores ?? throw new ArgumentNullException(nameof(lblErrores));
            _lblPartidasGanadas = lblPartidasGanadas ?? throw new ArgumentNullException(nameof(lblPartidasGanadas));
            _lblPartidasPerdidas = lblPartidasPerdidas ?? throw new ArgumentNullException(nameof(lblPartidasPerdidas));

            ActualizarDisplay();
        }

        #endregion

        #region Métodos públicos

        /// <summary>
        /// Incrementa el contador de errores y actualiza la interfaz
        /// </summary>
        public void IncrementarErrores()
        {
            _errores++;
            ActualizarErrores();
        }

        /// <summary>
        /// Registra una victoria, incrementando el contador y actualizando la interfaz
        /// </summary>
        public void RegistrarVictoria()
        {
            _partidasGanadas++;
            ActualizarPartidasGanadas();
        }

        /// <summary>
        /// Registra una derrota, incrementando el contador y actualizando la interfaz
        /// </summary>
        public void RegistrarDerrota()
        {
            _partidasPerdidas++;
            ActualizarPartidasPerdidas();
        }

        /// <summary>
        /// Reinicia el contador de errores para una nueva partida
        /// </summary>
        public void Reiniciar()
        {
            _errores = 0;
            ActualizarErrores();
        }

        /// <summary>
        /// Reinicia completamente todas las estadísticas
        /// </summary>
        public void ReiniciarCompleto()
        {
            _errores = 0;
            _partidasGanadas = 0;
            _partidasPerdidas = 0;
            ActualizarDisplay();
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Actualiza todas las etiquetas con los valores actuales
        /// </summary>
        private void ActualizarDisplay()
        {
            try
            {
                ActualizarErrores();
                ActualizarPartidasGanadas();
                ActualizarPartidasPerdidas();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar display de estadísticas: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza solo la etiqueta de errores
        /// </summary>
        private void ActualizarErrores()
        {
            if (_lblErrores?.IsDisposed == false)
            {
                _lblErrores.Text = PrefixErrores + _errores;
            }
        }

        /// <summary>
        /// Actualiza solo la etiqueta de partidas ganadas
        /// </summary>
        private void ActualizarPartidasGanadas()
        {
            if (_lblPartidasGanadas?.IsDisposed == false)
            {
                _lblPartidasGanadas.Text = PrefixGanadas + _partidasGanadas;
            }
        }

        /// <summary>
        /// Actualiza solo la etiqueta de partidas perdidas
        /// </summary>
        private void ActualizarPartidasPerdidas()
        {
            if (_lblPartidasPerdidas?.IsDisposed == false)
            {
                _lblPartidasPerdidas.Text = PrefixPerdidas + _partidasPerdidas;
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