var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var service = new CentralService();
var master = new DeliveryMaster("Попа");
service.AddMaster(master);
app.MapGet("get_request_info/{id:guid}", (Guid id) =>
{
    RequestStatus status = service.GetRequestStatus(id);
    return status.ToString();
});

app.MapPost("take_request", (TakeRequestDto requestDto) =>
{
    Request request;
    if (requestDto.RequestType == "delivery")
    {
        request = new Delivery(); 
    }
    else if (requestDto.RequestType == "cleaning")
    {
        request = new Cleaning();
    }
    else if (requestDto.RequestType == "techrepair")
    {
        request = new TechRepair();
    }
    else
    {
        throw new Exception("Unknown request type");
    }
    bool success = service.TakeRequest(request);
    if (success)
    {
        TakeRequestResponseDto response = new TakeRequestResponseDto(request.Id, request.Master.Name, request.Status);
        return response; 
    }
    else
    {
        TakeRequestResponseDto response = new TakeRequestResponseDto(request.Id, "None", request.Status);
        return response;
    }
});

app.MapGet("complete_request/{id:guid}", (Guid id) =>
{
    Request request = service.GetRequestById(id);
    service.CompleteRequest(request);
    return request.Status.ToString();
});

app.Run();