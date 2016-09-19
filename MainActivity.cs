using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using SQLite;

namespace MedicalApp
{

    [Activity(Label = "MedicalApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {


        RelativeLayout mRelativeLayout;
        Button mButton;
        private EditText UserName;
        private EditText Password;
        DatabaseControl dbControl = new DatabaseControl();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mRelativeLayout = FindViewById<RelativeLayout>(Resource.Id.mainView);
            mButton = FindViewById<Button>(Resource.Id.btnLogin);
            UserName = FindViewById<EditText>(Resource.Id.txtUserName);
            Password = FindViewById<EditText>(Resource.Id.txtPassword);
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlnet.db");
            dbControl.setPath(pathToDatabase);
            
            

            mButton.Click += mButton_Click;
            mRelativeLayout.Click += mRelativeLayout_Click;
            database_Setup();



        }

        public void database_Setup()
        {
            dbControl.accessDatabase();
           
        }

        void mButton_Click(object sender, EventArgs e)
        {
            string user = UserName.Text;
            string password = Password.Text;
            Person login = new Person(user, password);
            if (dbControl.checkLogin(login))
                {
                Intent intent = new Intent(this, typeof(GUI));
                this.StartActivity(intent);
                Finish();
            }
                else
                {
                    new AlertDialog.Builder(this).SetMessage("You have entered an incorrect Username or Password")
                    .SetTitle("Login Error")
                    .SetNeutralButton("Retry", (senderAlert, args) => { }
                      ) .Show();
                 };

        }

        void mRelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

    }
}



