using System;
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

namespace Master_floor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestBaseEntities db = new TestBaseEntities();
        public MainWindow()
        {
            InitializeComponent();
            tolist();
        }

        void tolist()
        {
            var listpartners = new List<Partner>();
            foreach (var a in db.Partners.ToList())
            {

                var sum = db.Partners_product.Where(y => a.ID == y.ID_Partner).Sum(x => x.Количество_продукции);
                string sale = "0%";
                if (sum < 10000)
                {
                    sale = "0%";
                }
                if (sum <= 10000 && sum < 50000)
                {
                    sale = "5%";
                }
                if (sum <= 50000 && sum < 300000)
                {
                    sale = "10%";
                }
                if (sum >= 300000)
                {
                    sale = "15%";
                }
                listpartners.Add(new Partner { ID = a.ID, Директор = a.Директор, Наименование_партнера = a.Наименование_партнера, Рейтинг = "Рейтинг: " + a.Рейтинг, Телефон_партнера = a.Телефон_партнера, Тип_партнера = a.Тип_партнера, Скидка = sale });
            }

            listPartner.ItemsSource = listpartners;
        }

        private void listPartner_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = listPartner.SelectedItem as Partner;
            if (selected != null)
            {
                //form
                var update = new AddPartner();
                //selected
                var partner = db.Partners.FirstOrDefault(x => x.ID == selected.ID);

                update.type.Text = partner.Тип_партнера;
                update.name.Text = partner.Наименование_партнера;
                update.director.Text = partner.Директор;
                update.email.Text = partner.Электронная_почта_партнера;
                update.telephone.Text = partner.Телефон_партнера;
                update.adress.Text = partner.Юридический_адрес_партнера;
                update.inn.Text = partner.ИНН.ToString();
                update.rating.Text = partner.Рейтинг.ToString();
                update.addUpdate.Content = "Update";
                update.Title = "Update partner";
                //dialog
                if (update.ShowDialog() == true)
                {
                    partner.Тип_партнера = update.type.Text;
                    partner.Наименование_партнера = update.name.Text;
                    partner.Директор = update.director.Text;
                    partner.Электронная_почта_партнера = update.email.Text;
                    partner.Телефон_партнера = update.telephone.Text;
                    partner.Юридический_адрес_партнера = update.adress.Text;
                    partner.ИНН = Convert.ToInt64(update.inn.Text);
                    partner.Рейтинг = Convert.ToInt64(update.rating.Text);
                    db.SaveChanges();
                    tolist();
                }
            }
        }

        private void btnAddPartner_Click(object sender, RoutedEventArgs e)
        {
            var update = new AddPartner();
            var partner = new Partners();
            if (update.ShowDialog() == true)
            {
                partner.Тип_партнера = update.type.Text;
                partner.Наименование_партнера = update.name.Text;
                partner.Директор = update.director.Text;
                partner.Электронная_почта_партнера = update.email.Text;
                partner.Телефон_партнера = update.telephone.Text;
                partner.Юридический_адрес_партнера = update.adress.Text;
                partner.ИНН = Convert.ToInt64(update.inn.Text);
                partner.Рейтинг = Convert.ToInt64(update.rating.Text);
                db.Partners.Add(partner);
                db.SaveChanges();
                tolist();
            }
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            var history = new History();
            history.Show();
            this.Close();
        }
    }
}
