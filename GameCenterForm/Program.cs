using System.Globalization;

namespace GameCenterForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            ApplicationConfiguration.Initialize();
            //Application.Run(new LoginForm());
            Application.Run(new MainForm());
        }
    }
}