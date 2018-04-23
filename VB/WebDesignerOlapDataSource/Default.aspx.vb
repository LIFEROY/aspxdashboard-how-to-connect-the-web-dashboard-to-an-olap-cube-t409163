Imports System
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters

Namespace WebDesignerOlapDataSource
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
            ASPxDashboard1.SetDashboardStorage(dashboardFileStorage)

            Dim olapDataSource As New DashboardOlapDataSource("OLAP Data Source", "olapConnection")

            Dim dataSourceStorage As New DataSourceInMemoryStorage()
            dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml())
            ASPxDashboard1.SetDataSourceStorage(dataSourceStorage)
        End Sub

        Protected Sub ASPxDashboard1_ConfigureDataConnection(ByVal sender As Object,
                                                             ByVal e As ConfigureDataConnectionWebEventArgs)
            If e.ConnectionName = "olapConnection" Then
                Dim olapParams As New OlapConnectionParameters()
                olapParams.ConnectionString = "provider=MSOLAP;" _
                                & ControlChars.CrLf & _
                                "data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" _
                                & ControlChars.CrLf & _
                                "initial catalog=Adventure Works DW Standard Edition;" _
                                & ControlChars.CrLf & _
                                "cube name=Adventure Works;"
                e.ConnectionParameters = olapParams
            End If
        End Sub
    End Class
End Namespace