using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCrud.Data;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    public class StudentsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (WebApiCrudDBEntities dbContext = new WebApiCrudDBEntities())
            {
                var student = dbContext.Students.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
        }
        public HttpResponseMessage Get(int id)
        {
            using (WebApiCrudDBEntities dbContext = new WebApiCrudDBEntities())
            {
                var emp = dbContext.Students.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Id" + id + "not found in dadtabase");
                }
            }
        }
        public HttpResponseMessage Post(Student employee)
        {
            using (WebApiCrudDBEntities dbContext = new WebApiCrudDBEntities())
            {
                if (employee != null)
                {
                    dbContext.Students.Add(employee);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, employee);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please provide proper input data to create an employee");
                }

            }

        }
        public HttpResponseMessage Put(int id, Student employee)
        {
            using (WebApiCrudDBEntities dbContext = new WebApiCrudDBEntities())
            {
                var emp = dbContext.Students.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.Gender = employee.Gender;
                    emp.City = employee.City;
                    emp.IsActive = employee.IsActive;
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with Id" + id + "not found in database updat failed.");
                }
            }

        }
        public HttpResponseMessage Delete(int id)
        {
            using (WebApiCrudDBEntities dbContext = new WebApiCrudDBEntities())
            {
                var emp = dbContext.Students.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    dbContext.Students.Remove(emp);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student woth Id" + id + "not found in database.Delete failed");
                }
            }

        }
    }
}
