using WMPLib;

namespace YadonBot
{
    public partial class Form1 : Form
    {
        private Yadonchan _chan = new("ドヤ太");
        WindowsMediaPlayer _mediaPlayer = new WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
        }


        private void PutLog(string str)
        {
            textBox1.AppendText(str + "\r\n");
        }

        private string Prompt()
        {
            return _chan.Name + "> ";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dialog();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //EnterやEscapeキーでビープ音が鳴らないようにする
            if (e.KeyValue ==(char)Keys.Enter)
            {
                Dialog();
            }

        }

        private void Dialog()
        {
            _mediaPlayer.URL = @"sound.mp3";
            _mediaPlayer.controls.play();


            string value = textBox2.Text;
            if (string.IsNullOrEmpty(value))
            {
                label1.Text = "なにどや？";
            }
            else
            {
                string response = _chan.Dialogue(value);
                label1.Text = response;
                PutLog("> " + value);
                PutLog(Prompt() + response);
                textBox2.Clear();

                int em = _chan.Emotion.Mood;

                if((-5<=em) && (em<=5)) {
                    this.pictureBox1.Image = Properties.Resources.yadon_normal;

                }else if ((-10 <=em) && (em <-5)) 
                {
                    this.pictureBox1.Image = Properties.Resources.yadon_sleep;
                }else if((-15 <= em) && (em < -10) )
                {
                    this.pictureBox1.Image = Properties.Resources.yadon_angry;
                }else if((5<= em) && em <= 15)
                {
                    this.pictureBox1.Image = Properties.Resources.yadon_happy;
                }

                label2.Text = Convert.ToString(_chan.Emotion.Mood);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            const string message = "記憶しちゃってよい？";
            const string caption = "質問です";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _chan.Save();
            }

        }
    }
}