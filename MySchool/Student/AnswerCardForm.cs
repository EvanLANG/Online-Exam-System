using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MySchool
{
    public partial class AnswerCardForm : Form
    {
        public AnswerCardForm()
        {
            InitializeComponent();
        }

        // ��ʱ���� Tick �¼� 
        private void tmrCostTime_Tick(object sender, EventArgs e)
        {
            int minute;   // ��ǰ�ķ���
            int second;   // ��

            // �����ʣ�д���ʱ�䣬����ʾʣ���ʱ��
            if (QuizHelper.remainSeconds > 0)
            {
                minute = QuizHelper.remainSeconds / 60;
                second = QuizHelper.remainSeconds % 60;
                lblTimer.Text = string.Format("{0:00}:{1:00}", minute, second);  // ����֪ʶ��
                QuizHelper.remainSeconds--;
            }
            // ����ֹͣ��ʱ����ʾ����
            else 
            {
                tmrCostTime.Stop();
                MessageBox.Show("ʱ�䵽�ˣ��ý����ˣ�", "�Ϻ�����ѧԺ���߿���ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                QuizResultForm quizResultForm = new QuizResultForm();
                quizResultForm.Show();
                this.Close();
            }
        }

        // �������ʱ����ʾ��
        private void AnswerCardForm_Load(object sender, EventArgs e)
        {
            tmrCostTime.Start();  // ������ʱ��
           /* int index = 0;
            foreach (Control item in this.Controls)
            {
                if (item is Label)
                {
                    index = Convert.ToInt32(item.Tag);
                    if (index != -1)
                    {
                        item.Text = QuizHelper.studentAnswers[index];
                    }
                }
            }*/

            
            
        }

        // ����
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // �������������岢��ʾ���رյ�ǰ����
            QuizResultForm quizResultForm = new QuizResultForm();
            quizResultForm.MdiParent = this.MdiParent;
            quizResultForm.Show();
            this.Close();
        }        

        // ת����Ӧ����Ŀ
        private void btnQuestion_Click(object sender, EventArgs e)
        {
            int questionIndex = Convert.ToInt32(((Button)sender).Tag);
            if (questionIndex < 15)
            {
                AnswerQuestionForm answerQuestionForm = new AnswerQuestionForm();
                answerQuestionForm.questionIndex = questionIndex;
                answerQuestionForm.MdiParent = this.MdiParent;
                answerQuestionForm.Show();
            }
            else if (14 < questionIndex && questionIndex < 19)
            {
                fillblank fillblank = new fillblank();
                fillblank.questionIndex21 = questionIndex;
                fillblank.MdiParent = this.MdiParent;
                fillblank.Show();
            }
            else
            {
                ShortAnswer shortanswer = new ShortAnswer();
                shortanswer.questionIndex31 = questionIndex;
                shortanswer.MdiParent =this.MdiParent ;
                shortanswer.Show();
 
            }
            this.Close();

        }        
    }
}