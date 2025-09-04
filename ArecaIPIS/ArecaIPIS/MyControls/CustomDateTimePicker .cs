using System;
using System.Drawing;
using System.Windows.Forms;

public partial class CustomDateTimePicker : UserControl
{
    private TableLayoutPanel dayPanel, hourPanel, minutePanel, secondPanel, monthPanel, yearPanel;
    private Panel selectionPanel;
    private Label lblHeader;
    private Button btnPrev, btnNext;

    private DateTime _currentDate = DateTime.Today;
    private int? _selectedDay;
    private int? _selectedMonth;
    private int? _selectedYear;
    private int? _selectedHour;
    private int? _selectedMinute;
    private int? _selectedSecond;

    public CustomDateTimePicker()
    {
        InitializeDateTimePicker();
        lblHeader.Text = _currentDate.ToString("MMMM yyyy");
        selectionPanel.Controls.Add(dayPanel);
        HighlightToday();
    }


    public void Reset()
    {
        _currentDate = DateTime.Now;

        _selectedHour = 0;
        _selectedMinute = 0;
        _selectedSecond = 0;
        _selectedMonth = _currentDate.Month;
        _selectedYear = _currentDate.Year;

        lblHeader.Text = _currentDate.ToString("MMMM yyyy");
        selectionPanel.Controls.Clear();
        selectionPanel.Controls.Add(dayPanel);
        PopulateDays();
        HighlightToday();
    }


    private void InitializeDateTimePicker()
    {
        lblHeader = new Label
        {
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 30,
            Text = _currentDate.ToString("MMMM yyyy"),
            Font = new Font("Arial", 10, FontStyle.Bold),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.MintCream
        };
        lblHeader.Click += LblHeader_Click;

        btnPrev = new Button
        {
            Text = "<-",
            Dock = DockStyle.Left,
            BackColor = Color.White,
            Width = 30
        };
        btnPrev.Click += BtnPrev_Click;

        btnNext = new Button
        {
            Text = "->",
            Dock = DockStyle.Right,
            BackColor = Color.White,
            Width = 30
        };
        btnNext.Click += BtnNext_Click;

        dayPanel = CreateTableLayoutPanel(7);
        PopulateDays();

        monthPanel = CreateTableLayoutPanel(3);
        PopulateMonths();

        yearPanel = CreateTableLayoutPanel(3);
        //PopulateYears(_currentDate.Year - (_currentDate.Year % 10));

        hourPanel = CreateTableLayoutPanel(4);
        PopulateTimeSlots(hourPanel, 24, HourClicked);

        minutePanel = CreateTableLayoutPanel(4);
        PopulateTimeSlots(minutePanel, 60, MinuteClicked);

        secondPanel = CreateTableLayoutPanel(3);
        PopulateTimeSlots(secondPanel, 60, SecondClicked);

        selectionPanel = new Panel
        {
            Dock = DockStyle.Fill,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.White
        };

        var headerPanel = new Panel { Dock = DockStyle.Top, Height = 30 };
        headerPanel.Controls.Add(lblHeader);
        headerPanel.Controls.Add(btnPrev);
        headerPanel.Controls.Add(btnNext);

        Controls.Add(selectionPanel);
        Controls.Add(headerPanel);

        selectionPanel.Controls.Add(dayPanel);
    }

