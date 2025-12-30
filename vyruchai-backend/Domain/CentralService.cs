using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CentralService
{
    private List<Request> Requests = new List<Request>();
    private List<IMaster> Masters = new List<IMaster>();

    public void CreateRequest(Request request)
    {
        Requests.Add(request);
    }

    public void CreateMaster(IMaster master)
    {
        Masters.Add(master);
    }

    public void TakeOneRequest(Request request, IMaster master)
    {
        if (master.CanHandle(request) == true)
        {
            request.AcceptedByMaster();
        }
        else
        {
            request.CancelRequest();
        }
    }

    public void CompleteRequestByMaster(Request request, IMaster master)
    {
        master.CompleteRequest();
        request.CompletedByMaster();
    }
}

