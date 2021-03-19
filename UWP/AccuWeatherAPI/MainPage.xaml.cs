using AccuWeatherAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AccuWeatherAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<WeatherJSON> WeatherEachHours;
        ObservableCollection<WeatherEachDay> WeatherEachDays;

        public MainPage()
        {

            this.InitializeComponent();
            WeatherEachHours = new ObservableCollection<WeatherJSON>();
            InitJSON();

            WeatherEachDays = new ObservableCollection<WeatherEachDay>();
            InitEachDaysJSON();

        }

        public async void InitJSON()
        {
            var url = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/353412"
                + "?apikey=tbFOLXfZmAxAexEYOmXhcxnbZBDjQBSh&language=vi-vn&metric=true";
            var list = await WeatherJSON.GetJSON(url) as List<WeatherJSON>;
            Debug.WriteLine("Count:" + list.Count);

            list.ForEach(it =>
            {
            var match = Regex.Matches(it.DateTime, "T(?<time>\\d+):")[0].Groups["time"].Value;
            if (int.Parse(match) - 12)
            {
                match = (int.Parse(match) - 12) + "PM";
            }
            else
            {
                match += "PM";
            }
            it.DateTime = match;
            it.Temparature.Value += "\u0000";
            it.WeatherICon = string.Format("https://vortex.accuweather.com/adc2010/images/slate/icons/{0}.svg"),
                    it.weatherIcon);

            WeatherEachHours.Add(it);

                
            }
        });

    WeatherDescriptionTextBlock.Text = List[0].IconPhrase;
    WeatherTemparatureTextBlock.Text = list[0].Temparuature.Value;

    }
}
