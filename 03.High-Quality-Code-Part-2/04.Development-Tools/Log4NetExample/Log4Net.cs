namespace Log4NetExample
{
    using System;

    using log4net;
    using log4net.Config;

    public class Log4Net
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Log4Net));

        public static void Main()
        {
            XmlConfigurator.Configure();
            Log.Debug("Starting application");
            for (int i = 0; i < 15; i++)
            {
                Log.InfoFormat(DateTime.Now.ToString("yyyy.MM.dd-hh.mm.ss~fff"));
            }

            Log.Debug("Ending application");
        }
    }
}
