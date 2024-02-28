using Back.Application.Dtos.Request;
using FluentValidation;

namespace Back.Application.Validators.Clientes
{
    public class ClientesValidator : AbstractValidator<ClienteRequestDto>
    {
        public ClientesValidator()
        {
            RuleFor(x => x.Nombre)
                .NotNull().WithMessage("El campo nombre de cliente no puede ser null")
                .NotEmpty().WithMessage("El campo nombre de cliente no puede ser vacio");
            RuleFor(x => x.Email)
                .NotNull().WithMessage("El campo email de cliente no puede ser null")
                .NotEmpty().WithMessage("El campo email de cliente no puede ser vacio");
        }
    }
}
