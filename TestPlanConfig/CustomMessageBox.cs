using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomMessageBox : Form {
    private readonly TextBox messageTextBox;
    private readonly Button copyButton;

    public CustomMessageBox(String message) {
        messageTextBox = new TextBox {
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            Font = new Font("Lucida Console", SystemFonts.DefaultFont.Size),
            Text = message
        };

        copyButton = new Button {
            Text = "Copy to clipboard",
            Dock = DockStyle.Bottom,
            Font = SystemFonts.MessageBoxFont,
        };
        copyButton.Click += CopyButton_Click;

        Controls.Add(messageTextBox);
        Controls.Add(copyButton);
        Icon = SystemIcons.Error;
        Text = "XML Validation Error";
        Size = new Size(800, 600);
    }

    private void CopyButton_Click(Object sender, EventArgs e) {
        Clipboard.SetText(messageTextBox.Text);
        MessageBox.Show("Text copied to clipboard!");
    }

    public static void Show(String message) {
        CustomMessageBox customMessageBox = new CustomMessageBox(message);
        customMessageBox.ShowDialog();
        customMessageBox.copyButton.Focus();
        customMessageBox.messageTextBox.Select(0,0);
        customMessageBox.messageTextBox.Refresh();
    }
}
