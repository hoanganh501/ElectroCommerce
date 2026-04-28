using FluentValidation;


namespace ElectroCommerce.Application.Request
{
    public class CreateProductRequest
    {
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public List<CreateVariantRequest> Variants { get; set; }
        public List<ProductSpecificationRequest> Specifications { get; set; }
    }

    //public class CreateProductRequestValidator: AbstractValidator<CreateProductRequest>
    //{
    //    public CreateProductRequestValidator()
    //    {
    //        RuleFor(x => x.BrandId)
    //            .NotEmpty();

    //        RuleFor(x => x.CategoryId)
    //            .NotEmpty();

    //        RuleFor(x => x.Name)
    //            .NotEmpty()
    //            .MaximumLength(3);
    //    }
    //}
}
