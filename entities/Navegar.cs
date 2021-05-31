using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PjeApplication.entities
{
    public class Navegar
    {
        private IWebDriver driver;

    
        public void Acessar()
        {

            List<Procedimentos> proc = new List<Procedimentos>();
         
           //     proc.Add(new Procedimentos("RO", "https://pjesg.tjro.jus.br/login.seam", 1, 1, "Fazer")); 
           //     proc.Add(new Procedimentos("PB", "https://pje.tjpb.jus.br/pje2g/login.seam", 1, 2, "Fazer")); 
          //      proc.Add(new Procedimentos("PE", "https://pje.tjpe.jus.br/2g/login.seam", 1, 3, "Fazer")); 
          //      proc.Add(new Procedimentos("ES", "https://sistemas.tjes.jus.br/pje2g/login.seam", 1, 1, "Fazer"));
           //     proc.Add(new Procedimentos("MA", "https://pje2.tjma.jus.br/pje2g/login.seam", 1, 2, "Fazer")); 
         //       proc.Add(new Procedimentos("MG", "http://pje.tjmg.jus.br/pje/login.seam", 1, 1, "Fazer"));  NÃO TEM
          //      proc.Add(new Procedimentos("BA", "https://pje2g.tjba.jus.br/pje/login.seam", 3, 4, "Fazer")); // PAGINA COM ERRO
          //      proc.Add(new Procedimentos("MT", "https://pje2.tjmt.jus.br/pje2/login.seam", 1, 1, "Fazer")); 
          //      proc.Add(new Procedimentos("PA", "https://pje.tjpa.jus.br/pje-2g/login.seam", 1, 1, "Fazer"));// PAGINA COM ERRO
          //      proc.Add(new Procedimentos("PI", "https://tjpi.pje.jus.br/1g/login.seam", 1, 1, "Fazer")); // PAGINA COM ERRO
         //       proc.Add(new Procedimentos("RJ", "https://tjrj.pje.jus.br/1g/login.seam", 1, 2, "Fazer")); // NÃO TEM
          //      proc.Add(new Procedimentos("RN", "https://pje2g.tjrn.jus.br/pje/login.seam", 1, 2, "Fazer")); //
          //      proc.Add(new Procedimentos("CE", "https://pje.tjce.jus.br/pje2grau/login.seam", 1, 1, "Fazer")); //
                  proc.Add(new Procedimentos("DF", "https://pje2i.tjdft.jus.br/pje/login.seam", 1, 1, "Fazer")); //
            

            // criar sessao
            
            driver = WebDriverFactory.CreateWebDriver(Browser.CHROME, @"C:\Users\mac1218\Desktop\Robô_DESPECHOS\robo_usuario_senha_2instancia", false);
            
          TimeSpan timeSpan = new TimeSpan(0, 0, 0, 30);


            // navegar para site
            WebDriverExtensions.LoadPage(driver, timeSpan, "http://www.pje.jus.br/navegador/");

            int contT = 0;
            int statusOK = 0;
            do{
                statusOK = 0;

                foreach (Procedimentos pro in proc)
                {
                    if(pro.Status == "Falhou" || pro.Status == "Fazer"){
                        System.Threading.Thread.Sleep(1000);
                        var estado = driver.FindElement(By.XPath("/html/body/div[3]/div/div[1]/select"));
                        var selecioneEstado = new SelectElement(estado);
                        selecioneEstado.SelectByValue(pro.Estado);

                        System.Threading.Thread.Sleep(1000);
                        var tribunal = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/select"));
                        var selecioneTribunal = new SelectElement(tribunal);

                       new WebDriverWait(driver, new TimeSpan(00, 00, 20)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[3]/div/div[2]/select/option[3]")));
                        System.Threading.Thread.Sleep(2000);
                       try{
                            selecioneTribunal.SelectByValue(pro.Tribunal);
                        }catch(Exception e){
                            //selecioneTribunal.SelectByValue(pro.Tribunal);
                        }                

                        System.Threading.Thread.Sleep(3000);
                        WebDriverExtensions.Click(driver, By.XPath("/html/body/div[3]/div/div[3]/button"));

                        Console.Write("");

                        List<String> tabs = new List<String>(driver.WindowHandles);

                        driver.SwitchTo().Window(driver.WindowHandles[1]);
                        

                        //driver.Url.
                        //try cath para indicar que o site esta ausente
                        try{
                            if(pro.Estado == "RO"){
                                WebDriverExtensions.LoadPage(driver,timeSpan, "https://pjesg.tjro.jus.br/login.seam");
                            }
                            if(pro.Estado == "RN"){
                                WebDriverExtensions.LoadPage(driver, timeSpan, "https://pje2g.tjrn.jus.br/pje/login.seam");
                            }
                            if(pro.Caminho == 4){
                                try{
                                    new WebDriverWait(driver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("btnUtilizarApplet")));
                                }catch(Exception e){

                                }
                                System.Threading.Thread.Sleep(11000);
                                WebDriverExtensions.Click(driver, By.Id("btnUtilizarApplet"));
                            }
                            new WebDriverWait(driver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("username")));
                             new WebDriverWait(driver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("password")));
                            new WebDriverWait(driver, new TimeSpan(00, 00, 30)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("btnEntrar")));
                         System.Threading.Thread.Sleep(2000);
                            
 

                            driver.FindElement(By.Name("username")).SendKeys("10208311890");
                             System.Threading.Thread.Sleep(2000);
                             driver.FindElement(By.Name("password")).SendKeys("mac@2019");
                              System.Threading.Thread.Sleep(2000);

                              
                               driver.FindElement(By.Name("btnEntrar")).SendKeys("btnEntrar");
                                WebDriverExtensions.Click(driver, By.Name("btnEntrar"));

                           //  WebDriverExtensions.Click(driver, By.Id("loginAplicacaoButton"));
                            
                            // WebDriverExtensions.Click(driver, By.Name("btnI"));

                              
                            

                            


                            System.Threading.Thread.Sleep(5000);
                            //-> aqui tem que criar os caminho ate chegar no local 
                            WebDriverExtensions.CaminhoPDF(driver, pro.Caminho);
                            
                            WebDriverExtensions.ObterPDF(driver, pro.Tipo, pro.Caminho, pro);

                            pro.Status = "OK";
                            statusOK ++;
                        }catch(Exception f){
                            pro.Status = "Falhou";                        
                        }

                        driver.Close();
                        driver.SwitchTo().Window(driver.WindowHandles[0]);
                    }else{
                        statusOK ++;
                    }
                    
                }

                contT ++;
            }while(statusOK < proc.Count && contT < 3);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.Close();
            
        }

    }
}