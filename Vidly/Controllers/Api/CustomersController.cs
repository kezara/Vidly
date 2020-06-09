using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Get /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDtos);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
            return Ok (Mapper.Map<Customer, CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer (CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer (int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDTO, customerInDb);

            //customerInDb.Name = customer.Name;
            //customerInDb.Birthdate = customer.Birthdate;
            //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //    //throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
