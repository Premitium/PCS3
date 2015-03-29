using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolArchiveExtended
{
    public class Teacher : Person
    {
        private Function function;     // function. E,g, DOCENT_1, DOCENT_2, TEAM_LEADER, ...
        private double salary;         // monthly salary 
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public Function Function
        {
            get { return function; }
            set { function = value; }
        }
        /// <summary>
        /// The only constructor.</summary>
        /// <param name="name">Initial name of the teacher.</param>
        /// <param name="pcn">Personal Fontys number of the teacher.</param>
        /// <param name="age">Age of the teacher.</param>
        /// <param name="function">Function of the teacher.</param>
        /// <param name="salary">Monthly salary of the teacher.</param>
        public Teacher(string name, int pcn, int age,int yearsAF, double salary)
            : base(name, pcn, age, yearsAF)
        {
            this.Function = function;
            this.Salary = salary;
        }
        /// <summary>
        /// Returns values of all properties in the following string format:
        /// "John Doe (12456)
        ///  age 45, 15 years at Fontys
        ///  function: DOCENT_1
        ///  salary:   15000"
        /// </summary>
        public override string InfoString()
        {
            string teacherString = base.InfoString();
            teacherString += "\nfunction:\t" + this.Function.ToString();
            teacherString += "\nsalary:\t" + this.Salary.ToString();

            return teacherString;
        }
        /// <summary>
        /// Promotes the teacher by one function. 
        /// For example, DOCENT_1 is promoted into DOCENT_2.
        /// </summary>
        public void Promote()
        {
            if (function < Function.DIRECTOR)
                function++;
        }
        /*
         * However, for teachers it is not sufficient only to increment YearsAtFontys. For
         * this method should also make sure that every 3 years a teacher gets 10% raise
         * of salary. In other words, if (after the increment) YearsAtFontys is 3, 6, 9, 12, …,
         * salary is increased by 10% (Salary = Salary * 1.1;). 
         */

        public override void AnotherSchoolYear()
        {
            this.YearsAtFontys++;
            if (this.YearsAtFontys % 3 == 0)
                this.Salary = this.Salary * 1.1;
        }
    }
}
