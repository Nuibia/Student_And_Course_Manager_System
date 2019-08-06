using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Managentment_System
{
    public static class Common
    {
        #region 判断输入数字是否合法
        /// <summary>
        /// 判断输入数字是否合法
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static int inputNum(int min, int max)
        {
        inputNum:
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if (num <= max && num >= min)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("输入错误，请输入合法选项");
                    goto inputNum;
                }
            }
            catch
            {
                Console.WriteLine("输入错误，请输入合法数字");
                goto inputNum;
            }
        }
        #endregion

        #region 展示集合所有的学生信息
        /// <summary>
        /// 展示集合所有的学生信息
        /// </summary>
        /// <param name="stuList"></param>
        static CourseBLL coubll = new CourseBLL();
        public static void ShowStudents(List<StudentInfo> stuList)
        {
            CourseInfo cou = new CourseInfo();
            if (stuList.Count > 0)
            {
                Console.WriteLine("学生信息如下：");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("{0,-14}{1,-12}{2,-10}{3,-13}", "学号", "姓名", "班级", "选课记录");
                foreach (StudentInfo item in stuList)
                {
                    
                    Console.WriteLine("{0,-15}{1,-10}{2,-10}", item.Id, item.Name, item.ClaName);
                    try
                    {
                        foreach (string courseid in item.Kecheng)
                        {
                            cou = coubll.getCourseByCouId(courseid);
                            Console.Write("{0,-5}", cou.Couname);
                        }
                    }
                    catch
                    {
                        item.Kecheng = null;
                    }

                    Console.Write("\n");
                }

            }
            else
            {
                Console.WriteLine("\n数据为空，请检查输入是否有误\n");
            }
        }
        #endregion

        #region 输出StudentModel对象
        /// <summary>
        /// 输出StudentModel对象
        /// </summary>
        /// <param name="stu"></param>
        public static void showStudnt(StudentInfo stu)
        {
            if (stu != null)
            {
                CourseInfo cour = new CourseInfo();
                Console.WriteLine("\n学生信息如下：");
                Console.WriteLine("\n--------------------------------------------------------------------------------");
                Console.WriteLine("{0,-8}{1,-10}{2,-10}{3,-13}", "学号", "姓名", "班级", "选课记录");
                Console.WriteLine("{0,-10}{1,-10}{2,-10}", stu.Id, stu.Name, stu.ClaName);
                foreach (string couid in stu.Kecheng)
                {
                    cour = coubll.getCourseByCouId(couid);
                    Console.WriteLine("{0,-5}",cour.Couname);
                }
                Console.WriteLine("\n--------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("\n数据为空，请检查输入是否有误\n");

            }
        }
        #endregion

        #region 输出集合所有的课程信息
        /// <summary>
        /// 输出集合所有的课程信息
        /// </summary>
        /// <param name="couList"></param>
        public static void ShowCourses(List<CourseInfo> couList)
        {   
            Console.WriteLine("课程信息如下");
            Console.WriteLine("----------------------------------------------------------------------");
            if (couList.Count > 0)
            {
                Console.WriteLine("{0,-14}{1,-14}", "课程id", "课程名");
                foreach (CourseInfo item in couList)
                {
                    Console.WriteLine("{0,-15}{1,-10}", item.Couid, item.Couname);
                }
            }
            else
            {
                Console.WriteLine("\n数据为空，请检查书入是否有误\n");
            }
            Console.WriteLine("----------------------------------------------------------------------");
        }
        #endregion

        #region 展示课程信息
        /// <summary>
        /// 展示课程信息
        /// </summary>
        /// <param name="cou"></param>
        public static void showCourse(CourseInfo cou)
        {         
            Console.WriteLine("\n课程信息如下：");    
            Console.WriteLine("\n--------------------------------------------------------------------------------");
            if (cou != null)
            {
                Console.WriteLine("{0,-8}{1,-10}", "课程id", "课程名");
                Console.WriteLine("{0,-10}{1,-10}", cou.Couid, cou.Couname);
            }
            else
            {
                Console.WriteLine("\n数据为空，请检查输入是否有误\n");
            }      
            Console.WriteLine("\n--------------------------------------------------------------------------------");
        }
        #endregion
    }
}
