using System;
using System.Drawing;
using System.Windows.Forms;

public class DynamicButtonControl : UserControl
{
    private Button mainButton;
    private Panel subButtonPanel; // A panel to hold the sub-buttons
    private int _subButtonCount;

    // Property to get or set the number of sub-buttons
    public int SubButtonCount
    {
        get { return _subButtonCount; }
        set
        {
            if (_subButtonCount != value)
            {
                _subButtonCount = value;
                CreateSubButtons(); // Re-create the sub-buttons when the count changes
            }
        }
    }

    public DynamicButtonControl()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Main button
        mainButton = new Button
        {
            Size = new Size(200, 50),
            Location = new Point(10, 10),
            Text = "Main Button",
            Font = new Font("Arial", 14, FontStyle.Bold),
            BackColor = Color.SkyBlue,
            ForeColor = Color.White
        };
        mainButton.Click += MainButton_Click;

        // Panel to hold sub-buttons
        subButtonPanel = new Panel
        {
            Location = new Point(10, 70),
            Size = new Size(200, 0), // Height starts at 0
            AutoSize = true,
            AutoScroll = true
        };

        // Add controls to the UserControl
        Controls.Add(mainButton);
        Controls.Add(subButtonPanel);
    }

    private void MainButton_Click(object sender, EventArgs e)
    {
        // Toggle visibility of the sub-buttons when the main button is clicked
        if (subButtonPanel.Visible)
        {
            subButtonPanel.Visible = false;
        }
        else
        {
            subButtonPanel.Visible = true;
        }
    }

    // Create sub-buttons based on the SubButtonCount property
    private void CreateSubButtons()
    {
        // Remove existing sub-buttons (if any)
        subButtonPanel.Controls.Clear();

        // Create the sub-buttons dynamically based on SubButtonCount
        for (int i = 0; i < _subButtonCount; i++)
        {
            Button subButton = new Button
            {
                Size = new Size(180, 40),
                Text = $"Sub Button {i + 1}",
                Font = new Font("Arial", 10),
                BackColor = Color.LightGreen,
                ForeColor = Color.White,
                Margin = new Padding(5)
            };

            // Optionally add click event for sub-buttons
            subButton.Click += (s, e) => MessageBox.Show($"Sub Button {i + 1} clicked!");

            subButtonPanel.Controls.Add(subButton);
        }

        // Adjust the panel height to fit the sub-buttons
        subButtonPanel.Height = _subButtonCount * 45; // 40px button height + 5px margin
    }
}
