using Medicine_Inventory_Management_System.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medicine_Inventory_Management_System.Controllers
{
    [RoutePrefix("Api/register")]
    public class UserRegistersController : ApiController
    {
        DatabaseContext db = new DatabaseContext();
        [Route("InsertUser")]
        [HttpPost]
        public object InsertUser(Register Reg)
        {
            try
            {

                UserRegister user = new UserRegister();
                if (user.U_Id == 0)
                {
                    user.U_Name = Reg.Name;
                    user.U_Address = Reg.Address;
                    user.U_Email = Reg.Email;
                    user.U_Password = Reg.Password;
                    user.U_Mobile = Reg.MobileNo;
                    user.U_LoginId = Reg.LoginId;
                    user.U_Type = Reg.Type;
                    db.UserRegisters.Add(user);
                    db.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };

        }

        [Route("Login")]
        [HttpPost]
        public ResponseModel userLogin(Login login)
        {
            var user = db.UserRegisters.FirstOrDefault(x => x.U_LoginId.Equals(login.LoginId) && x.U_Password.Equals(login.Password));

            if (user == null)
            {
                return new ResponseModel { UniqueId = Guid.NewGuid().ToString(), Message = Constants.Failure, Data = "Invalid User" };
            }
            else
                return new ResponseModel { UniqueId = Guid.NewGuid().ToString(), Message = Constants.Success, Data = new AuthenticateUser() { Name=user.U_Name, Email=user.U_Email, LoginId=user.U_LoginId, Type=user.U_Type } };
        }

        [Route("GetUserById")]
        [HttpGet]
        public ResponseModel GetUser([FromUri] string email)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    response.Message = Constants.Failure;
                    response.Data = "You have sent invalid request!";
                    return response;
                }

                var user = db.UserRegisters.FirstOrDefault(f => f.U_Email == email);
                if (user != null)
                {
                    response.Message = Constants.Success;
                    response.Data = new AuthenticateUser
                    {
                        LoginId = user.U_LoginId,
                        U_Id = user.U_Id,
                        Email = user.U_Email,
                        Name = user.U_Name,
                        Type = user.U_Type
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = Constants.Failure;
                response.Data = ex.Message;
            }
            return response;
        }


        [Route("Userdetails")]
        [HttpGet]
        public object Userdetails()
        {

            var a = db.UserRegisters.ToList();
            return a;
        }

        [Route("UserdetailByLoginId")]
        [HttpGet]
        public object UserdetailByLoginId(string LoginId)
        {
            var obj = db.UserRegisters.Where(x => x.U_LoginId == LoginId).ToList().FirstOrDefault();
            return obj;
        }


        //public object Deleteuser(int Id)
        //{

        //       var obj = db.UserRegisters.FirstOrDefault(x => x.U_Id == Id);
        //       db.UserRegisters.Remove(obj);
        //       db.SaveChanges();

        //    return new Response
        //    {
        //        Status = "Delete",
        //        Message = "Delete Successfuly"
        //    };
        //}


        [Route("Deleteuser")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using(DatabaseContext db = new DatabaseContext())
                {
                    var entity = db.UserRegisters.FirstOrDefault(s => s.U_Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse( HttpStatusCode.NotFound,
                                "User with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    { db.UserRegisters.Remove(entity);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
