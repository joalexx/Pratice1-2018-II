

namespace Zoo.ViewModels
{

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using Pratice1_2018_II.Domain.Models;
    using Services;

    public class AnimalsViewModel : BaseViewModel
    {
        #region Atributtes

        private ApiService apiService;
        public ObservableCollection<Animal> Animals
        {

            get { return this.animals; }
            set { this.SetValue(ref this.animals, value); }
        }
        private ObservableCollection<Animal> animals;
        #endregion
        #region Constructor
        public AnimalsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadAnimals();
        }

        private async void LoadAnimals()
        {
            var response = await this.apiService.GetList<Animal>("https://pratice1-2018-iiapi.azurewebsites.net", "/api", "/Animals");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list = (List<Animal>)response.Result;
            this.Animals = new ObservableCollection<Animal>(list);
        }
        #endregion
    }
}
