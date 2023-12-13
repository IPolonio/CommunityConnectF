using System.Threading.Tasks;
using AntDesign.Charts;
using New_folder.Services;
using Microsoft.AspNetCore.Components;

namespace New_folder.Pages.Dashboard.Analysis
{
    public partial class SalesCard
    {
        private readonly ColumnConfig _saleChartConfig = new ColumnConfig
        {
            AutoFit = true,
            Padding = "auto",
            XField = "x",
            YField = "y"
        };

        private readonly ColumnConfig _visitChartConfig = new ColumnConfig
        {
            AutoFit = true,
            Padding = "auto",
            XField = "x",
            YField = "y"
        };

        private IChartComponent _saleChart;
        private IChartComponent _visitChart;

        [Parameter]
        public SaleItem[] Items { get; set; } =
        {
          new SaleItem {Id = 1, Title = "Paris, France", Total = "323,234"},
new SaleItem {Id = 2, Title = "Tokyo, Japan", Total = "323,234"},
new SaleItem {Id = 3, Title = "Sydney, Australia", Total = "323,234"},
new SaleItem {Id = 4, Title = "New York, USA", Total = "323,234"},
new SaleItem {Id = 5, Title = "London, UK", Total = "323,234"},
new SaleItem {Id = 6, Title = "Berlin, Germany", Total = "323,234"},
new SaleItem {Id = 7, Title = "Rio de Janeiro, Brazil", Total = "323,234"}
        };

        [Inject] public IChartService ChartService { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await OnTabChanged("1");
            }
        }

        private async Task OnTabChanged(string activeKey)
        {
            var data = await ChartService.GetSalesDataAsync();
            if (activeKey == "1")
                await _saleChart.ChangeData(data);
            else
                await _visitChart.ChangeData(data);
        }
    }
}