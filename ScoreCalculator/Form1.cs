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
        // declare global vars
        // NOTE: I used doubles since realistically, scores will be decimal
        int countScore;
        List<double> scores;
        
        public Form1()
        {
            // init global vars
            InitializeComponent();
            countScore = 0;
            scores = new List<double>();
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

            // Add to total
            try
            {
                scores.Add(curScore);
                countScore++; //increment count for next input
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Max of amount of entries entries", "Error");
                return;
            }

            // calc avg
            double totalScore = 0.0;
            foreach (var x in scores) 
            {
                totalScore += x;
            }
            double averageScore = totalScore / countScore;

            // update text boxes
            tbScoreTotal.Text = Convert.ToString(totalScore);
            tbScoreCount.Text = Convert.ToString(countScore);
            tbAverage.Text = Convert.ToString(averageScore);

            return;
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            // reset scores
            scores = new List<double>();
            countScore = 0;

            // display changes
            tbScoreTotal.Text = Convert.ToString("");
            tbScoreCount.Text = Convert.ToString(countScore);
            tbAverage.Text = Convert.ToString("");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDspSco_Click(object sender, EventArgs e)
        {
            var mout = "";
            var outscores = new double[countScore];
            for (int x = 0; x < countScore; x++)
            {
                outscores[x] = scores[x];
            }
            Array.Sort(outscores);
            foreach (var x in outscores)
            {
                mout = mout + Convert.ToString(x) + "\n";
            }
            MessageBox.Show(mout, "Sorted Scores");
        }
    }
}
