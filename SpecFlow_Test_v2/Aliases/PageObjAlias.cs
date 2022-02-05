using System;
using OpenQA.Selenium;


namespace SpecFlow_Test_v2.Aliases

{
    public static class PageObjAlias
	{
		readonly static public string username = "testselenide@mail.ru";
		readonly static public string searchObject = "mail.ru";
		readonly static public string tableAsStringUser = "Логин";
		readonly static public string tableAsStringPassord = "Пароль";
		readonly static public string url = "https://www.google.ru/";
		readonly static public By googleFindString = By.Name("q");
		readonly static public By googleFindButton = By.XPath("//input[@value='Поиск в Google']");
		readonly static public By googleFindResult = By.XPath("//a[@href='https://mail.ru/']");
		readonly static public By loginString = By.Name("login");
		readonly static public By goToPasswordButton = By.XPath("//button[@data-testid='enter-password']");
		readonly static public By error_NullLogin = By.XPath("//div[text()='Введите имя ящика']");
		readonly static public By error_IncorrectLogin = By.XPath("//div[text()='Неверное имя ящика']");
		readonly static public By passwordString = By.Name("password");
		readonly static public By singInButton = By.XPath("//button[@data-testid='login-to-mail']");
		readonly static public By error_NullPassword = By.XPath("//div[text()='Введите пароль']");
		readonly static public By error_IncorrectPassword = By.XPath("//div[text()='Неверное имя или пароль']");
		readonly static public By userLabel = By.XPath("//div[@data-testid='whiteline-accoun']");
		
    }
}
