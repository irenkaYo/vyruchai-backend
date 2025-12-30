using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Delivery : Request
{
    public decimal sumForDelivery { get; private set; }
    private decimal sumForFreeDelivery = 50;
    private decimal sumOfDelivery = 20;

    public Delivery()
    {
        Id = Guid.NewGuid();
        Status = RequestStatus.Created;
    }
    public override decimal CostCalculation(UrgencyLevel level)
    {
        if (sumForDelivery >= sumForFreeDelivery)
        {
            return sumForDelivery;
        }
        else
        {
            return sumOfDelivery + sumForDelivery;
        }
    }

    public override void Processing()
    {

    }
}

