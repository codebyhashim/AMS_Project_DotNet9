using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AM.ApplicationCore.Feature.Product.Commmand
{
    public class CreateProductCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Decimal Rate { get; set; }
        
    }
    internal class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        public  async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return 1;
        }
    }
}
