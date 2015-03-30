using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MySchoolArchiveExtended 
{
    class PersonsFileHelper
    {
        public string FileName { get; set; }
        StreamWriter sw;
        StreamReader sr;
        FileStream fs;
        public PersonsFileHelper()
        {
            this.FileName = null;
        }
        public PersonsFileHelper(string fileName)
        {
            this.FileName = fileName;
        }
        public string PersonToString(Person person)
        {
            /*
             * using "is"-"as" construct to cast objects
             */
            string info = "";
            if (person is Student)
            {
                info = " ";
                Student student = person as Student;
                
                info += student.Id + "|" + student.Name + "|" + student.PCN.ToString();
                info += "|" + student.Age.ToString() + "|" + student.YearsAtFontys.ToString();
                info += "|" + student.Country + "|" + student.Ec.ToString();
            }
            else if (person is Teacher)
            {
                info = " ";
                Teacher teacher = person as Teacher;

                info += teacher.Id + "|" + teacher.Name + "|" + teacher.PCN.ToString();
                info += "|" + teacher.Age.ToString() + "|" + teacher.YearsAtFontys.ToString();
                info += "|" + teacher.Function.ToString() + "|" + teacher.Salary;
            }
            else
            {
                info = " ";
                info += person.Id + "|" + person.Name + "|" + person.PCN.ToString();
                info += "|" + person.Age.ToString() + "|" + person.YearsAtFontys.ToString();    
            }
            return info;
        }
        public Person PersonFromString(String input)
        {
            Person person;
            string[] stringParts = input.Split('|');
            if (stringParts[0] == "student")
            {
                person = new Student(stringParts[0], stringParts[1], int.Parse(stringParts[2]), int.Parse(stringParts[3]), int.Parse(stringParts[4]), stringParts[5], int.Parse(stringParts[6]));
            }
            else if (stringParts[0] == "teacher")
            {
                person = new Teacher(stringParts[0],stringParts[1], int.Parse(stringParts[2]), int.Parse(stringParts[3]), int.Parse(stringParts[4]), int.Parse(stringParts[5]));
                /*
                 * what about the Function???
                 */
            }
            else
            {
                person = new Person(stringParts[0],stringParts[1], int.Parse(stringParts[2]), int.Parse(stringParts[3]), int.Parse(stringParts[4]));
            }
            return person;
        }
        /*
         * Writes instances of the class Person as string to a txt file at a specific path
         */
        public void SaveToFile(List<Person> lines)
        {
            /*
             * instance of file writer to open the file at a specific path
             */
            fs = new FileStream(FileName, FileMode.Append, FileAccess.Write);

            /*
             * pass the file in the file stream to the Stream Writer
             */
            sw = new StreamWriter(fs);

            /*
             * Loop through the list and write the info to the "fs" file
             */
            foreach (var human in lines)
            {
                sw.WriteLine(PersonToString(human));
            }
            /*
             * close the resources 
             */
            sw.Close();
        }
        public List<Person> LoadFromFile(string path)
        {
            List<Person> internalPersonList = new List<Person>();
            try
            {
                /*
                 * 1. Get file at a specific path to the Stream Reader
                 * 2. Write all lines to string "s" at a new line
                 */
                fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
                sr = new StreamReader(fs);
                string s;

                /*
                 * 
                 */
                while (!sr.EndOfStream)//ор(!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    internalPersonList.Add(PersonFromString(s));
                }

            }
            catch (IOException ex)
            {
                //Console.WriteLine("Error reading the file");
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
            return internalPersonList;
        }
    }
}
