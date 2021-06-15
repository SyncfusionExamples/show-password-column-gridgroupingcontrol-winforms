Imports Microsoft.VisualBasic
#Region "Copyright Syncfusion Inc. 2001 - 2015"
'
'  Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
'
'  Use of this code is subject to the terms of our license.
'  A copy of the current license can be obtained at any time by e-mailing
'  licensing@syncfusion.com. Any infringement will be prosecuted under
'  applicable laws. 
'
#End Region

Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Syncfusion.Windows.Forms.Grid.Grouping

Namespace GridGroupingRebind
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits Form
		#Region "API Definition"
		Private gridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
		Private components As IContainer
		Private source As Integer = 0
		#End Region

		#Region "Constructor"
		Public Sub New()
			InitializeComponent()
			GridSettings()
		End Sub
		#End Region

		#Region "Grid Settings"
		''' <summary>
		''' Grid Settings for better Look and Feel
		''' </summary>
		Private Sub GridSettings()
			Me.gridGroupingControl1.DataSource = CreateTable()

            'Sets the password column character by using the PasswordChar property of the TableDescriptor.
            Me.gridGroupingControl1.TableDescriptor.Columns("Password").Appearance.AnyRecordFieldCell.PasswordChar = "*"c
            'Event subscription
            AddHandler Me.gridGroupingControl1.QueryCellStyleInfo, AddressOf GridGroupingControl1_QueryCellStyleInfo
        End Sub

		#End Region

		#Region "Designer Stuffs"
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.Run(New Form1())
		End Sub
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
			CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridGroupingControl1
			' 
			Me.gridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(64))))), (CInt(Fix((CByte(94))))), (CInt(Fix((CByte(171))))), (CInt(Fix((CByte(222))))))
			Me.gridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
			Me.gridGroupingControl1.ChildGroupOptions.ShowAddNewRecordBeforeDetails = False
			Me.gridGroupingControl1.ChildGroupOptions.ShowCaption = True
			Me.gridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridGroupingControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridGroupingControl1.Name = "gridGroupingControl1"
			Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
			Me.gridGroupingControl1.Size = New System.Drawing.Size(1020, 600)
			Me.gridGroupingControl1.TabIndex = 0
			Me.gridGroupingControl1.TableDescriptor.AllowNew = False
			Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
			Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(138))))), (CInt(Fix((CByte(138))))), (CInt(Fix((CByte(138))))))
			Me.gridGroupingControl1.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb((CInt(Fix((CByte(208))))), (CInt(Fix((CByte(208))))), (CInt(Fix((CByte(208)))))), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
			Me.gridGroupingControl1.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb((CInt(Fix((CByte(208))))), (CInt(Fix((CByte(208))))), (CInt(Fix((CByte(208)))))))
			Me.gridGroupingControl1.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
			Me.gridGroupingControl1.TableDescriptor.Appearance.GroupCaptionCell.CellType = "ColumnHeader"
			Me.gridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
			Me.gridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 25
			Me.gridGroupingControl1.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
			Me.gridGroupingControl1.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
			Me.gridGroupingControl1.Text = "gridGroupingControl1"
			Me.gridGroupingControl1.ThemesEnabled = False
			Me.gridGroupingControl1.UseRightToLeftCompatibleTextBox = True
			' 
			' Form1
			' 
			Me.ClientSize = New System.Drawing.Size(1020, 600)
			Me.Controls.Add(Me.gridGroupingControl1)
			Me.MinimumSize = New System.Drawing.Size(615, 330)
			Me.Name = "Form1"
			Me.ShowIcon = False
			Me.Text = "GridGroupingControl"
			CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#Region "Dispose"
		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub
		#End Region
		#End Region

		#Region "EventHanlder"
		'Eventcustomization
		Private Sub GridGroupingControl1_QueryCellStyleInfo(ByVal sender As Object, ByVal e As GridTableCellStyleInfoEventArgs)
			If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "Password" Then
				e.Style.PasswordChar = "*"c
			End If
		End Sub
		#End Region

		#region "Create DataTable"
		Private name1() As String = { "John", "Peter", "Smith", "Jay", "Krish", "Mike" }
		Private country() As String = { "UK", "USA", "Pune", "India", "China", "England" }
		Private city() As String = { "Graz", "Resende", "Bruxelles", "Aires", "Rio de janeiro", "Campinas" }
		Private scountry() As String = { "Brazil", "Belgium", "Austria", "Argentina", "France", "Beiging" }
		Private dt As New DataTable()
		Private dr As DataRow
		Private r As New Random()

		Private Function CreateTable() As DataTable
			dt.Columns.Add("Name")
			dt.Columns.Add("Id")
			dt.Columns.Add("Date")
			dt.Columns.Add("Country")
			dt.Columns.Add("Ship City")
			dt.Columns.Add("Ship Country")
			dt.Columns.Add("Freight")
			dt.Columns.Add("Postal code")
			dt.Columns.Add("Password")

			For l As Integer = 0 To 19
				dr = dt.NewRow()
				dr(0) = name1(r.Next(0, 5))
				dr(1) = "E" & r.Next(30)
				dr(2) = New DateTime(2012, 5, 23)
				dr(3) = country(r.Next(0, 5))
				dr(4) = city(r.Next(0, 5))
				dr(5) = scountry(r.Next(0, 5))
				dr(6) = r.Next(1000, 2000)
				dr(7) = r.Next(10 + (r.Next(600000, 600100)))
				dr(8) = r.Next(14000, 20000)

				dt.Rows.Add(dr)
			Next l
			Return dt
		End Function
		#End Region

	End Class
End Namespace
