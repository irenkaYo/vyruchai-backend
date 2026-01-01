
public class TakeRequestResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }

    public TakeRequestResponseDto(Guid id, string name, RequestStatus status)
    {
        Id = id;
        Name = name;
        Status = status.ToString();
    }
}

