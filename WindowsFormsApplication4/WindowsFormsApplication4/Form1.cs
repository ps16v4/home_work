using Google.API.Translate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string TranslateText(string input, string languagePair)
        {
            string url = String.Format("http://www.google.com/translate_t?hl=ru&ie=UTF8&text={0}&langpair={1}", input, languagePair);
            WebClient webClient = new WebClient();
   //         webClient.Encoding = System.Text.Encoding.UTF8;
            string result = webClient.DownloadString(url);
            result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
            result = result.Substring(result.IndexOf(">") + 1);
            result = result.Substring(0, result.IndexOf("</span>"));
            return result.Trim();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = TranslateText(textBox1.Text, "en");
        }
    }
}
