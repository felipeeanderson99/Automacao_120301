using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Automacao_120301
{
    class PageObject
    {
        public void aguardarCarregamentoDaTela(IWebDriver driver)
        {
            Thread.Sleep(1500);

            IWait<IWebDriver> wait2 = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30000));
            wait2.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            TimeSpan span = TimeSpan.FromSeconds(5000);
            WebDriverWait wait = new WebDriverWait(driver, span);
            wait.Until(d => d.FindElement(By.Id("header-menu")));
            Thread.Sleep(2500);


        }

        public void clickMenuTodasCategorias(IWebDriver driver)
        {

            IWebElement btnVoltarCategorias = driver.FindElement
            (By.XPath("//a[contains(., 'Todas as categorias')]"));

            btnVoltarCategorias.Click();
            Thread.Sleep(2500);

        }


        public void MenuCompensados(IWebDriver driver)
        {

            IWebElement menuMadeiras = driver.FindElement
           (By.XPath("//a[contains(., 'Madeiras')]"));

            IWebElement Compensados =
            driver.FindElement(By.XPath("//a[contains(., 'Compensados')]"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(menuMadeiras).Perform();
            builder.MoveToElement(Compensados).Click().Perform();
            Thread.Sleep(2000);

        }

        public void ComprandoProduto(IWebDriver driver)
        {
            //Descendo o Scroll
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,350)", "");

            Thread.Sleep(2000);
            //Adicionando mais uma peça
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[4]/main/div[1]/div[2]/div/div[2]/div/" +
                "div[1]/div[2]/div[2]/div/div/div[3]/div[3]/div/span[2]"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);

            Thread.Sleep(4000);

            //Clicando em comprar
            driver.FindElement(By.XPath("/html/body/div[4]/main/div[1]/div[2]/div/div[2]/div/div[1]/div[2]/div[2]" +
                "/div/div/div[3]/div[3]/button")).Click();
            Thread.Sleep(3500);

        }
        public void adicionandoAoCarrinho(IWebDriver driver)
        {
            //carinho
            driver.FindElement(By.XPath("/html/body/div[4]/header/div/div/div/div/div/div[2]/div[1]/div/div[5]/div/div/span[1]")).Click();
            Thread.Sleep(3000);

            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(d => d.FindElement(By.XPath("//input[@placeholder='Insira seu CEP']")));
            Thread.Sleep(2000);

        }

        public void cep(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//input[@placeholder='Insira seu CEP']")).SendKeys("13015904");
            Thread.Sleep(1000);

            IWebElement btnConfirmar =
              driver.FindElement(By.XPath("/html/body/div[4]/main/div[1]/div[1]/div/div[1]/div[1]/div[2]/div/div[2]/div[2]/button"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", btnConfirmar);
            Thread.Sleep(1000);
        }
        public void validandoPedido(IWebDriver driver)
        {
            string valorDoPedido = driver.FindElement(By.XPath("/html/body/div[4]/main/div[1]/div[1]/div/div[1]/" +
                "div[2]/div[1]/div[1]/div[2]/div/div[4]/div/div")).Text;

            Console.WriteLine("O valor do pedido foi: " + valorDoPedido);

            //Formatando a string do valor do pedido
            valorDoPedido = valorDoPedido.Substring(0, valorDoPedido.Length - 2);
            valorDoPedido = valorDoPedido.Replace("R$", "");
            valorDoPedido = valorDoPedido.Replace(",", "");
            valorDoPedido = valorDoPedido.Replace(".", "");
            int valorDoPedidoFormatado = Int32.Parse(valorDoPedido);

            //Validando se o valor é maior que 15 mil
            Assert.IsTrue(valorDoPedidoFormatado > 15000);
        }
    }
}
