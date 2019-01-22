using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Threading.Tasks;

namespace IoTVoiceControl.Speech
{
    public class SpeechToText
    {
        public async Task<Result<string>> Recognize(string filePath)
        {
            // Credenciais SpeechToText criado no Azure
            var config = SpeechConfig.FromSubscription("YourSpeechToTextKey", "YourRegion");
            config.SpeechRecognitionLanguage = "pt-br";

            using (var audioInput = AudioConfig.FromWavFileInput(filePath))
            {
                using (var recognizer = new SpeechRecognizer(config, audioInput))
                {
                    var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                    if (result.Reason == ResultReason.RecognizedSpeech)
                        return new Result<string>(result.Text);
                    else if (result.Reason == ResultReason.NoMatch)
                        return new Result<string>(result.Text, false, "Falha no reconhecimento do áudio!");
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = CancellationDetails.FromResult(result);
                        if (cancellation.Reason == CancellationReason.Error)
                            return new Result<string>(result.Text, false, $"Motivo: {cancellation.Reason}. Detalhes: {cancellation.ErrorDetails}");
                        return new Result<string>(result.Text, false, $"Motivo: {cancellation.Reason}.");
                    }
                }
            }
            return new Result<string>(null, false, "Erro desconhecido!");
        }
    }
}
