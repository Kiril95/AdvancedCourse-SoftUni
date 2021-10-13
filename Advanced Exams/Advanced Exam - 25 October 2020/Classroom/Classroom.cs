using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> Students;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count => this.Students.Count;

        public string RegisterStudent(Student student)
        {
            if (Capacity > Count)
            {
                this.Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            bool check1 = Students.Exists(x => x.FirstName == firstName);
            bool check2 = Students.Exists(x => x.LastName == lastName);

            if (check1 && check2)
            {
                Student target = Students
                    .Where(x => x.FirstName == firstName)
                    .FirstOrDefault(x => x.LastName == lastName);
                Students.Remove(target);

                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            var filtered = Students.FindAll(x => x.Subject == subject);
            if (filtered.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var person in filtered)
                {
                    sb.AppendLine($"{person.FirstName} {person.LastName}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }
        public int GetStudentsCount()
        {
            return Students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return Students.Where(x => x.FirstName == firstName)
                           .FirstOrDefault(x => x.LastName == lastName);
        }
    }
}
