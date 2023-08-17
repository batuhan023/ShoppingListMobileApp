using ShoppingListMobileApp1.ViewModels;

namespace ShoppingListMobileApp1;

public partial class ReminderPageView : ContentPage
{
    public DateTime SelectedDate { get; set; }
    public TimeSpan SelectedTime { get; set; }
    public DateTime MinimumDate { get; } = DateTime.Now.Date;
    private readonly ReminderPageViewModel _viewModel;
    public ReminderPageView()
    {
         InitializeComponent();

        _viewModel = new ReminderPageViewModel();
        BindingContext = _viewModel;

    }

    private async void Button_Clicked_Reminder(object sender, EventArgs e)
    {
        // Burada se�ilen tarih ve saat ayarlar�n� kullanarak hat�rlat�c� veya bildirim i�lemleri ger�ekle�tirebilirsiniz.

        // �rnek olarak:
        DateTime reminderDateTime = SelectedDate.Date + SelectedTime;
        // Hat�rlat�c� ayarlamak veya bildirim g�ndermek gibi i�lemler yap�labilir.

        // Sayfay� kapat
        await Navigation.PopModalAsync();
    }
}