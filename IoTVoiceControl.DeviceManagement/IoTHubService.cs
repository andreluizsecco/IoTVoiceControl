using Microsoft.Azure.Devices;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTVoiceControl.DeviceManagement
{
    public class IoTHubService
    {
        private const string ConnectionString = "YourIoTHubConnectionString";

        public void DeviceControl(bool on, string device_name)
        {
            string command = string.Empty;

            if (RemoveDiacritics(device_name.ToLower()).Contains("lampada") || device_name.ToLower().Contains("luz"))
                command = on ? "LampOn" : "LampOff";
            System.Threading.ThreadPool.QueueUserWorkItem(a => SendEvent(command).Wait());
        }

        private async Task SendEvent(string command)
        {
            ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(ConnectionString, TransportType.Amqp);
            Message eventMessage = new Message(Encoding.UTF8.GetBytes(command));
            await serviceClient.SendAsync("DeviceId", eventMessage);
        }

        public static string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                             UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }
    }
}
