using Core.Entities.Concrete;

namespace Business.Constants;

public static class Messages
{
    public const string CarAdded = "Car added.";
    public const string CarNameInvalid = "Car name invalid.";
    public const string CarsListed = "Cars listed.";
    public const string CarDeleted = "Car deleted.";
    public const string CarUpdated = "Car updated.";
    public const string RentalAdded = "Rental added.";
    public const string RentalDeleted = "Rental deleted.";
    public const string RentalUpdated = "Rental updated.";
    public const string RentalsListed = "Rentals listed.";
    public const string RentalNotAdded = "Rental operation failed because the car has not been returned from a previous rental.";
    public const string RentalNotAvailable = "Rental operation failed because the car is not available.";
    public const string BrandAdded = "Brand added.";
    public const string BrandDeleted = "Brand deleted.";
    public const string BrandUpdated = "Brand updated.";
    public const string BrandsListed = "Brands listed.";
    public const string BrandNameInvalid = "Brand name should be at least 2 characters.";
    public const string CustomerAdded = "Customer added.";
    public const string CustomerDeleted = "Customer deleted.";
    public const string CustomerUpdated = "Customer updated.";
    public const string CustomersListed = "Customers listed.";
    public const string ColorAdded = "Color added.";
    public const string ColorDeleted = "Color deleted.";
    public const string ColorUpdated = "Color updated.";
    public const string ColorsListed = "Colors listed.";
    public const string ColorNameInvalid = "Color name should be at least 2 characters.";
    public const string CarImageAdded = "Car image added.";
    public const string CarImageNotFound = "Car image not found.";
    public const string CarImageDeleted = "Car image deleted.";
    public const string CarImageUpdated = "Car image updated.";
    public const string CarImagesListed = "Car images listed.";
    public const string ImageLimitExceeded = "Image limit exceeded.";
    public const string InvalidImageExtension = "Invalid image extension.";
    public const string  UserAdded = "User added.";
    public const string UserRegistered = "User registered.";
    public const string UserNotFound = "User not found.";
    public const string PasswordError = "Password error.";
    public const string SuccessfulLogin = "Successful login.";
    public const string UserAlreadyExists = "User already exists";
    public const string AccessTokenCreated = "Access token created."; 
    public const string AuthorizationDenied = "Authorization denied.";
    public static readonly string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
}