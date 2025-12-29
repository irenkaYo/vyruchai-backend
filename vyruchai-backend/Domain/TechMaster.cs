using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TechMaster : IMaster
{
    public MasterStatus Status { get; set; } = MasterStatus.IsFree;

    public void TakeRequest()
    {
        Status = MasterStatus.IsBusy;
    }

    public void CompleteRequest()
    {
        Status = MasterStatus.IsBusy;
    }

}

