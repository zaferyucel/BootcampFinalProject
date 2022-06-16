using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Application.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product was created successfully.";
        public static string ProductAddedError = "Product already exists";
        public static string ProductAddedFail = "Product creation failed";
        public static string ProductDoesNotExist = "Product Does Not Exist";
        public static string ProductCanNotBeBuy = "Product can not be buy";
        public static string ProductSold = "Product was bought";
        public static string ProductDelete = "Product deleted";
        public static string ProductDeleteError = "Product was not deleted";
        public static string ProductNameExist = "Product name is exist";
        public static string ProductUpdateSuccess = "Product updated successfully";


        #region Category Messages
        public static string CategoryAdded = "Category was created successfully.";
        public static string CategoryAddedError = "Category could not be created.";
        public static string CategoryNotFound = "Category not found";
        public static string CategoryDeleted = "Category deleted";
        public static string CategoryUpdated = "Category was updated";

        #endregion

        public static string OfferCreateProductNotExist = " Product Does Not Exist";
        public static string OfferCreateError = "No offer can be made for the product.";
        public static string OfferCreateSuccess = "Offer was created successfully";
        public static string OfferFail = "Offer was not created";
        public static string OfferUpdated = "Offer was updated.";
        public static string OfferDeleted = " Offer was deleted";


        public static string RequestEmpty = "Request is empty";


        public static string AuthenticationError = "Authentication Error!";
        public static string UsernameOrPasswordError = "Username or password is wrong!";
        public static string UserCreateError = "An unexpected error was encountered while creating the user!";

    }
}
