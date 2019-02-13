using System.Diagnostics;
using System.Windows;

namespace MailSender
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("MailSender.log")
            {
                TraceOutputOptions = TraceOptions.DateTime
            });

            base.OnStartup(e);
        }
    }
}
