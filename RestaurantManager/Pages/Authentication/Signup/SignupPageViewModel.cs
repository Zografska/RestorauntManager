using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Storage;
using Prism.Navigation;
using RestaurantManager.Core.Authentication;
using RestaurantManager.Extensions;
using RestaurantManager.Pages.Base;
using RestaurantManager.Services;
using RestaurantManager.Services.Network;
using RestaurantManager.Utility;
using Xamarin.Essentials;
using Xamarin.Forms;
using XCT.Popups.Prism;

namespace RestaurantManager.Pages.Authentication.Signup
{
    public class SignupPageViewModel : PageViewModelBase
    {
        private readonly IProfileService _profileService;
        public ICommand SignUpCommand { get; }
        public ICommand UploadPhotoCommand { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        
        public SignupPageViewModel(INavigationService navigationService, IPopupService popupService,
            IAuthService authService, IProfileService profileService, INetworkService networkService)
            : base(navigationService, popupService, authService, networkService)
        {
            SignUpCommand = new SingleClickCommand(SignUpUser);
            UploadPhotoCommand = new SingleClickCommand(UploadPhoto);
            _profileService = profileService;
        }

        private async void SignUpUser()
        {
            if (Name.IsNullOrEmpty() || Surname.IsNullOrEmpty() || Password.IsNullOrEmpty() || Email.IsNullOrEmpty())
            {
                DisplayAlert("Fill in all the blanks");
                return;
            }
            if (NetworkService.IsNetworkConnected())
            {
                var result = await AuthService.SignUpWithEmailPassword(Email, Password);
                if (!result.IsNullOrEmpty())
                {
                    _ = _profileService.CreateUser(result, Name, Surname, Email, PhotoUrl);
                }
                var resultMessage = !result.IsNullOrEmpty() ? "User is successfully signed in" : "User is not signed in";
                DisplayAlert(resultMessage);
            }
            else
            {
                DisplayAlert(Constants.AlertConstants.NoInternet);
            }
            await NavigationService.GoBackAsync();
        }

        private async void UploadPhoto()
        {
            await TakePhotoAsync();
            await NavigationService.GoBackAsync();
        }

        private async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                return;
            }
            //save the photo to firebaseStorage
            var task = new FirebaseStorage("restaurantmanagerdb.appspot.com",
                    new FirebaseStorageOptions
                    {
                        ThrowOnCancel = true
                    })
                .Child(photo.FileName)
                .PutAsync(await photo.OpenReadAsync());

            PhotoUrl = await task;
        }
        private async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {photo.FullPath}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                DisplayAlert(Constants.FeatureConstants.FeatureNotImplemented);
            }
            catch (PermissionException pEx)
            {
                DisplayAlert(Constants.FeatureConstants.PermissionsNotGranted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }
    }
}