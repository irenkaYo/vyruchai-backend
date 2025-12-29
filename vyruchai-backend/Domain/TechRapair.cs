using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TechRepair : Request
{
    private decimal price = 100;
    private decimal allPercentage = 100;
    private decimal percentageForOneWeek = 20;
    private decimal percentageForOneHour = 50;
    public override decimal CostCalculation(UrgencyLevel level)
    {
        if (UrgencyLevel.WhenReady == level)
        {
            return price;
        }
        else if (UrgencyLevel.InOneWeek == level)
        {
            return price * (allPercentage + percentageForOneWeek) / allPercentage;
        }
        else if (UrgencyLevel.InOneHour == level)
        {
            return price * (allPercentage + percentageForOneHour) / allPercentage;
        }
        throw new Exception("");
    }

    public override void Processing()
    {

    }

}
