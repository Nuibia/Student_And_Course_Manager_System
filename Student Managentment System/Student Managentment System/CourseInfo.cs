using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Managentment_System
{
   public class CourseInfo
    {
       public static int counum;

       private string couid;

       /// <summary>
       /// 课程id
       /// </summary>
       public string Couid
       {
           get { return couid; }
       }
       private string couname;
       /// <summary>
       /// 课程名
       /// </summary>
       public string Couname
       {
           get { return couname; }
           set { couname = value; }
       }
       private int snum;
       /// <summary>
       /// 选课人数
       /// </summary>
       public int Snum
       {
           get { return snum; }
           set { snum = value; }
       }
       /// <summary>
       /// 无参构造函数，couid自动赋值
       /// </summary>
       public CourseInfo()
       {
           counum = counum + 1;
           couid = counum.ToString();
       }
       /// <summary>
       /// 有参构造函数，couid手动赋值
       /// </summary>
       /// <param name="counumber"></param>
       public CourseInfo(string counumber)
       {
           couid = counumber;
       }
    }
}
