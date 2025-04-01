using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Services
{
    public class GameStats
    {
        private int _errores = 0;
        private int _partidasGanadas = 0;
        private int _partidasPerdidas = 0;

        private Label _lblErrores;
        private Label _lblPartidasGanadas;
        private Label _lblPartidasPerdidas;

        public int Errores => _errores;
        public int PartidasGanadas => _partidasGanadas;
        public int PartidasPerdidas => _partidasPerdidas;

        public GameStats(Label lblErrores, Label lblPartidasGanadas, Label lblPartidasPerdidas)
        {
            _lblErrores = lblErrores;
            _lblPartidasGanadas = lblPartidasGanadas;
            _lblPartidasPerdidas = lblPartidasPerdidas;
            ActualizarDisplay();
        }

        public void IncrementarErrores()
        {
            _errores++;
            ActualizarDisplay();
        }

        public void RegistrarVictoria()
        {
            _partidasGanadas++;
            ActualizarDisplay();
        }

        public void RegistrarDerrota()
        {
            _partidasPerdidas++;
            ActualizarDisplay();
        }

        public void Reiniciar()
        {
            _errores = 0;
            ActualizarDisplay();
        }

        private void ActualizarDisplay()
        {
            _lblErrores.Text = $"Total de errores: {_errores}";
            _lblPartidasGanadas.Text = $"Partidas Ganadas: {_partidasGanadas}";
            _lblPartidasPerdidas.Text = $"Partidas Perdidas: {_partidasPerdidas}";
        }
    }

}
