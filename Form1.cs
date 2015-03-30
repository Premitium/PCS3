using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchoolArchiveExtended
{
    public partial class Form1 : Form
    {
        private Student myStudent = null;
        //private Teacher myTeacher = null;
        private Person myPerson = null;
        //private Person InstanceClass = new Person();
        List<Person> personList;
        PersonsFileHelper helper;

        public Form1()
        {
            InitializeComponent();
            helper = new PersonsFileHelper(@"C:\Users\OMIS\Documents\Visual Studio 2013\Projects\Projects\Week05\Solution1\MySchoolArchiveExtended\text.txt");
        }
        private void LogPersonChange(string changeName)
        {
            this.richTextBoxActivityLogMyPerson.AppendText("\n*********************** " + changeName);
            this.richTextBoxActivityLogMyPerson.AppendText("\n" + myPerson.InfoString());
            this.labelMyPersonInfo.Text = myPerson.InfoString();
        }

        private void buttonSchoolYearTeacher_Click(object sender, EventArgs e)
        {
            myPerson.AnotherSchoolYear();
            LogPersonChange("year at Fontys");
        }

        private void buttonBirthdayStudent_Click(object sender, EventArgs e)
        {
            myPerson.CelebrateBirthDay();
            LogPersonChange("birthday");
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            personList = new List<Person>();
            string name = this.textBoxName.Text;
            int pcn = Convert.ToInt32(this.textBoxPCN.Text);
            int age = Convert.ToInt32(this.textBoxAge.Text);
            string country = this.textBoxCountry.Text;
            double salary = double.Parse(this.textBoxSalary.Text);
            int yearsAF = 0;


            if (radioButtonPerson.Checked)
            {
                myPerson = new Person("person",name, pcn, age, yearsAF);
                personList.Add(myPerson);
                
                LogPersonChange("CREATED PERSON :");

            }
            else if (radioButtonStudent.Checked)
            {
                myPerson = new Student("student",name, pcn, age, yearsAF, country, 0);
                personList.Add(myPerson);
                helper.SaveToFile(personList);
                LogPersonChange("CREATED STUDENT :");
            }
            else
            {
                myPerson = new Teacher("teacher",name, pcn, age, yearsAF, salary);
                personList.Add(myPerson);
                helper.SaveToFile(personList);
                LogPersonChange("CREATE TEACHER :");
                if (myPerson is Teacher)
                {
                    Teacher testIt = myPerson as Teacher;
                    //testIt.SetRetirementListener(this);
                }
            }
        }

        private void btnPromotion_Click(object sender, EventArgs e)
        {
            if (radioButtonTeacher.Checked)
            {
                foreach (Person person in personList)
                {
                    if (person is Teacher)
                    {
                        Teacher soul;
                        soul = person as Teacher;
                        soul.Promote();
                        //print the object instance
                        LogPersonChange("PROMOTE TEACHER :");
                    }
                }
            }
            else
            {
                LogPersonChange("YOU CANNOT GET PROMOTED :");
            }
        }

        private void btnAddECs_Click(object sender, EventArgs e)
        {
            if (radioButtonStudent.Checked)
            {
                foreach (Person student in personList)
                {
                    if (student is Student)
                    {
                        Student StudentNEW;
                        StudentNEW = student as Student;
                        StudentNEW.AddOneModuleEC();
                        //prints the object instance
                        LogPersonChange("EC's added :");
                    }
                }
            }
        }

        private void btnRetire_Click(object sender, EventArgs e)
        {
            if (radioButtonTeacher.Checked)
            {
                foreach (Person teacher in personList)
                {
                    if (teacher is Teacher)
                    {
                        Teacher TeacherNEW;
                        TeacherNEW = teacher as Teacher;
                        WantToRetire(TeacherNEW, "kur!");
                    }
                }
            }
        }
        public void WantToRetire(Teacher t, string reason)
        {
            MessageBox.Show(t.Name + " wants to retire." + "\nThe reason is: " + reason);
        }
    }
}
