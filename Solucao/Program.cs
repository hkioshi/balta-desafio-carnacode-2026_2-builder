using System.Numerics;


ReportDirector director = new ReportDirector();
ReportBuilder builder = new ReportBuilder();

director.CriarReportMensal(builder).Generate();
director.CriarReportTrimestral(builder).Generate();
director.CriarReportAnual(builder).Generate();


public class SalesReport
{
    public string Title { get; set; }
    public string Format { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IncludeHeader { get; set; }
    public bool IncludeFooter { get; set; }
    public string HeaderText { get; set; }
    public string FooterText { get; set; }
    public bool IncludeCharts { get; set; }
    public string ChartType { get; set; }
    public bool IncludeSummary { get; set; }
    public List<string> Columns { get; set; }
    public List<string> Filters { get; set; }
    public string SortBy { get; set; }
    public string GroupBy { get; set; }
    public bool IncludeTotals { get; set; }
    public string Orientation { get; set; }
    public string PageSize { get; set; }
    public bool IncludePageNumbers { get; set; }
    public string CompanyLogo { get; set; }
    public string WaterMark { get; set; }

    public void Generate()
    {
        Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
        Console.WriteLine($"Formato: {Format}");
        Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");

        if (IncludeHeader)
            Console.WriteLine($"Cabeçalho: {HeaderText}");

        if (IncludeCharts)
            Console.WriteLine($"Gráfico: {ChartType}");

        Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");

        if (Filters.Count > 0)
            Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");

        if (!string.IsNullOrEmpty(GroupBy))
            Console.WriteLine($"Agrupado por: {GroupBy}");

        if (IncludeFooter)
            Console.WriteLine($"Rodapé: {FooterText}");

        Console.WriteLine("Relatório gerado com sucesso!");
    }
}

//builder
public interface IReportBuilder
{
    public void SetTitle(string title);
    public void SetFormat(string format);
    public void SetStartDate(DateTime startDate);
    public void SetEndDate(DateTime endDate);

    public void IncludeHeader();
    public void IncludeFooter();
    public void SetHeaderText(string headerText);
    public void SetFooterText(string footerText);

    public void IncludeCharts();
    public void SetChartType(string chartType);

    public void IncludeSummary();

    public void SetColumns(List<string> columns);
    public void SetFilters(List<string> filters);

    public void SetSortBy(string sortBy);
    public void SetGroupBy(string groupBy);

    public void IncludeTotals();

    public void SetOrientation(string orientation);
    public void SetPageSize(string pageSize);

    public void IncludePageNumbers();

    public void SetCompanyLogo(string companyLogo);
    public void SetWaterMark(string waterMark);

    public SalesReport Build ();
}

//concrete builder  

public class ReportBuilder : IReportBuilder
{

    private SalesReport _report = new SalesReport();
    public void SetTitle(string title) => _report.Title = title;
    public void SetFormat(string format) => _report.Format = format;
    public void SetStartDate(DateTime startDate) => _report.StartDate = startDate;
    public void SetEndDate(DateTime endDate) => _report.EndDate = endDate;

    public void IncludeHeader() => _report.IncludeHeader = true;
    public void IncludeFooter() => _report.IncludeFooter = true;
    public void SetHeaderText(string headerText) => _report.HeaderText = headerText;
    public void SetFooterText(string footerText) => _report.FooterText = footerText;

    public void IncludeCharts() => _report.IncludeCharts = true;
    public void SetChartType(string chartType) => _report.ChartType = chartType;

    public void IncludeSummary() => _report.IncludeSummary = true;

    public void SetColumns(List<string> columns) => _report.Columns = columns;
    public void SetFilters(List<string> filters) => _report.Filters = filters;

    public void SetSortBy(string sortBy) => _report.SortBy = sortBy;
    public void SetGroupBy(string groupBy) => _report.GroupBy = groupBy;

    public void IncludeTotals() => _report.IncludeTotals = true;

    public void SetOrientation(string orientation) => _report.Orientation = orientation;
    public void SetPageSize(string pageSize) => _report.PageSize = pageSize;

    public void IncludePageNumbers() => _report.IncludePageNumbers = true;

    public void SetCompanyLogo(string companyLogo) => _report.CompanyLogo = companyLogo;
    public void SetWaterMark(string waterMark) => _report.WaterMark = waterMark;

    public SalesReport Build() => _report;

}

public class ReportDirector
{
    public SalesReport CriarReportMensal(IReportBuilder builder)
    {

        builder.SetTitle("Vendas Mensais");
        builder.SetFormat("PDF");
        builder.SetStartDate(new DateTime(2024, 1, 1));
        builder.SetEndDate(new DateTime(2024, 1, 31));

        builder.IncludeHeader();
        builder.SetHeaderText("Relatório de Vendas");

        builder.IncludeFooter();
        builder.SetFooterText("Confidencial");

        builder.IncludeCharts();
        builder.SetChartType("Bar");

        builder.IncludeSummary();

        builder.SetColumns(new List<string> { "Produto", "Quantidade", "Valor" });
        builder.SetFilters(new List<string> { "Status=Ativo" });

        builder.SetSortBy("Valor");
        builder.SetGroupBy("Categoria");

        builder.IncludeTotals();

        builder.SetOrientation("Portrait");
        builder.SetPageSize("A4");

        builder.IncludePageNumbers();

        builder.SetCompanyLogo("logo.png");
        builder.SetWaterMark("Confidencial");

        return builder.Build();
    }

    public SalesReport CriarReportTrimestral(IReportBuilder builder)
    {

        builder.SetTitle("Relatório Trimestral");
        builder.SetFormat("Excel");
        builder.SetStartDate(new DateTime(2024, 1, 1));
        builder.SetEndDate(new DateTime(2024, 3, 31));

        builder.IncludeHeader();
        builder.SetHeaderText("Relatório Trimestral de Vendas");

        builder.IncludeFooter();
        builder.SetFooterText("Uso Interno");

        builder.IncludeCharts();
        builder.SetChartType("Line");

        builder.IncludeSummary();

        builder.SetColumns(new List<string> { "Vendedor", "Região", "Total" });
        builder.SetFilters(new List<string> { "Status=Ativo" });

        builder.SetSortBy("Total");
        builder.SetGroupBy("Região");

        builder.IncludeTotals();

        builder.SetOrientation("Portrait");
        builder.SetPageSize("A4");

        builder.IncludePageNumbers();

        builder.SetCompanyLogo("logo.png");
        builder.SetWaterMark("Interno");

        return builder.Build();
    }

    public SalesReport CriarReportAnual(IReportBuilder builder)
    {


        builder.SetTitle("Vendas Anuais");
        builder.SetFormat("PDF");
        builder.SetStartDate(new DateTime(2024, 1, 1));
        builder.SetEndDate(new DateTime(2024, 12, 31));

        builder.IncludeHeader();
        builder.SetHeaderText("Relatório Anual de Vendas");

        builder.IncludeFooter();
        builder.SetFooterText("Confidencial");

        builder.IncludeCharts();
        builder.SetChartType("Pie");

        builder.IncludeSummary();

        builder.SetColumns(new List<string> { "Produto", "Quantidade", "Valor" });
        builder.SetFilters(new List<string> { "Ano=2024" });

        builder.SetSortBy("Valor");
        builder.SetGroupBy("Categoria");

        builder.IncludeTotals();

        builder.SetOrientation("Landscape");
        builder.SetPageSize("A4");

        builder.IncludePageNumbers();

        builder.SetCompanyLogo("logo.png");
        builder.SetWaterMark("Confidencial");

        return builder.Build();
    }

}

