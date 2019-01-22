using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Intent;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace IoTVoiceControl.Speech
{
    public class SpeechToIntent
    {
        public async Task<Result<LuisResult>> Recognize(string filePath)
        {
            // Credenciais do LUIS
            var config = SpeechConfig.FromSubscription("YourSubscriptionKey", "YourRegion");
            config.SpeechRecognitionLanguage = "pt-br";

            using (var audioInput = AudioConfig.FromWavFileInput(filePath))
            {
                using (var recognizer = new IntentRecognizer(config, audioInput))
                {
                    var model = LanguageUnderstandingModel.FromAppId("YourLuisAppId");
                    recognizer.AddIntent(model, "intent.iot.device_off", "device_off");
                    recognizer.AddIntent(model, "intent.iot.device_on", "device_on");

                    var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                    if (result.Reason == ResultReason.RecognizedIntent)
                    {
                        var js = new DataContractJsonSerializer(typeof(LuisResult));
                        var ms = new MemoryStream(Encoding.UTF8.GetBytes(result.Properties.GetProperty(PropertyId.LanguageUnderstandingServiceResponse_JsonResult)));
                        return new Result<LuisResult>((js.ReadObject(ms) as LuisResult));
                    }
                    else if (result.Reason == ResultReason.NoMatch)
                        return new Result<LuisResult>(null, false, "Falha no reconhecimento do áudio!");
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = CancellationDetails.FromResult(result);
                        if (cancellation.Reason == CancellationReason.Error)
                            return new Result<LuisResult>(null, false, $"Motivo: {cancellation.Reason}. Detalhes: {cancellation.ErrorDetails}");
                        return new Result<LuisResult>(null, false, $"Motivo: {cancellation.Reason}.");
                    }
                }
            }
            return new Result<LuisResult>(null, false, "Erro desconhecido!");
        }
    }
}
