using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseAccess;

namespace YouLendProject.Controllers
{
    public class DatabaseController : ApiController
    {
        public IEnumerable<Lend> GetAllLoans()
        {
            using (databaseEntities dbEntities = new databaseEntities())
            {
                return dbEntities.Lends.ToList();
            }
        }

        public Lend GetLoan(int id)
        {
            using (databaseEntities dbEntities = new databaseEntities())
            {
                return dbEntities.Lends.FirstOrDefault(loanId => loanId.Id == id);
                
                /*if(dbEntities != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, dbEntity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no loan associated with the requested id: " + id.ToString());
                }
                */
            }
        }

        [HttpPost]
        public HttpResponseMessage AddLoan([FromBody]Lend loan)
        {
            try
            {
                using (databaseEntities dbEntities = new databaseEntities())
                {
                    //add to database
                    dbEntities.Lends.Add(loan);
                    dbEntities.SaveChanges();

                    //get the response code of 201 for successful post and return the newly added loan
                    var message = Request.CreateResponse(HttpStatusCode.Created, loan);
                    message.Headers.Location = new Uri(Request.RequestUri + loan.Id.ToString());

                    return message;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }

        public HttpResponseMessage DeleteLoan(int id)
        {
            try
            {
                using (databaseEntities dbEntities = new databaseEntities())
                {
                    var entity = dbEntities.Lends.FirstOrDefault(loanId => loanId.Id == id);

                    if (entity != null)
                    {
                        //remove from database
                        dbEntities.Lends.Remove(entity);
                        dbEntities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no loan associated with the requested id: " + id.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
