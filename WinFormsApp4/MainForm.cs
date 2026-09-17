using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinFormsApp4
{
    public partial class MainForm : Form
    {
        private int userRole;
        private string userName;

        // Тестовый список ювелирных украшений для работы без сервера
        private List<ProductItem> productList = new List<ProductItem>()
        {
            new ProductItem { Sku = "A112T4", Title = "Кольцо", Description = "Кольцо из серебра с позолотой", Manufacturer = "ЮвелирКарат", Price = 1110, Stock = 11 },
            new ProductItem { Sku = "G843Y6", Title = "Колье", Description = "Ювелирное колье из серебра 925 пробы с фианитами", Manufacturer = "ЮвелирКарат", Price = 2600, Stock = 5 },
            new ProductItem { Sku = "S648N6", Title = "Серьги", Description = "Серьги с фианитами и гематитами из серебра с позолотой", Manufacturer = "ЮвелирТорг", Price = 5200, Stock = 6 },
            new ProductItem { Sku = "D493Y7", Title = "Браслет", Description = "Браслет плетения Бисмарк из красного золота 585 пробы", Manufacturer = "ЗолотойВек", Price = 14500, Stock = 0 }
        };

        public MainForm(int roleId, string fullName)
        {
            InitializeComponent();

            // Железобетонно связываем все события через код
            this.Load += MainForm_Load;
            lstProducts.DrawItem += lstProducts_DrawItem;
            lstProducts.MeasureItem += lstProducts_MeasureItem;
            txtSearch.TextChanged += txtSearch_TextChanged;

            this.userRole = roleId;
            this.userName = fullName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Выводим ФИО зашедшего в лейбл
            lblUserFIO.Text = userName;
            this.Text = $"Каталог товаров (Роль: {userRole})";

            // Заполняем список плитками товаров при запуске
            UpdateProductList("");
        }

        // Общий метод для обновления списка (нужен и при загрузке, и при поиске)
        private void UpdateProductList(string searchText)
        {
            lstProducts.Items.Clear();
            foreach (var prod in productList)
            {
                if (string.IsNullOrEmpty(searchText) ||
                    prod.Title.ToLower().Contains(searchText) ||
                    prod.Description.ToLower().Contains(searchText))
                {
                    lstProducts.Items.Add(prod);
                }
            }
        }

        // Логика строки поиска — мгновенно фильтрует список при вводе букв
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateProductList(txtSearch.Text.ToLower().Trim());
        }

        // Задаем высоту плитки (карточки товара) по ТЗ
        private void lstProducts_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 120;
        }

        // Рисуем рамки, текст и заглушки картинок ювелирки вручную
        private void lstProducts_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ProductItem item = (ProductItem)lstProducts.Items[e.Index];

            // 1. Настраиваем фон (серый, если товара нет на складе)
            Brush backgroundBrush = (item.Stock == 0) ? Brushes.LightGray : Brushes.White;
            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            // 2. Рисуем внешнюю рамку карточки товара
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds.X + 5, e.Bounds.Y + 5, e.Bounds.Width - 10, e.Bounds.Height - 10);

            // 3. Рисуем рамку для картинки слева
            Rectangle imgRect = new Rectangle(e.Bounds.X + 15, e.Bounds.Y + 15, 90, 90);
            e.Graphics.DrawRectangle(Pens.Black, imgRect);
            e.Graphics.DrawString("ФОТО", new Font("Arial", 10, FontStyle.Bold), Brushes.Gray, e.Bounds.X + 35, e.Bounds.Y + 50);

            // 4. Текст по центру карточки
            Font titleFont = new Font("Arial", 12, FontStyle.Bold);
            Font infoFont = new Font("Arial", 9, FontStyle.Regular);

            e.Graphics.DrawString(item.Title, titleFont, Brushes.Black, e.Bounds.X + 120, e.Bounds.Y + 15);
            e.Graphics.DrawString(item.Description, infoFont, Brushes.Black, e.Bounds.X + 120, e.Bounds.Y + 40);
            e.Graphics.DrawString($"Производитель: {item.Manufacturer}", infoFont, Brushes.Black, e.Bounds.X + 120, e.Bounds.Y + 65);
            e.Graphics.DrawString($"Цена: {item.Price}", infoFont, Brushes.Black, e.Bounds.X + 120, e.Bounds.Y + 85);

            // 5. ДИНАМИЧЕСКИЙ РАСЧЕТ ДЛЯ ПРАВОГО КРАЯ (Без дубликатов и наслоений!)
            int stockBoxWidth = 35;
            int stockBoxHeight = 90;
            int stockBoxX = e.Bounds.Right - stockBoxWidth - 15; // Ровный отступ от правого края окна
            int stockBoxY = e.Bounds.Y + 15;

            Rectangle stockRect = new Rectangle(stockBoxX, stockBoxY, stockBoxWidth, stockBoxHeight);

            // Рисуем одну аккуратную рамку остатка на складе
            e.Graphics.DrawRectangle(Pens.Black, stockRect);

            // Выводим цифру количества строго по центру рамки
            e.Graphics.DrawString(item.Stock.ToString(), titleFont, Brushes.Black, stockBoxX + 8, stockBoxY + 35);
        }

        // Кнопка Назад - закрывает форму каталога и возвращает на авторизацию
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Класс-модель для хранения данных товара
    public class ProductItem
    {
        public string Sku { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
