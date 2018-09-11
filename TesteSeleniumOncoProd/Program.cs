using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSeleniumOncoProd
{
    class Program
    {
        static void Main(string[] args)
        {
            AcessarSite();
        }



        public static void AcessarSite()
        {
            for (int i = 0; i < 100; i++)
            {


                ChromeDriver _chromeDriver = new ChromeDriver();

                _chromeDriver.Manage().Window.Maximize();

                _chromeDriver.Navigate().GoToUrl(new Uri("http://localhost:4395/Login.aspx"));

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(10));

                IWebElement usuario = _chromeDriver.FindElement(By.Id("txtLogin"));
                usuario.SendKeys("THIAGOA");

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(10));

                IWebElement senha = _chromeDriver.FindElement(By.Id("txtPassword"));
                senha.SendKeys("oncoks");

                IWebElement button = _chromeDriver.FindElement(By.Id("btnLogin"));
                button.Click();

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(50000));


                _chromeDriver.Navigate().GoToUrl(new Uri("http://localhost:4395/AppPaginas/Cadastros/CadCheckListLicitatorio.aspx"));

                IWebElement novoItem = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_btnFiltrosNovoCadastro"));
                novoItem.Click();

                IWebElement CNPJ = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtCnpjIclusao"));
                CNPJ.SendKeys("67.838.490/0001-70");

                IWebElement checkCliente = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_imbContratoHeaderCnpjCheck"));
                checkCliente.Click();


                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(50000));
                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(50000));

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(50000));
                _chromeDriver.Quit();
            }
            //IWebElement CODE = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtCadCodigo"));
            //CODE.SendKeys("670001");

            //IWebElement vigencia = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtVigencia"));
            //CODE.SendKeys("20");

            //IWebElement prazo = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtPrazoEntrega"));
            //CODE.SendKeys("30");



            //

            //_chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(10));

            //_chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(500));

            //IWebElement bater = _chromeDriver.FindElement(By.Id("btnFecharModalBaterPonto"));
            //bater.Click();

            //_chromeDriver.Quit();

            //EnviarEmail();
            //btnIncluirBatidaModalBaterPonto
            //btnFecharModalBaterPonto

        }

        //public static void EnviarEmail()
        //{
        //    SmtpClient SmtpClient;

        //    MailMessage MailMessage;

        //    SmtpClient = new SmtpClient();
        //    SmtpClient.Host = "smtp.gmail.com";
        //    SmtpClient.Port = 587;
        //    SmtpClient.EnableSsl = true;
        //    SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    // cria uma mensagem
        //    MailMessage = new MailMessage("marcelofranco.ti@gmail.com", "marcelofranco.ti@gmail.com", "Ponto batido", "Seu ponto foi batido as " + DateTime.Now.ToString());

        //    SmtpClient.EnableSsl = true;

        //    SmtpClient.UseDefaultCredentials = false;
        //    NetworkCredential cred = new NetworkCredential("marcelofranco.ti@gmail.com", "M@rcelo1988");
        //    SmtpClient.Credentials = cred;

        //    // envia a mensagem
        //    SmtpClient.Send(MailMessage);
        //}
    }
}
