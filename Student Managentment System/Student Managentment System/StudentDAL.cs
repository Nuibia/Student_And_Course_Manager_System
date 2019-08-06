using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Student_Managentment_System
{
    public class StudentDAL
    {
        #region 添加学生
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public bool AddStudent(StudentInfo stu)
        {
            XmlDocument Xml = XmlHelper.Xml;

            XmlNode Students = Xml.SelectSingleNode("//Students");

            XmlElement studentNode = Xml.CreateElement("student");

            studentNode.SetAttribute("学号", stu.Id);
            Students.AppendChild(studentNode);

            XmlElement nameNode = Xml.CreateElement("name");
            nameNode.InnerText = stu.Name;
            studentNode.AppendChild(nameNode);

            XmlElement clsNameNode = Xml.CreateElement("clsName");
            clsNameNode.InnerText = stu.ClaName;
            studentNode.AppendChild(clsNameNode);

            XmlElement courseIDNode = Xml.CreateElement("CourseID");
            studentNode.AppendChild(courseIDNode);


            Students.Attributes["num"].Value = stu.Id;

            Xml.Save("data.xml");
            return true;

        }
        #endregion

        #region 获取所有学生信息
        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        public List<StudentInfo> getStudents()
        {
            List<StudentInfo> stuList = new List<StudentInfo>();
            XmlNodeList studentNodeList = XmlHelper.Xml.SelectSingleNode("//Students").ChildNodes;

            foreach (XmlNode item in studentNodeList)
            {
                string id = item.Attributes["学号"].Value;
                StudentInfo stu = new StudentInfo(id);
                stu.Name = item.SelectSingleNode("name").InnerText;
                stu.ClaName = item.SelectSingleNode("clsName").InnerText;
                try
                {
                    XmlNodeList couIdNodeList = item.SelectSingleNode("CourseID").ChildNodes;
                    foreach (XmlNode couid in couIdNodeList)
                    {
                        stu.Kecheng.Add(couid.InnerText);

                    }

                }
                catch
                {
                    stu.Kecheng = null;
                }

                stuList.Add(stu);


            }
            return stuList;
        }
        #endregion

        #region 通过学号找到指定节点
        /// <summary>
        /// 通过学号找到指定节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public XmlNode getStudentNodeById(string id)
        {
            XmlDocument Xml = XmlHelper.Xml;
            XmlNode studentNode = Xml.SelectSingleNode("//student[@学号='" + id + "']");
            return studentNode;
        }
        #endregion

        #region 通过学号查询学生信息
        /// <summary>
        /// 通过学号查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentInfo getStudentById(string id)
        {
            XmlNode studentNode = this.getStudentNodeById(id);
            if (studentNode != null)
            {


                StudentInfo stu = new StudentInfo(studentNode.Attributes["学号"].Value);
                stu.Name = studentNode.SelectSingleNode("name").InnerText;
                stu.ClaName = studentNode.SelectSingleNode("clsName").InnerText;
                XmlNodeList couIdNodeList = studentNode.SelectSingleNode("CourseID").ChildNodes;
                foreach (XmlNode couid in couIdNodeList)
                {
                    stu.Kecheng.Add(couid.InnerText);
                }
                return stu;
            }
            else
            {
                StudentInfo stu = null;
                return stu;
            }


        }
        #endregion

        #region 通过班级查询所有学生
        /// <summary>
        /// 通过班级查询所有学生
        /// </summary>
        /// <param name="clsName"></param>
        /// <returns></returns>
        public List<StudentInfo> getStudentsByClsName(string clsName)
        {
            List<StudentInfo> stuList = new List<StudentInfo>();
            XmlDocument Xml = XmlHelper.Xml;
            XmlNodeList studentsList = Xml.SelectNodes("//student[clsName='" + clsName + "']");
            foreach (XmlNode item in studentsList)
            {
                StudentInfo stu = new StudentInfo(item.Attributes["学号"].Value);
                stu.Name = item.SelectSingleNode("name").InnerText;
                stu.ClaName = item.SelectSingleNode("clsName").InnerText;
                XmlNodeList couIdNodeList = item.SelectSingleNode("CourseID").ChildNodes;
                foreach (XmlNode couid in couIdNodeList)
                {
                    stu.Kecheng.Add(couid.InnerText);
                }

                stuList.Add(stu);
            }
            return stuList;

        }
        #endregion

        #region 通过学号修改学生信息
        /// <summary>
        /// 通过学号修改学生信息
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public bool updateStudent(StudentInfo stu)
        {
            XmlNode studentNode = this.getStudentNodeById(stu.Id);
            if (studentNode != null)
            {
                studentNode.SelectSingleNode("clsName").InnerText = stu.ClaName;
                studentNode.SelectSingleNode("name").InnerText = stu.Name;
                XmlHelper.Xml.Save("data.xml");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        #region 删除学生信息
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteStudent(string id)
        {
            XmlNode studentNode = this.getStudentNodeById(id);
            if (studentNode != null)
            {
                studentNode.ParentNode.RemoveChild(studentNode);
                XmlHelper.Xml.Save("data.xml");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 删除选课
        /// <summary>
        /// 删除选课
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            XmlNode studentNode = this.getStudentNodeById(id);
            if (studentNode != null)
            {
                studentNode.RemoveChild(studentNode.SelectSingleNode("//CourseID"));
                XmlHelper.Xml.Save("data.xml");
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        public bool AddSelCourse(StudentInfo stu, CourseInfo cour)
        {
            //找到并修改学生节点 
            XmlNode studentNode = this.getStudentNodeById(stu.Id);
            XmlNode stucourIdNode = studentNode.SelectSingleNode("CourseID");
            XmlElement stucourNode = XmlHelper.Xml.CreateElement("courseId");
            stucourNode.InnerText = cour.Couid;
            stucourIdNode.AppendChild(stucourNode);
            //找到并修改课程Snum节点 
            XmlNode courseNode = XmlHelper.Xml.SelectSingleNode("//course[@课程id='" + cour.Couid + "']/Snum");
            if (courseNode != null)
            {
                courseNode.InnerText = (Convert.ToInt32(courseNode.InnerText) + 1).ToString();
            }
            else
            {
                courseNode.InnerText = "1";
            }

            XmlHelper.Xml.Save("data.xml");
            return true;
        }

    }
}
