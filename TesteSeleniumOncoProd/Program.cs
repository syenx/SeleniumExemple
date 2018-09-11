using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            try
            {

                ChromeDriver _chromeDriver = new ChromeDriver();

                _chromeDriver.Manage().Window.Maximize();

                _chromeDriver.Navigate().GoToUrl(new Uri("http://localhost:4395/Login.aspx"));

                IWebElement usuario = _chromeDriver.FindElement(By.Id("txtLogin"));
                usuario.SendKeys("THIAGOA");

                IWebElement senha = _chromeDriver.FindElement(By.Id("txtPassword"));
                senha.SendKeys("oncoks");

                IWebElement button = _chromeDriver.FindElement(By.Id("btnLogin"));
                button.Click();

                _chromeDriver.Navigate().Refresh();

                _chromeDriver.Url = "http://localhost:4395/AppPaginas/Cadastros/CadCheckListLicitatorio.aspx";
                for (int i = 0; i < 100; i++)
                {


                    Thread.Sleep(900);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_btnFiltrosNovoCadastro")).Click();
                    Thread.Sleep(4000);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtCnpjIclusao")).SendKeys("67.838.490/0001-70");
                    Thread.Sleep(600);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_imbContratoHeaderCnpjCheck")).Click();
                    Thread.Sleep(900);
                    _chromeDriver.FindElementById("ContentPlaceHolder1_txtCadCodigo").SendKeys("6701");
                    Thread.Sleep(600);
                    _chromeDriver.FindElementById("ContentPlaceHolder1_txtVigencia").SendKeys("20");
                    Thread.Sleep(600);
                    _chromeDriver.FindElementById("ContentPlaceHolder1_txtPrazoEntrega").SendKeys("30");
                    Thread.Sleep(600);
                    _chromeDriver.FindElementById("ContentPlaceHolder1_dtAbertura_txtData").SendKeys("11/09/2018");
                    Thread.Sleep(600);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtCredenc_txtData")).SendKeys("12/09/2018");
                    Thread.Sleep(600);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtRetomada_txtData")).SendKeys("13/09/2018");
                    Thread.Sleep(600);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtLimite_txtData")).SendKeys("13/09/2018");
                    Thread.Sleep(600);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtExigida_txtData")).SendKeys("13/09/2018");
                    Thread.Sleep(600);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtPesquisarItem")).SendKeys("00075");
                    Thread.Sleep(600);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_imgBuscaItensCheck")).Click();
                    Thread.Sleep(3000);
                    _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_btnSalvar")).Click();
                    Thread.Sleep(600);

                }
                _chromeDriver.Quit();
            }
            catch (Exception)
            {
                AcessarSite();
            }
        }
    }
}

