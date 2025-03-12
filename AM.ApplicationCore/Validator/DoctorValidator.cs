using AM.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AM.ApplicationCore.Validator
{
    public class DoctorValidator : AbstractValidator<DoctorModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
        private const int _maxFileSize = 5 * 1024 * 1024; // 2MB
        public DoctorValidator()
        {

            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.");

           // RuleFor(d => d.ImageFile)
           //.NotNull().WithMessage("Please upload an image.")
           //.Must(file => file != null && IsValidFileType(file))
           //.WithMessage("Only JPG, PNG, GIF files are allowed.")
           //.Must(file => file != null && IsValidFileSize(file))
           //.WithMessage($"Maximum allowed file size is {_maxFileSize / (1024 * 1024)}MB.");
            // Validate File Type


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email  is required")
                .EmailAddress().WithMessage("Please provide a valid email address");

            RuleFor(x => x.WaitTime)
            .NotEmpty().WithMessage("WaitTime  is required");
            RuleFor(x => x.Speciality).NotEmpty().WithMessage("Speciality  is required")
             .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.");



            // ✅ Image should only be required when creating a new doctor
            RuleFor(x => x.ImageFile)
                .Must((model, image) => image != null || !string.IsNullOrEmpty(model.ImagePath))
                .WithMessage("Image is required.");

            RuleFor(x => x.ImageFile)
                .Must(BeAValidFile).When(x => x.ImageFile != null)
                .WithMessage("Invalid image format.");

            RuleFor(x => x.ImageFile)
                .Must(BeValidSize).When(x => x.ImageFile != null)
                .WithMessage("Image size must be less than 5MB.");



            //RuleFor(x => x.AvailabilityDays)
            //.NotEmpty().WithMessage("AvailabilityDays  is required");

            RuleFor(x => x.AvailabilityDays)
             .NotEmpty().WithMessage("Please select at least one day.")  // Ensure that at least one day is selected
             .Must(days => days != null && days.Any()).WithMessage("At least one day must be selected."); // Checks if there are any selected days

            RuleFor(x => x.AvailabilityTimeSlot)
            .NotEmpty().WithMessage("AvailabilityHours  is required");

            RuleFor(x => x.City)
            .NotEmpty().WithMessage("City  is required")
            .MaximumLength(100).WithMessage("City can't be longer than 100 characters.");



            RuleFor(x => x.Degree)
            .NotEmpty().WithMessage("Degree is required")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.");

            RuleFor(x => x.Experience)
           .NotEmpty().WithMessage("Experience is required");


            RuleFor(x => x.Address)
          .NotEmpty().WithMessage("Address is required");


            RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Experience is required")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .Matches(@"^03[0-9]{9}$").WithMessage("Please enter a valid Pakistan mobile number starting with 03 followed by 9 digits.");

            RuleFor(x => x.Description)
           .NotEmpty().WithMessage("Description is required")
           .MaximumLength(300).WithMessage("Description can't be longer than 300 characters.");
        }

        private bool BeAValidFile(IFormFile file)
        {
            if (file == null) return true; // Skip validation if no new file is uploaded
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            return allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower());
        }

        private bool BeValidSize(IFormFile file)
        {
            if (file == null) return true; // Skip validation if no new file is uploaded
            return file.Length <= 5 * 1024 * 1024; // 5MB max size
        }
    }
}


//private bool IsValidFileType(IFormFile file)
//{
//    var extension = Path.GetExtension(file.FileName).ToLower();
//    return _allowedExtensions.Contains(extension);
//}

//// Validate File Size
//private bool IsValidFileSize(IFormFile file)
//{
//    return file.Length <= _maxFileSize;
//}