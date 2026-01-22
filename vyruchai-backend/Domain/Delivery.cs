using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Delivery : Request
{
    public decimal SumForDelivery { get; private set; }
    private decimal sumForFreeDelivery = 50;
    private decimal sumOfDelivery = 20;

    public Delivery(decimal sumForDelivery)
    {
        Id = Guid.NewGuid();
        Status = RequestStatus.Created;
        SumForDelivery = sumForDelivery;
    }
    public override decimal CostCalculation()
    {
        if (SumForDelivery >= sumForFreeDelivery)
        {
            return SumForDelivery;
        }
        else
        {
            return sumOfDelivery + SumForDelivery;
        }
    }
}

