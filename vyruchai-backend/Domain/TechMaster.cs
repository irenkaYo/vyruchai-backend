using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TechMaster : IMaster
{
    public MasterStatus Status { get; set; }
    public string Name { get; set; }
    public TechMaster(string name)
    {
        Status = MasterStatus.IsFree;
        Name = name;
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
        if (request is TechRepair && Status == MasterStatus.IsFree)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

