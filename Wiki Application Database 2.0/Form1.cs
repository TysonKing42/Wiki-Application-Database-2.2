using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Diagnostics;

/* Name: Tyson King
 * Title: Wiki Application Database 2.0f
 * Description: Database Application that uses Wiki to save data. User has multiple options of control of data
 * */

// Define namespace for application.
namespace Wiki_Application_Database_2._0
{
    public partial class Form1 : Form
    {
        // Set filePath to null for if user exits without making changes
        private string filePath = null;
        // 6.2 Create a global List<T> of type Information called Wiki
        List<Information> Wiki = new List<Information>();
        public Form1()
        {

            this.Click += NameTextBox_DoubleClick;
            InitializeComponent();
            LoadCategoriesFromFile();
            SortAndDisplayList();
            nameTextBox.DoubleClick += NameTextBox_DoubleClick;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button
        private void NameTextBox_DoubleClick(object sender, EventArgs e)
        {
            // Clear and reset the input controls.
            ClearAndResetControls();
            nameTextBox.ReadOnly = false;
        }

        // 6.3 Create a button method to ADD a new item to the list. Use a TextBox for the Name input, ComboBox for the Category, Radio group for the Structure and Multiline TextBox for the Definition
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values from the input controls.
                string name = nameTextBox.Text;

                
                // Check if the name is already in the list.
                if (ValidName(name))
                {
                    MessageBox.Show("A record with this name already exists. Please enter a different name.", "Duplicate Name");
                    return; // Prevent adding a duplicate name
                }
                // Get the values from the input controls.
                string category = categoryComboBox.SelectedItem != null ? categoryComboBox.SelectedItem.ToString() : string.Empty;
                string structure = GetSelectedStructure(); // Implement this method to get the selected radio button value.
                string definition = definitionTextBox.Text;

                // Check if all required information is entered.
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(structure) || string.IsNullOrWhiteSpace(definition))
                {
                    MessageBox.Show("Please fill in all required information before adding an item.", "Incomplete Information");
                    return; // If required information is not entered, notify user 
                }

                // Create a new Information object.
                Information newData = new Information(name, category, structure, definition);

                // Add the new Information object to the Wiki list.
                Wiki.Add(newData);

                // Clear the input fields and reset the form.
                nameTextBox.Clear();
                categoryComboBox.SelectedIndex = 0;
                ClearSelectedStructure();
                definitionTextBox.Clear();
                ClearAndResetControls();
                SortAndDisplayList();
            }
            catch (Exception ex)
            {
                // Handle exceptions and display an error message.
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }
        // Clear Linear button options.
        private void ClearSelectedStructure()
        {
            linearRadioButton.Checked = false;
            nonLinearRadioButton.Checked = false;
        }
        // 6.4 Create a custom method to populate the ComboBox when the Form Load method is called. The six categories must be read from a simple text file.
        private void LoadCategoriesFromFile()
        {
            // Get the executable directory, which should be the "bin\Debug" directory.
            string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Construct the file path relative to the executable directory.
            string filePath = Path.Combine(executableDirectory, "Categories.txt");

            // If file exists, continue.
            if (File.Exists(filePath))
            {
                // Read the categories from the text file.
                string[] categories = File.ReadAllLines(filePath);

                // Clear existing items in the ComboBox.
                categoryComboBox.Items.Clear();

                // Add the categories to the ComboBox.
                categoryComboBox.Items.AddRange(categories);
            }
            else
            {
                MessageBox.Show("Categories file not found.");
            }
        }
        // 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name and returns a Boolean after checking for duplicates. Use the built in List<T> method “Exists” to answer this requirement.
        private bool ValidName(string nameToCheck)
        {
            // Use the Exists method to check for duplicates.
            return Wiki.Exists(item => item.Name == nameToCheck);
        }
        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox. The first method must return a string value from the selected radio button (Linear or Non-Linear). The second method must send an integer index which will highlight an appropriate radio button.
        private string GetSelectedStructure()
        {
            if (linearRadioButton.Checked)
            {
                return "Linear";
            }
            else if (nonLinearRadioButton.Checked)
            {
                return "Non-Linear";
            }

            // Default to "Linear" if neither radio button is checked.
            return "Linear";
        }
        // Set radio button dependant of index selected
        private void HighlightStructureByIndex(int index)
        {
            if (index == 0)
            {
                linearRadioButton.Checked = true;
                nonLinearRadioButton.Checked = false;
            }
            else if (index == 1)
            {
                linearRadioButton.Checked = false;
                nonLinearRadioButton.Checked = true;
            }

        }
        // 6.7 Create a button method that will delete the currently selected record in the ListView. Ensure the user has the option to backout of this action by using a dialog box. Display an updated version of the sorted list at the end of this process.
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            // Ask the user for confirmation.
            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Get the selected item from the listView.
                ListViewItem selectedItem = listView.SelectedItems[0];
                              
