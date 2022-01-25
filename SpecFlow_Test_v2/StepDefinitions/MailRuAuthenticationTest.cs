using SpecFlow_Test_v2.Actions;

using TechTalk.SpecFlow.Assist;



namespace SpecFlow_Test_v2.StepDefinitions
{
    [Binding]

    public class MailRuAuthenticationTest
    {

        [Given(@"Найти mailru в поиске Google")]
        public void GivenНайтиMailruВПоискеGoogle()
        {
            MailRuActions.OpenGoogle();
        }

        [Given(@"Открыть сайт mailru")]
        public void GivenОткрытьСайтMailru()
        {
            MailRuActions.FindMailRuText();
        }



    [Then(@"Использовать неверные учётные записи на сайте mailru")]
        public void ThenИспользоватьНеверныеУчётныеЗаписиНаСайтеMailru(Table table)
        {
            MailRuActions.EnumIncorrectUsers(table);
        }

        [Then(@"Пройти авторизацию на mailru")]
        public void ThenПройтиАвторизациюНаMailru(Table table)
        {
            MailRuActions.LogInMailRu(table);
        }

        [Then(@"Проверить имя пользователя после авторизации")]
        public void ThenПроверитьИмяПользователяПослеАвторизации()
        {
            MailRuActions.AssertUser();
        }
    }
}
