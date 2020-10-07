using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(caseManagementSystem.App_Start.MoneyMaskBundleConfig), "RegisterBundles")]

namespace caseManagementSystem.App_Start
{
	public class MoneyMaskBundleConfig
	{
		public static void RegisterBundles()
		{
			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/moneymask").Include("~/Scripts/jquery.moneymask.js"));
		}
	}
}