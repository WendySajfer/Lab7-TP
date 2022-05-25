using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_TP
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_1, str_2, str_3;
            string[] Array = new string[3];
            bool flag1, flag2;
            double a;
            int p, q;
            str_1 = textBox1.Text;
            str_2 = textBox2.Text;
            str_3 = textBox3.Text;
            flag1 = checkBox1.Checked;
            flag2 = checkBox2.Checked;
            try
            {
                p = Convert.ToInt32(str_1);
                q = Convert.ToInt32(str_2);
                a = Convert.ToDouble(str_3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox4.Text = "Ошибка";
                return;
            }
            Dodecahedron Dodec = new Dodecahedron(p, q, a);
            if (!Dodec.get_flag_Poly)
            {
                MessageBox.Show("Введённые данные не соответствуют додекаэдру.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Text = "Ошибка";
                return;
            }
            if (Dodec.get_flag_Dodec)
            {
                Array[0] = "Правильный додекаэдр.";
                if (flag1)
                {
                    Array[1] = "S = " + Math.Round(1000*Dodec.S_get)/1000;
                    if (flag2)
                    {
                        Array[2] = "V = " + Math.Round(1000 * Dodec.V_get) / 1000;
                    }
                }
                else
                {
                    if (flag2)
                    {
                        Array[1] = "V = " + Math.Round(1000 * Dodec.V_get) / 1000;
                    }
                }
            }
            else
            {
                Array[0] = "Не является додекаэдром.";
            }
            textBox4.Lines = Array;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFD = new SaveFileDialog();
            SaveFD.ShowDialog();
            String filePath = SaveFD.FileName;
            string result = "Число рёбер в каждой грани: " + textBox1.Text + "\nЧисло рёбер, сходящихся в каждой вершине: " + textBox2.Text + "\nДлина ребра " + textBox3.Text + "\nРезультат:\n" + textBox4.Text;
            try { System.IO.File.WriteAllText(filePath, result); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (показатьToolStripMenuItem.CheckState == CheckState.Checked)
            {
                показатьToolStripMenuItem.CheckState = CheckState.Unchecked;
                textBox4.Visible = false;
            }
            else if(показатьToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                показатьToolStripMenuItem.CheckState = CheckState.Checked;
                textBox4.Visible = true;
            }
        }

        private void условиеЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение для расчёта параметров додекаэдра. Главная форма содержит: элементы для ввода значений числа рёбер в каждой грани и числа рёбер, сходящихся в каждой вершине; группу элементов для выбора вычислений объёма и площади поверхности додекаэдра.", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" p - число рёбер в каждой грани, принимает целое значение.\n q - число рёбер, сходящихся в каждой вершине, принимает целое значение.\n a - длина стороны, принимает вещественное значение с разделителем ','.\n Додекаэдр - это правильный многогранник, состоящий из пятиугольников поэтому для получения результата, p = 5, q = 3.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
