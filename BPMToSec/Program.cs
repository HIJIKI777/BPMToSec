using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BPMToSec
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form f = new MainForm();


            Application.Run(f);
        }

        class MainForm : Form
        {
            Button calcButton;
            TextBox InsertBPMBox;
            Label ExplainLabel;
            string InsertString;
            int BPM;
            float BeatSec;

            public MainForm()
            {
                //フォームの設定
                this.Width = 500;
                this.Height = 500;
                this.Text = "BPMから1拍の秒数を計算するよ";

                //変換ボタンの設定
                this.calcButton = new Button();
                this.calcButton.Location = new Point(250, 400);
                this.calcButton.Size = new Size(170, 30);
                this.calcButton.Text = "変換";

                //入力ボックスの設定
                this.InsertBPMBox = new TextBox();
                this.InsertBPMBox.Location = new Point(100,250);
                this.InsertBPMBox.Size = new Size(300,100);
                InsertString = InsertBPMBox.Text;

                //説明の設定
                this.ExplainLabel = new Label();
                this.ExplainLabel.Location = new Point(70,200);
                this.ExplainLabel.Size = new Size(200,200);
                this.ExplainLabel.Text = "BPMを入力してください";

                //クリック処理
                this.calcButton.Click += new EventHandler(this.CalcButtonClick);
                //表示
                this.Controls.Add(calcButton);
                this.Controls.Add(InsertBPMBox);
                this.Controls.Add(ExplainLabel);
            }

            //クリック時の処理
            void CalcButtonClick(object sender, EventArgs e)
            {
                InsertString = InsertBPMBox.Text;
                StringToInt(InsertString);
                BeatSec = CalcBeatSec(BPM);
                MessageBox.Show("BPM" + BPM + " の1拍の間隔は\n" + BeatSec + " です");
            }

            float CalcBeatSec(int bpm)
            {
                return 60.0f / bpm;
            }

            void StringToInt(string inputString)
            {
                try
                {
                    BPM = Convert.ToInt32(inputString);
                }
                catch (FormatException)
                {
                    MessageBox.Show("正しくない形式です");
                    Application.Exit();
                }
            }
        }
    }
}
