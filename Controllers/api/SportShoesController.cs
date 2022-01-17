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
    public class SportShoesController : ApiController
    {
        static string connectionString = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=ShoesDB;Integrated Security=True;Pooling=False";
        static List<SportShoe> sportShoesList = new List<SportShoe>();
        // GET: api/SportShoes
        public IHttpActionResult Get()
        {
            try
            {

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var qury = @"SELECT * FROM Shoe";
                    SqlCommand commandd = new SqlCommand(qury,connection);
                    SqlDataReader execute = commandd.ExecuteReader();
                    if (execute.HasRows)
                    {
                        while (execute.Read())
                        {
                            sportShoesList.Add(new SportShoe(execute.GetInt32(0), execute.GetString(1), execute.GetString(2), execute.GetInt32(3), execute.GetInt32(4)));
                        }
                     connection.Close();
                     return Ok(new {sportShoesList});
                    }
                     connection.Close();
                    return NotFound();
                }

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

        // GET: api/SportShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                SportShoe sport = new SportShoe();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var qury = $@"SELECT * FROM Shoe WHERE Id={id}";
                    SqlCommand Command = new SqlCommand(qury,connection);
                    SqlDataReader execute = Command.ExecuteReader();
                    if (execute != null)
                    {
                    while (execute.Read())
                    {
                         SportShoe shoe = new SportShoe(execute.GetInt32(0),execute.GetString(1),execute.GetString(2),execute.GetInt32(3),execute.GetInt32(4));
                         connection.Close();
                         return Ok(new { shoe });
                    }
                    }
                    connection.Close();
                    return NotFound();

                }
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

        // POST: api/SportShoes
        public IHttpActionResult Post([FromBody]SportShoe newShoe)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    connection.Open();
                    var qury = $@"INSERT INTO Shoe (companyName,modelName,size,price)VALUES('{newShoe.companyName}','{newShoe.modelName}',{newShoe.size},{newShoe.price})";
                    SqlCommand sql = new SqlCommand(qury,connection);
                    sql.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Added successfully");
                }
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

        // PUT: api/SportShoes/5
        public IHttpActionResult Put(int id, [FromBody]SportShoe updateShoe)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var qury = $@"UPDATE Shoe
                                  SET 
                                     companyName='{updateShoe.companyName}',
                                     modelName='{updateShoe.modelName}',
                                     size={updateShoe.size},
                                     price={updateShoe.price}
                                 WHERE Id = {id}";
                    SqlCommand sql = new SqlCommand(qury, connection);
                    sql.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Updated successfully");
                }
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

        // DELETE: api/SportShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var qury = $@"DELETE FROM Shoe WHERE Id ={id}";
                    SqlCommand sql = new SqlCommand(qury, connection);
                    sql.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Removed successfully");
                }
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
