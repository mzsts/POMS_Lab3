using System;
using POMS_Lab3.RESX;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POMS_Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageNumber : ContentPage
    {
        private int num;
        private double width = 0;
        private double height = 0;
        public PageNumber()
        {
            InitializeComponent();
        }
        async void ChengePageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
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
                    buttonStack.Orientation = StackOrientation.Horizontal;
                    var btns = buttonStack.Children;
                    foreach (Button btn in btns)
                        btn.HorizontalOptions = LayoutOptions.FillAndExpand;
                }
                else
                {
                    buttonStack.Orientation = StackOrientation.Vertical;
                    var btns = buttonStack.Children;
                    foreach (Button btn in btns)
                        btn.HorizontalOptions = LayoutOptions.Center;
                }
            }
        }
        private void AddButton_Clicked(object sender, EventArgs e)
        {
            labelResult.Text = (num + 2).ToString();
        }

        private void MulButton_Clicked(object sender, EventArgs e)
        {
            labelResult.Text = (num * 2).ToString();
        }

        private void SqrButton_Clicked(object sender, EventArgs e)
        {
            labelResult.Text = (num * num).ToString();
        }

        private void EntryNumber_Completed(object sender, EventArgs e)
        {
            try
            {
                num = Convert.ToInt32(entryNumber.Text);
            }
            catch (Exception)
            {
                DisplayAlert(Resource.errorAlertTitle, Resource.enrtyNumberExeptionText, "OK");
                entryNumber.Text = Resource.entryNumberPlaceholder;
            }   
        }
    }
}