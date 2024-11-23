﻿namespace TestSequencer {
    partial class CustomMessageBox {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClipboard.Font = new System.Drawing.Font("Lucida Console", 12F);
            this.buttonClipboard.Location = new System.Drawing.Point(-3, 565);
            this.buttonClipboard.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(1343, 54);
            this.buttonClipboard.TabIndex = 1;
            this.buttonClipboard.Text = "Copy to Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.ButtonClipboard_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(-3, -2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(1343, 571);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBox_LinkClicked);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 614);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.buttonClipboard);
            this.Font = new System.Drawing.Font("Lucida Console", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CustomMessageBox";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}