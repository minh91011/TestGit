using Excercise2_PRN231_MinhNNHE161638.Model;
using Excercise2_PRN231_MinhNNHE161638.Model.ViewModel;

namespace Excercise2_PRN231_MinhNNHE161638.Interface
{
    public interface IStudentRepository
    {
        //GetAll
        List<Student> GetAll();
        StudentViewModel Create(StudentModel studentViModel);
    }
}
