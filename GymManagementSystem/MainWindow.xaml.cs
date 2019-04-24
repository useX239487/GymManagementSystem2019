using GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace GymManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GymManagementSystemDatabaseDataSet gymManagementSystemDatabaseDataSet;
        private GymRoomTableAdapter roomTableAdapter;
        private GymTrainerTableAdapter trainerTableAdapter;
        private GymCustomerTableAdapter customerTableAdapter;
        private GymTrainerWithRoomNameTableAdapter trainerWithRoomNameTableAdapter;
        private GymEquipmentWithRoomNameTableAdapter equipmentWithRoomNameTableAdapter;
        private GymCustomerWithTrainerNameTableAdapter customerWithTrainerNameTableAdapter;
        private GymTrainerFullNamesTableAdapter trainerFullNamesTableAdapter;
        private GymCustomerWithExercisePlanTableAdapter customerWithExercisePlanTableAdapter;
        private GymCustomerWithoutExercisePlanTableAdapter customerWithoutExercisePlanTableAdapter;
        private GymScheduleAvailabilityTableAdapter gymScheduleAvailabilityTableAdapter;
        private AllGymCustomersWithExercisePlansTableAdapter allCustomersWithExercisePlanTableAdapter;
        private UpcomingSchedulesByCustomerIdTableAdapter upcomingSchedulesByCustomerIdTableAdapter; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gymManagementSystemDatabaseDataSet = ((GymManagementSystemDatabaseDataSet)(this.FindResource("gymManagementSystemDatabaseDataSet")));
            roomTableAdapter = new GymRoomTableAdapter();
            trainerTableAdapter = new GymTrainerTableAdapter();
            customerTableAdapter = new GymCustomerTableAdapter();
            trainerWithRoomNameTableAdapter = new GymTrainerWithRoomNameTableAdapter();
            equipmentWithRoomNameTableAdapter = new GymEquipmentWithRoomNameTableAdapter();
            customerWithTrainerNameTableAdapter = new GymCustomerWithTrainerNameTableAdapter();
            trainerFullNamesTableAdapter = new GymTrainerFullNamesTableAdapter();
            customerWithExercisePlanTableAdapter = new GymCustomerWithExercisePlanTableAdapter();
            customerWithoutExercisePlanTableAdapter = new GymCustomerWithoutExercisePlanTableAdapter();
            gymScheduleAvailabilityTableAdapter = new GymScheduleAvailabilityTableAdapter();
            allCustomersWithExercisePlanTableAdapter = new AllGymCustomersWithExercisePlansTableAdapter();
            upcomingSchedulesByCustomerIdTableAdapter = new UpcomingSchedulesByCustomerIdTableAdapter();

            RefreshAllDataTables();
            MenuManagementView_Click(sender, e);
            // TODO: Add code here to load data into the table UpcomingSchedulesByCustomerId.
            // This code could not be generated, because the gymManagementSystemDatabaseDataSetUpcomingSchedulesByCustomerIdTableAdapter.Fill method is missing, or has unrecognized parameters.
            GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.UpcomingSchedulesByCustomerIdTableAdapter gymManagementSystemDatabaseDataSetUpcomingSchedulesByCustomerIdTableAdapter = new GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.UpcomingSchedulesByCustomerIdTableAdapter();
            System.Windows.Data.CollectionViewSource upcomingSchedulesByCustomerIdViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("upcomingSchedulesByCustomerIdViewSource")));
            upcomingSchedulesByCustomerIdViewSource.View.MoveCurrentToFirst();
        }

        private void RefreshAllDataTables()
        {
            RefreshGymRoomsData();
            RefreshGymTrainerData();
            RefreshGymEquipmentData();
            RefreshGymCustomerData();
            RefreshGymTrainerExercisePlans();
        }

        private void RefreshGymRoomsData()
        {
            roomTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymRoom);

            // We're about to re-populate these controls from data source, so must make sure an item isn't selected.
            cmbBxAddTrainerAssignedRoom.SelectedIndex = -1; 
            cmbBxAddEquipmentAssignedRoom.SelectedIndex = -1;

            // Get Gym Room list from data set, then make it the ItemsSource for our combo boxes. 
            var cmbBxRoomData = gymManagementSystemDatabaseDataSet.GymRoom.ToList();
            cmbBxAddTrainerAssignedRoom.ItemsSource = cmbBxRoomData;
            cmbBxAddEquipmentAssignedRoom.ItemsSource = cmbBxRoomData;
        }

        private void RefreshGymTrainerData()
        {
            trainerWithRoomNameTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymTrainerWithRoomName);
            trainerFullNamesTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymTrainerFullNames);
            // We're about to re-populate these controls from data source, so must make sure an item isn't selected.
            cmbBxAddCustomerAssignedTrainer.SelectedIndex = -1;
            cmbBxExercisePlanTrainer.SelectedIndex = -1;

            // Get Gym Trainer list from data set, then make it the ItemsSource for our combo boxes. 
            var cmbBxTrainerData = gymManagementSystemDatabaseDataSet.GymTrainerFullNames.ToList();
            cmbBxAddCustomerAssignedTrainer.ItemsSource = cmbBxTrainerData;
            cmbBxExercisePlanTrainer.ItemsSource = cmbBxTrainerData;
        }

        private void RefreshGymCustomerData()
        {
            customerWithTrainerNameTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymCustomerWithTrainerName);
        }

        private void RefreshGymEquipmentData()
        {
            equipmentWithRoomNameTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymEquipmentWithRoomName);
        }

        private void RefreshGymTrainerExercisePlans()
        {
            allCustomersWithExercisePlanTableAdapter.Fill(gymManagementSystemDatabaseDataSet.AllGymCustomersWithExercisePlans);

            // We're about to re-populate these controls from data source, so must make sure an item isn't selected.
            cmbBxGymScheduleCustomer.SelectedIndex = -1;

            // Get Customers wtih Plans list from data set, then make it the ItemsSource for our combo boxes. 
            var cmbBxCustomersWithPlansData = gymManagementSystemDatabaseDataSet.AllGymCustomersWithExercisePlans.ToList();
            cmbBxGymScheduleCustomer.ItemsSource = cmbBxCustomersWithPlansData;
            
        }

        private void RefreshGymTrainerExercisePlansById(int trainerId)
        {
            customerWithExercisePlanTableAdapter.FillBy(gymManagementSystemDatabaseDataSet.GymCustomerWithExercisePlan, trainerId);
            customerWithoutExercisePlanTableAdapter.FillBy(gymManagementSystemDatabaseDataSet.GymCustomerWithoutExercisePlan, trainerId);
        }

        private void RefreshCustomerUpcomingSchedulesById(int customerId)
        {
            upcomingSchedulesByCustomerIdTableAdapter.Fill(gymManagementSystemDatabaseDataSet.UpcomingSchedulesByCustomerId, customerId);
        }

        private void PopulateExercisePlanDetailsByCustomer(int customerId)
        {
            txtBxGymScheduleCustomerTrainerName.Text = customerWithTrainerNameTableAdapter.GetTrainerNameByCustomerId(customerId);
            txtBxGymScheduleCustomerPlanDescription.Text = allCustomersWithExercisePlanTableAdapter.GetExercisePlanByCustomerId(customerId);
            txtBxGymScheduleCustomerPlanDuration.Text = allCustomersWithExercisePlanTableAdapter.GetExercisePlanDurationByCustomerId(customerId).ToString();
            RefreshCustomerUpcomingSchedulesById(customerId);
        }

        private int GetTrainerIdByCustomerId(int customerId)
        {
            return (int)customerWithTrainerNameTableAdapter.GetTrainerIdByCustomerId(customerId);
        }

        private int GetExercisePlanIdByCustomerId(int customerId)
        {
            return (int)allCustomersWithExercisePlanTableAdapter.GetExercisePlanIdByCustomer(customerId);
        }

        private void PopulateAvailableScheduleTimes(DateTime scheduleDate, TimeSpan duration, int trainerId)
        {
            gymScheduleAvailabilityTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymScheduleAvailability,
                scheduleDate.ToString("yyyy-MM-dd"), duration.Minutes, trainerId);

            // We're about to re-populate these controls from data source, so must make sure an item isn't selected.
            cmbBxGymScheduleAvailableTimes.SelectedIndex = -1;

            // Get Customers wtih Plans list from data set, then make it the ItemsSource for our combo boxes. 
            var cmbBxScheduleAvailabilityData = gymManagementSystemDatabaseDataSet.GymScheduleAvailability.ToList();
            cmbBxGymScheduleAvailableTimes.ItemsSource = cmbBxScheduleAvailabilityData;
        }

        private void BtnNewGymRoomAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new GymRoom(txtBxAddGymRoomName.Text, txtBxAddGymRoomDescription.Text);
                BtnNewGymRoomClear_Click(sender, e);
                RefreshGymRoomsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while trying to add new gym room.\n\nException message: {ex.Message}\n\nOperation aborted.",
                    "Error Creating Gym Room", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnNewGymRoomClear_Click(object sender, RoutedEventArgs e)
        {
            txtBxAddGymRoomName.Text = "";
            txtBxAddGymRoomDescription.Text = "";
            txtBxAddGymRoomName.Focus();
        }

        private void BtnNewTrainerAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBxAddTrainerStartTime.SelectedIndex == -1)
            {
                MessageBox.Show("Please select start time.", "No Start Time Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cmbBxAddTrainerAssignedRoom.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an assigned room.", "No Room Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    new GymTrainer(txtBxAddTrainerFirstName.Text, txtBxAddTrainerLastName.Text,
                        cmbBxAddTrainerStartTime.Text, Int32.Parse(cmbBxAddTrainerAssignedRoom.SelectedValue.ToString()));
                    BtnNewTrainerClear_Click(sender, e);
                    RefreshGymTrainerData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while trying to add new trainer.\n\nException message: {ex.Message}\n\nOperation aborted.",
                        "Error Creating Gym Trainer", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void BtnNewTrainerClear_Click(object sender, RoutedEventArgs e)
        {
            txtBxAddTrainerFirstName.Text = "";
            txtBxAddTrainerLastName.Text = "";
            txtBxAddTrainerFirstName.Focus();
        }

        

        private void BtnNewEquipmentAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBxAddEquipmentAssignedRoom.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an assigned room.", "No Room Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    new GymEquipment(txtBxAddEquipmentDescription.Text, Int32.Parse(cmbBxAddEquipmentAssignedRoom.SelectedValue.ToString()));
                    BtnNewEquipmentClear_Click(sender, e);
                    RefreshGymEquipmentData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while trying to add new equipment.\n\nException message: {ex.Message}\n\nOperation aborted.",
                        "Error Creating Gym Equipment", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnNewEquipmentClear_Click(object sender, RoutedEventArgs e)
        {
            txtBxAddEquipmentDescription.Text = "";
            txtBxAddEquipmentDescription.Focus();
        }

        private void BtnNewCustomerAdd_Click(object sender, RoutedEventArgs e)
        {
            if(cmbBxAddCustomerAssignedTrainer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an assigned trainer.", "No Trainer Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    new GymCustomer(txtBxAddCustomerFirstName.Text, txtBxAddCustomerLastName.Text,
                        Int32.Parse(cmbBxAddCustomerAssignedTrainer.SelectedValue.ToString()));
                    BtnNewCustomerClear_Click(sender, e);
                    RefreshGymCustomerData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while trying to add new customer.\n\nException message: {ex.Message}\n\nOperation aborted.",
                        "Error Creating Gym Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnNewCustomerClear_Click(object sender, RoutedEventArgs e)
        {
            txtBxAddCustomerFirstName.Text = "";
            txtBxAddCustomerLastName.Text = "";
            txtBxAddEquipmentDescription.Focus();
        }

        private void CmbBxExercisePlanTrainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateExercisePlansCustomerLists(sender, e);
        }

        private void PopulateExercisePlansCustomerLists(object sender, RoutedEventArgs e)
        {
            int trainerId = 0; 

            if (cmbBxExercisePlanTrainer.SelectedIndex == -1)
            {
                //MessageBox.Show("Please select a trainer from the drop-down first.", "No Trainer Selected", MessageBoxButton.OK, MessageBoxImage.Error);
                trainerId = -1;
            }
            else
            {
                try
                {
                    trainerId = Int32.Parse(cmbBxExercisePlanTrainer.SelectedValue.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error getting customer lists for trainer.\n\nException message: {ex.Message}",
                        "Error Populating Customer Lists", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            RefreshGymTrainerExercisePlansById(trainerId);
        }

        private void BtnAddExercisePlan_Click(object sender, RoutedEventArgs e)
        {
            
            if (cmbBxAddExercisePlanDuration.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a plan duration from the drop-down.", "No Plan Duration Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (gymCustomerWithoutExercisePlanDataGrid.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer in the list to add a new plan.", "No Customer Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    DataRowView customerDataRow = (DataRowView)gymCustomerWithoutExercisePlanDataGrid.SelectedItem;
                    int customerId = Int32.Parse(customerDataRow["gymCustomerId"].ToString());
                    int trainerId = Int32.Parse(customerDataRow["gymTrainerId"].ToString());
                    string duration = cmbBxAddExercisePlanDuration.Text;

                    new GymExercisePlan(txtBxAddExercisePlanDescription.Text, duration, trainerId, customerId);
                    PopulateExercisePlansCustomerLists(sender, e);
                    RefreshGymTrainerExercisePlans();

                    txtBxAddExercisePlanDescription.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding new exercise plan.\n\nException message: {ex.Message}",
                        "Error Adding Plan", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        private void PopulateGymScheduleCustomerInformation(object sender, RoutedEventArgs e)
        {
            datePickerGymScheduleCustomerPlanScheduleDate.SelectedDate = null;

            if (cmbBxGymScheduleCustomer.SelectedIndex == -1)
            {
                txtBxGymScheduleCustomerTrainerName.Text = "";
                txtBxGymScheduleCustomerPlanDescription.Text = "";
                txtBxGymScheduleCustomerPlanDuration.Text = "";
                PopulateExercisePlanDetailsByCustomer(-1); // Clears tables.
            }
            else
            {
                try
                {
                    int customerId = Int32.Parse(cmbBxGymScheduleCustomer.SelectedValue.ToString());
                    PopulateExercisePlanDetailsByCustomer(customerId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error getting plan description for customer.\n\nException message: {ex.Message}",
                        "Error Populating Plan Description", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CmbBxGymScheduleCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateGymScheduleCustomerInformation(sender, e);
        }

        private void GetAvailableScheduleTimes(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime selectedDate = (DateTime)datePickerGymScheduleCustomerPlanScheduleDate.SelectedDate;
                TimeSpan planDuration = new TimeSpan(Int32.Parse(txtBxGymScheduleCustomerPlanDuration.Text.Substring(0, 2)),
                    Int32.Parse(txtBxGymScheduleCustomerPlanDuration.Text.Substring(3, 2)), 
                    Int32.Parse(txtBxGymScheduleCustomerPlanDuration.Text.Substring(6, 2)));
                int customerId = Int32.Parse(cmbBxGymScheduleCustomer.SelectedValue.ToString());
                int trainerId = GetTrainerIdByCustomerId(customerId); 

                PopulateAvailableScheduleTimes(selectedDate, planDuration, trainerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting available timeslots.\n\nException message: {ex.Message}",
                    "Error Populating Available Times", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DatePickerGymScheduleCustomerPlanScheduleDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //cmbBxGymScheduleAvailableTimes.SelectedIndex = -1;
            //cmbBxGymScheduleAvailableTimes.ItemsSource = null;
            if (datePickerGymScheduleCustomerPlanScheduleDate.SelectedDate != null)
            {
                if (cmbBxGymScheduleCustomer.SelectedIndex == -1)
                {
                    MessageBox.Show("Customer must be selected prior to setting date.", "No Customer Selected", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePickerGymScheduleCustomerPlanScheduleDate.SelectedDate = null;
                }
                else
                {
                    GetAvailableScheduleTimes(sender, e);
                }
            }
        }

        private void BtnGymScheduleCustomerSubmitSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBxGymScheduleCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer before attempting to schedule a session",
                    "No Customer Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (datePickerGymScheduleCustomerPlanScheduleDate.SelectedDate == null)
            {
                MessageBox.Show("Please select a date before attempting to schedule a session",
                    "No Date Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
            else if (cmbBxGymScheduleAvailableTimes.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a time before attempting to schedule a session",
                    "No Time Selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int customerId = Int32.Parse(cmbBxGymScheduleCustomer.SelectedValue.ToString());
                int trainerId = GetTrainerIdByCustomerId(customerId);
                int planId = GetExercisePlanIdByCustomerId(customerId);

                try
                {
                    TimeSpan selectedTime = new TimeSpan(Int32.Parse(cmbBxGymScheduleAvailableTimes.Text.Substring(0, 2)),
                        Int32.Parse(cmbBxGymScheduleAvailableTimes.Text.Substring(3, 2)),
                        Int32.Parse(cmbBxGymScheduleAvailableTimes.Text.Substring(6, 2)));

                    DateTime selectedDateTime = (DateTime)datePickerGymScheduleCustomerPlanScheduleDate.SelectedDate + selectedTime;

                    new GymSchedule(trainerId, planId, selectedDateTime, txtBxGymScheduleCustomerPlanDuration.Text);



                    MessageBox.Show("Successfully scheduled your session!", "Schedule Created Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    RefreshCustomerUpcomingSchedulesById(customerId);
                    GetAvailableScheduleTimes(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating schedule.\n\nException message: {ex.Message}",
                        "Error Creating Schedule", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MenuManagementView_Click(object sender, RoutedEventArgs e) // Sets the proper tabs to be viewable for Management
        {
            menuManagementView.IsChecked = true;
            menuTrainerView.IsChecked = false;
            menuCustomerView.IsChecked = false;
            menuAdminView.IsChecked = false;
            menuTools.Visibility = Visibility.Hidden;
            tabControlMain.SelectedIndex = 0;
            tabManagementCustomers.Visibility = Visibility.Visible;
            tabManagementTrainers.Visibility = Visibility.Visible;
            tabManagementRooms.Visibility = Visibility.Visible;
            tabManagementEquipment.Visibility = Visibility.Visible;
            tabTrainerExercisePlans.Visibility = Visibility.Hidden;
            tabCustomerSchedule.Visibility = Visibility.Hidden;
            tabManagementCustomers.Width = Double.NaN;
            tabManagementTrainers.Width = Double.NaN;
            tabManagementRooms.Width = Double.NaN;
            tabManagementEquipment.Width = Double.NaN;
            tabTrainerExercisePlans.Width = 0;
            tabCustomerSchedule.Width = 0;
        }

        private void MenuTrainerView_Click(object sender, RoutedEventArgs e) // Sets the proper tabs to be viewable for Trainers
        {
            menuTrainerView.IsChecked = true;
            menuManagementView.IsChecked = false;
            menuCustomerView.IsChecked = false;
            menuAdminView.IsChecked = false;
            menuTools.Visibility = Visibility.Hidden;
            tabControlMain.SelectedIndex = 4;
            tabTrainerExercisePlans.Visibility = Visibility.Visible;
            tabManagementCustomers.Visibility = Visibility.Hidden;
            tabManagementTrainers.Visibility = Visibility.Hidden;
            tabManagementRooms.Visibility = Visibility.Hidden;
            tabManagementEquipment.Visibility = Visibility.Hidden;
            tabCustomerSchedule.Visibility = Visibility.Hidden;
            tabTrainerExercisePlans.Width = Double.NaN;
            tabManagementCustomers.Width = 0;
            tabManagementTrainers.Width = 0;
            tabManagementRooms.Width = 0;
            tabManagementEquipment.Width = 0;
            tabCustomerSchedule.Width = 0;
        }

        private void MenuCustomerView_Click(object sender, RoutedEventArgs e) // Sets the proper tabs to be viewable for Customers
        {
            menuCustomerView.IsChecked = true;
            menuManagementView.IsChecked = false;
            menuTrainerView.IsChecked = false;
            menuAdminView.IsChecked = false;
            menuTools.Visibility = Visibility.Hidden;
            tabControlMain.SelectedIndex = 5;
            tabCustomerSchedule.Visibility = Visibility.Visible;
            tabManagementCustomers.Visibility = Visibility.Hidden;
            tabManagementTrainers.Visibility = Visibility.Hidden;
            tabManagementRooms.Visibility = Visibility.Hidden;
            tabManagementEquipment.Visibility = Visibility.Hidden;
            tabTrainerExercisePlans.Visibility = Visibility.Hidden;
            tabCustomerSchedule.Width = Double.NaN;
            tabManagementCustomers.Width = 0;
            tabManagementTrainers.Width = 0;
            tabManagementRooms.Width = 0;
            tabManagementEquipment.Width = 0;
            tabTrainerExercisePlans.Width = 0;
        }

        private void MenuAdminView_Click(object sender, RoutedEventArgs e)
        {
            menuCustomerView.IsChecked = false;
            menuManagementView.IsChecked = false;
            menuTrainerView.IsChecked = false;
            menuAdminView.IsChecked = true;
            menuTools.Visibility = Visibility.Visible;
            tabControlMain.SelectedIndex = 0;
            tabCustomerSchedule.Visibility = Visibility.Visible;
            tabManagementCustomers.Visibility = Visibility.Visible;
            tabManagementTrainers.Visibility = Visibility.Visible;
            tabManagementRooms.Visibility = Visibility.Visible;
            tabManagementEquipment.Visibility = Visibility.Visible;
            tabTrainerExercisePlans.Visibility = Visibility.Visible;
            tabCustomerSchedule.Width = Double.NaN;
            tabManagementCustomers.Width = Double.NaN;
            tabManagementTrainers.Width = Double.NaN;
            tabManagementRooms.Width = Double.NaN;
            tabManagementEquipment.Width = Double.NaN;
            tabTrainerExercisePlans.Width = Double.NaN;
        }

        private void MenuGenerateFakeData_Click(object sender, RoutedEventArgs e)
        {
            new GymRoom("Free Weight Room", "Contains free weights");
            new GymRoom("Aerobics Machine Room", "Contains aerobics machines");
            new GymRoom("Exercise Stations", "Contains exercise stations");
            new GymTrainer("Bob", "Smith", "08:00:00", 1);
            new GymTrainer("Jessica", "Ross", "09:00:00", 2);
            new GymTrainer("Tiffany", "Alvarez", "10:00:00", 3);
            new GymEquipment("Barbell", 1);
            new GymEquipment("Hyper Extension Bench", 1);
            new GymEquipment("Preacher Bench", 1);
            new GymEquipment("Abdominal Bench", 1);
            new GymEquipment("Dipping Bars", 1);
            new GymEquipment("Chin Up Bar", 1);
            new GymEquipment("Treadmill", 2);
            new GymEquipment("Stair Mill", 2);
            new GymEquipment("Rowing Machine", 2);
            new GymEquipment("Spin Bike", 2);
            new GymEquipment("Elliptical", 2);
            new GymEquipment("Leg Press Machine", 3);
            new GymEquipment("Hack Squat Machine", 3);
            new GymEquipment("Leg Extension Machine", 3);
            new GymEquipment("Leg Curl Machine", 3);
            new GymEquipment("Leg Adduction Machine", 3);
            new GymEquipment("Lat Pull Down Machine", 3);
            new GymEquipment("Pec Deck Machine", 3);
            new GymCustomer("Andy", "Lopez", 1);
            new GymCustomer("Maria", "Smith", 1);
            new GymCustomer("Tommy", "Johnson", 1);
            new GymCustomer("Leah", "Cruz", 2);
            new GymCustomer("Jacob", "Baer", 2);
            new GymCustomer("Dakota", "Clark", 2);
            new GymCustomer("Zayn", "Lees", 3);
            new GymCustomer("Ethan", "Sumner", 3);
            new GymCustomer("Livia", "Yates", 3);
            new GymExercisePlan("Do some stuff\n\nThen do more stuff", "30 Minutes", 1, 1);
            RefreshAllDataTables();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
