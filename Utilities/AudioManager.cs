using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace Proyecto.Utilities
{
    public class AudioManager : IDisposable
    {
        private SoundPlayer? _musicPlayer;
        private bool _isPlaying = false;
        private Stream? _audioStream; // Mantener referencia al stream

        public bool IsPlaying => _isPlaying;

        public AudioManager(string audioFileName)
        {
            LoadAudio(audioFileName);
        }

        private void LoadAudio(string audioFileName)
        {
            try
            {
                // Primero, detener y liberar cualquier reproductor de música existente
                Stop();
                _musicPlayer?.Dispose();
                _musicPlayer = null;

                // Cerrar stream existente si lo hay
                _audioStream?.Dispose();
                _audioStream = null;

                var assembly = Assembly.GetExecutingAssembly();
                Debug.WriteLine("Recursos disponibles:");
                foreach (var resourceName in assembly.GetManifestResourceNames())
                {
                    Debug.WriteLine($" - {resourceName}");
                }

                // Intentar cargar desde un recurso incrustado
                string resourcePath = $"Proyecto.Resources.{audioFileName}";
                _audioStream = assembly.GetManifestResourceStream(resourcePath);
                if (_audioStream != null)
                {
                    Debug.WriteLine($"Cargando música desde recurso incrustado: {resourcePath}");
                    _musicPlayer = new SoundPlayer(_audioStream);
                    return;
                }

                string? audioFilePath = null;
                Debug.WriteLine($"Ruta base: {Application.StartupPath}");

                string[] possiblePaths = new string[]
                {
                    Path.Combine(Application.StartupPath, "Resources", audioFileName),
                    Path.Combine(Application.StartupPath, audioFileName),
                    Path.Combine(Application.StartupPath, "..", "..", "Resources", audioFileName),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", audioFileName)
                };

                foreach (var path in possiblePaths)
                {
                    Debug.WriteLine($"Intentando: {path} - Existe: {File.Exists(path)}");
                    if (File.Exists(path))
                    {
                        audioFilePath = path;
                        Debug.WriteLine($"Encontrado archivo en: {path}");
                        break;
                    }
                }

                if (audioFilePath == null)
                {
                    string customPath = Path.Combine(Application.StartupPath, audioFileName);
                    if (!File.Exists(customPath))
                    {
                        using (Stream? tempStream = assembly.GetManifestResourceStream(resourcePath))
                        {
                            if (tempStream != null)
                            {
                                using (FileStream fileStream = File.Create(customPath))
                                {
                                    tempStream.CopyTo(fileStream);
                                }
                                audioFilePath = customPath;
                                Debug.WriteLine($"Archivo extraído a: {customPath}");
                            }
                        }
                    }
                    else
                    {
                        audioFilePath = customPath;
                        Debug.WriteLine($"Usando archivo existente en: {customPath}");
                    }
                }

                if (audioFilePath == null)
                {
                    Debug.WriteLine($"No se pudo encontrar el archivo de audio: {audioFileName}");
                    throw new FileNotFoundException($"No se pudo encontrar el archivo de audio: {audioFileName}");
                }

                Debug.WriteLine($"Inicializando reproductor con: {audioFilePath}");
                // Para archivos, no necesitamos retener el stream
                _musicPlayer = new SoundPlayer(audioFilePath);
                Debug.WriteLine("Reproductor de música inicializado correctamente");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar el audio: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        public void Play()
        {
            _musicPlayer?.Play();
            _isPlaying = true;
        }

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
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                _isPlaying = false;
            }
        }

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
            _isPlaying = false;
        }

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

        public void Dispose()
        {
            try
            {
                Stop();
                _musicPlayer?.Dispose();
                _musicPlayer = null;

                if (_audioStream != null)
                {
                    _audioStream.Dispose();
                    _audioStream = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al liberar recursos de audio: {ex.Message}");
            }
        }
    }
}
