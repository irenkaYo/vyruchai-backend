using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeliveryMaster : IMaster
{
    public MasterStatus Status { get; set; }
    public string Name { get; set; }

    public DeliveryMaster(string name)
    {
        Name = name;
        Status = MasterStatus.IsFree;
    }
    public void TakeRequest()
    {
        Status = MasterStatus.IsBusy;
    }

    public void CompleteRequest()
    {
        Status = MasterStatus.IsFree;
    }

    public bool CanHandle(Request request)
    {
        if (request is Delivery && Status == MasterStatus.IsFree)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
