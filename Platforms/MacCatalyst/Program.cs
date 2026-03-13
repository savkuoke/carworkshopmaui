using ObjCRuntime;
using UIKit;

namespace CarWorkshopMaui;

public class Program
{
    // Main entry point for Mac Catalyst
    static void Main(string[] args)
    {
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}
