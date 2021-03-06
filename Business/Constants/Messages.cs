using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "The car has been successfully added.";
        public static string CarNameInvalid = "The car name is invalid.";
        public static string CarUpdated = "The car has been successfully updated.";
        public static string CarsListed = "The cars have been listed.";
        public static string CarsNotListed = "The cars could not be listed.";
        public static string CarDetailsListed = "The car details have been listed.";
        public static string CarIdInvalid = "The car ID is invalid.";
        public static string CarPriceInvalid = "The car price is invalid.";
        public static string BrandIdInvalid = "The brand ID is invalid.";
        public static string ColorIdInvalid = "The color ID is invalid.";
        public static string UserAdded = "User is successfully added.";
        public static string UserNotAdded = "User could not be added.";
        public static string UserDeleted = "User is successfully deleted.";
        public static string UserNotDeleted = "User could not be deleted.";
        public static string UserUpdated = "User is successfully updated.";
        public static string CustomerAdded = "Customer is successfully added.";
        public static string CustomerNotAdded = "Customer could not be added.";
        public static string CustomerDeleted = "Customer is successfully deleted.";
        public static string CustomerNotDeleted = "Customer could not be deleted.";
        public static string CustomerUpdated = "Customer is successfully updated.";
        public static string RentedListed = "All rented cars are listed.";
        public static string NotRentedListed = "All available cars are listed";
        public static string RentAdded = "New rent has been added";
        public static string RentNotAdded = "New rent can not be added";
        public static string RentDeleted = "A rent has been deleted";
        public static string RentUpdated = "A rent has been updated";
        public static string CannotBeListed = "This list cannot be listed.";
        public static string MaxImageCount = "Max image count for this car has been reached.";
        public static string ImageAdded = "Image has been added.";
        public static string ImageDeleted = "Image has been deleted.";
        public static object ImagesShown = "Images have been listed." ;
        public static string ImageUpdated = "Images have been updated.";
        public static string ImageNotAdded = "Image cannot be added.";
        public static string AuthorizationDenied = "Authorization denied.";
        public static string UserRegistered = "User successfully created.";
        public static string UserNotFound = "User could not be found.";
        public static string PasswordError = "Password is invalid.";
        public static string SuccessfulLogin = "You have logged in successfully.";
        public static string AccessTokenCreated = "Access Token created.";
        public static string UserAlreadyExists = "User already exists.";
    }
}
