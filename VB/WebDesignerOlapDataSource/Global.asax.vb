Imports System
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters

Namespace WebDesignerOlapDataSource
    Public Class [Global]
        Inherits System.Web.HttpApplication

        Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
'            #Region "#DashboardFileStorage"
            Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
            DashboardService.SetDashboardStorage(dashboardFileStorage)
'            #End Region

'            #Region "#DashboardOlapDataSource"
            Dim olapDataSource As New DashboardOlapDataSource("OLAP Data Source", "olapConnection")

            Dim dataSourceStorage As New DataSourceInMemoryStorage()
            dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml())
            DashboardService.SetDataSourceStorage(dataSourceStorage)
'            #End Region

            AddHandler DashboardService.DataApi.ConfigureDataConnection, AddressOf DataApi_ConfigureDataConnection


        End Sub

        Private Sub DataApi_ConfigureDataConnection(ByVal sender As Object, ByVal e As ServiceConfigureDataConnectionEventArgs)
            If e.ConnectionName = "olapConnection" Then
                Dim olapParams As New OlapConnectionParameters()
                olapParams.ConnectionString = "Provider=MSOLAP;" & ControlChars.CrLf & _
"                                        Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;  " & ControlChars.CrLf & _
"                                        Initial catalog=Adventure Works DW Standard Edition;" & ControlChars.CrLf & _
"                                        Cube name=Adventure Works;" & ControlChars.CrLf & _
"                                        Query Timeout=100;"
                e.ConnectionParameters = olapParams
            End If
        End Sub

        Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

        End Sub
    End Class
End Namespace