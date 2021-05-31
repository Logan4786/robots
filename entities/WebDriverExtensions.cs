using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Text;

namespace PjeApplication.entities
{
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver, TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static void SetText(this IWebDriver webDriver, By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void Click(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            //Actions actions = new Actions(webDriver);
            //actions.MoveToElement(webElement).Perform();
            try{
                webElement.Click();
            }catch(Exception){
                try{
                    IJavaScriptExecutor je = (IJavaScriptExecutor)webDriver;
                    je.ExecuteScript("arguments[0].scrollIntoView();", webElement);
                    webElement.Click();
                }catch(Exception){

                }
            }
        }

        public static void Clear(this IWebDriver webDriver, By by)
        {
            webDriver.FindElement(by).Clear();
        }

        
        public static void CaminhoPDF(this IWebDriver webDriver, int caminho)
        {
            if (caminho == 1)
            {
                System.Threading.Thread.Sleep(1000);
                //mp_formValidarContentDiv
                while (webDriver.FindElements(By.Id("home")).Count < 0)
                {
                    
                }
                
                //while (webDriver.FindElement(By.Id("mp_formValidarCDiv")).GetAttribute("style") == "position: absolute; left: 521px; top: 297px; z-index: 9;")
                //{}

                new WebDriverWait(webDriver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/nav/div/div[1]/ul/li/a")));
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/nav/div/div[1]/ul/li/a")); //clica no menu
                System.Threading.Thread.Sleep(1000);
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/div[5]/div/nav/div[2]/ul/li[1]/a")); //clica em painel

                System.Threading.Thread.Sleep(1000);
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/div[5]/div/nav/div[2]/ul/li[1]/div/ul/li[1]/a")); //clica em painel do representante

            }
            else if (caminho == 2)
            {
                System.Threading.Thread.Sleep(1000);
                if(webDriver.FindElements(By.Name("j_id189:j_id190")).Count > 0){
                    WebDriverExtensions.Click(webDriver, By.Name("j_id189:j_id190"));
                }

                if(webDriver.FindElements(By.Name("j_id188:j_id189")).Count > 0){
                    WebDriverExtensions.Click(webDriver, By.Name("j_id188:j_id189"));
                }

                if(webDriver.FindElements(By.Id("details-button")).Count > 0){
                    WebDriverExtensions.Click(webDriver, By.Id("details-button"));
                    System.Threading.Thread.Sleep(1000);
                    WebDriverExtensions.Click(webDriver, By.Id("proceed-link"));
                }

                //WebDriverExtensions.Click(webDriver, By.XPath("/html/body/div[6]/div/nav/div[2]/ul/li[1]/a"));
            }
            else if (caminho == 3)
            {
                System.Threading.Thread.Sleep(1000);
                new WebDriverWait(webDriver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/nav/div/div[1]/ul/li/a")));
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/nav/div/div[1]/ul/li/a"));
                System.Threading.Thread.Sleep(1000);
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/div[6]/div/nav/div[2]/ul/li[1]/a"));

                System.Threading.Thread.Sleep(1000);
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/div[6]/div/nav/div[2]/ul/li[1]/div/ul/li[1]/a"));
            }
            else if (caminho == 4)
           {
                new WebDriverWait(webDriver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/nav/div/div[1]/ul/li/a")));
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/nav/div/div[1]/ul/li/a"));
                System.Threading.Thread.Sleep(1000);
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/div[5]/div/nav/div[2]/ul/li[1]/a"));

                System.Threading.Thread.Sleep(1000);
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/div[5]/div/nav/div[2]/ul/li[1]/div/ul/li[1]/a"));

                System.Threading.Thread.Sleep(1000);
                WebDriverExtensions.Click(webDriver, By.XPath("/html/body/div[5]/div/div/div/div[2]/table/tbody/tr/td/form/table/tbody/tr/td[6]/table/tbody/tr/td[2]/table/tbody/tr/td"));
            }
        }

        public static void ObterPDF(this IWebDriver webDriver, int tipo, int caminho, Procedimentos pro){
            List<Processos> categorias = new List<Processos>();

            List<Processos> primeiro = new List<Processos>();
            List<Processos> segundo = new List<Processos>();
            List<Processos> terceiro = new List<Processos>();

            if (tipo == 1)
            {
                if(webDriver.FindElements(By.XPath("//*[@id='formAbaExpediente:listaAgrSitExp:0:linhaN1']/div/div/div/span[1]")).Count > 0){
                    categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:0:linhaN1']/div/div/div/span[1]", 0));
                }else{
                    categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:0:linhaN1']/div/div/a/span[1]", 0)); //*[@id='formAbaExpediente:listaAgrSitExp:0:j_id157']/span[1]
                }

                if(webDriver.FindElements(By.XPath("//*[@id='formAbaExpediente:listaAgrSitExp:1:linhaN1']/div/div/div/span[1]")).Count > 0){
                    categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:1:linhaN1']/div/div/div/span[1]", 1));
                }else{
                    categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:1:linhaN1']/div/div/a/span[1]", 1)); //*[@id='formAbaExpediente:listaAgrSitExp:0:j_id157']/span[1]
                }

                if(webDriver.FindElements(By.XPath("//*[@id='formAbaExpediente:listaAgrSitExp:3:linhaN1']/div/div/div/span[1]")).Count > 0){
                    categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:3:linhaN1']/div/div/div/span[1]", 3));
                }else{
                    categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:3:linhaN1']/div/div/a/span[1]", 3)); //*[@id='formAbaExpediente:listaAgrSitExp:0:j_id157']/span[1]
                }

                foreach (Processos x in categorias)
                {
                    System.Threading.Thread.Sleep(1000);
                    Click(webDriver, By.XPath(x.Procedimento)); //clica no menu

                    if (webDriver.FindElements(By.Id("formAbaExpediente:listaAgrSitExp:" + x.ListaForum.ToString() + ":linhaN2")).Count <= 0) //FindElements(By.Id("j_id406")
                    {
                        Console.Write("");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(4000);
                        //IList<IWebElement> webElement = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:0:trPend:childs")).FindElements(By.TagName("span"));
                        IList<IWebElement> webElement = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:" + x.ListaForum.ToString() + ":trPend:childs")).FindElements(By.CssSelector("span[class='nomeTarefa']"));
                        //IList<IWebElement> links = webDriver.FindElement(By.)
                        //var texto = new IList<IWebElement>("");
                        IList<IWebElement> texto= webDriver.FindElements(By.CssSelector("span[class='nomeTarefa']"));
                        //WebElement firstName = driver.findElement(By.cssSelector("input[name='first_name']"));
                        //List<IWebElement> elementos = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:0:trPend:childs")).GetAttribute("table");

                        int n = webElement.Count - 1;
                        for (int i = 0; i <= n; i++)
                        {                                                               //formAbaExpediente:listaAgrSitExp:3:trPend:childs
                            System.Threading.Thread.Sleep(1000);                        //formAbaExpediente:listaAgrSitExp:1:trPend:childs
                            int cont = 0;   
                            IList<IWebElement> webElement2;                                         //formAbaExpediente:listaAgrSitExp:0:trPend:childs
                            try{
                                webElement2 = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:" + x.ListaForum.ToString() + ":trPend:childs")).FindElements(By.CssSelector("span[class='nomeTarefa']"));
                            }catch(Exception)
                            {
                                Click(webDriver, By.XPath(x.Procedimento));
                                System.Threading.Thread.Sleep(1000); 
                            }
                            webElement2 = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:" + x.ListaForum.ToString() + ":trPend:childs")).FindElements(By.CssSelector("span[class='nomeTarefa']"));
                            foreach (var item2 in webElement2)
                            {

                                Debug.Print(item2.Text);
                                Debug.Print(item2.ToString());
                                String textoAgora = item2.Text;
                                if (cont == i & item2.Text != "")
                                {
                                    
                                    Debug.Print(item2.Text);
                                    Debug.Print(item2.ToString());
                                    if (cont == i & item2.Text != "")
                                    {
                                        var te = item2;
                                        if(item2.Text == "RONDONÓPOLIS"){
                                            Debug.Print("");
                                        }
                                        System.Threading.Thread.Sleep(1000);
                                        try{
                                            //Action actions;
                                            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(webDriver);
                                            action.MoveToElement(item2);
                                            action.Perform();
                                        }catch(Exception e){
                                            Debug.Print(e.Message);
                                        }
                                        
                                        item2.Click();
                                        System.Threading.Thread.Sleep(1000);
                                        BaixarPDF(webDriver, caminho, pro, x, i);
                                        //Debug.Print(item2.Text)
                                        break;
                                    }
                                    if(item2.Text == ""){
                                        cont--;
                                    }
                                    cont++;
                                }
                                if (item2.Text == "")
                                {
                                    cont--;
                                }
                                cont++;
                            }
                            //System.Threading.Thread.Sleep(2000);
                            while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                            
                            Click(webDriver, By.XPath(x.Procedimento));
                            while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                            //System.Threading.Thread.Sleep(2000);//_viewRoot:status.start
                            Click(webDriver, By.XPath(x.Procedimento));
                            while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                            //System.Threading.Thread.Sleep(2000);
                        }
                        Click(webDriver, By.XPath(x.Procedimento));
                        while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                    }
                }
                return;
            }
            if (tipo == 2)
            {
                
                categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:0:j_id150']/span[1]", 0));
                categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:1:j_id150']/span[1]", 1));
                categorias.Add(new Processos("//*[@id='formAbaExpediente:listaAgrSitExp:3:j_id150']/span[1]", 3));
            }
            if (tipo == 3)
            {
                
                categorias.Add(new Processos("//*[@id='dvPend']/form/div/div[1]", 1));
                categorias.Add(new Processos("//*[@id='dvCfInt']/form/div/div[1]", 2));
                categorias.Add(new Processos("//*[@id='dvCfSist']/form/div/div[1]", 3));

                foreach (Processos x in categorias)
                {
                    System.Threading.Thread.Sleep(1000);
                    new WebDriverWait(webDriver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(x.Procedimento))); 
                    Click(webDriver, By.XPath(x.Procedimento));
                    System.Threading.Thread.Sleep(3000);

                    try{
                        new WebDriverWait(webDriver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='agrup']/div[" + x.ListaForum.ToString() + "]form/div/div[2]"))); 
                        //Click(webDriver, By.XPath("//*[@id='agrup']/div[" + x.ListaForum.ToString() + "]form/div/div[2]"));
                    }catch(Exception){
                        
                    }
                    if(BaixarPDF(webDriver, caminho, pro, null, 0)){
                        return;
                    };

                    System.Threading.Thread.Sleep(1000);
                    Click(webDriver, By.XPath(x.Procedimento));
                }
            }
            /*
            categorias.Add(primeiro[0].Procedimento.ToString());
            categorias.Add(segundo[0].Procedimento.ToString());
            categorias.Add(terceiro[0].Procedimento.ToString());
            */
            int xContador = 0;
            foreach (Processos x in categorias)
            {
                System.Threading.Thread.Sleep(1000);
                Click(webDriver, By.XPath(x.Procedimento));
                if(xContador >= 1){
                    if (webDriver.FindElements(By.Id("formAbaExpediente:listaAgrSitExp:" + x.ListaForum.ToString() + ":linhaN2")).Count <= 0) //FindElements(By.Id("j_id406")
                    {
                        Console.Write("");
                    }
                    else
                    {
                        while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                        System.Threading.Thread.Sleep(3000);
                        //IList<IWebElement> webElement = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:0:trPend:childs")).FindElements(By.TagName("span"));
                        IList<IWebElement> webElement = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:" + x.ListaForum.ToString() + ":trPend:childs")).FindElements(By.CssSelector("span[class='nomeTarefa']"));
                        //IList<IWebElement> links = webDriver.FindElement(By.)
                        //var texto = new IList<IWebElement>("");
                        IList<IWebElement> texto= webDriver.FindElements(By.CssSelector("span[class='nomeTarefa']"));
                        //WebElement firstName = driver.findElement(By.cssSelector("input[name='first_name']"));
                        //List<IWebElement> elementos = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:0:trPend:childs")).GetAttribute("table");

                        bool sairLoop = false;
                        int n = webElement.Count - 1;
                        for (int i = 0; i <= n; i++)
                        {                                                               //formAbaExpediente:listaAgrSitExp:3:trPend:childs
                            System.Threading.Thread.Sleep(1000);                        //formAbaExpediente:listaAgrSitExp:1:trPend:childs
                            int cont = 0;                                               //formAbaExpediente:listaAgrSitExp:0:trPend:childs
                            IList<IWebElement> webElement2 = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:" + x.ListaForum.ToString() + ":trPend:childs")).FindElements(By.CssSelector("span[class='nomeTarefa']"));
                            foreach (IWebElement item2 in webElement2)
                            {

                                Debug.Print(item2.Text);
                                Debug.Print(item2.ToString());
                                if (cont == i & item2.Text != "")
                                {
                                    Debug.Print(item2.Text);
                                    Debug.Print(item2.ToString());
                                    if (cont == i & item2.Text != "")
                                    {
                                        try{
                                            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(webDriver);
                                            action.MoveToElement(item2);
                                            action.Perform();
                                        }catch(Exception e){

                                        }
                                        item2.Click();
                                        sairLoop = BaixarPDF(webDriver, caminho, pro, null, 0);
                                        if(sairLoop){
                                            return;
                                        }
                                        System.Threading.Thread.Sleep(1000);
                                        //Debug.Print(item2.Text);
                                        break;
                                    }
                                    if(item2.Text == ""){
                                        cont--;
                                    }
                                    cont++;
                                }
                                if (item2.Text == "")
                                {
                                    cont--;
                                }
                                cont++;
                            }
                            //System.Threading.Thread.Sleep(2000);
                            while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                            
                            Click(webDriver, By.XPath(x.Procedimento));
                            while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                            //System.Threading.Thread.Sleep(2000);//_viewRoot:status.start
                            Click(webDriver, By.XPath(x.Procedimento));
                            while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                            //System.Threading.Thread.Sleep(2000);
                        }
                        Click(webDriver, By.XPath(x.Procedimento));
                        while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                    }
                }
                xContador++;
            }
        }

        public static bool BaixarPDF(this IWebDriver webDriver, int tipo, Procedimentos pro, Processos x, int valor){
            
            Debug.Print("--------------");
            Debug.Print("--------------");
            
            while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
            
            if(pro.Estado == "BA"){
                ObterPDFEsp(webDriver);
                return true;
            }
            if (pro.Estado == "PB"){
                IWebElement listProc;
                bool sairLoop = false;

                do
                {
                    while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                    sairLoop = false;
                    try{
                        listProc = webDriver.FindElement(By.Id("formExpedientes:tbExpedientes:tb"));
                    }catch(Exception){
                        while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                        listProc = webDriver.FindElement(By.Id("j_id2123:tbPC:tb"));
                    }

                    foreach (var item in listProc.FindElements(By.TagName("a")))
                    {
                        var obj = "";
                        try{
                            obj = item.GetAttribute("title");
                        }catch(Exception e){
                            
                        }

                        Debug.Print(obj);

                        if(obj == "Tomar ciência"){
                            sairLoop = true;
                            do{
                                try{
                                    item.Click();
                                    System.Threading.Thread.Sleep(2000);
                                    webDriver.SwitchTo().Alert().Accept();
                                    System.Threading.Thread.Sleep(9000);
                                }catch(Exception){}                                
                            }while(webDriver.WindowHandles.Count < 3);    

                            string teste = null;
                            string valorTitulo = "";
                            do{
                                try{
                                    webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                                    
                                    if(webDriver.FindElements(By.Id("detalhesDocumento:j_id45")).Count > 0){
                                        valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id45")).Text;
                                    }

                                    if(webDriver.FindElements(By.Id("detalhesDocumento:j_id47")).Count > 0){
                                        valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id47")).Text;
                                    }

                                    if(webDriver.FindElements(By.Id("detalhesDocumento:j_id46")).Count > 0){
                                        valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id46")).Text;
                                    }

                                    if(webDriver.FindElements(By.Id("detalhesDocumento:j_id48")).Count > 0){
                                        valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id48")).Text;
                                    }

                                    System.Threading.Thread.Sleep(2000);

                                    if(webDriver.FindElements(By.Id("frameHtml")).Count > 0){
                                        teste = webDriver.SwitchTo().Frame("frameHtml").ToString();
                                        teste = webDriver.FindElement(By.TagName("html")).Text;
                                    }else{

                                        try{
                                            teste = webDriver.FindElement(By.Id("pagina")).Text; //j_id12
                                        }catch(Exception){
                                            teste = webDriver.FindElement(By.Id("j_id12")).Text; //j_id12
                                            //teste = "teste";
                                        }
                                    }
                                }catch(Exception){}                                
                            }while(RegistrarInfo(teste, valorTitulo) == false); 

                            //RegistrarInfo(teste, valorTitulo);
                            webDriver.Close();
                            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                            System.Threading.Thread.Sleep(2000);
                            Click(webDriver, By.XPath(x.Procedimento));
                            System.Threading.Thread.Sleep(2000);
                            
                            //--------------------------------------------------------------------------------------------------------

                            IList<IWebElement> webElement2 = webDriver.FindElement(By.Id("formAbaExpediente:listaAgrSitExp:" + x.ListaForum.ToString() + ":trPend:childs")).FindElements(By.CssSelector("span[class='nomeTarefa']"));
                            int cont = 0;
                            foreach (IWebElement item2 in webElement2)
                            {

                                Debug.Print(item2.Text);
                                Debug.Print(item2.ToString());
                                if (cont == valor & item2.Text != "")
                                {
                                    
                                    Debug.Print(item2.Text);
                                    Debug.Print(item2.ToString());
                                    if (cont == valor & item2.Text != "")
                                    {
                                        OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(webDriver);
                                        action.MoveToElement(item2);
                                        action.Perform();
                                        item2.Click();
                                        System.Threading.Thread.Sleep(1000);
                                        break;
                                    }
                                    if(item2.Text == ""){
                                        cont--;
                                    }
                                    cont++;
                                }
                                if (item2.Text == "")
                                {
                                    cont--;
                                }
                                cont++;
                            }

                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                    }
                } while (sairLoop);
                return false;
            }else{
                IWebElement listProc;
                try{
                    listProc = webDriver.FindElement(By.Id("formExpedientes:tbExpedientes:tb"));
                }catch(Exception){
                    listProc = webDriver.FindElement(By.Id("j_id2123:tbPC:tb"));
                }

                foreach (var item in listProc.FindElements(By.TagName("a")))
                {
                    var obj = "";
                    try{
                        obj = item.GetAttribute("title");
                    }catch(Exception e){

                    }
                    Debug.Print(obj);
                    if(obj == "Tomar ciência"){

                        string valorTitulo = "";

                        do{
                            try{
                                item.Click();
                                System.Threading.Thread.Sleep(2000);
                                webDriver.SwitchTo().Alert().Accept();
                                System.Threading.Thread.Sleep(9000);
                            }catch(Exception){}                                
                        }while(webDriver.WindowHandles.Count < 3);    

                        //IWebElement elementDoc = webDriver.FindElement(By.Id("j_id35"));
                        //string te = elementDoc.FindElement(By.Id("detalhesDocumento:tituloDocumento")).Text;
       
                        string teste = null;
                        do{
                            try{
                                webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                                System.Threading.Thread.Sleep(9000);

                                if(webDriver.FindElements(By.Id("detalhesDocumento:j_id45")).Count > 0){
                                    valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id45")).Text;
                                }

                                if(webDriver.FindElements(By.Id("detalhesDocumento:j_id47")).Count > 0){
                                    valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id47")).Text;
                                }

                                if(webDriver.FindElements(By.Id("detalhesDocumento:j_id46")).Count > 0){
                                    valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id46")).Text;
                                }

                                if(webDriver.FindElements(By.Id("detalhesDocumento:j_id48")).Count > 0){
                                    valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id48")).Text;
                                }

                                //System.Threading.Thread.Sleep(9000);
                                try{
                                    teste = webDriver.FindElement(By.Id("pagina")).Text; //j_id12
                                }catch(Exception){
                                    teste = webDriver.FindElement(By.Id("j_id12")).Text; //j_id12
                                    //teste = "teste";
                                }                     
                            }catch(Exception){
                                System.Environment.Exit(0);
                            }                                
                        }while(RegistrarInfo(teste, valorTitulo) == false); 
                        //RegistrarInfo(teste);
                        webDriver.Close();
                        webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                        System.Threading.Thread.Sleep(2000);
                    }
                    
                }
                return false;
            }
        }

        
        public static void ObterPDFEsp(this IWebDriver webDriver){
                
            List<Processos> categorias = new List<Processos>();

            categorias.Add(new Processos("//*[@id='dvPend']/form/div/div[1]", 1));
            categorias.Add(new Processos("//*[@id='dvCfInt']/form/div/div[1]", 2));
            categorias.Add(new Processos("//*[@id='dvCfSist']/form/div/div[1]", 3));

            foreach (Processos x in categorias)
            {
                string texoLoco = webDriver.FindElement(By.XPath(x.Procedimento)).Text;
                string[] xc = texoLoco.Split("-");
                int nv = 0;
                if(xc.Length > 0){
                    nv = int.Parse(xc[1].Replace(" ", "").ToString());
                }
                
                for (int i = 0; i < nv; i++)
                {
                
                    IWebElement listProc;
                    try{
                        listProc = webDriver.FindElement(By.Id("formExpedientes:tbExpedientes:tb"));
                    }catch(Exception){
                        listProc = webDriver.FindElement(By.Id("j_id2123:tbPC:tb"));
                    }
                    
                    foreach (var item in listProc.FindElements(By.TagName("a")))
                    {
                        var obj = item.GetAttribute("title");
                        Debug.Print(obj);
                        if(obj == "Tomar ciência"){
                            do{
                                try{
                                    item.Click();
                                    System.Threading.Thread.Sleep(2000);
                                    webDriver.SwitchTo().Alert().Accept();
                                    System.Threading.Thread.Sleep(9000);
                                }catch(Exception){}                                
                            }while(webDriver.WindowHandles.Count < 3);    

                            string teste = null;
                            string valorTitulo = "";
                            do{
                                try{
                                    webDriver.SwitchTo().Window(webDriver.WindowHandles[2]);
                                    
                                    if(webDriver.FindElements(By.Id("detalhesDocumento:j_id45")).Count > 0){
                                        valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id45")).Text;
                                    }

                                    if(webDriver.FindElements(By.Id("detalhesDocumento:j_id47")).Count > 0){
                                        valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id47")).Text;
                                    }

                                    if(webDriver.FindElements(By.Id("detalhesDocumento:j_id46")).Count > 0){
                                        valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id46")).Text;
                                    }

                                    if(webDriver.FindElements(By.Id("detalhesDocumento:j_id48")).Count > 0){
                                        valorTitulo = webDriver.FindElement(By.Id("detalhesDocumento:j_id48")).Text;
                                    }
                                    
                                    //System.Threading.Thread.Sleep(6000);
                                    try{
                                        teste = webDriver.FindElement(By.Id("pagina")).Text; //j_id12
                                    }catch(Exception){
                                        teste = webDriver.FindElement(By.Id("j_id12")).Text; //j_id12
                                        //teste = "teste";
                                    }                                    
                                }catch(Exception){}                                
                            }while(RegistrarInfo(teste, valorTitulo) == false);                            
                            
                            //RegistrarInfo(teste);
                            webDriver.Close();
                            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
                            break;
                        }
                    }

                    //***************************************************************************************************************
                    System.Threading.Thread.Sleep(1000);
                    new WebDriverWait(webDriver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(x.Procedimento))); 
                    Click(webDriver, By.XPath(x.Procedimento));
                    
                    System.Threading.Thread.Sleep(3000);

                    while (webDriver.FindElement(By.Id("_viewRoot:status.start")).GetAttribute("style") != "display: none;") { }
                }
                /*System.Threading.Thread.Sleep(1000);
                Click(webDriver, By.XPath(x.Procedimento));*/
            }
        }

        public static bool RegistrarInfo(string texto, string titulo){
            string caminhoApp;
            string caminhoPasta;
            string caminhoNomeArquivo;
            string[] partes;

            do{
                caminhoApp = Directory.GetCurrentDirectory();
                partes = caminhoApp.Split(Path.DirectorySeparatorChar);
                caminhoPasta = Path.DirectorySeparatorChar + partes[1] + Path.DirectorySeparatorChar + partes[2] + Path.DirectorySeparatorChar + "Desktop" + Path.DirectorySeparatorChar;
                //"/home/geovani/Desktop"; // ///home/marcosdev/Desktop  smb://192.168.2.209/desenvolvimento/PUBLICACAO/Publicacoes%20-%20PJE/Publicacoes
                caminhoNomeArquivo = caminhoPasta 
                            + Path.DirectorySeparatorChar 
                            + "Doc " + DateTime.Today.Day 
                            + "." + DateTime.Today.Month 
                            + "." + DateTime.Today.Year 
                            + ".txt";
                

                if(Directory.Exists(caminhoPasta)){
                    if(File.Exists(caminhoNomeArquivo)){}
                    else{
                        try{
                            File.Create(caminhoNomeArquivo).Close();
                            System.Threading.Thread.Sleep(1000);
                        }catch(Exception){}
                    }
                }
            }while(File.Exists(caminhoNomeArquivo) == false);

            try{
                string[] vect = texto.Split("\n");

                StringBuilder sb = new StringBuilder();
                
                if(!String.IsNullOrEmpty(titulo)){
                    sb.AppendLine(titulo);
                }

                //sb.AppendLine(titulo);

                foreach(var ix in vect){
                    sb.AppendLine(ix.Trim());
                }

                using(StreamWriter sw = File.AppendText(caminhoNomeArquivo)){
                    sw.WriteLine(sb.ToString());
                    sw.WriteLine("*****************************************************************************************************************************************************");
                    sw.WriteLine("*****************************************************************************************************************************************************");
                }
                return true;
            }catch(Exception){
                return false;
            }
            
        }
    }
}