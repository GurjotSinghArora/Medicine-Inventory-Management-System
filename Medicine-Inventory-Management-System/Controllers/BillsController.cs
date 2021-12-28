using System;
using System.Data;
using Medicine_Inventory_Management_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Medicine_Inventory_Management_System.Controllers
{
    [RoutePrefix("Api/billregister")]
    public class BillsController : ApiController
    {

        DatabaseContext db = new DatabaseContext();
        [Route("InsertBill")]
        [HttpPost]
        public object InsertBill(BillDetails Det)
        {
            try
            {
                CustomerBill bill = new CustomerBill();
                if (bill.B_Id == 0)
                {
                    bill.M_Id = Det.M_Id;
                    bill.U_Id = Det.U_Id;
                    bill.I_Quantity = Det.I_Quantity;
                    bill.B_CustomerName = Det.B_CustomerName;
                    bill.M_Name = Det.M_Name;
                    db.CustomerBills.Add(bill);
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


        [Route("Billdetails")]
        [HttpGet]
        public object Billdetails()
        {

            var a = db.CustomerBills.ToList();
            return a;
        }


        [Route("Billbyuser")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var entity = db.CustomerBills.FirstOrDefault(s => s.U_Id == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"User with id {id} not found");
                }

            }
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


        //PUT
        //[Route("Updatemedicine")]
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Put(int id, MedicineStockIn stock)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if(id != stock.M_Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(stock).State = System.Data.Entity.EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }

        //    catch(DBConcurrencyException)
        //    {
        //        if(!MedicineStockInExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = stock.M_Id }, stock);
        //    //return Ok();
        //}




        //PUT
        [Route("UpdateBill")]
        public HttpResponseMessage Put(int id, BillDetails Det)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var entity = db.CustomerBills.FirstOrDefault(s => s.B_Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Bill with Id" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.U_Id = Det.U_Id;
                        entity.M_Id = Det.M_Id;
                        entity.I_Quantity = Det.I_Quantity;
                        entity.B_CustomerName = Det.B_CustomerName;
                        entity.M_Name = Det.M_Name;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }



        [Route("DeleteBill")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var entity = db.CustomerBills.FirstOrDefault(s => s.B_Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                                "Bill with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        db.CustomerBills.Remove(entity);
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


        //private bool MedicineStockInExists(int id)
        //{
        //    return db.MedicineStockIns.Count(e => e.M_Id == id) > 0;
        //}
    }
}
