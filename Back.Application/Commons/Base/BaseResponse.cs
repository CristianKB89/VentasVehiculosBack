using FluentValidation.Results;

namespace Back.Application.Commons.Base
{
    public class BaseResponse<T>
    {
        public bool IsSucces { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
