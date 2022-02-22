namespace YadonBot
{
    public partial class Form1 : Form
    {
        private Yadonchan _chan = new("ドヤ太");

        public Form1()
        {
            InitializeComponent();
            UpdateCurrentTime();
        }

        private void UpdateCurrentTime()
        {
            DateTime dt = DateTime.Now;
            label2.Text = dt.ToLongTimeString();

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

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateCurrentTime();
        }
    }
}