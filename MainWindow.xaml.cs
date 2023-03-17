﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ZetaToXray.UCs;

namespace ZetaToXray
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow        
    {
        private Einstellungen? _Einstellungen;
        private Umstellung? _Umstellung;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Init() 
        {
            _Einstellungen = new Einstellungen();
            _Umstellung = new Umstellung();
        }

        private void BtnWindowsMinimizer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button senderBtn)
            {
                if (senderBtn is null) return;

                this.WindowState = WindowState.Minimized;
            }
        }

        private async void BtnWindowClose_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button senderBtn)
            {
                if (senderBtn is null) return;

                var dialogSetting = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ja",
                    NegativeButtonText = "Nein",
                    AnimateShow = true,
                    AnimateHide = true
                };

                var erg = await this.ShowMessageAsync("ACHTUNG!", "Wollen Sie ZetaToXray schließen?", MessageDialogStyle.AffirmativeAndNegative, dialogSetting);

                if (erg == MessageDialogResult.Affirmative)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void TglBtnWindowsNormalMax_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton senderTgBtn)
            {
                if (senderTgBtn is null) return;

                if (senderTgBtn.IsChecked == true)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            }
        }

        private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            }
            catch
            {

            }
        }

        private void TglBtnMenuOpenClose_Click(object sender, RoutedEventArgs e)
        {
            OpenCloseFlyout(0);
        }

        private void OpenCloseFlyout(int iFlyoutIndex)
        {
            try
            {
                var flyout = this.Flyouts.Items[iFlyoutIndex] as Flyout;

                if (flyout is null) return;

                flyout.IsOpen = !flyout.IsOpen;
            }
            catch (Exception)
            {

            }
        }

        private void MoveMenuCurser(int listViewSelectedIndex)
        {
            var listViewItemHeight = ListViewItemUmstellung.Height;

            if (listViewSelectedIndex < 0) return;

            BorderCurser.Margin = new Thickness(0, 4 + (listViewItemHeight * listViewSelectedIndex), 0, 0);
        }

        private void MainMenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listViewSelectedIndex = MainMenuListView.SelectedIndex;

            MoveMenuCurser(listViewSelectedIndex);
            OpenCloseFlyout(0);
            TglBtnMenuOpenClose.IsChecked = false;

            switch (listViewSelectedIndex)
            {
                case 0:
                    UCsPlaceHoldergrid.Children.Clear();
                    UCsPlaceHoldergrid.Children.Add(_Einstellungen);
                    break;
                case 1:
                    UCsPlaceHoldergrid.Children.Clear();
                    UCsPlaceHoldergrid.Children.Add(_Umstellung);
                    break;               
                default:
                    break;
            }
        }

        private void MetroWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var flyout = Flyouts.Items[0] as Flyout;

                if (flyout?.IsOpen == true)
                {
                    flyout.IsOpen = false;
                    TglBtnMenuOpenClose.IsChecked = false;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
