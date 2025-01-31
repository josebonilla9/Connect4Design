namespace Connect4Design
{
    partial class MessageForm
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
            messageLabel = new Label();
            congratsLabel = new Label();
            SuspendLayout();
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageLabel.ForeColor = Color.Lime;
            messageLabel.Location = new Point(74, 137);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(331, 29);
            messageLabel.TabIndex = 4;
            messageLabel.Text = "El jugador humano ha ganado";
            // 
            // congratsLabel
            // 
            congratsLabel.AutoSize = true;
            congratsLabel.Font = new Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            congratsLabel.ForeColor = Color.Lime;
            congratsLabel.Location = new Point(158, 97);
            congratsLabel.Name = "congratsLabel";
            congratsLabel.Size = new Size(148, 29);
            congratsLabel.TabIndex = 3;
            congratsLabel.Text = "¡Felicidades!";
            // 
            // messageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 266);
            Controls.Add(messageLabel);
            Controls.Add(congratsLabel);
            Name = "messageForm";
            Text = "messageForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label messageLabel;
        private Label congratsLabel;
    }
}