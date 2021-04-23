using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF5Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class CustomView : TemplatedView
    {
        public CustomView()
        {
            this.ControlTemplate = new ControlTemplate(typeof(StackLayout));
        }

        public View Input { get; set; }
    }
}
