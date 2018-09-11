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

            ChromeDriver _chromeDriver = new ChromeDriver();

            _chromeDriver.Manage().Window.Maximize();

            _chromeDriver.Navigate().GoToUrl(new Uri("http://localhost:4395/Login.aspx"));

            IWebElement usuario = _chromeDriver.FindElement(By.Id("txtLogin"));
            usuario.SendKeys("THIAGOA");

            IWebElement senha = _chromeDriver.FindElement(By.Id("txtPassword"));
            senha.SendKeys("oncoks");

            IWebElement button = _chromeDriver.FindElement(By.Id("btnLogin"));
            button.Click();

            Thread.Sleep(2000);
            _chromeDriver.Navigate().GoToUrl(new Uri("http://localhost:4395/AppPaginas/Cadastros/CadCheckListLicitatorio.aspx"));


            IWebElement novoItem = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_btnFiltrosNovoCadastro"));
            novoItem.Click();

            IWebElement CNPJ = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtCnpjIclusao"));
            CNPJ.SendKeys("67.838.490/0001-70");

            IWebElement checkCliente = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_imbContratoHeaderCnpjCheck"));
            checkCliente.Click();

            IWebElement CODE = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtCadCodigo"));
            CODE.SendKeys("670001");

            IWebElement vigencia = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtVigencia"));
            vigencia.SendKeys("20");

            IWebElement prazo = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtPrazoEntrega"));
            prazo.SendKeys("30");



            IWebElement dtAbertura = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtAbertura_txtData"));
            dtAbertura.SendKeys("11/09/2018");

            IWebElement dtCredenc = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtCredenc_txtData"));
            dtCredenc.SendKeys("12/09/2018");

            IWebElement dtRetomada = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtRetomada_txtData"));
            dtRetomada.SendKeys("13/09/2018");

            IWebElement dtLimite = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtLimite_txtData"));
            dtLimite.SendKeys("13/09/2018");

            IWebElement dtExigida = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_dtExigida_txtData"));
            dtExigida.SendKeys("13/09/2018");


            IWebElement item1 = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_txtPesquisarItem"));
            item1.SendKeys("00075");

            IWebElement clickItem = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_imgBuscaItensCheck"));
            clickItem.Click();
            Thread.Sleep(2000);
            item1.SendKeys("00074");
            clickItem.Click();
            Thread.Sleep(2000);

            item1.SendKeys("00074");
            clickItem.Click();
            Thread.Sleep(2000);

            item1.SendKeys("00077");
            clickItem.Click();
            Thread.Sleep(2000);


            IWebElement salvar = _chromeDriver.FindElement(By.Id("ContentPlaceHolder1_btnSalvar"));
            salvar.Click();

        }
    }
}
