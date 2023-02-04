﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
  public class CryptoTestContext :IdentityDbContext<IdentityUser>
  {
        public CryptoTestContext(DbContextOptions<CryptoTestContext> options)
            :base(options)
        {
            
        }
  }
}