                // Remove the selected item from the listView.
                listView.Items.Remove(selectedItem);

                // Find the corresponding item in the Wiki list and remove it.
                string selectedName = selectedItem.SubItems[0].Text;
                Information itemToRemove = Wiki.Find(info => info.Name == selectedName);
                Wiki.Remove(itemToRemove);
                SortAndDisplayList();
            }
        }
        // Colums for listView
        private void AddItemToListView(string name, string category)
        {
            ListViewItem item = new ListViewItem(name); // Create a ListViewItem with the "Name".
            item.SubItems.Add(category); // Add "Category" as a sub-item.
            listView.Items.Add(item); // Add the item to the ListView.
        }

        // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView. All the changes in the input controls will be written back to the list. Display an updated version of the sorted list at the end of this process.
        private void SaveEditedRecord()
        {
            // If no item selected when button pressed, notify user
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to edit.");
                return;
            }

            // Get the selected item from the ListView.
            ListViewItem selectedItem = listView.SelectedItems[0];

            // Find the corresponding item in the Wiki list and update it.
            string selectedName = selectedItem.SubItems[0].Text;
            Information itemToEdit = Wiki.Find(info => info.Name == selectedName);

            
            // Update the item with the values from the input controls.
            itemToEdit.Category = categoryComboBox.SelectedItem.ToString();
            itemToEdit.Structure = GetSelectedStructure();
            itemToEdit.Definition = definitionTextBox.Text;

            
            // Update the ListViewItem in the ListView.
            selectedItem.SubItems[1].Text = itemToEdit.Category;
                       
            // Display the sorted list after the update.
            SortAndDisplayList();
        }
        // 6.9 Create a single custom method that will sort and then display the Name and Category from the wiki information in the list.
        private void SortAndDisplayList()
        {
            Wiki.Sort((x, y) => x.Name.CompareTo(y.Name)); // Sort Wiki list by Name

            listView.Items.Clear(); // Clear the ListView

            // Populate the ListView with the sorted list
            foreach (var item in Wiki)
            {
                AddItemToListView(item.Name, item.Category);
            }
        }
        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name. If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView. At the end of the search process the search input TextBox must be cleared.
        private void binarySearch_Click(object sender, EventArgs e)
        {
            ClearAndResetControls();
            try
            {
                // Get the search input from the TextBox.
                string searchName = searchTextBox.Text;
                searchName = char.ToUpper(searchName[0]) + searchName.Substring(1);

                // Use BinarySearch to find the item in the Wiki list.
                int index = Wiki.BinarySearch(new Information(searchName, "", "", ""));

                // Clear the search input TextBox.
                searchTextBox.Clear();

                // Check if the search was successful.
                if (index >= 0)
                {
                    // Item found, update the input controls.
                    Information foundItem = Wiki[index];

                    // Populate input controls with found data.
                    nameTextBox.Text = foundItem.Name;
                    categoryComboBox.SelectedItem = foundItem.Category;
                    if (foundItem.Structure == "Linear")
                    {
                        linearRadioButton.Checked = true;
                    }
                    else if (foundItem.Structure == "Non-Linear")
                    {
                        nonLinearRadioButton.Checked = true;
                    }
                    definitionTextBox.Text = foundItem.Definition;

                    // Highlight the name in the ListView.
                    listView.Items[index].Selected = true;
                }
                else
                {
                    // Item not found, display a message and clear/reset controls.
                    MessageBox.Show("Item not found.", "Search Result");
                    ClearAndResetControls(); // Clear and reset the input controls
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during the search: " + ex.Message, "Error");
            }
        }
        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names and the associated information will be displayed in the related text boxes combo box and radio button.
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                // Get the selected item from the ListView.
                ListViewItem selectedItem = listView.SelectedItems[0];

                // Get the selected name from the selected item.
                string selectedName = selectedItem.SubItems[0].Text;

                // Find the corresponding item in the Wiki list.
                Information selectedItemInfo = Wiki.Find(info => info.Name == selectedName);

                if (selectedItemInfo != null)
                {
                    // Populate the input controls with the selected item's data.
                    nameTextBox.Text = selectedItemInfo.Name;
                    categoryComboBox.SelectedItem = selectedItemInfo.Category;
                    if (selectedItemInfo.Structure == "Linear")
                    {
                        linearRadioButton.Checked = true;
                    }
                    else if (selectedItemInfo.Structure == "Non-Linear")
                    {
                        nonLinearRadioButton.Checked = true;
                    }
                    definitionTextBox.Text = selectedItemInfo.Definition;

                    // Disable the nameTextBox to make it read-only.
                    nameTextBox.ReadOnly = true;
                }
            }
        }
        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        private void ClearAndResetControls()
        {
            try
            {
                // Clear and reset the TextBoxes, ComboBox, Radio buttons, and ListView selection.
                nameTextBox.Clear();
                categoryComboBox.SelectedItem = null as string;
                ClearSelectedStructure();
                definitionTextBox.Clear();
                listView.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while clearing and resetting controls: " + ex.Message, "Error");
            }
        }
        // 6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file or rename a saved file. All Wiki data is stored/retrieved using a binary reader/writer file format.
        private void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";
                // Open dialog to let user choose a file.
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName; // Get the selected file path
                    ReadDataFromFile(selectedFilePath); // Call a method to read data from the selected file
                    filePath = selectedFilePath; // Update the current file path for future saves
                }
            }
        }
        // 6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file or rename a saved file.All Wiki data is stored/retrieved using a binary reader/writer file format.
        private void saveButton1_Click(object sender, EventArgs e)
        {
            SaveDataWithDialog();
        }
        // Method to save data with a save dialog
        private void SaveDataWithDialog()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // User specified a file, saveFileDialog.FileName contains the chosen file path.
                    string selectedFilePath = saveFileDialog.FileName;

                    try
                    {
                        SaveDataToFile(selectedFilePath);
                        filePath = selectedFilePath; // Update the current file path
                        MessageBox.Show("Data saved successfully.", "Save Complete");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving data: " + ex.Message, "Error");
                    }
                }
            }
        }
        // Method to read data from a binary file.
        private void ReadDataFromFile(string filePath)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    // Clear the existing data in the Wiki list.
                    Wiki.Clear();

                    // Read and load data into your Wiki list
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        string name = reader.ReadString();
                        string category = reader.ReadString();
                        string structure = reader.ReadString();
                        string definition = reader.ReadString();

                        Information info = new Information(name, category, structure, definition);
                        Wiki.Add(info);
                    }

                    // Update the ListView after loading data
                    SortAndDisplayList();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Please choose a valid file.", "File Not Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error");
            }
        }
        // Method to save data to a binary file
        private void SaveDataToFile(string filePath)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (Information info in Wiki)
                    {
                        writer.Write(info.Name);
                        writer.Write(info.Category);
                        writer.Write(info.Structure);
                        writer.Write(info.Definition);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving data: " + ex.Message, "Error");
            }
        }
        // Save to file if changes made
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                SaveDataToFile(filePath); // Save data to the previously loaded file.
            }
        }
        // Allow user to enter data from an existing item into textbox and edit
        private void editButton_Click_1(object sender, EventArgs e)
        {
            SaveEditedRecord();
            ClearAndResetControls();
        }

    }
}



