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
using Microsoft.Win32;

namespace RPG
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hero main_hero;
        bool enable = false;
        bool hero_created = false;
        bool have_foto = false;
        List<string> enemy_names;
        List<int> enemy_ages;
        Random rnd = new Random();
        Hero enemy;
        List<string> enemy_gender;
        List<string> enemy_foto;

        public MainWindow()
        {
            InitializeComponent();
            main_hero = new Hero();
            enemy_names = new List<string> { "Лесной паук", "Подгнивший зомби", "Трухлявый скелет", "Бандит" };
            enemy_ages = new List<int> { 115, 92, 312, 31 };
            enemy_gender = new List<string> { "Женщина", "Мужчина", "Мужчина", "Мужчина" };
            enemy_foto = new List<string> { @"C:\SHP\0.jpg", @"C:\SHP\1.jpg", @"C:\SHP\2.jpg", @"C:\SHP\3.jpg" };
            tab_control.SelectedIndex = 1;
            main_hero.Skillpoints = 3 + main_hero.Level * main_hero.Level;
            tb_sett_skillpoints.Text = main_hero.Skillpoints.ToString();
        }

        private void Btn_apply_settings_Click(object sender, RoutedEventArgs e)
        {
            if (IsSmthContains(tb_sett_age.Text))
            {
                MessageBox.Show("Некорректный возраст", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                tb_sett_age.Text = "";
            }
            else
            {
                main_hero.Name = tb_sett_name.Text;
                main_hero.Age = Int32.Parse(tb_sett_age.Text);
                if (cb_sett_gender.SelectedIndex == 0)
                {
                    main_hero.Gender = "Мужчина";
                }
                else if (cb_sett_gender.SelectedIndex == 1)
                {
                    main_hero.Gender = "Женщина";
                }
                else
                {
                    main_hero.Gender = "1";
                }
                main_hero.Intellect = (int)(sl_intellect.Value);
                main_hero.Strength = (int)(sl_strength.Value);
                main_hero.Stamina = (int)(sl_stamina.Value);
                main_hero.Dexterity = (int)(sl_dexterity.Value);
                main_hero.Luck = (int)(sl_luck.Value);
                main_hero.HP = 100 + main_hero.Stamina * 20;
                main_hero.Mana = 100 + main_hero.Intellect * 20;
                Hero_refresh();
                tab_control.SelectedIndex = 0;
                hero_created = true;
            }
        }

        void Hero_refresh()
        {
            if (have_foto)
            {
                //main screen
                photo.Source = new BitmapImage(new Uri(main_hero.Foto));
                tb_name.Text = main_hero.Name;
                tb_age.Text = main_hero.Age.ToString();
                tb_gender.Text = main_hero.Gender;
                tb_general.Text = "Уровень: " + main_hero.Level.ToString() + "\nЗдоровье: " + main_hero.HP.ToString() + "\nМана: " + main_hero.Mana.ToString() + "\nОчки опыта: " + main_hero.Skillpoints.ToString();
                tb_abilities.Text = "Сила: " + main_hero.Strength.ToString() + "\nИнтеллект: " + main_hero.Intellect.ToString() + "\nВыносливость: " + main_hero.Stamina.ToString() + "\nЛовкость: " + main_hero.Dexterity.ToString() + "\nУдача: " + main_hero.Luck.ToString();

                tb_sett_skillpoints.Text = main_hero.Skillpoints.ToString();
                //fighting screen
                tb_fight_name_hero.Text = main_hero.Name;
                img_fight_hero.Source = new BitmapImage(new Uri(main_hero.Foto));
                tb_figth_hero_abilities.Text = "Сила: " + main_hero.Strength.ToString() + "\nИнтеллект: " + main_hero.Intellect.ToString() + "\nВыносливость: " + main_hero.Stamina.ToString() + "\nЛовкость" + main_hero.Dexterity.ToString() + "\nУдача: " + main_hero.Luck.ToString();
                pb_fight_hero_hp.Maximum = 100 + main_hero.Stamina * 20;
                pb_fight_hero_hp.Value = main_hero.HP;
                pb_fight_hero_mana.Maximum = 100 + main_hero.Intellect * 20;
                pb_fight_hero_mana.Value = main_hero.Mana;
            }
            else
            {
                //main screen
                photo.Source = new BitmapImage(new Uri(@"C:\Users\akosh\Desktop\sanitar-mem.jpg"));
                tb_name.Text = main_hero.Name;
                tb_age.Text = main_hero.Age.ToString();
                tb_gender.Text = main_hero.Gender;
                tb_general.Text = "Уровень: " + main_hero.Level.ToString() + "\nЗдоровье: " + main_hero.HP.ToString() + "\nМана: " + main_hero.Mana.ToString() + "\nОчки опыта: " + main_hero.Skillpoints.ToString();
                tb_abilities.Text = "Сила: " + main_hero.Strength.ToString() + "\nИнтеллект: " + main_hero.Intellect.ToString() + "\nВыносливость: " + main_hero.Stamina.ToString() + "\nЛовкость: " + main_hero.Dexterity.ToString() + "\nУдача: " + main_hero.Luck.ToString();

                tb_sett_skillpoints.Text = main_hero.Skillpoints.ToString();
                //fighting screen
                tb_fight_name_hero.Text = main_hero.Name;
                img_fight_hero.Source = new BitmapImage(new Uri(@"C:\SHP\sanitar-mem.jpg"));
                tb_figth_hero_abilities.Text = "Сила: " + main_hero.Strength.ToString() + "\nИнтеллект: " + main_hero.Intellect.ToString() + "\nВыносливость: " + main_hero.Stamina.ToString() + "\nЛовкость" + main_hero.Dexterity.ToString() + "\nУдача: " + main_hero.Luck.ToString();
                pb_fight_hero_hp.Maximum = 100 + main_hero.Stamina * 20;
                pb_fight_hero_hp.Value = main_hero.HP;
                pb_fight_hero_mana.Maximum = 100 + main_hero.Intellect * 20;
                pb_fight_hero_mana.Value = main_hero.Mana;
            }
        }

        void enemy_refresh()
        { 
            //fighting screen
            tb_fight_name_enemy.Text = enemy.Name;
            img_fight_enemy.Source = new BitmapImage(new Uri(enemy.Foto));
            tb_figth_enemy_abilities.Text = "Сила: " + enemy.Strength.ToString() + "\nИнтеллект: " + enemy.Intellect.ToString() + "\nВыносливость: " + enemy.Stamina.ToString() + "\nЛовкость" + enemy.Dexterity.ToString() + "\nУдача: " + enemy.Luck.ToString();
            pb_fight_enemy_hp.Maximum = 100 + enemy.Stamina * 20;
            pb_fight_enemy_hp.Value = enemy.HP;
            pb_fight_enemy_mana.Maximum = 100 + enemy.Intellect * 20;
            pb_fight_enemy_mana.Value = enemy.Mana;
        }

        private void Tab_control_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tab_control.SelectedIndex == 2)
            {
                if (!enable)
                {
                    btn_fight.Content = "Начать сражение";
                    if (tb_fight_name_hero.Visibility == Visibility.Visible)
                    {
                        tb_fight_name_hero.Visibility = Visibility.Hidden;
                    }
                    if (img_fight_hero.Visibility == Visibility.Visible)
                    {
                        img_fight_hero.Visibility = Visibility.Hidden;
                    }
                    if (tb_figth_hero_abilities.Visibility == Visibility.Visible)
                    {
                        tb_figth_hero_abilities.Visibility = Visibility.Hidden;
                    }
                    if (pb_fight_hero_hp.Visibility == Visibility.Visible)
                    {
                        pb_fight_hero_hp.Visibility = Visibility.Hidden;
                    }
                    if (pb_fight_hero_mana.Visibility == Visibility.Visible)
                    {
                        pb_fight_hero_mana.Visibility = Visibility.Hidden;
                    }
                    if (cb_figth_abilities.Visibility == Visibility.Visible)
                    {
                        cb_figth_abilities.Visibility = Visibility.Hidden;
                    }
                    if (btn_figth_apply_ability.Visibility == Visibility.Visible)
                    {
                        btn_figth_apply_ability.Visibility = Visibility.Hidden;
                    }
                    if (lb_fight_log.Visibility == Visibility.Visible)
                    {
                        lb_fight_log.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_name_enemy.Visibility == Visibility.Visible)
                    {
                        tb_fight_name_enemy.Visibility = Visibility.Hidden;
                    }
                    if (tb_figth_enemy_abilities.Visibility == Visibility.Visible)
                    {
                        tb_figth_enemy_abilities.Visibility = Visibility.Hidden;
                    }
                    if (img_fight_enemy.Visibility == Visibility.Visible)
                    {
                        img_fight_enemy.Visibility = Visibility.Hidden;
                    }
                    if (pb_fight_enemy_hp.Visibility == Visibility.Visible)
                    {
                        pb_fight_enemy_hp.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_hero_hp.Visibility == Visibility.Visible)
                    {
                        tb_fight_hero_hp.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_hero_mana.Visibility == Visibility.Visible)
                    {
                        tb_fight_hero_mana.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_enemy_hp.Visibility == Visibility.Visible)
                    {
                        tb_fight_enemy_hp.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_enemy_mana.Visibility == Visibility.Visible)
                    {
                        tb_fight_enemy_mana.Visibility = Visibility.Hidden;
                    }
                    if (pb_fight_enemy_mana.Visibility == Visibility.Visible)
                    {
                        pb_fight_enemy_mana.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    btn_fight.Content = "Закончить сражение";
                    if (pb_fight_enemy_mana.Visibility == Visibility.Hidden)
                    {
                        pb_fight_enemy_mana.Visibility = Visibility.Visible;
                    }
                    if (tb_fight_name_hero.Visibility == Visibility.Hidden)
                    {
                        tb_fight_name_hero.Visibility = Visibility.Visible;
                    }
                    if (img_fight_hero.Visibility == Visibility.Hidden)
                    {
                        img_fight_hero.Visibility = Visibility.Visible;
                    }
                    if (tb_figth_hero_abilities.Visibility == Visibility.Hidden)
                    {
                        tb_figth_hero_abilities.Visibility = Visibility.Visible;
                    }
                    if (pb_fight_hero_hp.Visibility == Visibility.Hidden)
                    {
                        pb_fight_hero_hp.Visibility = Visibility.Visible;
                    }
                    if (pb_fight_hero_mana.Visibility == Visibility.Hidden)
                    {
                        pb_fight_hero_mana.Visibility = Visibility.Visible;
                    }
                    if (cb_figth_abilities.Visibility == Visibility.Hidden)
                    {
                        cb_figth_abilities.Visibility = Visibility.Visible;
                    }
                    if (btn_figth_apply_ability.Visibility == Visibility.Hidden)
                    {
                        btn_figth_apply_ability.Visibility = Visibility.Visible;
                    }
                    if (lb_fight_log.Visibility == Visibility.Hidden)
                    {
                        lb_fight_log.Visibility = Visibility.Visible;
                    }
                    if (tb_fight_name_enemy.Visibility == Visibility.Hidden)
                    {
                        tb_fight_name_enemy.Visibility = Visibility.Visible;
                    }
                    if (tb_figth_enemy_abilities.Visibility == Visibility.Hidden)
                    {
                        tb_figth_enemy_abilities.Visibility = Visibility.Visible;
                    }
                    if (img_fight_enemy.Visibility == Visibility.Hidden)
                    {
                        img_fight_enemy.Visibility = Visibility.Visible;
                    }
                    if (pb_fight_enemy_hp.Visibility == Visibility.Hidden)
                    {
                        pb_fight_enemy_hp.Visibility = Visibility.Visible;
                    }
                    if (tb_fight_hero_hp.Visibility == Visibility.Hidden)
                    {
                        tb_fight_hero_hp.Visibility = Visibility.Visible;
                    }
                    if (tb_fight_hero_mana.Visibility == Visibility.Hidden)
                    {
                        tb_fight_hero_mana.Visibility = Visibility.Visible;
                    }
                    if (tb_fight_enemy_hp.Visibility == Visibility.Hidden)
                    {
                        tb_fight_enemy_hp.Visibility = Visibility.Visible;
                    }
                    if (tb_fight_enemy_mana.Visibility == Visibility.Hidden)
                    {
                        tb_fight_enemy_mana.Visibility = Visibility.Visible;
                    }
                }
            }
            else if (tab_control.SelectedIndex == 1)
            {
                if (hero_created)
                {
                    tb_sett_name.Text = main_hero.Name;
                    tb_sett_age.Text = main_hero.Age.ToString();
                    if (main_hero.Gender == "Мужчина")
                    {
                        cb_sett_gender.SelectedIndex = 0;
                    }
                    else if (main_hero.Gender == "Женщина")
                    {
                        cb_sett_gender.SelectedIndex = 1;
                    }
                    else
                    {
                        cb_sett_gender.SelectedIndex = 2;
                    }
                }
            }
        }

        private void Btn_fight_Click(object sender, RoutedEventArgs e)
        {
            if (!enable)
            {
                enable = !enable;

                Hero_refresh();
                generate_enemy();
                enemy_refresh();
                btn_fight.Content = "Закончить сражение";
                if (pb_fight_enemy_mana.Visibility == Visibility.Hidden)
                {
                    pb_fight_enemy_mana.Visibility = Visibility.Visible;
                }
                if (tb_fight_name_hero.Visibility == Visibility.Hidden)
                {
                    tb_fight_name_hero.Visibility = Visibility.Visible;
                }
                if (img_fight_hero.Visibility == Visibility.Hidden)
                {
                    img_fight_hero.Visibility = Visibility.Visible;
                }
                if (tb_figth_hero_abilities.Visibility == Visibility.Hidden)
                {
                    tb_figth_hero_abilities.Visibility = Visibility.Visible;
                }
                if (pb_fight_hero_hp.Visibility == Visibility.Hidden)
                {
                    pb_fight_hero_hp.Visibility = Visibility.Visible;
                }
                if (pb_fight_hero_mana.Visibility == Visibility.Hidden)
                {
                    pb_fight_hero_mana.Visibility = Visibility.Visible;
                }
                if (cb_figth_abilities.Visibility == Visibility.Hidden)
                {
                    cb_figth_abilities.Visibility = Visibility.Visible;
                }
                if (btn_figth_apply_ability.Visibility == Visibility.Hidden)
                {
                    btn_figth_apply_ability.Visibility = Visibility.Visible;
                }
                if (lb_fight_log.Visibility == Visibility.Hidden)
                {
                    lb_fight_log.Visibility = Visibility.Visible;
                }
                if (tb_fight_name_enemy.Visibility == Visibility.Hidden)
                {
                    tb_fight_name_enemy.Visibility = Visibility.Visible;
                }
                if (tb_figth_enemy_abilities.Visibility == Visibility.Hidden)
                {
                    tb_figth_enemy_abilities.Visibility = Visibility.Visible;
                }
                if (img_fight_enemy.Visibility == Visibility.Hidden)
                {
                    img_fight_enemy.Visibility = Visibility.Visible;
                }
                if (pb_fight_enemy_hp.Visibility == Visibility.Hidden)
                {
                    pb_fight_enemy_hp.Visibility = Visibility.Visible;
                }
                if (tb_fight_hero_hp.Visibility == Visibility.Hidden)
                {
                    tb_fight_hero_hp.Visibility = Visibility.Visible;
                }
                if (tb_fight_hero_mana.Visibility == Visibility.Hidden)
                {
                    tb_fight_hero_mana.Visibility = Visibility.Visible;
                }
                if (tb_fight_enemy_hp.Visibility == Visibility.Hidden)
                {
                    tb_fight_enemy_hp.Visibility = Visibility.Visible;
                }
                if (tb_fight_enemy_mana.Visibility == Visibility.Hidden)
                {
                    tb_fight_enemy_mana.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите закончить сражение?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    enable = !enable;
                    btn_fight.Content = "Начать сражение";
                    if (tb_fight_name_hero.Visibility == Visibility.Visible)
                    {
                        tb_fight_name_hero.Visibility = Visibility.Hidden;
                    }
                    if (img_fight_hero.Visibility == Visibility.Visible)
                    {
                        img_fight_hero.Visibility = Visibility.Hidden;
                    }
                    if (tb_figth_hero_abilities.Visibility == Visibility.Visible)
                    {
                        tb_figth_hero_abilities.Visibility = Visibility.Hidden;
                    }
                    if (pb_fight_hero_hp.Visibility == Visibility.Visible)
                    {
                        pb_fight_hero_hp.Visibility = Visibility.Hidden;
                    }
                    if (pb_fight_hero_mana.Visibility == Visibility.Visible)
                    {
                        pb_fight_hero_mana.Visibility = Visibility.Hidden;
                    }
                    if (cb_figth_abilities.Visibility == Visibility.Visible)
                    {
                        cb_figth_abilities.Visibility = Visibility.Hidden;
                    }
                    if (btn_figth_apply_ability.Visibility == Visibility.Visible)
                    {
                        btn_figth_apply_ability.Visibility = Visibility.Hidden;
                    }
                    if (lb_fight_log.Visibility == Visibility.Visible)
                    {
                        lb_fight_log.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_name_enemy.Visibility == Visibility.Visible)
                    {
                        tb_fight_name_enemy.Visibility = Visibility.Hidden;
                    }
                    if (tb_figth_enemy_abilities.Visibility == Visibility.Visible)
                    {
                        tb_figth_enemy_abilities.Visibility = Visibility.Hidden;
                    }
                    if (img_fight_enemy.Visibility == Visibility.Visible)
                    {
                        img_fight_enemy.Visibility = Visibility.Hidden;
                    }
                    if (pb_fight_enemy_hp.Visibility == Visibility.Visible)
                    {
                        pb_fight_enemy_hp.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_hero_hp.Visibility == Visibility.Visible)
                    {
                        tb_fight_hero_hp.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_hero_mana.Visibility == Visibility.Visible)
                    {
                        tb_fight_hero_mana.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_enemy_hp.Visibility == Visibility.Visible)
                    {
                        tb_fight_enemy_hp.Visibility = Visibility.Hidden;
                    }
                    if (tb_fight_enemy_mana.Visibility == Visibility.Visible)
                    {
                        tb_fight_enemy_mana.Visibility = Visibility.Hidden;
                    }
                    if (pb_fight_enemy_mana.Visibility == Visibility.Visible)
                    {
                        pb_fight_enemy_mana.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void Btn_load_photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();  // Создание переменной файлового диалога
            OpenFileDialog.Filter = "Image (*.png)|*.png";         // Настройка фильтров, т.е. типов файлов, которые будут видны в диалоге
            OpenFileDialog.InitialDirectory = @"C:\";   // Настройка папки, в которой откроется файловый диалог
            if (OpenFileDialog.ShowDialog() == true)
            {
                main_hero.Foto = OpenFileDialog.FileName;
            }
            have_foto = true;
        }

        static bool IsSmthContains(string input)
        {
            if (input.Length == 0)
            {
                return false;   
            }
            foreach (char c in input)
                if (!Char.IsNumber(c))
                    return true;
            return false;
        }

        private void generate_enemy()
        {
            enemy = new Hero();
            int index = rnd.Next(enemy_names.Count);
            enemy.Name = enemy_names[index];
            enemy.Age = enemy_ages[index];
            enemy.Foto = enemy_foto[index];
            enemy.Gender = enemy_gender[index];
            enemy.Level = main_hero.Level;
            enemy.Strength = rnd.Next(1, 10);
            enemy.Intellect = rnd.Next(1, 10);
            enemy.Experience = rnd.Next(1, 10);
            enemy.Stamina = rnd.Next(1, 10);
            enemy.Dexterity = rnd.Next(1, 10);
            enemy.Luck = rnd.Next(1, 10);
            enemy.HP = 100 + enemy.Stamina * 20;
            enemy.Mana = 100 + enemy.Intellect * 20;
        }

        private void Btn_figth_apply_ability_Click(object sender, RoutedEventArgs e)
        {
            string log = "";
            if (cb_figth_abilities.SelectedIndex == 0)
            {
                int x = main_hero.attack(enemy, 1);
                enemy.HP = enemy.HP - x;
                pb_fight_enemy_hp.Value = enemy.HP;
                if (main_hero.Gender == "Мужчина")
                {
                    log = main_hero.Name + " атаковал " + enemy.Name + " и нанес " + x.ToString() + " урона";
                }
                else if (main_hero.Gender == "Женщина")
                {
                    log = main_hero.Name + " атаковала " + enemy.Name + " и нанес " + x.ToString() + " урона";
                }
                else
                {
                    log = main_hero.Name + " атаковало " + enemy.Name + " и нанес " + x.ToString() + " урона";
                }

            }
            else if (cb_figth_abilities.SelectedIndex == 1)
            {
                int x = main_hero.attack(enemy, 3);
                enemy.HP = enemy.HP - x;
                pb_fight_enemy_hp.Value = enemy.HP;
                if (main_hero.Gender == "Мужчина")
                {
                    log = main_hero.Name + " атаковал " + enemy.Name + " и нанес " + x.ToString() + " урона";
                }else if (main_hero.Gender == "Женщина")
                {
                    log = main_hero.Name + " атаковала " + enemy.Name + " и нанес " + x.ToString() + " урона";
                }
                else
                {
                    log = main_hero.Name + " атаковало " + enemy.Name + " и нанес " + x.ToString() + " урона";
                }
            }
            lb_fight_log.Items.Insert(0, log);
            int y = enemy.attack(main_hero, rnd.Next(1, 2));
            main_hero.HP = main_hero.HP - y;
            pb_fight_hero_hp.Value = main_hero.HP;
            if (enemy.Gender == "Мужчина")
            {
                log = enemy.Name + " атаковал " + main_hero.Name + " и нанес " + y.ToString() + " урона";
            }
            else if (enemy.Gender == "Женщина")
            {
                log = enemy.Name + " атаковала " + main_hero.Name + " и нанес " + y.ToString() + " урона";
            }
            else
            {
                log = enemy.Name + " атаковало " + main_hero.Name + " и нанес " + y.ToString() + " урона";
            }
            lb_fight_log.Items.Insert(0, log);
            if ((main_hero.HP <= 0) || (enemy.HP <= 0)){
                if ((main_hero.HP <=0)&&(enemy.HP <= 0))
                {
                    MessageBox.Show("Ничья!", "Конец сражения", MessageBoxButton.OK, MessageBoxImage.Information);
                    main_hero.HP = 100 + main_hero.Stamina * 20;
                    enemy.HP = 100 + enemy.Stamina * 20;
                    tab_control.SelectedIndex = 0;
                }
                else
                {
                    if (main_hero.HP <= 0)
                    {
                        MessageBox.Show("Вы проиграли!", "Конец сражения", MessageBoxButton.OK, MessageBoxImage.Information);
                        main_hero.HP = 100 + main_hero.Stamina * 20;
                        enemy.HP = 100 + enemy.Stamina * 20;
                        tab_control.SelectedIndex = 0;
                    }
                    else
                    {
                        int x = rnd.Next(main_hero.Level + main_hero.Luck);
                        MessageBox.Show("Вы выиграли и получили " + x.ToString() + " очков опыта!", "Конец сражения", MessageBoxButton.OK, MessageBoxImage.Information);
                        main_hero.HP = 100 + main_hero.Stamina * 20;
                        main_hero.Skillpoints += x;
                        enemy.HP = 100 + enemy.Stamina * 20;
                        tab_control.SelectedIndex = 0;
                        if (main_hero.Skillpoints > main_hero.Level * 2)
                        {
                            MessageBox.Show("Вы получили новый уровень!", "Новый уровень", MessageBoxButton.OK, MessageBoxImage.Information);
                            main_hero.Level += main_hero.Skillpoints / 5;
                        }
                        Hero_refresh();
                    }
                }
                enable = !enable;
            }
            cb_figth_abilities.SelectedIndex = -1;
        }

        private void Sl_strength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int mid_value = main_hero.Strength;
            if (sl_strength.Value > mid_value && main_hero.Skillpoints > 0)
            {
                mid_value = Convert.ToInt32(sl_strength.Value);
                main_hero.Strength = mid_value;
                main_hero.Skillpoints--;
            }else if (sl_strength.Value < mid_value)
            {
                mid_value = Convert.ToInt32(sl_strength.Value);
                main_hero.Strength = mid_value;
                main_hero.Skillpoints++;
            }else if (main_hero.Skillpoints == 0)
            {
                sl_strength.Value = mid_value;
            }
            tb_sett_skillpoints.Text = main_hero.Skillpoints.ToString();
        }

        private void Sl_intellect_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int mid_value = main_hero.Intellect;
            if (sl_intellect.Value > mid_value && main_hero.Skillpoints > 0)
            {
                mid_value = Convert.ToInt32(sl_intellect.Value);
                main_hero.Intellect = mid_value;
                main_hero.Skillpoints--;
            }
            else if (sl_intellect.Value < mid_value)
            {
                mid_value = Convert.ToInt32(sl_intellect.Value);
                main_hero.Intellect = mid_value;
                main_hero.Skillpoints++;
            }
            else if (main_hero.Skillpoints == 0)
            {
                sl_intellect.Value = mid_value;
            }
            tb_sett_skillpoints.Text = main_hero.Skillpoints.ToString();
        }

        private void Sl_stamina_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int mid_value = main_hero.Stamina;
            if (sl_stamina.Value > mid_value && main_hero.Skillpoints > 0)
            {
                mid_value = Convert.ToInt32(sl_stamina.Value);
                main_hero.Stamina = mid_value;
                main_hero.Skillpoints--;
            }
            else if (sl_stamina.Value < mid_value)
            {
                mid_value = Convert.ToInt32(sl_stamina.Value);
                main_hero.Stamina = mid_value;
                main_hero.Skillpoints++;
            }
            else if (main_hero.Skillpoints == 0)
            {
                sl_stamina.Value = mid_value;
            }
            tb_sett_skillpoints.Text = main_hero.Skillpoints.ToString();
        }

        private void Sl_dexterity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int mid_value = main_hero.Dexterity;
            if (sl_dexterity.Value > mid_value && main_hero.Skillpoints > 0)
            {
                mid_value = Convert.ToInt32(sl_dexterity.Value);
                main_hero.Dexterity = mid_value;
                main_hero.Skillpoints--;
            }
            else if (sl_dexterity.Value < mid_value)
            {
                mid_value = Convert.ToInt32(sl_dexterity.Value);
                main_hero.Dexterity = mid_value;
                main_hero.Skillpoints++;
            }
            else if (main_hero.Skillpoints == 0)
            {
                sl_dexterity.Value = mid_value;
            }
            tb_sett_skillpoints.Text = main_hero.Skillpoints.ToString();
        }

        private void Sl_luck_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int mid_value = main_hero.Luck;
            if (sl_luck.Value > mid_value && main_hero.Skillpoints > 0)
            {
                mid_value = Convert.ToInt32(sl_luck.Value);
                main_hero.Luck = mid_value;
                main_hero.Skillpoints--;
            }
            else if (sl_luck.Value < mid_value)
            {
                mid_value = Convert.ToInt32(sl_luck.Value);
                main_hero.Luck = mid_value;
                main_hero.Skillpoints++;
            }
            else if (main_hero.Skillpoints == 0)
            {
                sl_luck.Value = mid_value;
            }
            tb_sett_skillpoints.Text = main_hero.Skillpoints.ToString();
        }
    }
}