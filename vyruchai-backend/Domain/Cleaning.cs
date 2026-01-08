using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cleaning : Request
{
    public decimal AreaOfApartment { get; private set; }
    private decimal priceForOneSquareMeter = 8;

    public Cleaning(decimal areaOfSquareMeter)
    {
        Id = Guid.NewGuid();
        Status = RequestStatus.Created;
        AreaOfApartment = areaOfSquareMeter;
    }
    public override decimal CostCalculation()
    {
        return AreaOfApartment * priceForOneSquareMeter;
    }
}
