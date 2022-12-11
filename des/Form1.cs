using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WinFormsApp1.Properties;
using System.IO;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string keyPath1, keyPath2, keyPath3, textPath, textoutPath;
        string[] keys = new string[3];
        public Form1()
        {
            InitializeComponent();
            keyPath1 = "..\\..\\input\\key.txt";
            keyPath2 = "..\\..\\input\\key1.txt";
            keyPath3 = "..\\..\\input\\key2.txt";
            textPath = "..\\..\\input\\text.txt";
            textoutPath = "..\\..\\output\\text.txt";
            readKeyFile();
            readTxtFile();
        }
        private void readKeyFile()
        {
            keys[0] = File.ReadAllText(keyPath1);
            keys[1] = File.ReadAllText(keyPath2);
            keys[2] = File.ReadAllText(keyPath3);
            textBox1.Text = keys[0];
            // textBox5.Text = keys[1];
            //textBox6.Text = keys[2];
        }
        private void readTxtFile()
        {
            string text = File.ReadAllText(textPath);
            textBox4.Text = text;
            //  textBox2.Text = "Исходный текст:\r\n" + text + "\r\n";
        }
        DataEncryptionStandard p = new DataEncryptionStandard();
        DataEncryptionStandard p1 = new DataEncryptionStandard();
        DataEncryptionStandard p2 = new DataEncryptionStandard();
        DataEncryptionStandard p3 = new DataEncryptionStandard();
        DataEncryptionStandard p4 = new DataEncryptionStandard();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = " ";
            string temp;
            for (int i = 0; i < textBox1.Text.Length; i++)
                if (textBox1.Text[i] != '1' && textBox1.Text[i] != '0') return;
            if (textBox1.Text.Length == 64)
            {
                temp = p.Des(Convert.ToString(textBox4.Text), Convert.ToUInt64(textBox1.Text, 2), true);
                str += "First E = " + temp + "\r\n";
                temp = p1.Des(temp, Convert.ToUInt64(textBox5.Text, 2), true);
                str += "Second E = " + temp + "\r\n";
                temp = p2.Des(temp, Convert.ToUInt64(textBox6.Text, 2), true);
                str += "Third E = " + temp + "\r\n";

                textBox2.Text = str;
                // textBox2.Text = p.initialPer;
                //textBox5.Text = p.feistel;

                textBox3.Text = temp;
            }

        }




        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = " ";
            string temp;
            for (int i = 0; i < textBox1.Text.Length; i++)
                if (textBox1.Text[i] != '1' && textBox1.Text[i] != '0') return;
            if (textBox1.Text.Length == 64)
            {
                temp = p.Des(Convert.ToString(textBox4.Text), Convert.ToUInt64(textBox6.Text, 2), false);
                str += "First D = " + temp + "\r\n";
                temp = p3.Des(temp, Convert.ToUInt64(textBox5.Text, 2), false);
                str += "Second D = " + temp + "\r\n";
                temp = p4.Des(temp, Convert.ToUInt64(textBox1.Text, 2), false);
                str += "Third D = " + temp + "\r\n";

                textBox2.Text = str;
                // textBox2.Text = p.initialPer;
                //textBox5.Text = p.feistel;

                textBox3.Text = temp;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }




}


