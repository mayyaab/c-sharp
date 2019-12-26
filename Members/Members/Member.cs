using System;
using System.Collections.Generic;
using System.Text;

namespace Members
{
    class Member
    {
        //members - private field

        private string memberName;
        private string jobTitle;
        private int salary;

        //members - pblick field

        public int age;

        //member - property exposes jobTitle safely - start wit a capitale letter
        public string JobTitle  { get; set; }
        
        
        //member constructor
        public Member()
        {
            age = 30;
            memberName = "Lucy";
            salary = 6000;
            jobTitle = "Devloper";
        }

        //public - finilized - destructor
        ~Member()
        {
            //cleanup statement
            Console.WriteLine("Deconstructor of members object");
        }

        //public member method - can be called from other class
        public void Introducing(bool isFriend)
        {
            if (isFriend == true)
            {
                SharingPrivateInfo();
            }
            else
            {
                Console.WriteLine("My name is {0}, and my job title is {1}, and my age{2}",memberName,jobTitle,age);
            }
        }

        public void SharingPrivateInfo()
        {
            Console.WriteLine("My salary is", salary);
        }
    }
}
