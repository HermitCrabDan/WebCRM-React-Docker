﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Data
{
    public interface ICRMDataContext
    {
        DbSet<T> Set<T>() where T: class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
