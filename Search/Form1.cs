using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Search
{
    public partial class Form1 : Form
    {
        const int countSearch = 101;
        string[] dataSearch = new string[countSearch];
        string[] dataSites = new string[countSearch];

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            #region search
            dataSearch[0] = "maxim is the best";
            dataSearch[1] = "photo";
            dataSearch[2] = "english";
            dataSearch[3] = "maximka";
            dataSearch[4] = "10";
            dataSearch[5] = "potato";
            dataSearch[6] = "pomidor";
            dataSearch[7] = "pomidor ???";
            dataSearch[8] = "google";
            dataSearch[9] = "yandex";
            dataSearch[10] = "vk";
            dataSearch[11] = "vkontakte";
            dataSearch[12] = "SECRET";
            #endregion

            #region sites
            dataSites[0] = "https://google.com";
            dataSites[1] = "https://yandex.com";
            dataSites[2] = "https://vk.com";
            dataSites[3] = "https://google.com";
            dataSites[4] = "https://vk.com";
            dataSites[5] = "https://yandex.com";
            dataSites[6] = "https://vk.com";
            dataSites[7] = "https://google.com";
            dataSites[8] = "https://google.com";
            dataSites[9] = "https://yandex.com";
            dataSites[12] = "https://pornhub.com";
            #endregion


            for (int i = 13; i < countSearch; i++)
            {
                dataSearch[i] = Convert.ToString(i);
            }

            this.Text = Application.ProductName;
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        void Run()
        { 
            string str = maskedTextBox1.Text;
            char[] c = str.ToCharArray();

            for (int b = 0; b < countSearch; b++)
            {
                string str1 = string.Empty;
                string str2 = string.Empty;
                char[] strA5 = dataSearch[b].ToCharArray();

                for (int j = 0; j < c.Length; j++)
                {
                    try
                    {
                        str1 += c[j];
                        str2 += strA5[j];

                        if (str1 == str2)
                        {
                            this.Invoke((MethodInvoker) delegate
                            {
                                listBox2.Items.Remove(dataSearch[b]);
                                listBox2.Items.Add(dataSearch[b]);
                            });
                            
                        }
                        else
                        {
                            this.Invoke((MethodInvoker) delegate
                            {
                                listBox2.Items.Remove(dataSearch[b]);
                            });
                        }
                    }
                    catch { }
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                button1.Enabled = true;
            });

        }

        Thread thread;
        bool bl = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!bl)
            {
                var s = sender as Button;
                s.Enabled = false;
                bl = false;
            }
            else
            {
                button1.Enabled = false;
            }
            
            listBox2.Items.Clear();

            thread = new Thread(Run);
            thread.Start();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataSearch.Length; i++)
            {
                if ((string)listBox2.SelectedItem == dataSearch[i])
                {
                    Process.Start(dataSites[i]);
                    break;
                }
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bl = true;
                button1_Click(null, null);
            }
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && e.Control)
            {
                maskedTextBox1.Text = string.Empty;
            }
        }
    }
}

