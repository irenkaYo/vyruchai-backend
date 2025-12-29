using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IMaster
{
    public MasterStatus status { get; set; }

    public void TakeRequest();

    public void CompleteRequest();
}
