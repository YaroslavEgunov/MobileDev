using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.IO;
using NativeMedia;

namespace Lab3
{
    public partial class MainPage : ContentPage
    {
        Image img;
        Button takePhotoBtn;
        Button getPhotoBtn;
        Button galPhotoBtn;
        public MainPage()
        {
            //InitializeComponent();
            takePhotoBtn = new Button { Text = "Сделать фото" };
            getPhotoBtn = new Button { Text = "Выбрать фото" };
            galPhotoBtn = new Button { Text = "Сохранить" };
            img = new Image();

            // выбор фото
            getPhotoBtn.Clicked += GetPhotoAsync;

            // съемка фото
            takePhotoBtn.Clicked += TakePhotoAsync;

            galPhotoBtn.Clicked += TakePhotoButton_Clicked;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    new StackLayout
                    {
                         Children = {takePhotoBtn, getPhotoBtn, galPhotoBtn},
                         Orientation =StackOrientation.Horizontal,
                         HorizontalOptions = LayoutOptions.CenterAndExpand
                    },
                    img
                }
            };
        }

        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                // для примера сохраняем файл в локальном хранилище
                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                // загружаем в ImageView
                img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void TakePhotoButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    var savedPhotoPath = await SavePhotoToGallery(photo);

                    // Показать путь к сохраненной фотографии
                    await DisplayAlert("Success", $"Photo saved to: {savedPhotoPath}", "OK");
                }
            }
            catch (Exception ex)
            {
                // Обработать ошибку, если не удалось сохранить фотографию
                await DisplayAlert("Error", $"Failed to save photo: {ex.Message}", "OK");
            }
        }

        private async Task<string> SavePhotoToGallery(FileResult photo)
        {
            var fileName = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

            using (var stream = await photo.OpenReadAsync())
            using (var outputStream = File.OpenWrite(fileName))
            {
                await stream.CopyToAsync(outputStream);
            }

            // Сохранение фотографии в галерею устройства
            var savedPhotoPath = await MediaGallery.SavePhoto(fileName, "MyPhotos");

            return savedPhotoPath;
        }
    }
}
