using System;
using System.Windows.Forms;

public class CustomMessageBox : Form {
    private TextBox messageTextBox;
    private Button copyButton;

    public CustomMessageBox(String message) {
        messageTextBox = new TextBox {
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            Text = message
        };

        copyButton = new Button {
            Text = "Copy",
            Dock = DockStyle.Bottom
        };
        copyButton.Click += CopyButton_Click;

        Controls.Add(messageTextBox);
        Controls.Add(copyButton);

        Text = "Custom Message Box";
        Size = new System.Drawing.Size(400, 300);
    }

    private void CopyButton_Click(Object sender, EventArgs e) {
        Clipboard.SetText(messageTextBox.Text);
        MessageBox.Show("Text copied to clipboard!");
    }

    public static void Show(String message) {
        CustomMessageBox customMessageBox = new CustomMessageBox(message);
        customMessageBox.ShowDialog();
    }
}
