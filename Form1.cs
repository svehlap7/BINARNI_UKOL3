using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UKOL_BINARNI33
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream stream = new FileStream(@"..\..\Texty.dat", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter binarpis = new BinaryWriter(stream);
            BinaryReader binarcti = new BinaryReader(stream);
            listBox1.Items.Clear();
            string veta;
            for (int i = 0; i < textBox1.Lines.Count(); ++i)
            {
                veta = textBox1.Lines[i];
                binarpis.Write(veta);

                listBox1.Items.Add(veta);
                
            }

            binarpis.Seek(0, SeekOrigin.Begin);

            while (binarpis.BaseStream.Position < binarpis.BaseStream.Length)
            {
                veta = binarcti.ReadString();
                veta = veta.Replace('.', '#');

                listBox2.Items.Add(veta);
            }
            stream.Close();
            binarcti.Close();
            binarpis.Close();

            }
            catch
            {
                MessageBox.Show("CHYBA, PRAZDNY RADEK");
            }
        }
    }
}
