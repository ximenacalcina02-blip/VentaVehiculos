using FluentValidation;

namespace VentaDeVehiculo.DTO.Cliente.AgregarCliente
{
    public class AgregarClienteValidator : AbstractValidator<AgregarClienteInput>
    {
        public AgregarClienteValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio");

            RuleFor(x => x.Ci)
                .GreaterThan(0).WithMessage("El CI debe ser válido");

            RuleFor(x => x.Extension)
                .MaximumLength(5);
        }
    }
}