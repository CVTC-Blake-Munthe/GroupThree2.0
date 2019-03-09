using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Guest.xaml
    /// </summary>
    public partial class Guest : UserControl
    {
        GuestEntities context = new GuestEntities();
        CollectionViewSource guestViewSource;


        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            guestViewSource.View.MoveCurrentToLast();
        }

        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            guestViewSource.View.MoveCurrentToPrevious();
        }

        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            guestViewSource.View.MoveCurrentToNext();
        }

        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            guestViewSource.View.MoveCurrentToFirst();
        }

        private void DeleteGuestCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // If existing window is visible, delete the customer(guest).  
            // In a real application, you should add warnings and allow the user to cancel the operation.  
            var cur = guestViewSource.View.CurrentItem as Guest;

            var guest = (from c in context.Guests
                         where c.GuestID == cur.GuestID
                         select c).FirstOrDefault();

            if (guest != null)
            {
                /*  foreach (var guest in cust.Orders.ToList())
                  {
                      Delete_Order(ord);
                  }*/
                context.Guests.Remove(guest);
            }
            context.SaveChanges();
            guestViewSource.View.Refresh();
        }

        // Commit changes from the new customer form, the new order form,  
        // or edits made to the existing customer form.  
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (newGuestGrid.IsVisible)
            {
                // Create a new object because the old one  
                // is being tracked by EF now.  
                Guest newGuest = new Guest
                {
                    
                    FirstName = add_guestFNameTextBox.Text,
                    MiddleInitial = add_guestMInitialTextBox.Text,
                    LastName = add_guestLNameTextBox.Text,
                    Gender = add_guestGenderTextBox.Text,
                    DateOfBirth = Convert.ToDateTime(add_guestDateOfBirthDatePicker.Text),
                    SocialSecurity = add_guestSocialSecurityTextBox.Text,
                    PhoneNumber = add_guestPhoneNumberTextBox.Text,
                    Services = add_guestServicesTextBox.Text,
                    IntakeComplete = Convert.ToBoolean(add_guestIntakeCompleteCheckBox.IsChecked)
                };

                // Perform very basic validation, would be cool to implement
                /*if (newGuest.GuestID == 5)
                {
                    // Insert the new customer at correct position:  
                    int len = context.Guests.Local.Count();
                    int pos = len;
                    for (int i = 0; i < len; ++i)
                    {
                        if (String.CompareOrdinal(newGuest.GuestID, context.Guests.Local[i].GuestID) < 0)
                        {
                            pos = i;
                            break;
                        }
                    }*/

                // Null exception error occurring with guestViewSource.View.Refresh()

                context.Guests.Add(newGuest);
                if (guestViewSource.View != null)
                {
                    guestViewSource.View.Refresh();
                    guestViewSource.View.MoveCurrentTo(newGuest);
                }

                /*   else
                   {
                       MessageBox.Show("GuestID must have 5 characters.");
                   }*/

                newGuestGrid.Visibility = Visibility.Collapsed;
                existingGuestGrid.Visibility = Visibility.Visible;
            }
            /* else if (newOrderGrid.IsVisible)
             {
                 // Order ID is auto-generated so we don't set it here.  
                 // For CustomerID, address, etc we use the values from current customer.  
                 // User can modify these in the datagrid after the order is entered.  

                 Order newOrder = new Order()
                 {
                     OrderDate = add_orderDatePicker.SelectedDate,
                     RequiredDate = add_requiredDatePicker.SelectedDate,
                     ShippedDate = add_shippedDatePicker.SelectedDate
                 };

                 try
                 {
                     // Exercise for the reader if you are using Northwind:  
                     // Add the Northwind Shippers table to the model.

                     // Acceptable ShipperID values are 1, 2, or 3.  
                     if (add_ShipViaTextBox.Text == "1" || add_ShipViaTextBox.Text == "2"
                         || add_ShipViaTextBox.Text == "3")
                     {
                         newOrder.ShipVia = Convert.ToInt32(add_ShipViaTextBox.Text);
                     }
                     else
                     {
                         MessageBox.Show("Shipper ID must be 1, 2, or 3 in Northwind.");
                         return;
                     }
                 }
                 catch
                 {
                     MessageBox.Show("Ship Via must be convertible to int");
                     return;
                 }

                 try
                 {
                     newOrder.Freight = Convert.ToDecimal(add_freightTextBox.Text);
                 }
                 catch
                 {
                     MessageBox.Show("Freight must be convertible to decimal.");
                     return;
                 }

                 // Add the order into the EF model  
                 context.Orders.Add(newOrder);
                 ordViewSource.View.Refresh();
             }*/

            // Save the changes, either for a new customer, a new order  
            // or an edit to an existing customer or order.
            context.SaveChanges();
            
        }

        // Sets up the form so that user can enter data. Data is later  
        // saved when user clicks Commit.  
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingGuestGrid.Visibility = Visibility.Collapsed;
            //      newOrderGrid.Visibility = Visibility.Collapsed;
            newGuestGrid.Visibility = Visibility.Visible;

            // Clear all the text boxes before adding a new guest.  
            foreach (var child in newGuestGrid.Children)
            {
                var tb = child as TextBox;
                if (tb != null)
                {
                    tb.Text = "";
                }
            }
        }

        /*    private void NewOrder_click(object sender, RoutedEventArgs e)
            {
                var cust = custViewSource.View.CurrentItem as Customer;
                if (cust == null)
                {
                    MessageBox.Show("No customer selected.");
                    return;
                }

                Order newOrder = new Order();
                newOrder.CustomerID = cust.CustomerID;

                // Get address and other mostly constant fields from   
                // an existing order, if one exists  
                var coll = custViewSource.Source as IEnumerable<Customer>;
                var lastOrder = (from c in coll
                                 from ord in c.Orders
                                 select ord).LastOrDefault();
                if (lastOrder != null)
                {
                    newOrder.ShipAddress = lastOrder.ShipAddress;
                    newOrder.ShipCity = lastOrder.ShipCity;
                    newOrder.ShipCountry = lastOrder.ShipCountry;
                    newOrder.ShipName = lastOrder.ShipName;
                    newOrder.ShipPostalCode = lastOrder.ShipPostalCode;
                    newOrder.ShipRegion = lastOrder.ShipRegion;
                }

                existingCustomerGrid.Visibility = Visibility.Collapsed;
                newCustomerGrid.Visibility = Visibility.Collapsed;
                newOrderGrid.UpdateLayout();
                newOrderGrid.Visibility = Visibility.Visible;
            }

            // Cancels any input into the new customer form  
            private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
            {
                add_addressTextBox.Text = "";
                add_cityTextBox.Text = "";
                add_companyNameTextBox.Text = "";
                add_contactNameTextBox.Text = "";
                add_contactTitleTextBox.Text = "";
                add_countryTextBox.Text = "";
                add_customerIDTextBox.Text = "";
                add_faxTextBox.Text = "";
                add_phoneTextBox.Text = "";
                add_postalCodeTextBox.Text = "";
                add_regionTextBox.Text = "";

                existingCustomerGrid.Visibility = Visibility.Visible;
                newCustomerGrid.Visibility = Visibility.Collapsed;
                newOrderGrid.Visibility = Visibility.Collapsed;
            }

            private void Delete_Order(Order order)
            {
                // Find the order in the EF model.  
                var ord = (from o in context.Orders.Local
                           where o.OrderID == order.OrderID
                           select o).FirstOrDefault();

                // Delete all the order_details that have  
                // this Order as a foreign key  
                foreach (var detail in ord.Order_Details.ToList())
                {
                    context.Order_Details.Remove(detail);
                }

                // Now it's safe to delete the order.  
                context.Orders.Remove(ord);
                context.SaveChanges();

                // Update the data grid.  
                ordViewSource.View.Refresh();
            }

            private void DeleteOrderCommandHandler(object sender, ExecutedRoutedEventArgs e)
            {
                // Get the Order in the row in which the Delete button was clicked.  
                Order obj = e.Parameter as Order;
                Delete_Order(obj);
            }*/


        public Guest()
        {
            InitializeComponent();
            guestViewSource = ((CollectionViewSource)(FindResource("guestViewSource")));
            DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Load is an extension method on IQueryable,    
            // defined in the System.Data.Entity namespace.   
            // This method enumerates the results of the query,    
            // similar to ToList but without creating a list.   
            // When used with Linq to Entities, this method    
            // creates entity objects and adds them to the context.
            context.Guests.Load();

            // After the data is loaded, call the DbSet<T>.Local property    
            // to use the DbSet<T> as a binding source.
            guestViewSource.Source = context.Guests.Local;

        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }
    }
}
