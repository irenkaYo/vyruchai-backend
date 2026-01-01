using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Request
{
    public Guid Id { get; protected set; }
    public RequestStatus Status { get; protected set; }
    public IMaster Master { get; protected set; }

    public abstract decimal CostCalculation(UrgencyLevel level);

    public void CancelRequest()
    {
        Status = RequestStatus.Canceled;
    }

    public void AcceptedByMaster(IMaster master)
    {
        Status = RequestStatus.InWork;
        Master = master;
    }

    public void CompletedByMaster()
    {
        Status = RequestStatus.Done;
    }
}
