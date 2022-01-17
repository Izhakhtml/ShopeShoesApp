using ShopeShoesApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopeShoesApp.Controllers.api
{
    public class ChildShoeController : ApiController
    {
        // GET: api/ChildShoe
        static string connectionString = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=ShoesDB;Integrated Security=True;Pooling=False";
        static DataClassesDataContext dataContext = new DataClassesDataContext(connectionString);
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new {dataContext.Shoes});
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ChildShoe/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                var GetById = dataContext.Shoes.First(item => item.Id == id);
                if (GetById != null)
                {
                  return Ok(new {GetById});
                }
                  return NotFound();
                
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ChildShoe
        public IHttpActionResult Post([FromBody]Shoe newShoe)
        {
            try
            {
                dataContext.Shoes.InsertOnSubmit(newShoe);
                dataContext.SubmitChanges();
                return Ok("Added successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ChildShoe/5
        public IHttpActionResult Put(int id, [FromBody]Shoe updateShoe)
        {
            try
            {
                Shoe GetById = dataContext.Shoes.First(item => item.Id == id);
                if (GetById != null)
                {
                    GetById.CompanyName = updateShoe.CompanyName;
                    GetById.ModelName = updateShoe.ModelName;
                    GetById.Size = updateShoe.Size;
                    GetById.Price = updateShoe.Price;
                    dataContext.SubmitChanges();
                    return Ok("Updated successfully");
                }
                 return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ChildShoe/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                dataContext.Shoes.DeleteOnSubmit(dataContext.Shoes.First(item => item.Id == id));
                dataContext.SubmitChanges();
                return Ok("Removed successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
