using ShopeShoesApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopeShoesApp.Controllers.api
{
    public class OutShoeController : ApiController
    {
        // GET: api/OutShoe
        OutShoeModel dbContext = new OutShoeModel();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { dbContext.OutShoe });
            }
            catch(SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/OutShoe/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
              OutShoes GetById = await dbContext.OutShoe.FindAsync(id);
              if (GetById!=null)
              {
                return Ok(new { GetById });
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
        // POST: api/OutShoe
        public async Task<IHttpActionResult> Post([FromBody]OutShoes newOutShoes)
        {
            try
            {
                dbContext.OutShoe.Add(newOutShoes);
                await dbContext.SaveChangesAsync();
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
        // PUT: api/OutShoe/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]OutShoes UpdateOutShoes)
        {
            try
            {
                OutShoes shoes = await dbContext.OutShoe.FindAsync(id);
                if (shoes != null)
                {
                    shoes.CompanyName = UpdateOutShoes.CompanyName;
                    shoes.Gender = UpdateOutShoes.Gender;
                    shoes.IfThereIsHeel = UpdateOutShoes.IfThereIsHeel;
                    shoes.IfThereIsInStock = UpdateOutShoes.IfThereIsInStock;
                    shoes.Size = UpdateOutShoes.Size;
                    shoes.Price = UpdateOutShoes.Price;
                    await dbContext.SaveChangesAsync();   
                return Ok("updated successfully");
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
        // DELETE: api/OutShoe/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                OutShoes RemoveById = await dbContext.OutShoe.FindAsync(id);
                if (RemoveById != null)
                {
                    dbContext.OutShoe.Remove(RemoveById);
                    await dbContext.SaveChangesAsync();
                return Ok("Removed successfully");
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
    }
}
