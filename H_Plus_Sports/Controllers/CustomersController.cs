using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H_Plus_Sports.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_Plus_Sports.Controllers
{
    //controller decorated with 2 annotations
    [Produces("application/json")]// produces json
    [Route("api/Customers")] //route to this controller
    public class CustomersController : Controller
    {
        //connect controller to models to get data from database
        //build a constructor and inject DbContext through constructor
        //Create private variable containing ref to DbContext that actions can use

        private readonly H_Plus_SportsContext _context;

        public CustomersController(H_Plus_SportsContext context)
        {
            _context = context;
        }

        //add five methods to controller

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return new ObjectResult(_context.Customer);
        }

        [HttpGet("{id}", Name = "GetCustomer")] // get particular customer with given id
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.CustomerId == id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")] //update customer of id
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpDelete("{id}")] // delete customer of id 
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.CustomerId == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

    }// end controller
}//end class