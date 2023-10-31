namespace Wiki_Application_Database_2._0
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.definitionTextBox = new System.Windows.Forms.TextBox();
            this.linearRadioButton = new System.Windows.Forms.RadioButton();
            this.nonLinearRadioButton = new System.Windows.Forms.RadioButton();
            this.listView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteButton = new System.Windows.Forms.Button();
            this.structureGroupBox = new System.Windows.Forms.GroupBox();
            this.editButton_1 = new System.Windows.Forms.Button();
            this.binarySearch = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.structureGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(28, 93);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(383, 100);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(135, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(383, 138);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(135, 21);
            this.categoryComboBox.TabIndex = 2;
            // 
            // definitionTextBox
            // 
            this.definitionTextBox.Location = new System.Drawing.Point(383, 266);
            this.definitionTextBox.Multiline = true;
            this.definitionTextBox.Name = "definitionTextBox";
            this.definitionTextBox.Size = new System.Drawing.Size(231, 149);
            this.definitionTextBox.TabIndex = 4;
            // 
            // linearRadioButton
            // 
            this.linearRadioButton.AutoSize = true;
            this.linearRadioButton.Location = new System.Drawing.Point(6, 19);
            this.linearRadioButton.Name = "linearRadioButton";
            this.linearRadioButton.Size = new System.Drawing.Size(54, 17);
            this.linearRadioButton.TabIndex = 5;
            this.linearRadioButton.TabStop = true;
            this.linearRadioButton.Text = "Linear";
            this.linearRadioButton.UseVisualStyleBackColor = true;
            // 
            // nonLinearRadioButton
            // 
            this.nonLinearRadioButton.AutoSize = true;
            this.nonLinearRadioButton.Location = new System.Drawing.Point(6, 42);
            this.nonLinearRadioButton.Name = "nonLinearRadioButton";
            this.nonLinearRadioButton.Size = new System.Drawing.Size(77, 17);
            this.nonLinearRadioButton.TabIndex = 6;
            this.nonLinearRadioButton.TabStop = true;
            this.nonLinearRadioButton.Text = "Non-Linear";
            this.nonLinearRadioButton.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.category});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(109, 58);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(257, 357);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 160;
            // 
            // category
            // 
            this.category.Text = "Category";
            this.category.Width = 90;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(28, 151);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // structureGroupBox
            // 
            this.structureGroupBox.Controls.Add(this.linearRadioButton);
            this.structureGroupBox.Controls.Add(this.nonLinearRadioButton);
            this.structureGroupBox.Location = new System.Drawing.Point(383, 165);
            this.structureGroupBox.Name = "structureGroupBox";
            this.structureGroupBox.Size = new System.Drawing.Size(135, 82);
            this.structureGroupBox.TabIndex = 9;
            this.structureGroupBox.TabStop = false;
            this.structureGroupBox.Text = "Structure";
            // 
            // editButton_1
            // 
            this.editButton_1.Location = new System.Drawing.Point(28, 122);
            this.editButton_1.Name = "editButton_1";
            this.editButton_1.Size = new System.Drawing.Size(75, 23);
            this.editButton_1.TabIndex = 10;
            this.editButton_1.Text = "Edit";
            this.editButton_1.UseVisualStyleBackColor = true;
            this.editButton_1.Click += new System.EventHandler(this.editButton_Click_1);
            // 
            // binarySearch
            // 
            this.binarySearch.Location = new System.Drawing.Point(539, 12);
            this.binarySearch.Name = "binarySearch";
            this.binarySearch.Size = new System.Drawing.Size(75, 23);
            this.binarySearch.TabIndex = 11;
            this.binarySearch.Text = "Search";
            this.binarySearch.UseVisualStyleBackColor = true;
            this.binarySearch.Click += new System.EventHandler(this.binarySearch_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(620, 14);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(84, 20);
            this.searchTextBox.TabIndex = 12;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(28, 180);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 13;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton1
            // 
            this.saveButton1.Location = new System.Drawing.Point(28, 209);
            this.saveButton1.Name = "saveButton1";
            this.saveButton1.Size = new System.Drawing.Size(75, 23);
            this.saveButton1.TabIndex = 14;
            this.saveButton1.Text = "Save";
            this.saveButton1.UseVisualStyleBackColor = true;
            this.saveButton1.Click += new System.EventHandler(this.saveButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Definition";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Category";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.binarySearch);
            this.Controls.Add(this.editButton_1);
            this.Controls.Add(this.structureGroupBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.definitionTextBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.addButton);
            this.Name = "Form1";
            this.Text = "Wiki Application Database 2.0";
            this.structureGroupBox.ResumeLayout(false);
            this.structureGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.TextBox definitionTextBox;
        private System.Windows.Forms.RadioButton linearRadioButton;
        private System.Windows.Forms.RadioButton nonLinearRadioButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader category;
        private System.Windows.Forms.GroupBox structureGroupBox;
        private System.Windows.Forms.Button editButton_1;
        private System.Windows.Forms.Button binarySearch;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

