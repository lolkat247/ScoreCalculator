using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCalculator
{
    public partial class Form1 : Form
    {
        // I used doubles since input would probably be percentages
        double totalScore;
        int countScore;
        double averageScore;
        
        public Form1()
        {
            InitializeComponent();
            totalScore = 0.0;
            countScore = 0;
            averageScore = 0.0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // get and convert input into percentage score
            double curScore;
            try
            {
                curScore = Convert.ToDouble(tbScore.Text);
            }
            catch (Exception)
            {
                var mbVal = MessageBox.Show("Invalid Score");
                return;
            }

            // Add to totals
            totalScore += curScore;
            countScore++;
            averageScore = totalScore / countScore;

            // update text boxes
            tbScoreTotal.Text = Convert.ToString(totalScore);
            tbScoreCount.Text = Convert.ToString(countScore);
            tbAverage.Text = Convert.ToString(averageScore);

            return;
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            // reset scores
            totalScore = 0.0;
            countScore = 0;
            averageScore = 0.0;

            // display changes
            tbScoreTotal.Text = Convert.ToString(totalScore);
            tbScoreCount.Text = Convert.ToString(countScore);
            tbAverage.Text = Convert.ToString(averageScore);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
