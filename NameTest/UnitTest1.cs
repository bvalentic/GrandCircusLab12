using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrandCircusLab12;
using System.Collections.Generic;
using System.Linq;

namespace NameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StudentFirstName_ReturnString_True()
        {
            //
            Student testStudent = new Student();
            //
            string testFirstName = testStudent.FirstName;
            //
            Assert.AreEqual("John", testFirstName);
        }

        [TestMethod]
        public void ArchivedStudentFirstName_ReturnString_True()
        {
            ArchivedStudent testArchive = new ArchivedStudent();

            string testFirstName = testArchive.FirstName;

            Assert.AreEqual("John", testFirstName);
        }

        [TestMethod]
        public void SortStudentList_SortByLastName_True()
        {
            List<Student> studentList = new List<Student>
            {
                new Student("John Smith"),
                new Student("Jack Jones")
            };

            studentList.Sort();

            Assert.AreEqual("Jack", studentList[0].FirstName);
        }

        [TestMethod]
        public void SortStudentList_SortByScore_True()
        {
            List<Student> studentList = new List<Student>
            {
                new ArchivedStudent("Alice Jones", 50),
                new ArchivedStudent("Bob Jackson", 0),
                new ArchivedStudent("Carl Jameson", 70)
            };

            studentList = studentList.OrderBy(student => student.FinalScore).ToList();

            Assert.AreEqual(70, studentList[2].FinalScore);
        }
    }
}
