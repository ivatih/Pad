#r "System.Windows.Forms"

using System.Windows.Forms;

Button button = new Button();
button.Text = "Click me";
button.Click += LogPlainEvent;
button.KeyPress += LogPlainEvent;
button.MouseClick += LogPlainEvent;

Form form = new Form();
form.AutoSize = true;
form.Controls.Add(button);
Application.Run(form);

static void LogPlainEvent(object sender, EventArgs e)
{
    Console.WriteLine ("An event occurred");
}