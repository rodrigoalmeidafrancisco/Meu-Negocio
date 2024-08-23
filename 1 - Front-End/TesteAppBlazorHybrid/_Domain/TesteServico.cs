#if ANDROID
using Android.Content;
using Android.Views;
using Android.Runtime;
#elif IOS
using CoreLocation;
using UIKit;
#endif
using TesteAppBlazorHybrid.Shared;

namespace TesteAppBlazorHybrid._Domain
{
    public class TesteServico
    {
        public TesteServico()
        {
        }

        public EnumDeviceOrientation GetOrientation()
        {
#if ANDROID
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            SurfaceOrientation orientation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = orientation == SurfaceOrientation.Rotation90 || orientation == SurfaceOrientation.Rotation270;
            return isLandscape ? EnumDeviceOrientation.Landscape : EnumDeviceOrientation.Portrait;
#elif IOS
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = orientation == UIInterfaceOrientation.Portrait || orientation == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? EnumDeviceOrientation.Portrait : EnumDeviceOrientation.Landscape;
#else
            return EnumDeviceOrientation.Undefined;
#endif
        }

    }
}
