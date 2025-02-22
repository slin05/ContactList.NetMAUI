namespace ContactList.NetMAUI;

public partial class ContactDetails : ContentPage
{
    public ContactDetails(string name, string image, string email, string phone, string description)
    {
        InitializeComponent();

        contactImage.Source = image;
        nameLabel.Text = name;
        emailLabel.Text = email;
        phoneLabel.Text = phone;
        descriptionLabel.Text = description;
    }
}