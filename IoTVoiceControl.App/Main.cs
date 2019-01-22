using IoTVoiceControl.DeviceManagement;
using IoTVoiceControl.Speech;
using System;
using System.Linq;
using System.Windows.Forms;

namespace IoTVoiceControl.App
{
    public partial class Main : Form
    {
        private readonly SpeechToText _speechToText;
        private readonly SpeechToIntent _speechToIntent;
        private readonly IoTHubService _iotHubService;

        public Main()
        {
            InitializeComponent();
            _speechToText = new SpeechToText();
            _speechToIntent = new SpeechToIntent();
            _iotHubService = new IoTHubService();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            filePathTextBox.Text = openFileDialog.FileName;
        }

        private async void luisRecognizerButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePathTextBox.Text))
            {
                // Usando esse tipo de reconhecimento de fala, você terá um retorno que já passou por um serviço de processamento de linguagem natural,
                // contendo a intenção da frase e as entidades (são partes chave da frase que representam algo dentro do contexto do seu modelo, nesse caso o dispositivo)
                var result = await _speechToIntent.Recognize(filePathTextBox.Text);
                if (result.Success)
                {
                    var intent = result.Data.topScoringIntent.intent;
                    var device = result.Data.entities.FirstOrDefault(x => x.type.Equals("iot.device_name")).entity;

                    MessageBox.Show("Conteúdo reconhecido:\r\n\r\nTEXTO: " + result.Data.query + "\r\n" +
                                    "INTENÇÃO: " + intent + "\r\nENTIDADE: " + device);

                    if (intent.Equals("intent.iot.device_on"))
                    {
                        _iotHubService.DeviceControl(true, device);
                        ChangePicture(true);
                    }
                    else if (intent.Equals("intent.iot.device_off"))
                    {
                        _iotHubService.DeviceControl(false, device);
                        ChangePicture(false);
                    }
                }
                else
                    MessageBox.Show(result.Error, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Selecione um arquivo de áudio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ChangePicture(bool state)
        {
            if (state)
                pictureBox.Image = Properties.Resources.lamp_on;
            else
                pictureBox.Image = Properties.Resources.lamp_off;
        }

        private async void textRecognizerButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePathTextBox.Text))
            {
                // Usando esse tipo de reconhecimento de fala, você terá apenas o texto extraído do áudio
                // que não possui nenhum tipo processamento de linguagem natural, dificultando a identificação da intenção no comando de voz
                var result = await _speechToText.Recognize(filePathTextBox.Text);
                if (result.Success)
                {
                    MessageBox.Show("Conteúdo reconhecido:\r\n\r\n" + result.Data);

                    if (result.Data.ToLower().Contains("desligar"))
                    {
                        _iotHubService.DeviceControl(false, "lampada");
                        ChangePicture(false);
                    }
                    else if (result.Data.ToLower().Contains("ligar"))
                    {
                        _iotHubService.DeviceControl(true, "lampada");
                        ChangePicture(true);
                    }
                }
                else
                    MessageBox.Show(result.Error, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Selecione um arquivo de áudio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
