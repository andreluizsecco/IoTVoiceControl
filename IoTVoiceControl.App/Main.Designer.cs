namespace IoTVoiceControl.App
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.luisRecognizeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(64, 21);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(251, 20);
            this.filePathTextBox.TabIndex = 0;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(321, 19);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Procurar";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Arquivo:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::IoTVoiceControl.App.Properties.Resources.lamp_off;
            this.pictureBox.Location = new System.Drawing.Point(141, 110);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(127, 183);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // luisRecognizeButton
            // 
            this.luisRecognizeButton.Location = new System.Drawing.Point(218, 57);
            this.luisRecognizeButton.Name = "luisRecognizeButton";
            this.luisRecognizeButton.Size = new System.Drawing.Size(112, 38);
            this.luisRecognizeButton.TabIndex = 4;
            this.luisRecognizeButton.Text = "Reconhecer intenção com LUIS";
            this.luisRecognizeButton.UseVisualStyleBackColor = true;
            this.luisRecognizeButton.Click += new System.EventHandler(this.luisRecognizerButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 57);
            this.button1.Name = "textRecognizerButton";
            this.button1.Size = new System.Drawing.Size(95, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Reconhecer apenas texto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.textRecognizerButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 328);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.luisRecognizeButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.filePathTextBox);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IoT Voice Control";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button luisRecognizeButton;
        private System.Windows.Forms.Button button1;
    }
}

