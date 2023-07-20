using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace firebase_connect
{
    public partial class Form1 : Form
    {
        //// FIREBASE CONFIGURATION ////
        ///

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "",  //Add your own AuthSecret, FirebaseProject->Project Setting->Service Accounts->Database Secrets
            BasePath = ""  //Add your own BasePath, FirebaseProject->Realtime Database
        };

        //Creating a variable for firebase client
        IFirebaseClient client;

        public int points { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Instantiation of client 
            //Firebase Connection 
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
               MessageBox.Show(" Connected to Firebase ");
            }
        }




        bool exist; //Initializing "exist" as a boolean

        //Using async method as communication between C# and firebase is asynchronous
        private async void updatebutton_Click(object sender, EventArgs e) //event handler when button is clicked
        {




            ////RETRIEVING THE DATA IF IT EXISTS IN FIREBASE DATA////
            ///


            //try this, 
            try
            {
                //Condition if the user input is empty

                if (textBox1.Text == "") //if the Phone field is empty and only button is pressed
                {
                    textBox1.Text = "donation"; //set the Phone field as "donation"
                }


                //For retriving the data from Firebase, we use FirebaseResponse
                //await keyword is used to be used with async method.
                FirebaseResponse response2 = await client.GetTaskAsync("newuserdata/" + textBox1.Text); //passing the, ("name of the parent node/", name of the subnode that we have to retrieve)


                //FirebaseResponse sends the data in form of class object
                Data obj = response2.ResultAs<Data>(); //Retriving data in this object created
               
                //saving the data retrived in textBox3 i.e Your old score
                textBox3.Text = obj.points.ToString(); //converting it to string so it can be displayed on the text field 



                Console.WriteLine("DATA UPDATED");
                exist = true; //set the boolean exist as true
            }
            catch
            {
                Console.WriteLine("DATA INSERTED");
                exist = false; //set the boolean exist as false
            }




            ////UPDATING THE NEW DATA TO THE EXISTING FIREBASE DATA////
            ///

            //if the data i.e phone number exists in firebase data base then update the points
            if (exist == true)
            {

                int points1 = int.Parse(textBox3.Text); //seting old score retrived as point1 in integer form

                Console.WriteLine("points1 : " + points1);



                int points2 = int.Parse(textBox2.Text); //seting new score as point2 in integer form
                Console.WriteLine("points2 : " + points2);

                points = points1 + points2; //adding the old points and new points together
                Console.WriteLine("points : " + points);

                textBox4.Text = Convert.ToString(points); //setting the total points in textbox4 field 

                Console.WriteLine(" ");

                //Now sending the updated data to firebase again
                //firebase accepts objects as a class, thus creating class name

                var data = new Data  //data is the object & Data is the class created in seperate file
                {
                    //Attributes that we have to update
                    points = int.Parse(textBox4.Text), //points accepeted by user converted from string to int

                };


                //For Updating the data we use FirebaseResponse from C# application to firebase
                //await keyword is used to be used with async method.
                FirebaseResponse response3 = await client.UpdateTaskAsync("newuserdata/" + textBox1.Text, data); //passing the, ("name of the parent node/", name of the subnode, object of the class Data)
                
                //The firebase data gives the response in object class i.e Data
                Data result = response3.ResultAs<Data>();

                //MessageBox to show data is updated successfully
                MessageBox.Show("Data Updated");

                //To go to new form2
               // this.Hide();
               // Form2 f2 = new Form2();
              //  f2.ShowDialog();

            }




            ////SENDING THE DATA IF IT DOES NOT EXIST IN FIREBASE DATA////
            ///

            //if the data i.e phone number does not exist in the firebase data base.

            else
            {
                //Sending the new data to firebase 
                //firebase accepts objects as a class, thus creating class name

                var data = new Data //data is the object & Data is the class created in seperate file
                {
                    //Attributes that we have to send
                    points = int.Parse(textBox2.Text),

                };


                //For Sending the new data we use SetResponse from C# application to firebase
                //await keyword is used to be used with async method.

                SetResponse response = await client.SetTaskAsync("newuserdata/" + textBox1.Text, data); //passing the, ("name of the parent node/", name of the subnode, object of the class Data)

                //The firebase data gives the response in object class i.e Data
                Data result = response.ResultAs<Data>();

                int points2 = int.Parse(textBox2.Text); 
                Console.WriteLine("points : " + points2);
                Console.WriteLine(" ");

                //MessageBox to show new data is sent successfully
                MessageBox.Show("Data Inserted");

                //To go to new form2
               
            }


        }




        //Styling
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(120, Color.Green);
        }
    }
}
