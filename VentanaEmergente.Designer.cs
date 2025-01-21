namespace Connect4Design
{
    partial class VentanaEmergente
    {
        private System.ComponentModel.IContainer components = null;

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
            sendBox = new TextBox();
            chatBox = new TextBox();
            sendButton = new Button();
            SuspendLayout();
            // 
            // sendBox
            // 
            sendBox.Location = new Point(194, 22);
            sendBox.Multiline = true;
            sendBox.Name = "sendBox";
            sendBox.ReadOnly = true;
            sendBox.Size = new Size(400, 354);
            sendBox.TabIndex = 0;
            sendBox.TextChanged += sendBox_TextChanged;
            // 
            // chatBox
            // 
            chatBox.Location = new Point(194, 399);
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(400, 23);
            chatBox.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(600, 398);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(78, 24);
            sendButton.TabIndex = 2;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            // 
            // VentanaEmergente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sendButton);
            Controls.Add(chatBox);
            Controls.Add(sendBox);
            Name = "VentanaEmergente";
            Text = "VentanaEmergente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox sendBox;
        private TextBox chatBox;
        private Button sendButton;
    }
}