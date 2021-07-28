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
using System.Xml;

namespace StudentRegistrationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string filepath="C:\\Users\\mukpahwa\\source\\repos\\StudentRegistrationApp\\StudentRegistrationApp\\class.xml";
   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // creating object of XML DOCument class  
            XmlDocument xDoc = new XmlDocument();
            try {

                xDoc.Load(filepath);

                //Select root node which is already defined  
                XmlNode RootNode = xDoc.SelectSingleNode("class");
                //Creating one child node with tag name student  
                XmlNode bookNode = RootNode.AppendChild(xDoc.CreateNode(XmlNodeType.Element, "student", ""));
                //adding node FirstName to student node and inside it data taking from txtStudentFirstName TextBox  

                bookNode.AppendChild(xDoc.CreateNode(XmlNodeType.Element, "FirstName", "")).InnerText = txtStudentFirstName.Text;
                //adding node LastName to student node and inside it data taking from txtStudentLastName TextBox   
                bookNode.AppendChild(xDoc.CreateNode(XmlNodeType.Element, "LastName", "")).InnerText = txtStudentLastName.Text;
                //adding node DateofBirth to student node and inside it data taking from StudentdateofBirth TextBox 
                bookNode.AppendChild(xDoc.CreateNode(XmlNodeType.Element, "DateofBirth", "")).InnerText = StudentdateofBirth.Text;
                xDoc.Save(filepath);
                MessageBox.Show("Student Registered Successfully!!");
                txtStudentFirstName.Clear();
                txtStudentLastName.Clear();
                StudentdateofBirth.Text = string.Empty;



            }
            catch (Exception)
            {
                MessageBox.Show("Xml File Not found,Check path");

            }

        }

        private void btnUnRegister_Click(object sender, RoutedEventArgs e)  
        {
            var fname = txtStudentFirstName.Text;
            var lname = txtStudentLastName.Text;
            var dob = StudentdateofBirth.Text;
            bool flag = false;
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(filepath);

                foreach (XmlNode xNode in xDoc.SelectNodes("class/student"))
                {
                    if ((xNode.SelectSingleNode("FirstName").InnerText == fname) && (xNode.SelectSingleNode("LastName").InnerText == lname) && (xNode.SelectSingleNode("DateofBirth").InnerText == dob))
                    {
                        flag = true;
                        xNode.ParentNode.RemoveChild(xNode);

                        xDoc.Save(filepath);
                        MessageBox.Show("Student Unregistered Successfully!!");

                        txtStudentFirstName.Clear();
                        txtStudentLastName.Clear();
                        StudentdateofBirth.Text = string.Empty;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xml File Not found, Check file path");

            }
            

            if(flag == false)
            {
                MessageBox.Show("Invalid Record! Try again ");
                txtStudentFirstName.Clear();
                txtStudentLastName.Clear();
                StudentdateofBirth.Text = string.Empty;
            }
           

        }
    }
}
