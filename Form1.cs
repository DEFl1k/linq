using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Collections;
using System.IO;

namespace linq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sw = File.OpenText("1.txt");
            while (!sw.EndOfStream)
            {
                label1.Text = sw.ReadToEnd();
            }
            sw.Dispose();
        }
        private void plus(string x, Hashtable c)
        {
            StringBuilder str = new StringBuilder();
            ICollection coll = c.Keys;
            str.AppendLine(x);
            foreach (string i in coll)
            {
                str.AppendLine(i + " " + c[i]);
            }
            MessageBox.Show(str.ToString(), "Сообщение");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hashtable people = new Hashtable();
            StreamReader sw = File.OpenText("1.txt");
            string peoples;
            while ((peoples = sw.ReadLine()) != null)
            {
                string[] str = peoples.Split(' ');
                string n = str[0] + " " + str[1] + " " + str[2];
                string s = str[3] + " " + str[4];
                if (int.Parse(str[3]) < 40) people.Add(n, s);
            }
            plus("Меньше 40:", people);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = null;
            List<Employ> employes = new List<Employ>()
            {
            new Employ {Name="Иванов", Department="Отдел закупок"},
            new Employ {Name="Петров", Department="Отдел закупок"},
            new Employ {Name="Сидоров", Department="Отдел продаж"},
            new Employ {Name="Лямин", Department="Отдел продаж"},
            new Employ {Name="Сидоренко", Department="Отдел маркетинга"},
            new Employ {Name="Кривоносов", Department="Отдел продаж"}
            };

            List<Department> department = new List<Department>()
            {
            new Department {Name = "Отдел закупок", Reg="Германия"},
            new Department {Name = "Отдел продаж", Reg="Испания"},
            new Department {Name = "Отдел маркетинга", Reg="Испания"}
            };

            var result = from a in employes
                         join t in department on a.Department equals t.Name
                         select new { Name = a.Name, Department = a.Department, Reg = t.Reg };
            foreach (var mb in result)
            {

                label1.Text = ($"{mb.Name}-{mb.Department} ({mb.Reg}) \n" + label1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = null;
            List<Employ> employes = new List<Employ>()
            {
            new Employ {Name="Иванов", Department="Отдел закупок"},
            new Employ {Name="Петров", Department="Отдел закупок"},
            new Employ {Name="Сидоров", Department="Отдел продаж"},
            new Employ {Name="Лямин", Department="Отдел продаж"},
            new Employ {Name="Сидоренко", Department="Отдел маркетинга"},
            new Employ {Name="Кривоносов", Department="Отдел продаж"}
            };

            List<Department> department = new List<Department>()
            {
            new Department {Name = "Отдел закупок", Reg="Германия"},
            new Department {Name = "Отдел продаж", Reg="Испания"},
            new Department {Name = "Отдел маркетинга", Reg="Испания"}
            };

            var result = from a in employes
                         join t in department on a.Department equals t.Name
                         select new { Name = a.Name, Department = a.Department, Reg = t.Reg };
            foreach (var mb in result)
            {
                if (mb.Reg.StartsWith("И"))
                    label1.Text = ($"{mb.Name}-{mb.Department} ({mb.Reg}) \n" + label1.Text);
            }
        }
    }
}
