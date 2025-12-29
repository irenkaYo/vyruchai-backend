using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TechRepair : Request
{
    private decimal price = 100;
    private decimal allPersentage = 100;
    private decimal persentageForOneWeek = 20;
    private 
    public override decimal CostCalculation(UrgencyLevel level)
    {
        if (UrgencyLevel.WhenReady == level)
        {
            return price;
        }
        else
        {
            if (UrgencyLevel.InOneWeek == level)
            {
                return price * (allPersentage + persentageForOneWeek)/allPersentage;
            }
        }
    }
}

