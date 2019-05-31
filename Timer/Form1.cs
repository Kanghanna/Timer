using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; //using은 import의 의미

namespace Timer
{
    public partial class Form1 : Form
    {
        int CountOrgNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CountOrgNum < 1)
            {
                this.Timer.Enabled = false; //타이머를 끔
                this.txtNum.ReadOnly = false; //
                this.txtNum.Text = "";
                MessageBox.Show("펑!", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNum.Focus(); //다시 시간을 입력하는 곳에 포커스 주기
            }
            else
            {
                this.CountOrgNum--;
                this.txtCountDown.Text = Convert.ToString(this.CountOrgNum);
            }

        }

        private bool IntCheck()
        {
            if (Information.IsNumeric(this.txtNum.Text)) //숫자인지 판별하는 ISNumeric
            {
                return true;
            }
            else
            {
                MessageBox.Show("숫자를 입력하세요~", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNum.Focus();
                return false;
            }
        }

        private void BtnCount_Click(object sender, EventArgs e)
        {
            if (IntCheck())
            {
                this.CountOrgNum = Convert.ToInt32(this.txtNum.Text);
                this.txtNum.ReadOnly = true;
                this.Timer.Enabled = true;
            }
            else
            {
                this.txtNum.Text = "";
                this.txtNum.Focus();
            }

        }

     
    }
}
