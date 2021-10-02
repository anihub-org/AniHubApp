using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AniHubApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AniHubApp.Droid.Services
{
    public class BatteryService : IBatteryService
    {
        public string GetStatus() => string.Empty;
    }
}