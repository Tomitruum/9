using System;
using System.Windows;

namespace TimeApp
{
    public partial class MainWindow : Window
    {
        Time vremya;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void vychestMinuty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte chasy = byte.Parse(vvodChasov.Text);
                byte minuty = byte.Parse(vvodMinut.Text);
                uint skolko = uint.Parse(vvodVichMinut.Text);

                vremya = new Time(chasy, minuty);
                vremya = vremya - skolko;
                rezultat.Text = "Новое время: " + vremya.ToString();
            }
            catch (Exception ex)
            {
                rezultat.Text = "Ошибка: " + ex.Message;
            }
        }

        private void obnulytVse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vremya = !vremya;
                rezultat.Text = "Обнулено: " + vremya.ToString();
            }
            catch
            {
                rezultat.Text = "Ошибка: создайте время сначала.";
            }
        }

        private void obnulytMinuty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vremya = --vremya;
                rezultat.Text = "Обнулены минуты: " + vremya.ToString();
            }
            catch
            {
                rezultat.Text = "Ошибка: создайте время сначала.";
            }
        }

        private void proverkaNaNol_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool estVremya = (bool)vremya;
                rezultat.Text = estVremya ? "Время не ноль" : "Всё обнулено";
            }
            catch
            {
                rezultat.Text = "Ошибка: создайте время сначала.";
            }
        }

        private void pokazatChasy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte chasy = vremya;
                rezultat.Text = "Часы (как byte): " + chasy;
            }
            catch
            {
                rezultat.Text = "Ошибка: создайте время сначала.";
            }
        }

        private void sravnitRavno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte chasy1 = byte.Parse(vvodChasov.Text);
                byte minuty1 = byte.Parse(vvodMinut.Text);
                byte chasy2 = byte.Parse(vvodChasov2.Text);
                byte minuty2 = byte.Parse(vvodMinut2.Text);

                Time vremya1 = new Time(chasy1, minuty1);
                Time vremya2 = new Time(chasy2, minuty2);

                bool result = vremya1 == vremya2;
                rezultat.Text = "Результат == : " + result;
            }
            catch (Exception ex)
            {
                rezultat.Text = "Ошибка: " + ex.Message;
            }
        }

        private void sravnitNeRavno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte chasy1 = byte.Parse(vvodChasov.Text);
                byte minuty1 = byte.Parse(vvodMinut.Text);
                byte chasy2 = byte.Parse(vvodChasov2.Text);
                byte minuty2 = byte.Parse(vvodMinut2.Text);

                Time vremya1 = new Time(chasy1, minuty1);
                Time vremya2 = new Time(chasy2, minuty2);

                bool result = vremya1 != vremya2;
                rezultat.Text = "Результат != : " + result;
            }
            catch (Exception ex)
            {
                rezultat.Text = "Ошибка: " + ex.Message;
            }
        }
    }
}
