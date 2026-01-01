using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CentralService
{
    private List<Request> requests;
    private List<IMaster> masters;

    public CentralService()
    {
        requests = new List<Request>();
        masters = new List<IMaster>();
    }
    public void CreateRequest(Request request)
    {
        requests.Add(request);
    }

    public void CreateMaster(IMaster master)
    {
        masters.Add(master);
    }

    public void TakeOneRequest(Request request, IMaster master)
    {
        if (master.CanHandle(request) == true)
        {
            request.AcceptedByMaster();
            master.TakeRequest();
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

