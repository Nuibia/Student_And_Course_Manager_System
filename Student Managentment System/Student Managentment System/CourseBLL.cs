using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Managentment_System
{
   public class CourseBLL
    {
       private CourseDAL couDal = new CourseDAL();

       #region 课程添加
       /// <summary>
       /// 课程添加
       /// </summary>
       public void AddCourse()
       {
           CourseInfo cou = new CourseInfo();
           Console.Write("请输入你要添加的课程名：");
           cou.Couname = Console.ReadLine();
           if (couDal.AddCourse(cou))
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
       #endregion

       #region 获取所有课程信息
       /// <summary>
       /// 获取所有课程信息
       /// </summary>
       /// <returns></returns>
       public List<CourseInfo> getCourses()
       {
           return couDal.getCourses();
       } 
       #endregion

       #region 课程id查询
       /// <summary>
       /// 课程id查询
       /// </summary>
       public CourseInfo getCourseByCouId(string couid)
       {
           //Console.WriteLine("请输入你想查询的课程id：");
           // couid = Console.ReadLine();
           CourseInfo cou = couDal.getCourseByCouId(couid);
           Common.showCourse(cou);  
           //Console.ReadKey();    
           return cou;
       }
       public void getcoursebyid()
       {

           Console.WriteLine("请输入你想查询的课程id：");
           string couid = Console.ReadLine();
           CourseInfo cou = couDal.getCourseByCouId(couid);

           Common.showCourse(cou);
           Console.ReadKey();   
       }
       #endregion

       #region 修改课程
       /// <summary>
       /// 修改课程
       /// </summary>
       public void updateCourse()
       {
           Console.Write("请输入需要修改的课程id：");
           string couid = Console.ReadLine();
           CourseInfo cou = couDal.getCourseByCouId(couid);
           if (cou != null)
           {
               Common.showCourse(cou);
               Console.Write("请输入新课程名：");
               string couname = Console.ReadLine();
               cou.Couname = couname;
               if (couDal.updateCourse(cou))
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
               Console.WriteLine("课程不存在");
               Console.ReadKey();
           }
       } 
       #endregion

       #region 课程删除
       /// <summary>
       /// 课程删除
       /// </summary>
       public void deleteCourse()
       {
       InputId:
           Console.Write("请输入课程id：");
           string couid = Console.ReadLine();
           if (couDal.deleteCourse(couid))
           {
               Console.WriteLine("删除成功");
               Console.ReadKey();
           }
           else
           {
               Console.WriteLine("输入为空，请重新输入");
               goto InputId;
           }

       } 
       #endregion
    }
}
