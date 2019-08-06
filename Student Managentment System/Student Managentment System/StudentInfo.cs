using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Managentment_System
{
   public class StudentInfo
    {
        public static int num;

        private string id;
/// <summary>
/// 学号
/// </summary>
        public string Id
        {
            get { return id; }
        }
        private string claName;
       /// <summary>
       /// 班级名
       /// </summary>
        public string ClaName
        {
            get { return claName; }
            set { claName = value; }
        }
        private string name;
       /// <summary>
       /// 姓名
       /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
       /// <summary>
       /// 无参构造函数，id手动赋值
       /// </summary>
        public StudentInfo()
        {
            num = num + 1;
            id = num.ToString();
        }
        public StudentInfo(string number)
        {
            id = number;

        }

        private List<string> kecheng = new List<string>();
       /// <summary>
       /// 选课记录
       /// </summary>
        public List<string> Kecheng
        {
            get { return kecheng; }
            set { kecheng = value; }
        }
    }
}
