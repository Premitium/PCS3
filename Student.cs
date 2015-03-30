using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolArchiveExtended
{
    class Student : Person
    {
        private string country;
        private int ec;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public int Ec
        {
            get { return ec; }
            set { ec = value; }
        }
        public Student(string id, string name, int pcn, int age, int yearsAF, string country, int ec)
            : base(id, name, pcn, age, yearsAF)
        {
            this.Country = country;
            this.Ec = ec;
        }
        public override string InfoString()
        {
            string studentInfo = base.InfoString();
            studentInfo += "\ncountry: " + this.Country;
            studentInfo += "\nec: " + this.Ec;
            return studentInfo;
        }

        public override void AnotherSchoolYear()
        {
            base.AnotherSchoolYear();
        }

        public override void CelebrateBirthDay()
        {
            base.CelebrateBirthDay();
        }

        public void AddOneModuleEC()
        {
            Ec++;
        }
    }
}

