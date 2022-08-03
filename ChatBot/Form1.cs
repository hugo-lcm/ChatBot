using System;
using System.Speech.Synthesis;
using System.Windows.Forms;
using AIMLbot;

namespace ChatBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bot AI = new Bot();
            AI.loadSettings();
            AI.loadAIMLFromFiles();
            AI.isAcceptingUserInput = false;

            User myUser = new User("your name", AI);
            AI.isAcceptingUserInput = true;
            Request r = new Request(textBox2.Text, myUser, AI);
            Result res = AI.Chat(r);
            textBox1.Text = "bot: " + res.Output;

            //codigo para o bot falar
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.Speak(res.Output);
        }
    }
}
