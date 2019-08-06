using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Managentment_System
{
   public class UI
    {
       private StudentBLL stuBll = new StudentBLL();
       private CourseBLL couBll = new CourseBLL();

       #region 总菜单
       /// <summary>
       /// 总菜单
       /// </summary>
       public void mainMenu()
       {
           Console.Clear();
           Console.WriteLine("\n\n{0,35}", "学生选课管理系统");
           Console.WriteLine("\n\n--------------------------------------------------------------------------------");
           Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}\n\n{4,-15}{5,-15}{6,-15}{7,-15}\n\n{8,-13}{9,-13}\n", "1.查看学生", "2.添加学生", "3.修改学生", "4.删除学生","5.查看课程","6.添加课程","7.修改课程","8.删除课程","9.增加选课","10.删除选课");
           Console.Write("请输入你的选择：");
           int num = Common.inputNum(1, 11);
           switch (num)
           {
               case 1:
                   {
                       selectMenu();
                       break;
                   }
               case 2:
                   {
                       stuBll.AddStudent();
                       returnMainMenu();
                       break;
                   }
               case 3:
                   {
                       stuBll.updateStudent();
                       returnMainMenu();
                       break;
                   }
               case 4:
                   {
                       stuBll.deleteStudent();
                       returnMainMenu();
                       break;
                   }
               case 5:
                   {
                       selectCourseMenu();
                       break;
                   }
               case 6:
                   {
                       couBll.AddCourse();
                       returnMainMenu();
                       break;
                   }
               case 7:
                   {
                       couBll.updateCourse();
                       returnMainMenu();
                       break;
                   }
               case 8:
                   {
                       couBll.deleteCourse();
                       returnMainMenu();
                       break;
                   }
               case 9:
                   {
                       stuBll.AddSelCourse();
                       returnMainMenu();
                       break;
                   }
               case 10:
                   {
                       stuBll.Deletecourse();
                       returnMainMenu();
                       break;
                   }
           }

       } 
       #endregion


       #region 查询菜单
       /// <summary>
       /// 查询菜单
       /// </summary>
       public void selectMenu()
       {
           Console.Clear();
           Console.WriteLine("\n\n{0,35}", "查询学生");
           Console.WriteLine("\n\n--------------------------------------------------------------------------------\n");
           Console.WriteLine("{0,-15}{1,-15}{2,-10}{3,-15}\n", "1.查看所有学生", "2.根据Id查询", "3.根据班级查询", "4.返回总菜单");
           Console.Write("请输入你的选择：");
           int num = Common.inputNum(1, 4);
           switch (num)
           {
               case 1:
                   {
                       List<StudentInfo> stuList = stuBll.getStudents();
                       Common.ShowStudents(stuList);
                       Console.ReadKey();
                       this.returnSelectMenu();
                       break;
                   }
               case 2:
                   {
                       stuBll.getStudentById();
                       this.returnSelectMenu();
                       break;
                   }
               case 3:
                   {
                       stuBll.getStudentByClsName();
                       this.returnSelectMenu();
                       break;
                   }
               case 4:
                   {
                       returnMainMenu();
                       break;
                   }
           }
       } 
       #endregion

       #region 课程查询菜单
       /// <summary>
       /// 课程查询菜单
       /// </summary>
       public void selectCourseMenu()
       {
           Console.Clear();
           Console.WriteLine("\n\n{0,35}", "查询课程");
           Console.WriteLine("\n\n--------------------------------------------------------------------------------\n");
           Console.WriteLine("{0,-15}{1,-15}{2,-15}\n", "1.查看所有课程", "2.根据Id查询", "3.返回总菜单");
           Console.Write("请输入你的选择：");
           int num = Common.inputNum(1, 3);
           switch (num)
           {
               case 1:
                   {
                       List<CourseInfo> couList = couBll.getCourses();
                       Common.ShowCourses(couList);
                       Console.ReadKey();
                       this.returnSelectMenu();
                       break;
                   }
               case 2:
                   {
                       couBll.getcoursebyid();
                       this.returnSelectMenu();
                       break;
                   }
               case 3:
                   {
                       returnMainMenu();
                       break;
                   }
           }
       } 
       #endregion


       #region 按任意键返回总菜单
       /// <summary>
       /// 按任意键返回总菜单
       /// </summary>
       public void returnMainMenu()
       {
           Console.WriteLine("按任意键返回总菜单");
           //Console.ReadKey();
           this.mainMenu();
       } 
       #endregion


       #region 按任意键返回查询菜单
       /// <summary>
       /// 按任意键返回查询菜单
       /// </summary>
       private void returnSelectMenu()
       {
           Console.WriteLine("按任意键返回查询菜单");
           //Console.ReadKey();
           this.selectMenu();
       } 
       #endregion
       }
    }
