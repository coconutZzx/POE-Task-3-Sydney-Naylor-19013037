using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1_Sydney_Naylor_19013037
{
    public partial class frmGame : Form
    {
        GameEngine engine;
        Timer timer;
        GameState gameState = GameState.PAUSED;
        int count = 0;
        public frmGame()
        {
            InitializeComponent();
            engine = new GameEngine();
            UpdateUI();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += TimerTick;
        }
        private void UpdateUI()
        {
            lblArea.Text = engine.GetMapDisplay();
            rTxtBox.Text = engine.GetUnitInfo() + engine.GetBuildingInfo();
            //rTxtBox.Text = engine.GetBuildingInfo();
            lblRounds.Text = "Round: " + engine.Round;

        }
        public enum GameState
        {
            RUNNING,
            PAUSED,
            ENDED
        }

        private void LblRounds(object sender, EventArgs e)
        {
            //engine.GameLoop();
            //UpdateUI();

            //if (engine.GameOver)
            //{
            //    timer.Stop();
            //    lblArea.Text = engine.WinningTeam + " WON! \n" + lblArea.Text;
            //    gameState = GameState.ENDED;
            //    btnStartPause.Text = "Restart";
            //}
        }

        private void LblRounds_Click(object sender, EventArgs e)
        {
            engine.GameLoop();
            UpdateUI();

            if (engine.GameOver)
            {
                timer.Stop();
                lblArea.Text = engine.WinningTeam + " WON! \n" + lblArea.Text;
                gameState = GameState.ENDED;
                btnStartPause.Text = "Restart";
            }
        }

        private void BtnStartPause_Click(object sender, EventArgs e)
        {
            timer.Start();
            BtnStartPause_Click.Text = "Start" + "\n" + "(click for each round)";
            /*if (gameState == GameState.RUNNING)
            {
                timer.Stop();
                gameState = GameState.PAUSED;
                btnStartPause.Text = "Start";
            }
            else
            {
                if (gameState == GameState.ENDED)
                {
                    engine.Reset();
                }
                timer.Start();
                gameState = GameState.RUNNING;
                btnStartPause.Text = "Pause";
            }*/

            // Populate();
            // map.Render(lblArea);
            // map.GenerateBattlefield();
            // map.Populate();
            // map.Update();
            // map.Information(txtBox);
        }

        private void RTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            engine.SaveUnitsToFile();
            engine.SaveBuidlingsToFile();
            lblArea.Text = "Game Saved! \n" + lblArea.Text;
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            engine.LoadGame();
            

        }
        private void TimerTick(object sender, EventArgs e)
        {
            count++;
            timer.
            engine.GameLoop();
            LblRounds.Text = count + ""; 
            UpdateUI();
        }
    }
}
