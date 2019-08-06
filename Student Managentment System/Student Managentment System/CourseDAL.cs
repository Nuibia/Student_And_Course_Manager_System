using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Student_Managentment_System
{
    public class CourseDAL
    {
        #region 课程添加
        /// <summary>
        /// 课程添加
        /// </summary>
        /// <param name="cou">课程名</param>
        /// <returns></returns>
        public bool AddCourse(CourseInfo cou)
        {
            XmlDocument Xml = XmlHelper.Xml;

            XmlNode Courses = Xml.SelectSingleNode("//Courses");

            XmlElement courseNode = Xml.CreateElement("course");

            courseNode.SetAttribute("课程id", cou.Couid);
            Courses.AppendChild(courseNode);

            XmlElement counameNode = Xml.CreateElement("couname");
            counameNode.InnerText = cou.Couname;
            courseNode.AppendChild(counameNode);

            XmlElement snumNode = Xml.CreateElement("Snum");
            snumNode.InnerText = cou.Snum.ToString();
            courseNode.AppendChild(snumNode);
            //更改Course节点的值
            Courses.Attributes["counum"].Value = cou.Couid;

            Xml.Save("data.xml");
            return true;
        }
        #endregion

        #region 获得全部CourseInfo信息
        /// <summary>
        /// 获得全部CourseInfo信息
        /// </summary>
        /// <returns></returns>
        public List<CourseInfo> getCourses()
        {
            List<CourseInfo> couList = new List<CourseInfo>();
            XmlNodeList courseNodeList = XmlHelper.Xml.SelectSingleNode("//Courses").ChildNodes;
            foreach (XmlNode item in courseNodeList)
            {
                string couid = item.Attributes["课程id"].Value;
                CourseInfo cou = new CourseInfo(couid);
                cou.Couname = item.SelectSingleNode("couname").InnerText;

                couList.Add(cou);
            }
            return couList;
        }
        #endregion

        #region 通过课程id查询课程节点
        /// <summary>
        /// 通过课程id查询课程节点
        /// </summary>
        /// <param name="couid"></param>
        /// <returns></returns>
        public XmlNode getCourseNodeByCouId(string couid)
        {
            XmlDocument Xml = XmlHelper.Xml;
            XmlNode courseNode = Xml.SelectSingleNode("//course[@课程id='" + couid + "']");
            return courseNode;
        }
        #endregion

        #region 课程id查询
        /// <summary>
        /// 课程id查询
        /// </summary>
        /// <param name="couid"></param>
        /// <returns></returns>
        public CourseInfo getCourseByCouId(string couid)
        {
            //XmlNode courseNode = this.getCourseNodeByCouId(couid);
            //if (courseNode != null)
            //{
            //CourseInfo cou = new CourseInfo(courseNode.Attributes["课程id"].Value);
            //cou.Couname = courseNode.SelectSingleNode("couname").InnerText;
            //return cou;
            //}
            //else
            //{
            //    CourseInfo cou = null;
            //    return cou;
            //}
            try
            {
                XmlNode courseNode = this.getCourseNodeByCouId(couid);
                CourseInfo cour = new CourseInfo(courseNode.Attributes["课程id"].Value);
                cour.Snum = Convert.ToInt32(courseNode.SelectSingleNode("Snum").InnerText);
                cour.Couname = courseNode.SelectSingleNode("couname").InnerText;

                return cour;
            }
            catch (Exception)
            {
                return null;
            }

        }
        #endregion

        #region 修改课程
        /// <summary>
        /// 修改课程
        /// </summary>
        /// <param name="cou"></param>
        /// <returns></returns>
        public bool updateCourse(CourseInfo cou)
        {
            XmlNode courseNode = this.getCourseNodeByCouId(cou.Couid);
            if (courseNode != null)
            {
                courseNode.SelectSingleNode("couname").InnerText = cou.Couname;
                XmlHelper.Xml.Save("data.xml");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 课程删除
        /// <summary>
        /// 课程删除
        /// </summary>
        /// <param name="couid"></param>
        /// <returns></returns>
        public bool deleteCourse(string couid)
        {
            XmlNode courseNode = this.getCourseNodeByCouId(couid);
            if (courseNode != null)
            {
                courseNode.ParentNode.RemoveChild(courseNode);
                XmlHelper.Xml.Save("data.xml");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
