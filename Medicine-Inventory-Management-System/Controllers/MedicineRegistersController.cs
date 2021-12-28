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
    [RoutePrefix("Api/medicineregister")]
    public class MedicineRegistersController : ApiController
    {
        DatabaseContext db = new DatabaseContext();
        [Route("InsertMedicine")]
        [HttpPost]
        public object InsertMedicine(MedicineDetails Med)
        {
            try
            {
                MedicineStockIn stock = new MedicineStockIn();
                if (stock.M_Id == 0)
                {
                    stock.M_Name = Med.M_Name;
                    stock.M_Description = Med.M_Description;
                    stock.M_Price = Med.M_Price;
                    stock.M_Quantity = Med.M_Quantity;
                    stock.SupplierName = Med.SupplierName;
                    stock.M_Location = Med.M_Location;
                    stock.M_ExpDate = Med.M_ExpDate;
                    stock.S_Id = Med.S_Id;
                    db.MedicineStockIns.Add(stock);
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


        [Route("Medicinedetails")]
        [HttpGet]
        public object Medicinedetails()
        {

            var a = db.MedicineStockIns.ToList();
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
        [Route("Updatemedicine")]
        public HttpResponseMessage Put(int id, MedicineDetails Med)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var entity = db.MedicineStockIns.FirstOrDefault(s => s.M_Id == id);
                    if(entity==null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Medicine with Id" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.M_Name = Med.M_Name;
                        entity.M_Description = Med.M_Description;
                        entity.M_Price = Med.M_Price;
                        entity.M_Quantity = Med.M_Quantity;
                        entity.SupplierName = Med.SupplierName;
                        entity.S_Id = Med.S_Id;
                        entity.M_Location = Med.M_Location;
                        entity.M_ExpDate = Med.M_ExpDate;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }

            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        
        }



        [Route("Deletemedicine")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var entity = db.MedicineStockIns.FirstOrDefault(s => s.M_Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                                "Medicine with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        db.MedicineStockIns.Remove(entity);
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
