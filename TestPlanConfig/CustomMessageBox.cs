using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TestSequencer {
    public partial class CustomMessageBox : Form {
        public CustomMessageBox() {
            InitializeComponent();
        }

        public static void Show(String Title, String Message, Icon OptionalIcon = null) {
            CustomMessageBox cms = new CustomMessageBox {
                Text = Title,
                Icon = (OptionalIcon is null ? SystemIcons.Information : OptionalIcon),

            };
            cms.richTextBox.Text = Message;
            cms.buttonClipboard.Focus();
            cms.richTextBox.Select(0, 0);
            cms.richTextBox.Refresh();
            cms.Refresh();
            cms.ShowDialog();
        }

        private void ButtonClipboard_Click(Object sender, EventArgs e) { Clipboard.SetText(richTextBox.Text); }
    }
}
