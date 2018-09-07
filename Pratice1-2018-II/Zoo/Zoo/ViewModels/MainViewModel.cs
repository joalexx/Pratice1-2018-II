namespace Zoo.ViewModels
{
    public class MainViewModel
    {
        #region Propierties
        public AnimalsViewModel Animals { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            this.Animals = new AnimalsViewModel();
        }
        #endregion
    }
}
