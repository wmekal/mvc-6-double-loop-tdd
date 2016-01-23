namespace TestStack.BDDfy.Reporters.Html
{
    public interface IHtmlReportConfiguration
    {
        string ReportHeader { get; }
        string ReportDescription { get; }
        string OutputPath { get; }
        string OutputFileName { get; }
        bool ResolveJqueryFromCdn { get; }
        bool RunsOn(Story story);
    }
}