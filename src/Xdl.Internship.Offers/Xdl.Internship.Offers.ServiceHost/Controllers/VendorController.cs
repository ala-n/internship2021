﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Controller]
    [Route("api/vendors")]
    public class VendorController : ControllerBase
    {
        private readonly VendorRepository _vendorRepository;

        public VendorController(VendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Vendor>> GetAll()
        {
            var vendors = await _vendorRepository.FindAsync((Vendor v) => true);
            return vendors.ToArray();
        }
    }
}
