using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace Proyecto.Utilities
{
    /// <summary>
    /// Gestiona la reproducción de archivos de audio en la aplicación
    /// </summary>
    public class AudioManager : IDisposable
    {
        #region Campos privados

        /// <summary>
        /// Reproductor de sonido utilizado para la música
        /// </summary>
        private SoundPlayer? _musicPlayer;

        /// <summary>
        /// Indica si actualmente se está reproduciendo audio
        /// </summary>
        private bool _isPlaying = false;

        /// <summary>
        /// Stream del archivo de audio (debe mantenerse en memoria para reproducción continua)
        /// </summary>
        private Stream? _audioStream;

        /// <summary>
        /// Prefijo para la ruta de recursos incrustados
        /// </summary>
        private const string ResourcePrefix = "Proyecto.Resources.";

        /// <summary>
        /// Carpeta de recursos
        /// </summary>
        private const string ResourceFolder = "Resources";

        #endregion

        #region Propiedades públicas

        /// <summary>
        /// Indica si se está reproduciendo audio actualmente
        /// </summary>
        public bool IsPlaying => _isPlaying;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia del administrador de audio
        /// </summary>
        /// <param name="audioFileName">Nombre del archivo de audio a cargar</param>
        /// <exception cref="FileNotFoundException">Se lanza cuando no se encuentra el archivo de audio</exception>
        public AudioManager(string audioFileName)
        {
            if (string.IsNullOrEmpty(audioFileName))
                throw new ArgumentNullException(nameof(audioFileName));

            LoadAudio(audioFileName);
        }

        #endregion

        #region Métodos de carga de audio

        /// <summary>
        /// Carga un archivo de audio desde recursos incrustados o desde el sistema de archivos
        /// </summary>
        /// <param name="audioFileName">Nombre del archivo de audio</param>
        private void LoadAudio(string audioFileName)
        {
            try
            {
                // Primero liberamos cualquier recurso existente
                LiberarRecursos();

                // Intentar cargar desde recursos incrustados, luego desde archivos
                if (!CargarDesdeRecursosIncrustados(audioFileName) && !CargarDesdeArchivos(audioFileName))
                {
                    // Si no se encontró, intentar extraer recurso incrustado al sistema de archivos
                    string customPath = Path.Combine(Application.StartupPath, audioFileName);
                    if (!ExtraerRecurso(audioFileName, customPath) && !File.Exists(customPath))
                    {
                        throw new FileNotFoundException($"No se pudo encontrar el archivo de audio: {audioFileName}");
                    }
                    else if (File.Exists(customPath))
                    {
                        _musicPlayer = new SoundPlayer(customPath);
                        Debug.WriteLine($"Usando archivo existente en: {customPath}");
                    }
                }

                Debug.WriteLine("Reproductor de música inicializado correctamente");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar el audio: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Intenta cargar el audio desde los recursos incrustados en el ensamblado
        /// </summary>
        /// <param name="audioFileName">Nombre del archivo de audio</param>
        /// <returns>True si se cargó correctamente, false en caso contrario</returns>
        private bool CargarDesdeRecursosIncrustados(string audioFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Listar recursos disponibles en modo debug
            if (Debugger.IsAttached)
            {
                ListarRecursosDisponibles(assembly);
            }

            string resourcePath = $"{ResourcePrefix}{audioFileName}";
            _audioStream = assembly.GetManifestResourceStream(resourcePath);

            if (_audioStream != null)
            {
                Debug.WriteLine($"Cargando música desde recurso incrustado: {resourcePath}");
                _musicPlayer = new SoundPlayer(_audioStream);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Lista todos los recursos disponibles en el ensamblado (solo en modo debug)
        /// </summary>
        /// <param name="assembly">El ensamblado a analizar</param>
        private void ListarRecursosDisponibles(Assembly assembly)
        {
            Debug.WriteLine("Recursos disponibles:");
            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                Debug.WriteLine($" - {resourceName}");
            }
        }

        /// <summary>
        /// Intenta cargar el audio desde el sistema de archivos buscando en diferentes ubicaciones
        /// </summary>
        /// <param name="audioFileName">Nombre del archivo de audio</param>
        /// <returns>True si se cargó correctamente, false en caso contrario</returns>
        private bool CargarDesdeArchivos(string audioFileName)
        {
            Debug.WriteLine($"Ruta base: {Application.StartupPath}");

            // Rutas posibles donde podría estar el archivo
            string[] possiblePaths = {
                Path.Combine(Application.StartupPath, ResourceFolder, audioFileName),
                Path.Combine(Application.StartupPath, audioFileName),
                Path.Combine(Application.StartupPath, "..", "..", ResourceFolder, audioFileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ResourceFolder, audioFileName)
            };

            foreach (var path in possiblePaths)
            {
                if (Debugger.IsAttached)
                {
                    Debug.WriteLine($"Intentando: {path} - Existe: {File.Exists(path)}");
                }

                if (File.Exists(path))
                {
                    Debug.WriteLine($"Encontrado archivo en: {path}");
                    _musicPlayer = new SoundPlayer(path);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Intenta extraer un recurso incrustado al sistema de archivos
        /// </summary>
        /// <param name="audioFileName">Nombre del archivo de audio</param>
        /// <param name="targetPath">Ruta donde extraer el archivo</param>
        /// <returns>True si se extrajo correctamente, false en caso contrario</returns>
        private bool ExtraerRecurso(string audioFileName, string targetPath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = $"{ResourcePrefix}{audioFileName}";

            using (Stream? tempStream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (tempStream == null)
                    return false;

                try
                {
                    using (FileStream fileStream = File.Create(targetPath))
                    {
                        tempStream.CopyTo(fileStream);
                    }

                    Debug.WriteLine($"Archivo extraído a: {targetPath}");
                    _musicPlayer = new SoundPlayer(targetPath);
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error al extraer recurso: {ex.Message}");
                    return false;
                }
            }
        }

        #endregion

        #region Métodos de control de reproducción

        /// <summary>
        /// Reproduce el audio una sola vez
        /// </summary>
        public void Play()
        {
            try
            {
                _musicPlayer?.Play();
                _isPlaying = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al reproducir audio: {ex.Message}");
                _isPlaying = false;
            }
        }

        /// <summary>
        /// Reproduce el audio en bucle continuo
        /// </summary>
        public void PlayLooping()
        {
            try
            {
                _musicPlayer?.PlayLooping();
                _isPlaying = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al reproducir audio en bucle: {ex.Message}");
                _isPlaying = false;
            }
        }

        /// <summary>
        /// Detiene la reproducción de audio
        /// </summary>
        public void Stop()
        {
            try
            {
                _musicPlayer?.Stop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al detener audio: {ex.Message}");
            }
            finally
            {
                _isPlaying = false;
            }
        }

        /// <summary>
        /// Alterna entre reproducir y detener el audio
        /// </summary>
        public void Toggle()
        {
            if (_isPlaying)
            {
                Stop();
            }
            else
            {
                PlayLooping();
            }
        }

        #endregion

        #region Gestión de recursos

        /// <summary>
        /// Libera los recursos utilizados por el administrador de audio
        /// </summary>
        private void LiberarRecursos()
        {
            // Detener reproducción
            Stop();

            // Liberar reproductor
            if (_musicPlayer != null)
            {
                _musicPlayer.Dispose();
                _musicPlayer = null;
            }

            // Liberar stream
            if (_audioStream != null)
            {
                _audioStream.Dispose();
                _audioStream = null;
            }
        }

        /// <summary>
        /// Implementación de IDisposable para liberar recursos
        /// </summary>
        public void Dispose()
        {
            try
            {
                LiberarRecursos();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al liberar recursos de audio: {ex.Message}");
            }

            GC.SuppressFinalize(this);
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