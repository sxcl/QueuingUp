namespace QueuingUp
{
    public class Patient
    {
        // 真实id
        public int id;
        // 患者姓名
        public string name;
        // 患者门诊号
        public string mzno;
        // 下一位患者
        public Patient next;
        // 上一位患者
        public Patient prev;

        public Patient(int id, string name, string mzno)
        {
            this.id = id;
            this.name = name;
            this.mzno = mzno;
        }
    }
}