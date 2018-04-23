using System;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;

namespace WebDesignerOlapDataSource
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboard1.SetDashboardStorage(dashboardFileStorage);

            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource("OLAP Data Source", "olapConnection");

            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml());
            ASPxDashboard1.SetDataSourceStorage(dataSourceStorage);
        }

        protected void ASPxDashboard1_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "olapConnection") {
                OlapConnectionParameters olapParams = new OlapConnectionParameters();
                olapParams.ConnectionString = @"Provider=MSOLAP;
                                        Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;  
                                        Initial catalog=Adventure Works DW Standard Edition;
                                        Cube name=Adventure Works;
                                        Query Timeout=100;";
                e.ConnectionParameters = olapParams;
            }
        }
    }
}