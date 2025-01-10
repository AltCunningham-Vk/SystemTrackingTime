using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using App.Data;
using App.Models;

namespace App.Services
{
    public class AuthService
    {
        private readonly TimeTrackingSystemContext _context;

        public AuthService()
        {
            _context = new TimeTrackingSystemContext();
        }

        public bool Authenticate(string username, string password)
        {
            var admin = _context.Admins.SingleOrDefault(a => a.Username == username);
            
            // используй
            // return admin == null || admin.Passwordhash != password

            if (admin == null || admin.Passwordhash != password)
            {
                return false;
            }

            return true;
        }
    }
}
