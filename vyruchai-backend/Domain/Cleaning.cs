using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cleaning : Request
{
    public decimal areaOfSquareMeter { get; private set; }
    private decimal priceForOneSquareMeter = 8;

    public Cleaning()
    {
        Id = Guid.NewGuid();
        Status = RequestStatus.Created;
    }
    public override decimal CostCalculation(UrgencyLevel level)
    {
        return areaOfSquareMeter * priceForOneSquareMeter;
    }

    public override void Processing()
    {

    }
}
