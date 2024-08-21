namespace Core.Application.Authorization;

public interface ISecuredRequest
{
    public string[] Roles { get; }
}