using Shuffood.Views;

namespace Shuffood;

public partial class Picknation : ContentPage
{
	public Picknation()
	{
		InitializeComponent();
	}
	private async void OnNationSelected(string selectedNation)
	{
		// Navigate to MenuPage with the selected nation
		await Navigation.PushAsync(new MenuPage(selectedNation));
	}
	private async void OnNationButtonClicked(object sender, EventArgs e)
	{
		if (sender is ImageButton button && button.CommandParameter is string selectedNation)
		{
			Console.WriteLine($"Nation selected: {selectedNation}"); // Debug output

			await Navigation.PushAsync(new MenuPage(selectedNation));
		}
	}
}