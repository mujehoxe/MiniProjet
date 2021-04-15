﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agent.Assets
{
    /// <summary>
    /// Interaction logic for NotificationCard.xaml
    /// </summary>
    public partial class NotificationCard : UserControl
    {
        public NotificationCard(string username, string type, string title)
        {
            InitializeComponent();

            Username.Text = username;
            Type.Text = type;
            Title.Text = title;
        }
    }
}
