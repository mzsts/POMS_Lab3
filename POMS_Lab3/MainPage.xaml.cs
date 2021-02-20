using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POMS_Lab3.RESX;

namespace POMS_Lab3
{
    public partial class MainPage : ContentPage
    {
        private string name;
        private string surname;
        private int age = 0;
        private double width = 0;
        private double height = 0;
        private PageNumber pageNumber;
        public MainPage()
        {
            InitializeComponent();
            dataPicker.Date = DateTime.Now;
            pageNumber = new PageNumber();
        }
        async void ChangePageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(pageNumber);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(name))
                DisplayAlert(Resource.errorAlertTitle, Resource.errorAlertText, "ОК");
            else if (age == -1)
                DisplayAlert(name + " " + surname, Resource.alertIncorrectDoB, "ОК");
            else
            {
                DisplayAlert(name + " " + surname, Resource.alertText + age.ToString(), "ОК");
            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    entryStack.Orientation = StackOrientation.Horizontal;
                }
                else
                {
                    entryStack.Orientation = StackOrientation.Vertical;
                }
            }
        }
        void OnNameEntryCompleted(object sender, EventArgs e)
        {
            name = ((Entry)sender).Text;
        }

        void OnSurnameEntryCompleted(object sender, EventArgs e)
        {
            surname = ((Entry)sender).Text;
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            DateTime DateOfBorn = ((DatePicker)sender).Date;
            Calculateage(DateOfBorn);
        }

        void Calculateage(DateTime dateOfBorn)
        {
            if (dateOfBorn > DateTime.Now)
            {
                age = -1;
            }
            else
            {
                age = DateTime.Now.Year - dateOfBorn.Year;
            }
        }
    }
}
