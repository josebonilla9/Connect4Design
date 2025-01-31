namespace Connect4Design
{
    partial class GameChatForm
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
            sendButton = new Button();
            sendBox = new TextBox();
            chatBox = new TextBox();
            SuspendLayout();
            // 
            // sendButton
            // 
            sendButton.Location = new Point(564, 401);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(78, 24);
            sendButton.TabIndex = 5;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            // 
            // sendBox
            // 
            sendBox.Location = new Point(158, 402);
            sendBox.Name = "sendBox";
            sendBox.Size = new Size(400, 23);
            sendBox.TabIndex = 4;
            // 
            // chatBox
            // 
            chatBox.Location = new Point(158, 25);
            chatBox.Multiline = true;
            chatBox.Name = "chatBox";
            chatBox.ReadOnly = true;
            chatBox.Size = new Size(400, 354);
            chatBox.TabIndex = 3;
            // 
            // pruebaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sendButton);
            Controls.Add(sendBox);
            Controls.Add(chatBox);
            Name = "pruebaForm";
            Text = "pruebaForm";
            Load += pruebaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendButton;
        private TextBox sendBox;
        private TextBox chatBox;
    }
}