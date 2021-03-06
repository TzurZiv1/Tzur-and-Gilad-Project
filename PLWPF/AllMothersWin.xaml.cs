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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AllMothers.xaml
    /// </summary>
    public partial class AllMothers : Window
    {
        BL.IBL bl;
        /// <summary>
        /// constructor of AllMothers
        /// </summary>
        public AllMothers()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.MothersDataGrid.ItemsSource = bl.GetAllMothers();
        }
    }
}
