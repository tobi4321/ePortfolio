using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bomb_Defuse
{
    public partial class MainPage : ContentPage
    {
        static string bombCode = "";
        static int clickCount = 0;

        public MainPage()
        {
            InitializeComponent();
            generateBombCode();
        }

        async void Btn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text.Equals(bombCode))
            {
                clickCount++;
                lbl_defCode.Text = this.lbl_defCode.Text + bombCode;
                generateBombCode();
                if (clickCount == 3)
                {
                    await DisplayAlert("BOMB DEFUSED", "You got the code right", "RETRY");
                    lbl_defCode.Text = "Code: ";
                    clickCount = 0;
                    generateBombCode();
                }
            }
            else {
                await DisplayAlert("GAME OVER", "This was the wrong code", "RETRY");
                lbl_defCode.Text = "Code: ";
                clickCount = 0;
                generateBombCode();
            }

        }
        private void generateBombCode()
        {
                bombCode = new Random().Next(0, 2).ToString();
                //this.lbl_defCode.Text = "Code: " + bombCode;
        }
    }
}
