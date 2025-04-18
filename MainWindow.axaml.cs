using System;
using System.Collections.Generic; 
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using GGExam.Entities;

namespace GGExam
{
    public partial class MainWindow : Window 
    {
        private PostgresContext context;
        public List<Order> Orders { get; set; } 

        public MainWindow()
        {
            InitializeComponent();
            context = new PostgresContext();
            ShowTable();
        }

        private void ShowTable()
        {
           Orders = context.Orders
                               .Include(x => x.Gender) 
                               .ToList();
            dataGridExam.ItemsSource = Orders;
        }
        private void btnDelete_Click (object sender, RoutedEventArgs e)
    {
        var OrderDelete = dataGridExam.SelectedItem as Order;
            if(OrderDelete == null)
            return;
            try
        {
            context.Orders.Remove(OrderDelete);
            context.SaveChanges();
        }
            catch(System.Exception)
        {
            Console.Write("Error");
        }
            dataGridExam.ItemsSource =  Orders;
    }
        private void btnFilter_Click(object sender, RoutedEventArgs e)
    {
        Orders = context.Orders
                           .Include(x => x.Products) 
                           .OrderBy(r=>r.Quantity) 
                           .ToList();
        dataGridExam.ItemsSource = Orders;
    }
}

    }
