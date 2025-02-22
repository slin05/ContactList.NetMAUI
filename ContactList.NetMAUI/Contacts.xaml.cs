using System.Collections.ObjectModel;

namespace ContactList.NetMAUI
{
    public partial class Contacts : ContentPage
    {
        private ObservableCollection<ContactGroup> contactGroups = new();

        public class Contact
        {
            public required string Name { get; set; }
            public required string Image { get; set; }
            public required string Email { get; set; }
            public required string Phone { get; set; }
            public required string Description { get; set; }
        }

        public class ContactGroup : ObservableCollection<Contact>
        {
            public string Name { get; private set; }

            public ContactGroup(string name, List<Contact> contacts) : base(contacts)
            {
                Name = name;
            }
        }

        public Contacts()
        {
            InitializeComponent();
            LoadContacts();
        }

        void LoadContacts()
        {
            var contacts = new List<Contact>
            {
                // A group
                new Contact { Name = "Alice Smith", Image = "pic1.png", Email = "alice@email.com", Phone = "123-456-7890", Description = "Software Developer" },
                new Contact { Name = "Adam Johnson", Image = "pic2.png", Email = "adam@email.com", Phone = "234-567-8901", Description = "Project Manager" },
                new Contact { Name = "Andrew Davis", Image = "pic3.png", Email = "andrew@email.com", Phone = "345-678-9012", Description = "Designer" },
                
                // B group
                new Contact { Name = "Bob Wilson", Image = "pic4.png", Email = "bob@email.com", Phone = "456-789-0123", Description = "Engineer" },
                new Contact { Name = "Bill Taylor", Image = "pic1.png", Email = "bill@email.com", Phone = "567-890-1234", Description = "Architect" },
                new Contact { Name = "Brian Moore", Image = "pic2.png", Email = "brian@email.com", Phone = "678-901-2345", Description = "Manager" },
                
                // C group
                new Contact { Name = "Carol White", Image = "pic3.png", Email = "carol@email.com", Phone = "789-012-3456", Description = "Developer" },
                new Contact { Name = "Chris Brown", Image = "pic4.png", Email = "chris@email.com", Phone = "890-123-4567", Description = "Designer" },
                new Contact { Name = "Catherine Lee", Image = "pic1.png", Email = "catherine@email.com", Phone = "901-234-5678", Description = "Engineer" },
                
                // D group
                new Contact { Name = "David Clark", Image = "pic2.png", Email = "david@email.com", Phone = "012-345-6789", Description = "Manager" },
                new Contact { Name = "Diana Wilson", Image = "pic3.png", Email = "diana@email.com", Phone = "123-456-7890", Description = "Developer" },
                new Contact { Name = "Daniel Smith", Image = "pic4.png", Email = "daniel@email.com", Phone = "234-567-8901", Description = "Designer" },
                
                // E group
                new Contact { Name = "Emma Davis", Image = "pic1.png", Email = "emma@email.com", Phone = "345-678-9012", Description = "Engineer" },
                new Contact { Name = "Eric Johnson", Image = "pic2.png", Email = "eric@email.com", Phone = "456-789-0123", Description = "Manager" },
                new Contact { Name = "Eva Brown", Image = "pic3.png", Email = "eva@email.com", Phone = "567-890-1234", Description = "Developer" }
            };

            contactGroups.Clear();
            var groups = contacts.OrderBy(c => c.Name)
                                .GroupBy(c => c.Name[0].ToString())
                                .Select(g => new ContactGroup(g.Key, g.ToList()));

            foreach (var group in groups)
            {
                contactGroups.Add(group);
            }

            ContactsList.ItemsSource = contactGroups;
        }

        async void OnContactSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Contact selectedContact)
            {
                await Navigation.PushAsync(new ContactDetails(
                    selectedContact.Name,
                    selectedContact.Image,
                    selectedContact.Email,
                    selectedContact.Phone,
                    selectedContact.Description));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}