    private TableLayoutPanel CreateTableLayoutPanel(int columnCount)
    {
        var table = new TableLayoutPanel
        {
            ColumnCount = columnCount,
            Dock = DockStyle.Fill,
            AutoSize = true,
            BorderStyle = BorderStyle.None,
            Padding = new Padding(0),
            Margin = new Padding(0),
            BackColor = Color.Transparent
        };

        for (int i = 0; i < columnCount; i++)
        {
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnCount));
        }

        table.RowCount = 7;

        for (int i = 0; i < table.RowCount; i++)
        {
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 18f));
        }
        //table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / table.RowCount));

        return table;

    }

    private void PopulateDays()
    {
        dayPanel.Controls.Clear();

        string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        foreach (var day in weekDays)
        {
            dayPanel.Controls.Add(new Label
            {
                Text = day,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.White
            });
        }

        DateTime firstDay = new DateTime(_currentDate.Year, _currentDate.Month, 1);
        int startDayOfWeek = (int)firstDay.DayOfWeek;

        for (int i = 0; i < startDayOfWeek; i++)
            dayPanel.Controls.Add(new Label());

        int totalDays = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
        for (int day = 1; day <= totalDays; day++)
        {
            var lblDay = new Label
            {
                Text = day.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 10, FontStyle.Regular),
                //BackColor = Color.White,
                //BorderStyle = BorderStyle.FixedSingle,
                BorderStyle = BorderStyle.None,
                Padding = new Padding(0),
                Margin = new Padding(0),
                BackColor = Color.Transparent
            };

            if (_currentDate.Year == DateTime.Today.Year &&
                _currentDate.Month == DateTime.Today.Month &&
                day == DateTime.Today.Day)
            {
                lblDay.BackColor = Color.DodgerBlue;
            }

            //lblDay.Click += (s, e) => DayClicked(day);
            int currentDay = day;
            lblDay.Click += (s, e) => DayClicked(currentDay);
            dayPanel.Controls.Add(lblDay);
        }
    }

    private void PopulateMonths()
    {
        monthPanel.Controls.Clear();
        string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        for (int i = 0; i < months.Length; i++)
        {
            var lblMonth = new Label
            {
                Text = months[i],
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12, FontStyle.Regular),
                //BackColor = Color.White,
                //BorderStyle = BorderStyle.FixedSingle
                BorderStyle = BorderStyle.None,
                Padding = new Padding(0),
                Margin = new Padding(0),
                BackColor = Color.Transparent
            };


            if (_currentDate.Year == DateTime.Today.Year && _currentDate.Month == i + 1)
            {
                lblMonth.BackColor = Color.LightBlue;
            }

            var monthIndex = i + 1;
            lblMonth.Click += (s, e) => MonthClicked(monthIndex);

            monthPanel.Controls.Add(lblMonth);
        }
    }

    private void PopulateYearPanel(int startYear, int endYear)
    {
        yearPanel.Controls.Clear();
        int j = (endYear - startYear) + 1;
        for (int i = 0; i < j; i++)
        {
            var year = startYear + i;
            var lblYear = new Label
            {
                Text = year.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12, FontStyle.Regular),
                //BackColor = Color.White,
                //BorderStyle = BorderStyle.FixedSingle

                BorderStyle = BorderStyle.None,
                Padding = new Padding(0),
                Margin = new Padding(0),
                BackColor = Color.Transparent
            };
            if (year == DateTime.Today.Year)
            {
                lblYear.BackColor = Color.LightBlue;
            }

            lblYear.Click += (s, e) => YearClicked(year);
            yearPanel.Controls.Add(lblYear);

        }
    }

    private void OnYearSelected(int selectedYear)
    {
        _currentDate = new DateTime(selectedYear, _currentDate.Month, 1);
        lblHeader.Text = _currentDate.ToString("MMMM yyyy");
        ReplacePanel(yearPanel, monthPanel);
    }


    //private void PopulateTimeSlots(TableLayoutPanel panel, int max, Action<int> clickHandler)
    //{
    //    panel.Controls.Clear();
    //    if(panel==hourPanel)
    //    {
    //        for (int i = 0; i < max; i++)
    //        {
    //            var lbl = new Label
    //            {
    //                Text = i.ToString("D2"),
    //                TextAlign = ContentAlignment.MiddleCenter,
    //                Dock = DockStyle.Fill,
    //                BackColor = Color.White,
    //                BorderStyle = BorderStyle.FixedSingle
    //            };
    //            lbl.Click += (s, e) => clickHandler(i);
    //            panel.Controls.Add(lbl);
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < max; i+=5)
    //        {
    //            var lbl = new Label
    //            {
    //                Text = i.ToString("D2"),
    //                TextAlign = ContentAlignment.MiddleCenter,
    //                Dock = DockStyle.Fill,
    //                BackColor = Color.White,
    //                BorderStyle = BorderStyle.FixedSingle
    //            };
    //            lbl.Click += (s, e) => clickHandler(i);
    //            panel.Controls.Add(lbl);
    //        }
    //    }

    //}

    private void PopulateTimeSlots(TableLayoutPanel panel, int max, Action<int> clickHandler)
    {
        panel.Controls.Clear();


        bool isHourPanel = (panel == hourPanel);
        bool isMinutePanel = (panel == minutePanel);
        bool isSecondPanel = (panel == secondPanel);


        int increment = isHourPanel ? 1 : 5;

        for (int i = 0; i < max; i += increment)
        {
            int value = i;
            string labelText;

            if (isHourPanel)
            {
                labelText = $"{value:D2}:00";
            }
            else if (isMinutePanel)
            {
                labelText = $"{_selectedHour:D2}:{value:D2}";
            }
            else if (isSecondPanel)
            {
                labelText = $"{_selectedHour:D2}:{_selectedMinute:D2}:{value:D2}";
            }
            else
            {
                continue;
            }


            var lbl = new Label
            {
                Text = labelText,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 10, FontStyle.Regular),
                //BackColor = Color.White,
                //BorderStyle = BorderStyle.FixedSingle
                BorderStyle = BorderStyle.None,
                Padding = new Padding(0),
                Margin = new Padding(0),
                BackColor = Color.Transparent
            };

            // Attach the click event
            lbl.Click += (s, e) => clickHandler(value);

            // Add the label to the panel
            panel.Controls.Add(lbl);
        }
    }





    private void BtnPrev_Click(object sender, EventArgs e)
    {

        int startYear = (_currentDate.Year / 10) * 10;
        int endYear = startYear + 9;

        if (DateTime.TryParseExact(lblHeader.Text, "MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
        {
            _currentDate = new DateTime(monthYear.Year, monthYear.Month, 1);
            _currentDate = _currentDate.AddMonths(-1);

            lblHeader.Text = _currentDate.ToString("MMMM yyyy");
            PopulateDays();
        }
        else if (int.TryParse(lblHeader.Text, out int year))
        {
            year--;
            lblHeader.Text = year.ToString();

            PopulateMonths();
        }

        else if (lblHeader.Text.Contains("-") && lblHeader.Text.Split('-').Length == 2)
        {
            string[] range = lblHeader.Text.Split('-');
            if (int.TryParse(range[0], out int displayedStartYear) && int.TryParse(range[1], out int displayedEndYear))
            {
                // Move to the previous decade
                displayedStartYear -= 10;
                displayedEndYear -= 10;
                lblHeader.Text = $"{displayedStartYear}-{displayedEndYear}";


                PopulateYearPanel(displayedStartYear, displayedEndYear);
            }
        }

        else if (DateTime.TryParseExact(lblHeader.Text, "dd MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fullDate))
        {
            fullDate = fullDate.AddDays(-1);
            lblHeader.Text = fullDate.ToString("dd MMMM yyyy");

            PopulateDays();
        }
        else
        {
            _currentDate = _currentDate.AddMonths(-1);
            lblHeader.Text = _currentDate.ToString("MMMM yyyy");

            PopulateDays();
        }

        if (lblHeader.Text.Contains("-"))
        {

            string[] range = lblHeader.Text.Split('-');
            PopulateYearPanel(int.Parse(range[0]), int.Parse(range[1]));
        }
        else if (lblHeader.Text.Length == 4)
        {
            PopulateMonths();
        }
        else if (lblHeader.Text.Contains(" "))
        {
            PopulateDays();
        }
    }



    //private void BtnPrev_Click(object sender, EventArgs e)
    //{
    //    int startYear = (_currentDate.Year / 10) * 10;
    //    int endYear = startYear + 9;

    //    if (lblHeader.Text == _currentDate.ToString("MMMM yyyy") || lblHeader.Text == $"{_selectedMonth} {_selectedYear}")
    //    {
    //        _currentDate = _currentDate.AddMonths(-1);
    //        lblHeader.Text = _currentDate.ToString("MMMM yyyy");
    //    }
    //    else if (lblHeader.Text == _currentDate.ToString("yyyy") || lblHeader.Text == $"{_selectedYear}")
    //    {
    //        _currentDate = _currentDate.AddYears(-1);
    //        lblHeader.Text = _currentDate.ToString("yyyy");
    //    }
    //    else if (lblHeader.Text == $"{startYear}-{endYear}")
    //    {
    //        _currentDate = _currentDate.AddYears(-10);
    //        lblHeader.Text = $"{startYear - 10}-{endYear - 10}";
    //        PopulateYearPanel((startYear - 10), (endYear - 10));
    //    }
    //    else
    //    {
    //        _currentDate = _currentDate.AddMonths(-1);
    //        lblHeader.Text = _currentDate.ToString("MMMM yyyy");
    //    }

    //    PopulateDays();
    //}
    private void BtnNext_Click(object sender, EventArgs e)
    {
        try
        {
            string headerText = lblHeader.Text.Trim();


            if (DateTime.TryParseExact(headerText,
                       "d MMMM yyyy",
                       System.Globalization.CultureInfo.InvariantCulture,
                       System.Globalization.DateTimeStyles.None,
                       out DateTime fullDate))
            {
                fullDate = fullDate.AddDays(1);
                lblHeader.Text = fullDate.ToString("dd MMMM yyyy");

                PopulateDays();
            }

            else if (DateTime.TryParseExact(headerText,
                       "MMMM yyyy", // Month and Year format
                       null,
                       System.Globalization.DateTimeStyles.None,
                       out DateTime monthYearDate))
            {

                _currentDate = new DateTime(monthYearDate.Year, monthYearDate.Month, 1);


                _currentDate = _currentDate.AddMonths(1);
                lblHeader.Text = _currentDate.ToString("MMMM yyyy");

                // Update the days for the new month
                PopulateDays();
            }

            else if (int.TryParse(headerText, out int displayedYear))
            {
                // Move to the next year
                displayedYear++;
                lblHeader.Text = displayedYear.ToString();

                PopulateMonths();
            }

            else if (headerText.Contains("-"))
            {
                string[] range = headerText.Split('-');
                if (range.Length == 2 &&
                    int.TryParse(range[0], out int startDecadeYear) &&
                    int.TryParse(range[1], out int endDecadeYear))
                {
                    // Move to the next decade
                    startDecadeYear += 10;
                    endDecadeYear += 10;
                    lblHeader.Text = $"{startDecadeYear}-{endDecadeYear}";

                    // Update the year panel to reflect the new range
                    PopulateYearPanel(startDecadeYear, endDecadeYear);
                }
            }
            else
            {
                DateTime fallbackMonthYear = DateTime.ParseExact(headerText, "MMMM yyyy", null);
                fallbackMonthYear = fallbackMonthYear.AddMonths(1);
                lblHeader.Text = fallbackMonthYear.ToString("MMMM yyyy");

                PopulateDays();
            }

            if (lblHeader.Text.Contains("-"))
            {
                // Decade view
                string[] range = lblHeader.Text.Split('-');
                PopulateYearPanel(int.Parse(range[0]), int.Parse(range[1]));
            }
            else if (lblHeader.Text.Length == 4)
            {
                // Year view
                PopulateMonths();
            }
            else if (lblHeader.Text.Contains(" "))
            {
                // Month or day view
                PopulateDays();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void LblHeader_Click(object sender, EventArgs e)
    {
        try
        {
            string headerText = lblHeader.Text.Trim();

            //if (DateTime.TryParseExact(headerText, "d MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fullDate))
            //{
            //    int month = fullDate.Month;
            //    int year = fullDate.Year;

            //    lblHeader.Text = fullDate.ToString("MMMM yyyy");
            //    ReplacePanel(hourPanel, dayPanel);
            //    PopulateDays();
            //}
            if (DateTime.TryParseExact(headerText, "d MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fullDate))
            {
                //lblHeader.Text = fullDate.ToString("MMMM yyyy");

                // Check the current panel and switch to the appropriate one
                if (_currentPanel == hourPanel)
                {
                    ReplacePanel(hourPanel, dayPanel);
                    PopulateDays();
                }
                else if (_currentPanel == minutePanel)
                {
                    ReplacePanel(minutePanel, hourPanel);
                    PopulateTimeSlots(hourPanel, 24, HourClicked);
                }
                else if (_currentPanel == secondPanel)
                {
                    ReplacePanel(secondPanel, minutePanel);
                    PopulateTimeSlots(minutePanel, 60, MinuteClicked);
                }

                if (_currentPanel == dayPanel)
                {
                    lblHeader.Text = fullDate.ToString("MMMM yyyy");
                }
            }

            else if (DateTime.TryParseExact(headerText, "MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYearDate))
            {
                lblHeader.Text = monthYearDate.ToString("yyyy");
                ReplacePanel(dayPanel, monthPanel);
                HighlightToday();
            }

            else if (int.TryParse(headerText, out int displayedYear))
            {
                yearPanel = CreateTableLayoutPanel(3);
                ReplacePanel(monthPanel, yearPanel);

                int startYear = (displayedYear / 10) * 10;
                int endYear = startYear + 9;
                lblHeader.Text = $"{startYear}-{endYear}";
                PopulateYearPanel(startYear, endYear);
            }

            else if (headerText.Contains("-"))
            {
                string[] range = headerText.Split('-');
                if (range.Length == 2 &&
                    int.TryParse(range[0], out int startDecadeYear) &&
                    int.TryParse(range[1], out int endDecadeYear))
                {
                    lblHeader.Text = startDecadeYear.ToString();
                    PopulateMonths();
                }
            }
            else
            {
                lblHeader.Text = _currentDate.ToString("MMMM yyyy");
                ReplacePanel(dayPanel, monthPanel);
                PopulateDays();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



    //private void DayClicked(int day)
    //{

    //    _selectedDay = day;
    //    ReplacePanel(dayPanel, hourPanel);
    //    if(_selectedMonth==null && _selectedYear==null)
    //    {
    //        lblHeader.Text = $"{_selectedDay} {_currentDate:MMMM} {_currentDate:yyyy}";
    //    }
    //    else if (_selectedYear == null)
    //    {
    //        lblHeader.Text = $"{_selectedDay} {GetMonthName((int)_selectedMonth)} {_currentDate:yyyy}";
    //    }
    //    else
    //    {
    //        lblHeader.Text = $"{_selectedDay} {GetMonthName((int)_selectedMonth)} {_selectedYear}";
    //    }

    //}

    private void DayClicked(int day)
    {
        _selectedDay = day;

        if (DateTime.TryParseExact(lblHeader.Text, "MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
        {
            _currentDate = new DateTime(monthYear.Year, monthYear.Month, _selectedDay.Value);
            lblHeader.Text = _currentDate.ToString("dd MMMM yyyy");
        }
        else if (DateTime.TryParseExact(lblHeader.Text, "dd MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fullDate))
        {
            _currentDate = new DateTime(fullDate.Year, fullDate.Month, _selectedDay.Value);
            lblHeader.Text = _currentDate.ToString("dd MMMM yyyy");
        }
        else
        {
            MessageBox.Show("Unable to determine the current month and year from the header.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        ReplacePanel(dayPanel, hourPanel);
    }



    private string GetMonthName(int month)
    {
        return new DateTime(2021, month, 1).ToString("MMMM");
    }

    private void HourClicked(int hour)
    {
        _selectedHour = hour;
        ReplacePanel(hourPanel, minutePanel);
        PopulateTimeSlots(minutePanel, 60, MinuteClicked);
    }

    private void MinuteClicked(int minute)
    {
        _selectedMinute = minute;
        ReplacePanel(minutePanel, secondPanel);
        PopulateTimeSlots(secondPanel, 60, SecondClicked);
    }

    //private void SecondClicked(int second)
    //{
    //    _selectedSecond = second;
    //    string finalTime = $"{_selectedHour:D2}:{_selectedMinute:D2}:{_selectedSecond:D2}";
    //    MessageBox.Show($"Time Selected: {finalTime}", "Time Picker");
    //}
    public event EventHandler<string> DateTimeSelected;
    private void SecondClicked(int second)
    {
        try
        {
            // Update the selected second
            _selectedSecond = second;

            // Ensure the header text is a valid date
            if (DateTime.TryParseExact(lblHeader.Text, "d MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime headerDate))
            {
                // Parse the hour, minute, and second from the string fields
                if (int.TryParse(_selectedHour.ToString(), out int hour) &&
                    int.TryParse(_selectedMinute.ToString(), out int minute) &&
                    int.TryParse(_selectedSecond.ToString(), out int sec))
                {
                    // Combine the components into a final DateTime
                    DateTime finalDateTime = new DateTime(
                        headerDate.Year,
                        headerDate.Month,
                        headerDate.Day,
                        hour,
                        minute,
                        sec
                    );

                    string finalDateTimeString = $"{finalDateTime:dd-MMM-yyyy HH:mm:ss}";
                    //MessageBox.Show($"Selected DateTime: {finalDateTimeString}", "DateTime Picker");



                    DateTimeSelected?.Invoke(this, finalDateTimeString);

                    // Highlight the selected second
                    foreach (Control control in secondPanel.Controls)
                    {
                        // Check if the control is a Label
                        if (control is Label label)
                        {
                            if (int.TryParse(label.Text, out int labelSecond))
                            {

                                if (labelSecond == second)
                                {
                                    label.BackColor = Color.DodgerBlue;
                                    label.ForeColor = Color.White;
                                }
                                else
                                {
                                    label.BackColor = Color.White;
                                    label.ForeColor = Color.Black;
                                }
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Invalid hour, minute, or second format. Please provide valid numeric values.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Invalid date in header. Please ensure the header shows a valid date in 'd MMMM yyyy' format.", "Error");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



    //private void MonthClicked(int month)
    //{
    //    _selectedMonth = month;
    //    _currentDate = new DateTime(_currentDate.Year, month, 1);
    //    if(_selectedYear==null)
    //    {
    //        lblHeader.Text = $" {GetMonthName((int)_selectedMonth)} {_currentDate:yyyy}";
    //    }
    //    else
    //    {
    //        lblHeader.Text = $"{GetMonthName((int)_selectedMonth)} {_selectedYear}";
    //    }

    //    ReplacePanel(monthPanel, dayPanel);
    //    PopulateDays();
    //}


    private void MonthClicked(int month)
    {
        _selectedMonth = month;

        if (DateTime.TryParseExact(lblHeader.Text, "MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
        {
            _currentDate = new DateTime(monthYear.Year, month, 1);
            lblHeader.Text = $"{GetMonthName(month)} {_currentDate:yyyy}";
        }
        else if (int.TryParse(lblHeader.Text, out int year))
        {
            _currentDate = new DateTime(year, month, 1);
            lblHeader.Text = $"{GetMonthName(month)} {year}";
        }
        else
        {
            MessageBox.Show("Unable to determine the current year from the header.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ReplacePanel(monthPanel, dayPanel);
        PopulateDays();
    }

    private void YearClicked(int year)
    {
        _selectedYear = year;
        _currentDate = new DateTime(year, _currentDate.Month, 1);
        lblHeader.Text = $"{_selectedYear}";
        ReplacePanel(yearPanel, monthPanel);
    }
    private Control _currentPanel;

    private void ReplacePanel(Control oldPanel, Control newPanel)
    {
        selectionPanel.Controls.Clear();
        selectionPanel.Controls.Add(newPanel);

        // Update the current panel reference
        _currentPanel = newPanel;
    }

    private void HighlightToday()
    {
        if (_currentDate.Month == DateTime.Today.Month && _currentDate.Year == DateTime.Today.Year)
        {
            PopulateDays();
            PopulateMonths();

        }
    }
}
