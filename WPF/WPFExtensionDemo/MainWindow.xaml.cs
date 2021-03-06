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
using System.Windows.Shapes;

namespace WPFExtensionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SampleLauncherButton_Click(object sender, RoutedEventArgs e)
        {
            string sampleName = ((Button) sender).Content.ToString();
            Type sampleType = this.GetType().Assembly.GetType("WPFExtensionDemo." + sampleName);
            Window sample = Activator.CreateInstance(sampleType) as Window;
            sample.Show();
        }
    }
}
