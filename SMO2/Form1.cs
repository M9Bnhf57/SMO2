using SMO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMO2
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

        private void button1_Click(object sender, EventArgs e)
        {
            int arriveTime = 0;
            int operatorTime1 = 0;
            int operatorTime2 = 0;
            int operatorTime3 = 0;
            Service operator1 = new Service
            {
                a = 15,
                b = 25
            };
            Service operator2 = new Service
            {
                a = 30,
                b = 50
            };
            Service operator3 = new Service
            {
                a = 20,
                b = 60
            };



            bool ClientHere = true;
            int ClientCounter = 0;
            int ClientLosses = 0;
            int DoneCounter = 0;

            int accum1 = 0;
            int accum2 = 0;

            int compTime1 = 0;
            int compTime2 = 0;
            Service comp1 = new Service
            {
                a = 14,
                b = 15
            };
            Service comp2 = new Service
            {
                a = 29,
                b = 30
            };

            for (int i = 0; DoneCounter < 300; i++)
            {
                if (i == arriveTime)
                {
                    arriveTime += (int)(Arrival.GetNextTime());
                    ClientHere = true;
                }

                if (i == operatorTime1 && ClientHere == true)
                {
                    accum1++;
                    ClientCounter++;
                    ClientHere = false;
                    operatorTime1 += (int)(operator1.Work());
                }
                else if (i == operatorTime1 && ClientHere == false)
                    operatorTime1++;

                if (i == operatorTime2 && ClientHere == true)
                {
                    accum1++;
                    ClientCounter++;
                    ClientHere = false;
                    operatorTime2 += (int)(operator2.Work());
                }
                else if (i == operatorTime2 && ClientHere == false)
                    operatorTime2++;

                if (i == operatorTime3 && ClientHere == true)
                {
                    accum2++;
                    ClientCounter++;
                    ClientHere = false;
                    operatorTime3 += (int)(operator3.Work());
                }
                else if (i == operatorTime3 && ClientHere == false)
                    operatorTime3++;

                if (ClientHere == true)
                {
                    ClientLosses++;
                    ClientHere = false;
                }

                if (i == compTime1 && accum1 > 0)
                {
                    accum1--;
                    compTime1 += (int)(comp1.Work());
                    DoneCounter++;
                }
                else if (i == compTime1 && accum1 == 0)
                {
                    compTime1++;
                }
                if (i == compTime2 && accum2 > 0)
                {
                    accum2--;
                    compTime2 += (int)(comp2.Work());
                    DoneCounter++;
                }
                else if (i == compTime2 && accum2 == 0)
                {
                    compTime2++;
                }
            }
            double otkaz = (double)ClientLosses / (double)DoneCounter;
            textBox1.Text = $"Вероятность отказа: {otkaz}";
        }
    }
}
