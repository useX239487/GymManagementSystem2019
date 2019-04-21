using GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
        private GymManagementSystemDatabaseDataSetTableAdapters.GymRoomTableAdapter gymManagementSystemDatabaseDataSetGymRoomTableAdapter;
        private GymManagementSystemDatabaseDataSetTableAdapters.GymTrainerTableAdapter gymManagementSystemDatabaseDataSetGymTrainerTableAdapter;
        private GymManagementSystemDatabaseDataSetTableAdapters.GymTrainerWithRoomNameTableAdapter gymManagementSystemDataSetGymTrainerWithRoomNameTableAdapter;
        private GymManagementSystemDatabaseDataSetTableAdapters.GymEquipmentWithRoomNameTableAdapter gymManagementSystemDatabaseDataSetGymEquipmentWithRoomNameTableAdapter;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gymManagementSystemDatabaseDataSet = ((GymManagementSystem.GymManagementSystemDatabaseDataSet)(this.FindResource("gymManagementSystemDatabaseDataSet")));
            gymManagementSystemDatabaseDataSetGymRoomTableAdapter = new GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.GymRoomTableAdapter();
            gymManagementSystemDatabaseDataSetGymTrainerTableAdapter = new GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.GymTrainerTableAdapter();
            gymManagementSystemDataSetGymTrainerWithRoomNameTableAdapter = new GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.GymTrainerWithRoomNameTableAdapter();
            gymManagementSystemDatabaseDataSetGymEquipmentWithRoomNameTableAdapter = new GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.GymEquipmentWithRoomNameTableAdapter();
            RefreshAllDataTables();
            MenuManagementView_Click(sender, e);
        }

        private void RefreshAllDataTables()
        {
            RefreshGymRoomsData();
            RefreshGymTrainerData();
            RefreshGymEquipmentData();
        }

        private void RefreshGymRoomsData()
        {
            gymManagementSystemDatabaseDataSetGymRoomTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymRoom);

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
            gymManagementSystemDataSetGymTrainerWithRoomNameTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymTrainerWithRoomName);
        }

        private void RefreshGymEquipmentData()
        {
            gymManagementSystemDatabaseDataSetGymEquipmentWithRoomNameTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymEquipmentWithRoomName);
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

        private void TxtBxAddGymRoomName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnNewGymRoomAdd_Click(sender, e);
            else if (e.Key == Key.Escape)
                BtnNewGymRoomClear_Click(sender, e);
        }

        private void TxtBxAddGymRoomDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnNewGymRoomAdd_Click(sender, e);
            else if (e.Key == Key.Escape)
                BtnNewGymRoomClear_Click(sender, e);
        }

        private void BtnNewTrainerAdd_Click(object sender, RoutedEventArgs e)
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

        private void BtnNewTrainerClear_Click(object sender, RoutedEventArgs e)
        {
            txtBxAddTrainerFirstName.Text = "";
            txtBxAddTrainerLastName.Text = "";
            txtBxAddTrainerFirstName.Focus();
        }

        

        private void BtnNewEquipmentAdd_Click(object sender, RoutedEventArgs e)
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

        private void BtnNewEquipmentClear_Click(object sender, RoutedEventArgs e)
        {
            txtBxAddEquipmentDescription.Text = "";
            txtBxAddEquipmentDescription.Focus();
        }

        private void MenuManagementView_Click(object sender, RoutedEventArgs e) // Sets the proper tabs to be viewable for Management
        {
            menuManagementView.IsChecked = true;
            menuTrainerView.IsChecked = false;
            menuCustomerView.IsChecked = false;
            menuTools.Visibility = Visibility.Visible;
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

        private void MenuGenerateSeedData_Click(object sender, RoutedEventArgs e)
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
            RefreshAllDataTables();
        }

        private void MenuDeleteAllData_Click(object sender, RoutedEventArgs e)
        {
            GymRoomTableAdapter roomTableAdapter = new GymRoomTableAdapter();
            GymTrainerTableAdapter trainerTableAdapter = new GymTrainerTableAdapter();
            GymEquipmentTableAdapter equipmentTableAdapter = new GymEquipmentTableAdapter();
            trainerTableAdapter.DeleteAllEntries();
            equipmentTableAdapter.DeleteAllEntries();
            roomTableAdapter.DeleteAllEntries();
            RefreshAllDataTables();
        }
    }
}
