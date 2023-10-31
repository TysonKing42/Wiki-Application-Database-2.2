using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Name: Tyson King
 * Title: Wiki Application Database 2.0
 * Description: Database Application that uses Wiki to save data. User has multiple options of control of data 
 * */

namespace Wiki_Application_Database_2._0
{
    // 6.1 Create a separate class file to hold the four data items of the Data Structure (use the Data Structure Matrix as a guide). Use private properties for the fields which must be of type “string”. The class file must have separate setters and getters, add an appropriate IComparable for the Name attribute. Save the class as “Information.cs”.
    public class Information : IComparable<Information>
    {
        //// Use private properties for the fields which must be of type “string”.
        // The class file must have separate setters and getters, add an appropriate IComparable for the Name attribute.
        // Save the class as “Information.cs”.
        private string name;
        private string category;
        private string structure;
        private string definition;
        // Property for the Name field with a getter and setter
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // Property for the Category field with a getter and setter
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        // Property for the Structure field with a getter and setter
        public string Structure
        {
            get { return structure; }
            set { structure = value; }
        }
        // Property for the Definition field with a getter and setter
        public string Definition
        {
            get { return definition; }
            set { definition = value; }
        }
        // Constructor to initialize the Information object with values for its fields
        public Information(string name, string category, string structure, string definition)
        {
            Name = name;
            Category = category;
            Structure = structure;
            Definition = definition;
        }
        // Implementation of the IComparable interface to enable sorting of Information 
        public int CompareTo(Information other)
        {
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}

