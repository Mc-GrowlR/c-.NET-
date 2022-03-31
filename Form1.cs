using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jisuanqi
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        //字符串声明
        //string tempStrNum1 = "";
        string tempStrOperator = "";

        //数字声明
        double num1 = 0;
        double num2 = 0;
        double result = 0;

        private void mainForm_Load(object sender, EventArgs e)
        {

        }
        private void ButtonNum_Click(object sender, EventArgs e)
        {
            Button buttonNumber = (Button)sender;

            if (lblShow.Text == "0")
            {
                //判断输入的是否为小数点。
                if (buttonNumber.Text != ".")
                    lblShow.Text = buttonNumber.Text;
                else
                    lblShow.Text += buttonNumber.Text;
                //tempStrNum1 = str1;
            }
            else
            {
                lblShow.Text += buttonNumber.Text;
                //tempStrNum1 += str1;
                //lblShow.Text = "9";
            }//if (lblShow.Text == "0")
        }

        //
        //操作符按钮方法
        //
        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            Button buttonOperator = (Button)sender;
            //tempStrOperator = buttonOperator.Text;
            if (buttonOperator.Text != "=")
            {
                //
                //查找运算符
                //
                switch (buttonOperator.Text)
                {
                    case "+":
                        {
                            tempStrOperator = buttonOperator.Text;
                            lblShow.Text += tempStrOperator;
                        } break;
                    case "-":
                        {
                            tempStrOperator = buttonOperator.Text;
                            lblShow.Text += tempStrOperator;
                        }
                        break;
                    case "×":
                        {
                            tempStrOperator = buttonOperator.Text;
                            lblShow.Text += tempStrOperator;
                        }
                        break;
                    case "÷":
                        {
                            tempStrOperator = buttonOperator.Text;
                            lblShow.Text += tempStrOperator;
                        }
                        break;
                } 
            }
            else if (buttonOperator.Text == "=")
            {

                //string tempStrNum = lblShow.Text;
                if (lblShow.Text != "")
                {
                    int j = 0;
                    for (int i = 0; i < lblShow.Text.Length; i++)
                    {
                        //if(tempStrOperator!="")
                        if (lblShow.Text[i] == '+' || lblShow.Text[i] == '-' || lblShow.Text[i] == '×' || lblShow.Text[i] == '÷')
                        {
                            j = i;
                            break;
                        }

                    }//for(int i = 0; i < lblShow.Text.Length; i++)

                    if (j == 0)
                        num1 = Convert.ToDouble(lblShow.Text.Substring(0));
                    else
                    {
                        num1 = Convert.ToDouble(lblShow.Text.Substring(0, j));
                        if (lblShow.Text.Length - 1 >= j + 1)
                            num2 = Convert.ToDouble(lblShow.Text.Substring(j + 1));
                    }
                    //lblShow.Text = lblShow.Text.Substring(j+1);
                    result = num1 + num2;
                    string str1 = result.ToString();
                    lblShow.Text += buttonOperator.Text;//附上等于号
                                                        //lblShow.Text = result.ToString();//出现了小数点不能正确运算的问题
                                                        //lblShow.Text += num2.ToString();
                                                        //lblShow.Text = lblShow.Text+'\n'+ num1.ToString()+'\n'+num2.ToString()+'\n'+result.ToString();



                    switch (tempStrOperator)
                    {
                        case "+": 
                            { 
                                result = num1 + num2;
                                lblShow.Text += Convert.ToString(result);
                            } break;
                        case "-": 
                            {
                                result = num1 - num2;
                                lblShow.Text += Convert.ToString(result);
                            } break;
                        case "×":
                            {
                                result = num1 * num2;
                                lblShow.Text += Convert.ToString(result);
                            } break;
                        case "÷":
                            {
                                //判断除数是否为零
                                if (num2 != 0)
                                {
                                    result = num1 / num2;
                                    lblShow.Text += Convert.ToString(result);
                                }
                                else
                                    lblShow.Text = "不能除以零";
                            }
                            break;
                    }//switch (tempStrOperator)

                    //
                    //结果现显示
                    //


                    //lblShow.Text += Convert.ToString(result);
                    //lblShow.Text += Convert.ToString(result);
                    //lblShow.Text += str1;

                    //witch()

                }

                //运算符标记清零
                tempStrOperator = "";
            }
        }
        //
        //运算函数
        //
        
        //
        //退格按钮
        //
        private void button1_Click(object sender, EventArgs e)
        {

            string tempStr = lblShow.Text;
            //如果显示器内字符串长度大于0，则执行退格操作
            if (tempStr.Length > 0)
            {                
                lblShow.Text = tempStr.Substring(0, tempStr.Length - 1);
                //如果数字暂存区内字符串长度大于0，则执行退格操作
                //if (tempStrNum1.Length > 0)
                  //  tempStrNum1 = tempStrNum1.Substring(0, tempStrNum1.Length - 1);
            }
        }
        //
        //清屏按钮
        //
        private void button3_Click(object sender, EventArgs e)
        {
            lblShow.Text = null;
            tempStrOperator = null;
            result = 0;
            num1 = 0;
            num2 = 0;
        }

        private void button20_Click(object sender, EventArgs e)
        {

        }
    }
}
