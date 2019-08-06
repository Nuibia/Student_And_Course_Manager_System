using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Student_Managentment_System
{
    public class StudentBLL
    {
        StudentDAL stuDal = new StudentDAL();
        CourseDAL couDal = new CourseDAL();


        #region 添加学生
        public void AddStudent()
        {
            StudentInfo stu = new StudentInfo();
        InputName:
            Console.Write("请输入你要添加的学生姓名：");
            stu.Name = Console.ReadLine();
            if (stu.Name.Length == 0)
            {
                Console.WriteLine("姓名不能为空，请重新输入");
                goto InputName;
            }
            else
            {
            InputClsName:
                Console.Write("请输入班级：");
                stu.ClaName = Console.ReadLine();
                if (stu.ClaName.Length == 0)
                {
                    Console.WriteLine("输入为空，请重新输入");
                    goto InputClsName;
                }
                else
                {

                    Console.WriteLine("添加成功");
                    stuDal.AddStudent(stu);
                    Console.ReadKey();
                }
            }


        }
        #endregion

        #region 获取所有学生
        /// <summary>
        /// 获取所有学生
        /// </summary>
        /// <returns></returns>
        public List<StudentInfo> getStudents()
        {
            return stuDal.getStudents();
        }
        #endregion

        #region 通过学号查找学生信息
        /// <summary>
        /// 通过学号查找学生信息
        /// </summary>
        public void getStudentById()
        {
            Console.Write("请输入你想查询的学生学号：");
            string id = Console.ReadLine();
            StudentInfo stu = stuDal.getStudentById(id);
            Common.showStudnt(stu);
            Console.ReadKey();
        }
        #endregion

        #region 通过班级查询学生信息
        /// <summary>
        ///通过班级查询学生信息
        /// </summary>
        public void getStudentByClsName()
        {
        InputClsName:
            Console.Write("请输入想查询的班级：");
            string clsName = Console.ReadLine();
            if (clsName.Length == 0)
            {
                Console.WriteLine("班级不可为空，请重新输入");
                goto InputClsName;
            }
            else
            {
                List<StudentInfo> stuList = stuDal.getStudentsByClsName(clsName);
                Common.ShowStudents(stuList);
                Console.ReadKey();
            }

        }
        #endregion

        #region 修改学生信息
        /// <summary>
        /// 修改学生信息
        /// </summary>
        public void updateStudent()
        {
            Console.Write("请输入需要修改的学生学号：");
            string id = Console.ReadLine();
            StudentInfo stu = stuDal.getStudentById(id);
            if (stu != null)
            {
                Common.showStudnt(stu);
                Console.Write("请输入新名字:");
                string name = Console.ReadLine();
                Console.Write("请输入新班级:");
                string clsName = Console.ReadLine();

                stu.Name = name;
                stu.ClaName = clsName;

                if (stuDal.updateStudent(stu))
                {
                    Console.WriteLine("修改成功");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("修改失败");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("学生不存在");
                Console.ReadKey();
            }
        }
        #endregion

        #region 学生删除
        /// <summary>
        /// 学生删除
        /// </summary>
        public void deleteStudent()
        {
        InputId:
            Console.Write("请输入学号：");
            string id = Console.ReadLine();
            if (stuDal.deleteStudent(id))
            {
                Console.WriteLine("删除成功");
                Console.ReadKey();
            }
            else
            {
                Console.Write("输入为空，请重新输入");
                goto InputId;
            }
        }
        #endregion

        #region 课程删除
        /// <summary>
        /// 课程删除
        /// </summary>
        public void Deletecourse()
        {
        InputId:
            Console.Write("请输入学号：");
            string id = Console.ReadLine();
            if (stuDal.Delete(id))
            {
                Console.WriteLine("删除成功");
                Console.ReadKey();
            }
            else
            {
                Console.Write("输入为空，请重新输入");
                goto InputId;
            }
        }
        #endregion


        public void AddSelCourse()
        {
            StudentInfo stu = new StudentInfo();
            CourseInfo cou = new CourseInfo();
            Console.Write("请输入学号：");
            stu = stuDal.getStudentById(Console.ReadLine());
            if (stu != null)
            {
                Console.Write("请输入课程号：");
                cou = couDal.getCourseByCouId(Console.ReadLine());
                if (cou != null)
                {
                    if (stuDal.AddSelCourse(stu, cou))
                    {
                        Console.WriteLine("添加成功");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("添加失败");
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("查无此课程");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("查无此人");
            }
        }
    }
}
