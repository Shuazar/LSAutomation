using Browser = Common.Browser;
namespace LSAutomation.Pages
{
   public abstract class PageBase
   {
       protected Browser Browser { get; }

       protected PageBase(Browser browser)
       {
           Browser = browser;
       }
   }
}
