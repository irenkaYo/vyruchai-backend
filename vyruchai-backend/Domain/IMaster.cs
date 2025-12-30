using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMaster
{
    public MasterStatus Status { get; protected set; }
    public string Name { get; protected set; }

    protected void TakeRequest();

    public void CompleteRequest();

    public bool CanHandle(Request request);
}
