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
        // Burada seçilen tarih ve saat ayarlarýný kullanarak hatýrlatýcý veya bildirim iþlemleri gerçekleþtirebilirsiniz.

        // Örnek olarak:
        DateTime reminderDateTime = SelectedDate.Date + SelectedTime;
        // Hatýrlatýcý ayarlamak veya bildirim göndermek gibi iþlemler yapýlabilir.

        // Sayfayý kapat
        await Navigation.PopModalAsync();
    }
}