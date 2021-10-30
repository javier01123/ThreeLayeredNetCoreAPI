﻿using DemoAPI.DAL;
using DemoAPI.DAL.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Categories.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCmd>
    {
        DemoAPIContext _ctx;

        public CreateCategoryHandler(DemoAPIContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Unit> Handle(CreateCategoryCmd request, CancellationToken cancellationToken)
        {
            var newCategory = new Category()
            {
                Name = request.Name
            };

            _ctx.Add(newCategory);
            await _ctx.SaveChangesAsync();
            return Unit.Value;
        }
    }
}