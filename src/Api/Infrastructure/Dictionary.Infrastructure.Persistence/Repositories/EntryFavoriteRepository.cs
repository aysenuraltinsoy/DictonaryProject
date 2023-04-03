﻿using Dictionary.Api.Application.Interfaces.Repositories;
using Dictionary.Api.Domain.Models;
using Dictionary.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Infrastructure.Persistence.Repositories
{
    public class EntryFavoriteRepository : GenericRepository<EntryFavorite>, IEntryFavoriteRepository
    {
        protected EntryFavoriteRepository(DictionaryContext dbContext) : base(dbContext)
        {
        }
    }
}
