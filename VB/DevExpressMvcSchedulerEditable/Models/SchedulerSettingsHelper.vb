Imports Microsoft.VisualBasic
Imports DevExpress.Web.Mvc
Imports DevExpress.Web.ASPxScheduler
Imports System
Imports DevExpress.XtraScheduler
Imports DevExpressMvcSchedulerEF.Views
Imports System.Data.Entity
Imports DevExpressMvcSchedulerEF

	#Region "#schedulersettingshelper"
	Public Class SchedulerSettingsHelper

		Private Shared _localcontext As SchedulerContext
		Public Shared ReadOnly Property LocalContext() As SchedulerContext
			Get
				If _localcontext Is Nothing Then
					_localcontext = New SchedulerContext()
				End If
				Return _localcontext
			End Get
		End Property

		Private Shared _commonSchedulerSettings As SchedulerSettings
		Public Shared ReadOnly Property CommonSchedulerSettings() As SchedulerSettings
			Get
				If _commonSchedulerSettings Is Nothing Then
					_commonSchedulerSettings = CreateSchedulerSettings()
				End If
				Return _commonSchedulerSettings
			End Get
		End Property
		Private Shared Function CreateSchedulerSettings() As SchedulerSettings
			Database.SetInitializer(New SchedulerContextSeedInilializer())
			LocalContext.Database.Initialize(True)


			LocalContext.EFAppointments.Load()
			LocalContext.EFResources.Load()


			Dim settings As New SchedulerSettings()
			settings.Name = "scheduler"
			settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "SchedulerPartial"}
			settings.EditAppointmentRouteValues = New With {Key .Controller = "Home", Key .Action = "EditAppointment"}

			settings.Storage.Appointments.Assign(SchedulerDataHelper.DefaultAppointmentStorage)
			settings.Storage.Resources.Assign(SchedulerDataHelper.DefaultResourceStorage)

			settings.Storage.Appointments.ResourceSharing = True
			settings.Storage.Resources.ColorSaving = ColorSavingType.ArgbColor
			settings.GroupType = SchedulerGroupType.Resource

			settings.Width = 300
			settings.Views.WeekView.Styles.DateCellBody.Height = 50
			settings.Views.MonthView.CellAutoHeightOptions.Mode = AutoHeightMode.FitToContent
			settings.Views.MonthView.AppointmentDisplayOptions.AppointmentAutoHeight = True
			settings.Views.MonthView.AppointmentDisplayOptions.TimeDisplayType = AppointmentTimeDisplayType.Clock
			settings.Views.DayView.Styles.ScrollAreaHeight = 250
			settings.Views.DayView.ShowWorkTimeOnly = True
			settings.Views.DayView.DayCount = 2
			settings.Start = New DateTime(2012, 5, 9)
			settings.ActiveViewType = SchedulerViewType.Day

			Return settings
		End Function
	End Class

#End Region ' #schedulersettingshelper