using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AutoAirDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        #region load list account , airdrop
        private void loadFormAccount()
        {
            /* danh sách tài khoản hiển thị ở đây
             * ID là id của tài khoản
             * twitter
             * telegram
             */
            if (!File.Exists("Account.txt"))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            List<string> stringList = new List<string>();
            using (StreamReader streamReader = new StreamReader("Account.txt"))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    this.dtgAccount.Rows.Add(
                        (object)str.Split('|')[0],
                        (object)str.Split('|')[1],
                        (object)str.Split('|')[2]);
                }
            }
        }

        private void loadFormAirdrop()
        {
            /* danh sách airdrop hiển thị ở đây. 
             * Trong đó sắp xếp theo ID của airdrop. 
             * Type - là thể loại reg: gleam or normal.
             * Name - của airdrop token: momo, ksb, shib,...
             * Ref link - là link chính để các account còn lại ref
             * Data được load lên từ file .txt
             */
            if (!File.Exists("Airdrop.txt"))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            List<string> stringList = new List<string>();
            using (StreamReader streamReader = new StreamReader("Airdrop.txt"))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    this.dtgAirdrop.Rows.Add(
                        (object)str.Split('|')[0],
                        (object)str.Split('|')[1],
                        (object)str.Split('|')[2],
                        (object)str.Split('|')[3]);
                }
            }

        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            loadFormAccount();
            loadFormAirdrop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cần mở được profile theo id account

            FirefoxOptions options = new FirefoxOptions();
            FirefoxProfile profile = new FirefoxProfileManager().GetProfile("1");
            options.Profile = profile; // trước thiếu dòng này nên không chạy được đúng profile
            IWebDriver driver = new FirefoxDriver(options);
            driver.Navigate().GoToUrl("https://web.telegram.org/k/");






            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //sau khi kết thúc 1 phiên thì sử dụng lệnh quit để clear temp
            // driver.Quit();

        }
    }
}
