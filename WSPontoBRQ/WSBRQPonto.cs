using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WSPontoBRQ
{
    public partial class WSBRQPonto : ServiceBase
    {
        public WSBRQPonto()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            while (true)
            {
                BaterPonto(09, 05);
                BaterPonto(12, 02);
                BaterPonto(13, 05);
                BaterPonto(18, 00);
            }
        }

        protected override void OnStop()
        {
        }

        public static void BaterPonto(int horaDeBater, int minutos)
        {

            DateTime hora = DateTime.Now;
            //Console.WriteLine("agora são:" + hora.Hour + ":" + hora.Minute);
            if (hora.Hour == horaDeBater && hora.Minute == minutos && hora.Second == 00)
            {


                // Rotina que executa ao meio-dia todos os dias.
                ChromeDriver _chromeDriver = new ChromeDriver();

                _chromeDriver.Manage().Window.Maximize();

                _chromeDriver.Navigate().GoToUrl(new Uri("http://portal.brq.com.br"));

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(10));

                IWebElement usuario = _chromeDriver.FindElement(By.Id("txtUsuario"));
                usuario.SendKeys("marcelofranco");

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(10));

                IWebElement senha = _chromeDriver.FindElement(By.Id("txtSenha"));
                senha.SendKeys("M@rcelo1991");

                IWebElement button = _chromeDriver.FindElement(By.Id("btnEntrar"));
                button.Click();

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(15));

                IWebElement relogio = _chromeDriver.FindElement(By.Id("lnkWidgetBaterPonto"));
                relogio.Click();

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(10));

                _chromeDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(500));

                IWebElement bater = _chromeDriver.FindElement(By.Id("btnFecharModalBaterPonto"));
                bater.Click();

                _chromeDriver.Quit();

                EnviarEmail();
                //btnIncluirBatidaModalBaterPonto
                //btnFecharModalBaterPonto
            }
        }

        public static void EnviarEmail()
        {
            SmtpClient SmtpClient;

            MailMessage MailMessage;

            SmtpClient = new SmtpClient();
            SmtpClient.Host = "smtp.gmail.com";
            SmtpClient.Port = 587;
            SmtpClient.EnableSsl = true;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            // cria uma mensagem
            MailMessage = new MailMessage("marcelofranco.ti@gmail.com", "marcelofranco.ti@gmail.com", "Ponto batido", "Seu ponto foi batido as " + DateTime.Now.ToString());

            SmtpClient.EnableSsl = true;

            SmtpClient.UseDefaultCredentials = false;
            NetworkCredential cred = new NetworkCredential("marcelofranco.ti@gmail.com", "M@rcelo1988");
            SmtpClient.Credentials = cred;

            // envia a mensagem
            SmtpClient.Send(MailMessage);
        }
    }
}
