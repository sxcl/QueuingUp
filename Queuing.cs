using System.Text;

namespace QueuingUp
{
    public class Queuing
    {
        // 队列池总数
        public int size;
        // 第一位
        public Patient head;
        // 末尾位
        public Patient tail;
        // 可排队人数
        public int capacity;

        public Queuing(int capacity = int.MaxValue)
        {
            head = null;
            tail = null;
            size = 0;
            this.capacity = capacity;
        }

        /// <summary>
        /// 插队到首位
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Patient QueueTheTop(Patient patient)
        {
            if (size >= capacity)
            {
                return null;
            }

            if (head == null) // 还没人排队
            {
                patient.next = null;
                patient.prev = null;
                head = patient;
                tail = patient;
            }
            else
            {
                head.prev = patient;
                patient.prev = null;
                patient.next = head;
                head = patient;
            }
            size++;
            return patient;
        }

        /// <summary>
        /// 老实排队
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Patient Queue(Patient patient)
        {
            if (head == null) // 还没人排队
            {
                patient.next = null;
                patient.prev = null;
                head = patient;
                tail = patient;
            }
            else
            {
                tail.next = patient;
                patient.prev = tail;
                tail = patient;
            }
            size++;
            return patient;
        }

        /// <summary>
        /// 老实排队
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Patient Queue(Patient patient, int location)
        {
            if (head == null) // 还没人排队
            {
                patient.next = null;
                patient.prev = null;
                head = patient;
                tail = patient;
            }
            else
            {
                if (location == 0)
                {
                    QueueTheTop(patient);
                }
                else if (location == size)
                {
                    Queue(patient);
                }
                else
                {
                    Patient prevpatient = head;
                    Patient nextpatient = null;
                    int i = 0;
                    while (i < (location - 1)) // 因为要插队到第i个，所有要插入的位置前一个为location-1
                    {
                        i++;
                        prevpatient = prevpatient.next;
                    }
                    nextpatient = prevpatient.next;

                    prevpatient.next = patient;
                    patient.prev = prevpatient;
                    patient.next = nextpatient;
                    nextpatient.prev = patient;
                }
            }
            size++;
            return patient;
        }

        /// <summary>
        /// 放弃排队
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Patient DeQueue(Patient patient)
        {
            if (patient == head)
                DeQueueTheTop();
            else if (patient == tail)
                DeQueueTheTail();
            else
            {
                patient.prev.next = patient.next;
                patient.next.prev = patient.prev;
                size--;
            }
            return patient;
        }

        public Patient DeQueueTheTop()
        {
            if (head == null)
                return null;

            var patient = head;
            if (head.next != null)
            {
                head = patient.next;
                head.prev = null;
            }
            else
            {
                head = tail = null;
            }
            size--;
            return patient;
        }

        public Patient DeQueueTheTail()
        {
            if (tail == null)
                return null;
            var patient = tail;
            if (tail.prev != null)
            {
                tail = patient.prev;
                tail.next = null;
            }
            else
            {
                head = tail = null;
            }
            size--;
            return patient;
        }

        /// <summary>
        /// 查看队列
        /// </summary>
        public void Print()
        {
            StringBuilder line = new StringBuilder();
            var p = head;
            while (p != null)
            {
                line.Append($"name:{p.name}");
                p = p.next;
                if (p != null)
                    line.Append("==>");
            }
            System.Console.WriteLine(line.ToString());
        }
    }
}