using Excercise2_PRN231_MinhNNHE161638.Interface;
using Excercise2_PRN231_MinhNNHE161638.Model;
using Excercise2_PRN231_MinhNNHE161638.Model.ViewModel;

namespace Excercise2_PRN231_MinhNNHE161638.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private MyDBContext _context;
        public StudentRepository(MyDBContext dbContext)
        {
            _context = dbContext;
        }

        public StudentViewModel Create(StudentModel student)
        {
            var newStudent = new Student
            {
                StudentName = student.StudentName,
            };
            _context.Add(newStudent);
            _context.SaveChanges();
            return new StudentViewModel
            {
                StudentId = newStudent.StudentId,
                StudentName = student.StudentName,
            };
        }

        public List<Student> GetAll()
        {
            var list = _context.Students.Select(s => new Student
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName,
            });
            return list.ToList();
        }
    }
}
