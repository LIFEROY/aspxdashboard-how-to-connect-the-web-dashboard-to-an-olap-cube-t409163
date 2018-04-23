using System;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;

namespace WebDesignerOlapDataSource
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            #region #DashboardFileStorage
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            DashboardService.SetDashboardStorage(dashboardFileStorage);
            #endregion

            #region #DashboardOlapDataSource
            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource("OLAP Data Source", "olapConnection");

            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml());
            DashboardService.SetDataSourceStorage(dataSourceStorage);
            #endregion

            DashboardService.DataApi.ConfigureDataConnection += DataApi_ConfigureDataConnection;


        }

        private void DataApi_ConfigureDataConnection(object sender, ServiceConfigureDataConnectionEventArgs e)
        {
            if (e.ConnectionName == "olapConnection")
            {
                OlapConnectionParameters olapParams = new OlapConnectionParameters();
                olapParams.ConnectionString = @"Provider=MSOLAP;
                                        Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;  
                                        Initial catalog=Adventure Works DW Standard Edition;
                                        Cube name=Adventure Works;
                                        Query Timeout=100;";
                e.ConnectionParameters = olapParams;
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}