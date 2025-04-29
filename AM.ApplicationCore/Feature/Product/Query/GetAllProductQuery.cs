using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AM.ApplicationCore.Feature.Product.Query
{
    public class GetAllProductQuery : IRequest<List<Product>>
    {

        internal class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Product>>
        {
            public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var product = new List<Product>();
                for (int i = 0; i < 50; i++)
                {
                    var prod = new Product();
                    prod.Name = "hashim";
                    prod.Description = "dlfkaklavkjbf akjsdnv akjdf ";
                    prod.Rate = 100 + i;
                    product.Add(prod);

                }
                return product;
            }
        }
    }
    public class Product
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Decimal Rate { get; set; }

    }
}