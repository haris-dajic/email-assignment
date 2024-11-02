using System.Net;
using System.Text.Json.Serialization;

namespace Application.Common.Models;

public class ApiResult
{
    public bool Succeeded { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? Errors { get; init; }
    public HttpStatusCode HttpStatusCode { get; init; }
    
    public static ApiResult Success()
    {
        return new ApiResult
        {
            HttpStatusCode = HttpStatusCode.OK,
            Succeeded = true
        };
    }
}

public class ApiResult<T> : ApiResult
{
    public T Data { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PaginationInfo PaginationInfo { get; set; }
    
    public ApiResult<T> WithData(T data)
    {
        Data = data;
        return this;
    }

    public ApiResult<T> WithMeta(PaginationInfo info)
    {
        PaginationInfo = info;
        return this;
    }
    
    public static ApiResult<T> Success()
    {
        return new ApiResult<T>
        {
            HttpStatusCode = HttpStatusCode.OK,
            Succeeded = true
        };
    }
}