using System;
using System.Windows;

namespace Master_floor
{
    /// <summary>
    /// Логика взаимодействия для AddPartner.xaml
    /// </summary>
    public partial class AddPartner : Window
    {
        public AddPartner()
        {
            InitializeComponent();
        }

        private void addUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (type.Text == "")
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }
            if (name.Text == "")
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }
            if (director.Text == "")
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }
            if (email.Text == "")
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }
            if(telephone.Text == "")
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }
            if (adress.Text == "")
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }
            try
            {
                var _inn = Convert.ToInt64(inn.Text);
                var _raing = Convert.ToInt64(rating.Text);
            }
            catch
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }
            if (inn.Text == "")
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }
            if (rating.Text == "" || Convert.ToInt64(rating.Text)<0)
            {
                MessageBox.Show("Некорректно введены поля");
                return;
            }

            this.DialogResult = true;

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
