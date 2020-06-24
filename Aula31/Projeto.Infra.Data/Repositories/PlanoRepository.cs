﻿using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Infra.Data.Repositories
{
    public class PlanoRepository : BaseRepository<PlanoEntity>, IPlanoRepository
    {
        private readonly DataContext context;
        public PlanoRepository(DataContext context)
        : base(context)
        {
            this.context = context;
        }
    }
}