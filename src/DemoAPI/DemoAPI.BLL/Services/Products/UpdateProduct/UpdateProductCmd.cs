using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.BLL.Services.Products.UpdateProduct
{
    public class UpdateProductCmd : IRequest
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }

    public class UpdateProductValidator : AbstractValidator<UpdateProductCmd>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty()
                                .MaximumLength(100);
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
