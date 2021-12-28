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
    [RoutePrefix("Api/supplierregister")]
    public class SupplierRegistersController : ApiController
    {
        DatabaseContext db = new DatabaseContext();
        [Route("InsertSupplier")]
        [HttpPost]
        public object InsertSupplier(SupplierDetails Det)
        {
            try
            {
                UserRegister user = new UserRegister();
                SupplierRegister supplier = new SupplierRegister();
                if (supplier.S_Id == 0)
                {
                    supplier.S_Name = Det.Name;
                    supplier.S_Address = Det.Address;
                    supplier.S_ContactPerson = Det.ContactPerson;
                    supplier.S_Mobile = Det.MobileNo;
                    supplier.U_Id = Det.U_Id;
                    db.SupplierRegisters.Add(supplier);
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


        [Route("Supplierdetails")]
        [HttpGet]
        public object Supplierdetails()
        {

            var a = db.SupplierRegisters.ToList();
            return a;
        }

        //[Route("UserdetailByLoginId")]
        //[HttpGet]
        //public object UserdetailByLoginId(string LoginId)
        //{
        //    var obj = db.UserRegisters.Where(x => x.U_LoginId == LoginId).ToList().FirstOrDefault();
        //    return obj;
        //}


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


        [Route("Deletesupplier")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var entity = db.SupplierRegisters.FirstOrDefault(s => s.S_Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                                "Supplier with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        db.SupplierRegisters.Remove(entity);
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
