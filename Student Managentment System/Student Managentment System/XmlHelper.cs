using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Student_Managentment_System
{
    public class XmlHelper
    {
        public static XmlDocument Xml;
        /// <summary>
        /// 判断xml文档是否存在
        /// </summary>
        /// <returns></returns>
        public static bool Init()
        {
            bool flag = false;
            try
            {
                if (File.Exists("data.xml"))
                {
                    Xml = new XmlDocument();
                    Xml.Load("data.xml");
                    XmlNode Students = Xml.SelectSingleNode("System/Students");
                    XmlNode Courses = Xml.SelectSingleNode("//Courses");
                    StudentInfo.num = Convert.ToInt32(Students.Attributes["num"].Value);
                    CourseInfo.counum = Convert.ToInt32(Courses.Attributes["counum"].Value);
                    flag = true;
                }
                else
                {
                    Xml = new XmlDocument();
                    XmlDeclaration xdt = Xml.CreateXmlDeclaration("1.0", "utf-8", null);
                    Xml.AppendChild(xdt);

                    XmlElement system = Xml.CreateElement("System");
                    system.SetAttribute("title", "学生管理系统");
                    Xml.AppendChild(system);

                    XmlElement students = Xml.CreateElement("Students");
                    students.SetAttribute("title", "学生信息节点");
                    students.SetAttribute("num", "174804000");
                    system.AppendChild(students);
                    StudentInfo.num = 174804000;

                    XmlElement classes = Xml.CreateElement("classes");
                    classes.SetAttribute("title", "班级信息节点");
                    system.AppendChild(classes);

                    XmlElement courses = Xml.CreateElement("Courses");
                    courses.SetAttribute("title", "课程信息节点");
                    courses.SetAttribute("counum", "000");
                    system.AppendChild(courses);
                    StudentInfo.num = 174804000;
                    CourseInfo.counum = 000;

                    Xml.Save("data.xml");
                    flag = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }
    }
}
