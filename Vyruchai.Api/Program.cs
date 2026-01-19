var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var service = new CentralService();
var master = new DeliveryMaster("Попа");
var master2 = new TechMaster("okak");
service.AddMaster(master);
service.AddMaster(master2);
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
        decimal sum = decimal.Parse(requestDto.Parameters[0]);
        request = new Delivery(sum);
    }
    else if (requestDto.RequestType == "cleaning")
    {
        decimal square = decimal.Parse(requestDto.Parameters[0]);
        request = new Cleaning(square);
    }
    else if (requestDto.RequestType == "techrepair")
    {
        string content = requestDto.Parameters[0];
        UrgencyLevel level = (UrgencyLevel)Enum.Parse(typeof(UrgencyLevel), requestDto.Parameters[1]);
        request = new TechRepair(content, level);
    }
    else
    {
        throw new Exception("Unknown request type");
    }
    bool success = service.TakeRequest(request);
    if (success)
    {
        decimal result = request.CostCalculation();
        TakeRequestResponseDto response = new TakeRequestResponseDto(request.Id, request.Master.Name, request.Status, result);
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