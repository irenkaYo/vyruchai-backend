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
    public void AddRequest(Request request)
    {
        requests.Add(request);
    }

    public void AddMaster(IMaster master)
    {
        masters.Add(master);
    }

    public RequestStatus GetRequestStatus(Guid id)
    {
         return GetRequestById(id).Status;
    }

    public Request GetRequestById(Guid id)
    {
        foreach(Request request in requests)
        {
            if (request.Id == id)
                return request;
        }
        throw new Exception("There is no requests with this ID");
    }
    public bool TakeRequest(Request request)
    {
        foreach (IMaster master in masters)
        {
            if (master.CanHandle(request) == true)
            {
                AddRequest(request);
                request.AcceptedByMaster(master);
                master.TakeRequest();
                return true;
            }
        }
        request.CancelRequest();
        return false;
    }

    public void CompleteRequest(Request request)
    {
        request.Master.CompleteRequest();
        request.CompletedByMaster();
    }
}

