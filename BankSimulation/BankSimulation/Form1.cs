using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSimulation
{
    public partial class Form1 : Form
    {
        public Bank Bank { get; set; }

        public Form1()
        {
            Bank = new Bank();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bank.LoadMoney(
                Int32.Parse(this.numericUpDown6.Text),
                Int32.Parse(this.numericUpDown5.Text),
                Int32.Parse(this.numericUpDown4.Text),
                Int32.Parse(this.numericUpDown3.Text),
                Int32.Parse(this.numericUpDown2.Text),
                Int32.Parse(this.numericUpDown1.Text)
            );
            this.textBox1.Text = Bank.TotalMoney.ToString();
            MoneyInAtm(Bank.MoneyList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<Money> moneyList = Bank.TakeMoney(Int32.Parse(this.numericUpDown7.Text));
                this.textBox9.Text = moneyList[0].Count.ToString();
                this.textBox10.Text = moneyList[1].Count.ToString();
                this.textBox11.Text = moneyList[2].Count.ToString();
                this.textBox12.Text = moneyList[3].Count.ToString();
                this.textBox13.Text = moneyList[4].Count.ToString();
                this.textBox14.Text = moneyList[5].Count.ToString();
            } catch
            {
                MessageBox.Show("Atm içerisinde yeterli para bulunamaktadır."); 
            }

            this.textBox1.Text = Bank.TotalMoney.ToString();
            MoneyInAtm(Bank.MoneyList);
        }

        private void MoneyInAtm(List<Money> moneyList)
        {
            this.textBox15.Text = moneyList[0].Count.ToString();
            this.textBox16.Text = moneyList[1].Count.ToString();
            this.textBox17.Text = moneyList[2].Count.ToString();
            this.textBox18.Text = moneyList[3].Count.ToString();
            this.textBox19.Text = moneyList[4].Count.ToString();
            this.textBox20.Text = moneyList[5].Count.ToString();

        }
    }
}
