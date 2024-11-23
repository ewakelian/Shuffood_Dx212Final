using Microsoft.Maui.Controls;
using Shuffood.Firebase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shuffood.Views
{
    public partial class MenuPage : ContentPage
    {

        private FirestoreService _firestoreService;
        private string _selectedNation;

        public MenuPage(string selectedNation)
        {
            InitializeComponent();

            // Store the selected nation
            _selectedNation = selectedNation;



            // Load data
            this.LoadMenu();

        }

        private async Task LoadMenu()
        {
            _firestoreService = new FirestoreService();
            MenuCollectionView.ItemsSource = await _firestoreService.GetFoodByNationAsync(_selectedNation);
        }

/*      private async void OnShuffleButtonClicked(object sender, EventArgs e)
        {
            // Assuming 'Menus' is your collection of menu items
            // Ensure you have a valid Menus collection here
            var menusList = Menus.ToList();

            // Navigate to ShufflePage with the menus list
            await Navigation.PushAsync(new ShufflePage(menusList));
        }
*/


    }
}