﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Banking_WebAPI_Practice_Project.Data;
using Banking_WebAPI_Practice_Project.Models;

namespace Banking_WebAPI_Practice_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Banking_WebAPI_Practice_ProjectContext _context;

        public CustomersController(Banking_WebAPI_Practice_ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.ID)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'Banking_WebAPI_Practice_ProjectContext.Customer'  is null.");
          }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.ID }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        [HttpPut("{type}")]
        public async Task<IActionResult> AddAccount(string type, Account acc) {
        if (type == "CK"||type == "ck") {
            acc.Type = "CK";
            acc.InterestRate = 0;
        } else if (type == "SV"||type == "sv") {
            acc.Type = "SV";
            if (acc.InterestRate == 0) {
            acc.InterestRate = 0.01m;
            }
        }
        AccountsController ACC = new(_context);
        await ACC.PostAccount(acc);
        return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> CloseAccount(int Id) {
            AccountsController ACC = new(_context);
            await ACC.DeleteAccount(Id);
            return NoContent();
        }
    }
}
