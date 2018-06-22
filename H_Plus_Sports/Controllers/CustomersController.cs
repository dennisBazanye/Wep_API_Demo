using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H_Plus_Sports.Controllers
{
    //decorated with 2 annotations
    [Produces("application/json")]// produces json
    [Route("api/Customers")] //route to this controller
    public class CustomersController : Controller
    {
        //build a constructor and inject DbContext
        public CustomersController()
        {

        }

        //add five methods to controller

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return Ok();
        }

        [HttpGet("{id}")] // get particular customer with given id
        public IActionResult GetCustomer([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Object obj)
        {
            return Ok();
        }

        [HttpPut("{id}")] //update customer of id
        public IActionResult PutCustomer([FromRoute] int id, [FromBody] Object obj)
        {
            return Ok();
        }

        [HttpDelete("{id}")] // delete customer of id 
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            return Ok();
        }

    }// end controller
}//end class