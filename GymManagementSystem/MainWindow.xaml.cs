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

namespace GymManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GymEquipment> gymEquipment;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            GymManagementSystem.GymManagementSystemDatabaseDataSet gymManagementSystemDatabaseDataSet = ((GymManagementSystem.GymManagementSystemDatabaseDataSet)(this.FindResource("gymManagementSystemDatabaseDataSet")));
            // Load data into the table GymRoom. You can modify this code as needed.
            GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.GymRoomTableAdapter gymManagementSystemDatabaseDataSetGymRoomTableAdapter = new GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.GymRoomTableAdapter();
            gymManagementSystemDatabaseDataSetGymRoomTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymRoom);
            System.Windows.Data.CollectionViewSource gymRoomViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("gymRoomViewSource")));
            gymRoomViewSource.View.MoveCurrentToFirst();
        }

        private void RefreshGymRoomsTable()
        {
            GymManagementSystem.GymManagementSystemDatabaseDataSet gymManagementSystemDatabaseDataSet = ((GymManagementSystem.GymManagementSystemDatabaseDataSet)(this.FindResource("gymManagementSystemDatabaseDataSet")));
            // Load data into the table GymRoom. You can modify this code as needed.
            GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.GymRoomTableAdapter gymManagementSystemDatabaseDataSetGymRoomTableAdapter = new GymManagementSystem.GymManagementSystemDatabaseDataSetTableAdapters.GymRoomTableAdapter();
            gymManagementSystemDatabaseDataSetGymRoomTableAdapter.Fill(gymManagementSystemDatabaseDataSet.GymRoom);
        }

        private void BtnNewGymRoomAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new GymRoom(txtBxAddGymRoomName.Text, txtBxAddGymRoomDescription.Text);
                BtnNewGymRoomClear_Click(sender, e);
                RefreshGymRoomsTable();
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
    }
}
