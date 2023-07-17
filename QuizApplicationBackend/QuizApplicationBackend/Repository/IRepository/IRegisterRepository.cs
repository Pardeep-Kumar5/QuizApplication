using System;
using System.Collections.Generic;
using System.Linq;
using QuizApplicationBackend.Model;
using System.Threading.Tasks;
using QuizApplicationBackend.MappingProfile.DTOs;

namespace QuizApplicationBackend.Repository.IRepository
{
   public interface IRegisterRepository
    {
        RegisterTable StudentRegister(RegisterDto register);
        RegisterTable TeacherRegister(RegisterDto register);
        IEnumerable<RegisterTable> GetRegister();
        RegisterTable GetStatusByUserID(int userID);
        RegisterTable ApproveStatus(int registerId);
        RegisterTable UnApproveStatus(int registerId);
        bool IsUniqueUser(string Username);
        RegisterTable Login(string UserName, string Password);
    }
}
