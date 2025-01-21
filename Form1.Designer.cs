namespace prueba
{
    partial class Form1
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

        private Label[] labelArray;

        private void InitLabelArray()
        {
            labelArray = new Label[]
            {
                label1, label2, label3, label4, label5, label6, label7,
                label8, label9, label10, label11, label12, label13, label14,
                label15, label16, label17, label18, label19, label20, label21,
                label22, label23, label24, label25, label26, label27, label28,
                label29, label30, label31, label32, label33, label34, label35,
                label36, label37, label38, label39, label40, label41, label42
            };

            for (int i = 0; i < labelArray.Length; i++)
            {
                labelArray[i].Click += label_Click;

                int x = (i % 7) + 1;
                int y = (i / 7) + 1;

                labelArray[i].Tag = $"({x},{y})";
            }
        }



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            difficultyLabel = new Label();
            mainPanel = new Panel();
            gamePanel = new FlowLayoutPanel();
            firstRowPanel = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            secondRowPanel = new FlowLayoutPanel();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            thirdRowPanel = new FlowLayoutPanel();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            fourthRowPanel = new FlowLayoutPanel();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            fifthRowPanel = new FlowLayoutPanel();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            sixthRowPanel = new FlowLayoutPanel();
            label36 = new Label();
            label37 = new Label();
            label38 = new Label();
            label39 = new Label();
            label40 = new Label();
            label41 = new Label();
            label42 = new Label();
            difficultyChooser = new ComboBox();
            label43 = new Label();
            mainPanel.SuspendLayout();
            gamePanel.SuspendLayout();
            firstRowPanel.SuspendLayout();
            secondRowPanel.SuspendLayout();
            thirdRowPanel.SuspendLayout();
            fourthRowPanel.SuspendLayout();
            fifthRowPanel.SuspendLayout();
            sixthRowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // difficultyLabel
            // 
            difficultyLabel.AutoSize = true;
            difficultyLabel.Location = new Point(704, 21);
            difficultyLabel.Name = "difficultyLabel";
            difficultyLabel.Size = new Size(58, 15);
            difficultyLabel.TabIndex = 10;
            difficultyLabel.Text = "Dificultad";
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(label43);
            mainPanel.Controls.Add(gamePanel);
            mainPanel.Controls.Add(difficultyLabel);
            mainPanel.Controls.Add(difficultyChooser);
            mainPanel.Location = new Point(-1, 2);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(961, 667);
            mainPanel.TabIndex = 11;
            // 
            // gamePanel
            // 
            gamePanel.Controls.Add(firstRowPanel);
            gamePanel.Controls.Add(secondRowPanel);
            gamePanel.Controls.Add(thirdRowPanel);
            gamePanel.Controls.Add(fourthRowPanel);
            gamePanel.Controls.Add(fifthRowPanel);
            gamePanel.Controls.Add(sixthRowPanel);
            gamePanel.FlowDirection = FlowDirection.BottomUp;
            gamePanel.Location = new Point(3, 47);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(958, 617);
            gamePanel.TabIndex = 12;
            // 
            // firstRowPanel
            // 
            firstRowPanel.Controls.Add(label1);
            firstRowPanel.Controls.Add(label2);
            firstRowPanel.Controls.Add(label3);
            firstRowPanel.Controls.Add(label4);
            firstRowPanel.Controls.Add(label5);
            firstRowPanel.Controls.Add(label6);
            firstRowPanel.Controls.Add(label7);
            firstRowPanel.Location = new Point(3, 518);
            firstRowPanel.Name = "firstRowPanel";
            firstRowPanel.Size = new Size(948, 96);
            firstRowPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Cursor = Cursors.Hand;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 96);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Cursor = Cursors.Hand;
            label2.Location = new Point(138, 0);
            label2.Name = "label2";
            label2.Size = new Size(129, 96);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Cursor = Cursors.Hand;
            label3.Location = new Point(273, 0);
            label3.Name = "label3";
            label3.Size = new Size(129, 96);
            label3.TabIndex = 2;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Cursor = Cursors.Hand;
            label4.Location = new Point(408, 0);
            label4.Name = "label4";
            label4.Size = new Size(129, 96);
            label4.TabIndex = 3;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Cursor = Cursors.Hand;
            label5.Location = new Point(543, 0);
            label5.Name = "label5";
            label5.Size = new Size(129, 96);
            label5.TabIndex = 4;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Cursor = Cursors.Hand;
            label6.Location = new Point(678, 0);
            label6.Name = "label6";
            label6.Size = new Size(129, 96);
            label6.TabIndex = 5;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Cursor = Cursors.Hand;
            label7.Location = new Point(813, 0);
            label7.Name = "label7";
            label7.Size = new Size(129, 96);
            label7.TabIndex = 6;
            // 
            // secondRowPanel
            // 
            secondRowPanel.Controls.Add(label8);
            secondRowPanel.Controls.Add(label9);
            secondRowPanel.Controls.Add(label10);
            secondRowPanel.Controls.Add(label11);
            secondRowPanel.Controls.Add(label12);
            secondRowPanel.Controls.Add(label13);
            secondRowPanel.Controls.Add(label14);
            secondRowPanel.Location = new Point(3, 416);
            secondRowPanel.Name = "secondRowPanel";
            secondRowPanel.Size = new Size(948, 96);
            secondRowPanel.TabIndex = 7;
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Cursor = Cursors.Hand;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(129, 96);
            label8.TabIndex = 7;
            // 
            // label9
            // 
            label9.BorderStyle = BorderStyle.FixedSingle;
            label9.Cursor = Cursors.Hand;
            label9.Location = new Point(138, 0);
            label9.Name = "label9";
            label9.Size = new Size(129, 96);
            label9.TabIndex = 8;
            // 
            // label10
            // 
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.Cursor = Cursors.Hand;
            label10.Location = new Point(273, 0);
            label10.Name = "label10";
            label10.Size = new Size(129, 96);
            label10.TabIndex = 9;
            // 
            // label11
            // 
            label11.BorderStyle = BorderStyle.FixedSingle;
            label11.Cursor = Cursors.Hand;
            label11.Location = new Point(408, 0);
            label11.Name = "label11";
            label11.Size = new Size(129, 96);
            label11.TabIndex = 10;
            // 
            // label12
            // 
            label12.BorderStyle = BorderStyle.FixedSingle;
            label12.Cursor = Cursors.Hand;
            label12.Location = new Point(543, 0);
            label12.Name = "label12";
            label12.Size = new Size(129, 96);
            label12.TabIndex = 11;
            // 
            // label13
            // 
            label13.BorderStyle = BorderStyle.FixedSingle;
            label13.Cursor = Cursors.Hand;
            label13.Location = new Point(678, 0);
            label13.Name = "label13";
            label13.Size = new Size(129, 96);
            label13.TabIndex = 12;
            // 
            // label14
            // 
            label14.BorderStyle = BorderStyle.FixedSingle;
            label14.Cursor = Cursors.Hand;
            label14.Location = new Point(813, 0);
            label14.Name = "label14";
            label14.Size = new Size(129, 96);
            label14.TabIndex = 13;
            // 
            // thirdRowPanel
            // 
            thirdRowPanel.Controls.Add(label15);
            thirdRowPanel.Controls.Add(label16);
            thirdRowPanel.Controls.Add(label17);
            thirdRowPanel.Controls.Add(label18);
            thirdRowPanel.Controls.Add(label19);
            thirdRowPanel.Controls.Add(label20);
            thirdRowPanel.Controls.Add(label21);
            thirdRowPanel.Location = new Point(3, 314);
            thirdRowPanel.Name = "thirdRowPanel";
            thirdRowPanel.Size = new Size(948, 96);
            thirdRowPanel.TabIndex = 8;
            // 
            // label15
            // 
            label15.BorderStyle = BorderStyle.FixedSingle;
            label15.Cursor = Cursors.Hand;
            label15.Location = new Point(3, 0);
            label15.Name = "label15";
            label15.Size = new Size(129, 96);
            label15.TabIndex = 7;
            // 
            // label16
            // 
            label16.BorderStyle = BorderStyle.FixedSingle;
            label16.Cursor = Cursors.Hand;
            label16.Location = new Point(138, 0);
            label16.Name = "label16";
            label16.Size = new Size(129, 96);
            label16.TabIndex = 8;
            // 
            // label17
            // 
            label17.BorderStyle = BorderStyle.FixedSingle;
            label17.Cursor = Cursors.Hand;
            label17.Location = new Point(273, 0);
            label17.Name = "label17";
            label17.Size = new Size(129, 96);
            label17.TabIndex = 9;
            // 
            // label18
            // 
            label18.BorderStyle = BorderStyle.FixedSingle;
            label18.Cursor = Cursors.Hand;
            label18.Location = new Point(408, 0);
            label18.Name = "label18";
            label18.Size = new Size(129, 96);
            label18.TabIndex = 10;
            // 
            // label19
            // 
            label19.BorderStyle = BorderStyle.FixedSingle;
            label19.Cursor = Cursors.Hand;
            label19.Location = new Point(543, 0);
            label19.Name = "label19";
            label19.Size = new Size(129, 96);
            label19.TabIndex = 11;
            // 
            // label20
            // 
            label20.BorderStyle = BorderStyle.FixedSingle;
            label20.Cursor = Cursors.Hand;
            label20.Location = new Point(678, 0);
            label20.Name = "label20";
            label20.Size = new Size(129, 96);
            label20.TabIndex = 12;
            // 
            // label21
            // 
            label21.BorderStyle = BorderStyle.FixedSingle;
            label21.Cursor = Cursors.Hand;
            label21.Location = new Point(813, 0);
            label21.Name = "label21";
            label21.Size = new Size(129, 96);
            label21.TabIndex = 13;
            // 
            // fourthRowPanel
            // 
            fourthRowPanel.Controls.Add(label22);
            fourthRowPanel.Controls.Add(label23);
            fourthRowPanel.Controls.Add(label24);
            fourthRowPanel.Controls.Add(label25);
            fourthRowPanel.Controls.Add(label26);
            fourthRowPanel.Controls.Add(label27);
            fourthRowPanel.Controls.Add(label28);
            fourthRowPanel.Location = new Point(3, 212);
            fourthRowPanel.Name = "fourthRowPanel";
            fourthRowPanel.Size = new Size(948, 96);
            fourthRowPanel.TabIndex = 9;
            // 
            // label22
            // 
            label22.BorderStyle = BorderStyle.FixedSingle;
            label22.Cursor = Cursors.Hand;
            label22.Location = new Point(3, 0);
            label22.Name = "label22";
            label22.Size = new Size(129, 96);
            label22.TabIndex = 7;
            // 
            // label23
            // 
            label23.BorderStyle = BorderStyle.FixedSingle;
            label23.Cursor = Cursors.Hand;
            label23.Location = new Point(138, 0);
            label23.Name = "label23";
            label23.Size = new Size(129, 96);
            label23.TabIndex = 8;
            // 
            // label24
            // 
            label24.BorderStyle = BorderStyle.FixedSingle;
            label24.Cursor = Cursors.Hand;
            label24.Location = new Point(273, 0);
            label24.Name = "label24";
            label24.Size = new Size(129, 96);
            label24.TabIndex = 9;
            // 
            // label25
            // 
            label25.BorderStyle = BorderStyle.FixedSingle;
            label25.Cursor = Cursors.Hand;
            label25.Location = new Point(408, 0);
            label25.Name = "label25";
            label25.Size = new Size(129, 96);
            label25.TabIndex = 10;
            // 
            // label26
            // 
            label26.BorderStyle = BorderStyle.FixedSingle;
            label26.Cursor = Cursors.Hand;
            label26.Location = new Point(543, 0);
            label26.Name = "label26";
            label26.Size = new Size(129, 96);
            label26.TabIndex = 11;
            // 
            // label27
            // 
            label27.BorderStyle = BorderStyle.FixedSingle;
            label27.Cursor = Cursors.Hand;
            label27.Location = new Point(678, 0);
            label27.Name = "label27";
            label27.Size = new Size(129, 96);
            label27.TabIndex = 12;
            // 
            // label28
            // 
            label28.BorderStyle = BorderStyle.FixedSingle;
            label28.Cursor = Cursors.Hand;
            label28.Location = new Point(813, 0);
            label28.Name = "label28";
            label28.Size = new Size(129, 96);
            label28.TabIndex = 13;
            // 
            // fifthRowPanel
            // 
            fifthRowPanel.Controls.Add(label29);
            fifthRowPanel.Controls.Add(label30);
            fifthRowPanel.Controls.Add(label31);
            fifthRowPanel.Controls.Add(label32);
            fifthRowPanel.Controls.Add(label33);
            fifthRowPanel.Controls.Add(label34);
            fifthRowPanel.Controls.Add(label35);
            fifthRowPanel.Location = new Point(3, 110);
            fifthRowPanel.Name = "fifthRowPanel";
            fifthRowPanel.Size = new Size(948, 96);
            fifthRowPanel.TabIndex = 10;
            // 
            // label29
            // 
            label29.BorderStyle = BorderStyle.FixedSingle;
            label29.Cursor = Cursors.Hand;
            label29.Location = new Point(3, 0);
            label29.Name = "label29";
            label29.Size = new Size(129, 96);
            label29.TabIndex = 7;
            // 
            // label30
            // 
            label30.BorderStyle = BorderStyle.FixedSingle;
            label30.Cursor = Cursors.Hand;
            label30.Location = new Point(138, 0);
            label30.Name = "label30";
            label30.Size = new Size(129, 96);
            label30.TabIndex = 8;
            // 
            // label31
            // 
            label31.BorderStyle = BorderStyle.FixedSingle;
            label31.Cursor = Cursors.Hand;
            label31.Location = new Point(273, 0);
            label31.Name = "label31";
            label31.Size = new Size(129, 96);
            label31.TabIndex = 9;
            // 
            // label32
            // 
            label32.BorderStyle = BorderStyle.FixedSingle;
            label32.Cursor = Cursors.Hand;
            label32.Location = new Point(408, 0);
            label32.Name = "label32";
            label32.Size = new Size(129, 96);
            label32.TabIndex = 10;
            // 
            // label33
            // 
            label33.BorderStyle = BorderStyle.FixedSingle;
            label33.Cursor = Cursors.Hand;
            label33.Location = new Point(543, 0);
            label33.Name = "label33";
            label33.Size = new Size(129, 96);
            label33.TabIndex = 11;
            // 
            // label34
            // 
            label34.BorderStyle = BorderStyle.FixedSingle;
            label34.Cursor = Cursors.Hand;
            label34.Location = new Point(678, 0);
            label34.Name = "label34";
            label34.Size = new Size(129, 96);
            label34.TabIndex = 12;
            // 
            // label35
            // 
            label35.BorderStyle = BorderStyle.FixedSingle;
            label35.Cursor = Cursors.Hand;
            label35.Location = new Point(813, 0);
            label35.Name = "label35";
            label35.Size = new Size(129, 96);
            label35.TabIndex = 13;
            // 
            // sixthRowPanel
            // 
            sixthRowPanel.Controls.Add(label36);
            sixthRowPanel.Controls.Add(label37);
            sixthRowPanel.Controls.Add(label38);
            sixthRowPanel.Controls.Add(label39);
            sixthRowPanel.Controls.Add(label40);
            sixthRowPanel.Controls.Add(label41);
            sixthRowPanel.Controls.Add(label42);
            sixthRowPanel.Location = new Point(3, 8);
            sixthRowPanel.Name = "sixthRowPanel";
            sixthRowPanel.Size = new Size(948, 96);
            sixthRowPanel.TabIndex = 11;
            // 
            // label36
            // 
            label36.BorderStyle = BorderStyle.FixedSingle;
            label36.Cursor = Cursors.Hand;
            label36.Location = new Point(3, 0);
            label36.Name = "label36";
            label36.Size = new Size(129, 96);
            label36.TabIndex = 7;
            // 
            // label37
            // 
            label37.BorderStyle = BorderStyle.FixedSingle;
            label37.Cursor = Cursors.Hand;
            label37.Location = new Point(138, 0);
            label37.Name = "label37";
            label37.Size = new Size(129, 96);
            label37.TabIndex = 8;
            // 
            // label38
            // 
            label38.BorderStyle = BorderStyle.FixedSingle;
            label38.Cursor = Cursors.Hand;
            label38.Location = new Point(273, 0);
            label38.Name = "label38";
            label38.Size = new Size(129, 96);
            label38.TabIndex = 9;
            // 
            // label39
            // 
            label39.BorderStyle = BorderStyle.FixedSingle;
            label39.Cursor = Cursors.Hand;
            label39.Location = new Point(408, 0);
            label39.Name = "label39";
            label39.Size = new Size(129, 96);
            label39.TabIndex = 10;
            // 
            // label40
            // 
            label40.BorderStyle = BorderStyle.FixedSingle;
            label40.Cursor = Cursors.Hand;
            label40.Location = new Point(543, 0);
            label40.Name = "label40";
            label40.Size = new Size(129, 96);
            label40.TabIndex = 11;
            // 
            // label41
            // 
            label41.BorderStyle = BorderStyle.FixedSingle;
            label41.Cursor = Cursors.Hand;
            label41.Location = new Point(678, 0);
            label41.Name = "label41";
            label41.Size = new Size(129, 96);
            label41.TabIndex = 12;
            // 
            // label42
            // 
            label42.BorderStyle = BorderStyle.FixedSingle;
            label42.Cursor = Cursors.Hand;
            label42.Location = new Point(813, 0);
            label42.Name = "label42";
            label42.Size = new Size(129, 96);
            label42.TabIndex = 13;
            // 
            // difficultyChooser
            // 
            difficultyChooser.FormattingEnabled = true;
            difficultyChooser.Location = new Point(768, 18);
            difficultyChooser.Name = "difficultyChooser";
            difficultyChooser.Size = new Size(121, 23);
            difficultyChooser.TabIndex = 11;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Cursor = Cursors.Hand;
            label43.Location = new Point(149, 17);
            label43.Name = "label43";
            label43.Size = new Size(109, 15);
            label43.TabIndex = 13;
            label43.Text = "Ventana Emergente";
            label43.Click += label43_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 671);
            Controls.Add(mainPanel);
            Name = "Form1";
            Text = "Form1";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            gamePanel.ResumeLayout(false);
            firstRowPanel.ResumeLayout(false);
            secondRowPanel.ResumeLayout(false);
            thirdRowPanel.ResumeLayout(false);
            fourthRowPanel.ResumeLayout(false);
            fifthRowPanel.ResumeLayout(false);
            sixthRowPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label difficultyLabel;
        private Panel mainPanel;
        private FlowLayoutPanel firstRowPanel;
        private ComboBox difficultyChooser;
        private FlowLayoutPanel gamePanel;
        private FlowLayoutPanel secondRowPanel;
        private FlowLayoutPanel thirdRowPanel;
        private FlowLayoutPanel fourthRowPanel;
        private FlowLayoutPanel fifthRowPanel;
        private FlowLayoutPanel sixthRowPanel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
    }
}
