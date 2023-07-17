using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuizApplicationBackend.Data;
using QuizApplicationBackend.MappingProfile.DTOs;
using QuizApplicationBackend.Model;
using QuizApplicationBackend.Repository.IRepository;
using QuizApplicationBackend.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationBackend.Repository
{
    public class RegisterRepository :IRegisterRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtToken _jWTToken;
        public RegisterRepository(ApplicationDbContext context, IOptions<JwtToken> JwtToken)
        {
            _context = context;
            _jWTToken = JwtToken.Value;
        }

        public RegisterTable StudentRegister(RegisterDto register)
        {
            RegisterTable table = new RegisterTable()
            {
                Name = register.Name,
                Address = register.Address,
                Email = register.Email,
                Password = register.Password,
                Role = "Student",
                Status = false
            };
            _context.RegisterTable.Add(table);
            _context.SaveChanges();
            return table;
        }
        public RegisterTable ApproveStatus(int registerId)
        {
            var RegisterInDb = _context.RegisterTable.FirstOrDefault(r => r.id == registerId);
           if (RegisterInDb != null)
            {
                RegisterInDb.Status = true;
            }
            _context.RegisterTable.Update(RegisterInDb);
            _context.SaveChanges(); 
            return RegisterInDb;
        }
        public RegisterTable UnApproveStatus(int registerId)
        {
            var registerIndb = _context.RegisterTable.FirstOrDefault(r => r.id == registerId);
            if(registerId!=null)
            {
                registerIndb.Status = false;
            }
            _context.RegisterTable.Update(registerIndb);
            _context.SaveChanges();
            return registerIndb;
        }
        public bool IsUniqueUser(string Username)
        {
            var user = _context.RegisterTable.First(usertable => usertable.Name == Username);
            if (user == null)
            {
                return true;
            }
            return false;
        }
        public RegisterTable Login(string UserName, string Password)
        {
            var user = _context.RegisterTable.FirstOrDefault(usertable => usertable.Name == UserName & usertable.Password == Password);
            if (user == null) return null;
            
            //jwt token
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_jWTToken.secret);
            var TokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //new Claim(ClaimTypes.Name, UserIndb.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescritor);
            user.Token = TokenHandler.WriteToken(Token);

            // UserIndb.Password = "";
            return user;
        }

        public RegisterTable TeacherRegister(RegisterDto teacher)
        {
            RegisterTable table = new RegisterTable()
            {
                Name = teacher.Name,
                Password = teacher.Password,
                Email = teacher.Email,
                Address = teacher.Address,
                Role = "Teacher",
            };
            _context.RegisterTable.Add(table);
            _context.SaveChanges();
            return table;
        }

        public RegisterTable GetStatusByUserID(int userID)
        {
            return _context.RegisterTable.FirstOrDefault(r => r.id == userID);
        }

        public IEnumerable<RegisterTable> GetRegister()
        {
            return _context.RegisterTable;
        }

        
    }
}
