﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow_Test_v2.Aliases;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow_Test_v2.Actions
{
    internal class MailRuActions
    {
        private static readonly IWebDriver driver = new ChromeDriver();


        public static void OpenGoogle()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(PageObjAlias.url);  
        }
        public static void FindMailRuText()
        {
            try
            {
                Thread.Sleep(500);
                IWebElement searchstr = driver.FindElement(PageObjAlias.googleFindString);
                searchstr.SendKeys(PageObjAlias.searchObject);
                Thread.Sleep(500);
                driver.FindElement(PageObjAlias.googleFindButton).Click();
                Thread.Sleep(500);
                driver.FindElement(PageObjAlias.googleFindResult).Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n----------Exception in FindMailRu: " + ex.Message + " ----------");
                Console.WriteLine("----------------------------- Test Fail -----------------------------\n");
                driver.Quit();
            }
        }

        public static void EnumIncorrectUsers(Table table)
        {
            try
            {
                string[] username = table.AsStringArr("Логин");
                string[] password = table.AsStringArr("Пароль");
                for (int i = 0; i < table.RowCount; i++)
                {
                    bool visibleState = false;
                    driver.Navigate().Refresh();
                    Thread.Sleep(300);
                    driver.FindElement(PageObjAlias.loginString).SendKeys(username[i]);
                    driver.FindElement(PageObjAlias.goToPasswordButton).Click();
                    Thread.Sleep(100);

                    TryFindElement(PageObjAlias.error_NullLogin, out visibleState);
                    if (visibleState) { continue; }

                    TryFindElement(PageObjAlias.error_IncorrectLogin, out visibleState);
                    if (visibleState) { continue; }

                    Thread.Sleep(200);
                    driver.FindElement(PageObjAlias.passwordString).SendKeys(password[i]);
                    driver.FindElement(PageObjAlias.singInButton).Click();

                    TryFindElement(PageObjAlias.error_NullPassword, out visibleState);
                    if (visibleState) { continue; }

                    TryFindElement(PageObjAlias.error_IncorrectPassword, out visibleState);
                    if (visibleState) { continue; }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n----------Exception in LogInMailRu: " + ex.Message + " ---------- ");
                Console.WriteLine("----------------------------- Test Fail -----------------------------\n");
                driver.Quit();
            }
        }

        public static void LogInMailRu(Table table)
        {
            string[] username = table.AsStringArr("Логин");
            string[] password = table.AsStringArr("Пароль");
            try
            {
                for (int i = 0; i < table.RowCount; i++)
                {
                    driver.Navigate().Refresh();
                    Thread.Sleep(300);
                    driver.FindElement(PageObjAlias.loginString).SendKeys(username[i]);
                    driver.FindElement(PageObjAlias.goToPasswordButton).Click();
                    Thread.Sleep(500);
                    driver.FindElement(PageObjAlias.passwordString).SendKeys(password[i]);
                    driver.FindElement(PageObjAlias.singInButton).Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n----------Exception in LogInMailRu: " + ex.Message + " ---------- ");
                Console.WriteLine("----------------------------- Test Fail -----------------------------\n");
                driver.Quit();
            }
        }

        public static void TryFindElement(By Element, out bool ElementState)
        {
            try
            {
                driver.FindElement(Element);
                ElementState = true;
            }
            catch (NoSuchElementException)
            {
                ElementState = false;
            }
        }

        public static void AssertUser()
        {
            try
            {
                Thread.Sleep(1000);
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@aria-label='testselenide@mail.ru']")).Text.Contains(PageObjAlias.username));
                Console.WriteLine("\n----------------------------- Test Done -----------------------------\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n----------Exception in AssertUser: " + ex.Message + " ----------");
                Console.WriteLine("----------------------------- Test Fail -----------------------------\n");
            }
            finally { driver.Quit(); }
        }
    }
}